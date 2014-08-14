using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;

namespace Skyrise
{
    using Extensions;
    /// <summary>
    /// Is responsible for communicating serially with whatever sends us the telemetry string.
    /// </summary>
    public class Communicator : IDisposable
    {
        // ---------- Instance variables ---------- \\
        private const char START_OF_MESSAGE = '$';
        private const char END_OF_MESSAGE = '\n';
        public const string RAW_DATA_PATH = @"rawData.txt";

        private const int NUMBER_OF_TELEMETRY_FIELDS = 15;

        private SerialPort _port;

        private Logger _logger;
        private Publisher _publisher;

        private Telemetry _lastReading = new Telemetry() { Timestamp = new DateTime(0) };

        private string _currentIndata = "";

        // ---------- Statics and events ---------- \\
        public delegate void ReceivedTelemetryEventHandler(object sender, EventArgs e);
        public event ReceivedTelemetryEventHandler ReceivedTelemetry;

        public delegate void TelemetryErrorEventHandler(object sender, string briefMessage);
        public event TelemetryErrorEventHandler TelemetryError;

        // ---------- Constructors       ---------- \\
        /// <summary>
        /// Constructs the Communicator object. It needs a Logger and a Publisher to both log to the local database and to upload data to the online database.
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="logger"></param>
        /// <param name="publisher"></param>
        public Communicator(string serialPort, Logger logger, Publisher publisher)
        {
            _port = new SerialPort(serialPort, 9600, Parity.None, 8, StopBits.One);
            _port.DataReceived += new SerialDataReceivedEventHandler(_port_DataReceived);
            _port.Open();

            _logger = logger;
            _publisher = publisher;

            try
            {
                using (StreamWriter sw = new StreamWriter(RAW_DATA_PATH, true))
                {
                    sw.WriteLine("\n----NEW SESSION----");
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "File IO", 
                    Description = "Tried to write NEW SESSION line to " + RAW_DATA_PATH + ". Got exception.", ErrorMessage = ex.ToString() });
            }
            
        }

        ~Communicator()
        {
            _port.Dispose();
        }

        // ---------- Public methods     ---------- \\
        public void Dispose()
        {
            _port.Dispose();
            _currentIndata = "";
            _logger = null;
            _publisher = null;
        }

        // ---------- Properties         ---------- \\
        /// <summary>
        /// Gets last reading of telemetry.
        /// </summary>
        public Telemetry Telemetry
        {
            get { return _lastReading; }
        }

        /// <summary>
        /// Gets whether the serial port is open.
        /// </summary>
        public bool SerialConnected
        {
            get { return _port.IsOpen; }
        }

        // ---------- Private methods    ---------- \\
        /// <summary>
        /// Reads whatever is on the serial port right now.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string read = _port.ReadExisting();

