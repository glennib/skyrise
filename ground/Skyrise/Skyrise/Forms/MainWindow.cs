using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Skyrise
{
    using Extensions;
    public partial class MainWindow : Form
    {
        
        // ---------- Instance variables ---------- \\
        DataWindow _dataWindow;
        DirectionWindow _directionWindow;
        TwitterTest _twitterWindow;

        Communicator _communicator;
        Logger _logger;
        Publisher _publisher;

        // ---------- Statics and events ---------- \\        
        

        // ---------- Constructors       ---------- \\
        public MainWindow()
        {
            InitializeComponent();
            _logger = new Logger();
            _publisher = new Publisher();

            _publisher.Response += new Publisher.ResponseHandler(_publisher_Response);
            _logger.NewDebugLog += new Logger.DebugLogEventHandler(_logger_NewDebugLog);
        }

        // ---------- Public methods     ---------- \\


        // ---------- Properties         ---------- \\


        // ---------- Private methods    ---------- \\
        private void _logger_NewDebugLog(object sender, string message)
        {
            txtLatestError.SetTextSafe(message);
        }

        private void btnOpenTables_Click(object sender, EventArgs e)
        {
            if (_dataWindow == null || _dataWindow.IsDisposed)
            {
                _dataWindow = new DataWindow();
            }
            _dataWindow.Show();
        }

        private void btnRawData_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Communicator.RAW_DATA_PATH);
            }
            catch (Exception)
            {
                MessageBox.Show("File not found. Try to connect to a COM-port.", "File Not Found");
            }


        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            foreach (string port in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboSerialPort.Items.Add(port);
            }

            if (_twitterWindow == null || _twitterWindow.IsDisposed)
            {
                _twitterWindow = new TwitterTest();
            }
            _twitterWindow.Show();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_communicator == null || !_communicator.SerialConnected)
            {
                try
                {
                    _communicator = new Communicator(cboSerialPort.SelectedItem.ToString(), _logger, _publisher);
                    _communicator.ReceivedTelemetry += new Communicator.ReceivedTelemetryEventHandler(_communicator_ReceivedData);
                    _communicator.TelemetryError += new Communicator.TelemetryErrorEventHandler(_communicator_TelemetryError);

                    btnConnect.Text = "Disconnect";
                    cboSerialPort.Enabled = false;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Please select a COM-port from the drop down box.", "COM not selected");
                }
                catch (Exception ex)
                {
                    _communicator.Dispose();
                    btnConnect.Text = "Connect";
                    cboSerialPort.Enabled = true;
                    MessageBox.Show(ex.Message, ex.ToString());
                }
            }
            else
            {
                _communicator.Dispose();
                btnConnect.Text = "Connect";
                cboSerialPort.Enabled = true;
            }
            

            
        }

        private void _communicator_ReceivedData(object sender, EventArgs e)
        {
            txtTimestamp.SetTextSafe(_communicator.Telemetry.Timestamp.Value.ToString());
            txtVoltage.SetTextSafe(_communicator.Telemetry.Voltage.ToString() + " V");

            txtHeading.SetTextSafe(_communicator.Telemetry.Heading.ToString() + " °");

            txtSpin.SetTextSafe(_communicator.Telemetry.Spin.ToString() + " °/s");

            txtLatitude.SetTextSafe(_communicator.Telemetry.Latitude.ToString() + " °");
            txtLongitude.SetTextSafe(_communicator.Telemetry.Longitude.ToString() + " °");
            txtAltitude.SetTextSafe(_communicator.Telemetry.Altitude.ToString() + " m");
            txtSatellites.SetTextSafe(_communicator.Telemetry.Satellites.ToString());

            txtAccX.SetTextSafe(_communicator.Telemetry.AccX.ToString() + " m/s^2");
            txtAccY.SetTextSafe(_communicator.Telemetry.AccY.ToString() + " m/s^2");
            txtAccZ.SetTextSafe(_communicator.Telemetry.AccZ.ToString() + " m/s^2");

            txtPressure.SetTextSafe(_communicator.Telemetry.Pressure.ToString() + " mbar");
            txtTempPressure.SetTextSafe(_communicator.Telemetry.TempPressure.ToString() + " °C");

            txtHumidity.SetTextSafe(_communicator.Telemetry.Humidity.ToString() + " %");
            txtTempHumidity.SetTextSafe(_communicator.Telemetry.TempHumidity.ToString() + " °C");
        }

        private void _communicator_TelemetryError(object sender, string briefMessage)
        {
            ttError.Show(briefMessage, btnOpenTables, 1000);
        }

        private void _publisher_Response(object sender, string message)
        {
            txtMessage.SetTextSafe(message);
        }

        private void btnOpenDirection_Click(object sender, EventArgs e)
        {
            if (_directionWindow == null || _directionWindow.IsDisposed)
            {
                _directionWindow = new DirectionWindow();
            }
            _directionWindow.Show();
        }        
    }
}