            _currentIndata += read;
            try
            {
                using (StreamWriter sw = new StreamWriter(RAW_DATA_PATH, true))
                {
                    sw.Write(read);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "File IO", Description = "Tried to write received data to " +
                RAW_DATA_PATH + ". Got exception.", ErrorMessage = ex.ToString()});
            }
            

            ProcessIndata();
        }

        /// <summary>
        /// Processes whatever is currently in the _currentIndata string.
        /// </summary>
        private void ProcessIndata()
        {
            int startPosition = _currentIndata.IndexOf(START_OF_MESSAGE);
            bool moreThanOneMessage = false;

            if (startPosition != -1 && _currentIndata.IndexOf(START_OF_MESSAGE, startPosition + 1) > 0)
            {
                moreThanOneMessage = true;
            }
            
            if (startPosition == 0)
            {
                int endPosition = _currentIndata.IndexOf(END_OF_MESSAGE);
                if (endPosition != -1)
                {
                    string completeIndata = _currentIndata.Substring(startPosition, endPosition + 1);
                    _currentIndata = _currentIndata.Substring(endPosition + 1);
                    ParseString(completeIndata);

                    if (_lastReading.Timestamp.Value.Ticks != 0)
                    {
                        ReceivedTelemetry(this, new EventArgs());
                        _logger.AppendTelemetry(_lastReading);
                        _publisher.Push(_lastReading);
                    }
                }
            }
            else if (startPosition != -1)
            {                
                _currentIndata = _currentIndata.Substring(startPosition);
                ProcessIndata();
            }

            if (moreThanOneMessage)
                ProcessIndata();
        }

        private void ParseString(string completeIndata)
        {
            completeIndata = completeIndata.Substring(1, completeIndata.Length - 2);
            string[] telemetry = completeIndata.Split(',');

            _lastReading = new Telemetry() { Timestamp = new DateTime(0) };

            if (telemetry.Length != NUMBER_OF_TELEMETRY_FIELDS)
            {
                _logger.AppendDebugLog(new DebugLog()
                {
                    Timestamp = DateTime.Now,
                    Type = "Telemetry",
                    Description = "Telemetry string is not complete. Expected " + Convert.ToString(NUMBER_OF_TELEMETRY_FIELDS) + "fields of information.",
                    ErrorMessage = completeIndata });

                TelemetryError(this, "Telemetry error");
            }

            try
            {
                int hour = Convert.ToInt32(telemetry[0].Substring(0, 2));
                int minute = Convert.ToInt32(telemetry[0].Substring(2, 2));
                int second = Convert.ToInt32(telemetry[0].Substring(4, 2));
                _lastReading.Timestamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second);
            }
            catch (Exception)
            {
                _lastReading.Timestamp = new DateTime(0);
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry", 
                    Description = "Something wrong with the time part of the telemetry string.", ErrorMessage = telemetry[0] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.Latitude = telemetry[1].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.Latitude = 0;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the latitude part of the telemetry string.", ErrorMessage = telemetry[1] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.Longitude = telemetry[2].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.Longitude = 0;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the longitude part of the telemetry string.", ErrorMessage = telemetry[2] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.Altitude = (int)telemetry[3].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.Altitude = 0;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the altitude part of the telemetry string.", ErrorMessage = telemetry[3] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.Satellites = (int)telemetry[4].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.Satellites = -1;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the satelites part of the telemetry string.", ErrorMessage = telemetry[4] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.AccX = telemetry[5].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.AccX = 0;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the accX part of the telemetry string.", ErrorMessage = telemetry[5] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.AccY = telemetry[6].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.AccY = 0;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the accY part of the telemetry string.", ErrorMessage = telemetry[6] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.AccZ = telemetry[7].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.AccZ = 0;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the accZ part of the telemetry string.", ErrorMessage = telemetry[7] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.Heading = (int)telemetry[8].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.Heading = -1;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the heading part of the telemetry string.", ErrorMessage = telemetry[8] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.Pressure = telemetry[9].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.Pressure = -1;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the pressure part of the telemetry string.", ErrorMessage = telemetry[9] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.TempPressure = telemetry[10].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.TempPressure = 0;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the tempPressure part of the telemetry string.", ErrorMessage = telemetry[10] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.Humidity = telemetry[11].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.Humidity = -1;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the humidity part of the telemetry string.", ErrorMessage = telemetry[11] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.TempHumidity = telemetry[12].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.TempHumidity = 0;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the tempHumidity part of the telemetry string.", ErrorMessage = telemetry[12] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.Voltage = telemetry[13].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.Voltage = -1;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the voltage part of the telemetry string.", ErrorMessage = telemetry[13] });
                TelemetryError(this, "Telemetry error");
            }

            try
            {
                _lastReading.Spin = telemetry[14].ToGbDouble();
            }
            catch (Exception)
            {
                _lastReading.Spin = -1;
                _logger.AppendDebugLog(new DebugLog() { Timestamp = DateTime.Now, Type = "Telemetry",
                    Description = "Something wrong with the spin part of the telemetry string.", ErrorMessage = telemetry[14] });
                TelemetryError(this, "Telemetry error");
            }
        }
    }
}
