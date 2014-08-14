using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Skyrise
{
    using Extensions;
    /// <summary>
    /// Responsible for publishing a telemetry entry to the online DB.
    /// </summary>
    public class Publisher
    {
        // ---------- Instance variables ---------- \\
        const string BASE_URL = "http://skyrise.hit.no/wp-content/plugins/pst/pushdata.php?"; // Base URL for appending data. Including the password.        

        // ---------- Statics and events ---------- \\
        public delegate void ResponseHandler(object sender, string message); // Delegate for the Response event.
        public event ResponseHandler Response; // The response event. Triggers whenever a HTTP-response is parsed.

        public static double DateTimeToUnixTimestamp(DateTime dateTime) // This method converts a datetime object to Unix timestamp.
        {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }

        // ---------- Constructors       ---------- \\
        public Publisher() // Empty constructor.
        {

        }

        // ---------- Public methods     ---------- \\
        public void Push(Telemetry telemetry) // This pushes a telemetry reading to the database.
        {
            string input = "pass=" + Properties.Settings.Default.pushPassword + "&";


            // URL Formatting
            input += "time=";
            if (telemetry.Timestamp.HasValue)
            {
                input += DateTimeToUnixTimestamp(telemetry.Timestamp.Value).ToGbString();
            }
            else
            {
                input += DateTimeToUnixTimestamp(DateTime.Now).ToGbString();
            }
            input += "&";


            if (telemetry.Latitude.HasValue)
            {
                input += "lat=" + telemetry.Latitude.Value.ToGbString() + "&";
            }

            if (telemetry.Longitude.HasValue)
            {
                input += "lon=" + telemetry.Longitude.Value.ToGbString() + "&";
            }

            if (telemetry.Altitude.HasValue)
            {
                input += "alt=" + telemetry.Longitude.Altitude.ToGbString() + "&";
            }

            if (telemetry.Pressure.HasValue)
            {
                input += "pressure=" + telemetry.Pressure.Value.ToGbString() + "&";
            }

            if (telemetry.TempPressure.HasValue)
            {
                input += "tempin=" + telemetry.TempPressure.Value.ToGbString() + "&";
            }

            if (telemetry.TempHumidity.HasValue)
            {
                input += "tempout=" + telemetry.TempHumidity.Value.ToGbString() + "&";
            }

            if (telemetry.Heading.HasValue)
            {
                input += "heading=" + telemetry.Heading.Value.ToString() + "&";
            }

            if (telemetry.AccX.HasValue)
            {
                input += "accelX=" + telemetry.AccX.Value.ToGbString() + "&";
            }

            if (telemetry.AccY.HasValue)
            {
                input += "accelY=" + telemetry.AccY.Value.ToGbString() + "&";
            }

            if (telemetry.AccZ.HasValue)
            {
                input += "accelZ=" + telemetry.AccZ.Value.ToGbString() + "&";
            }

            if (telemetry.Humidity.HasValue)
            {
                input += "humidity=" + telemetry.Humidity.Value.ToGbString() + "&";
            }

            if (telemetry.Spin.HasValue)
            {
                input += "spin=" + telemetry.Spin.Value.ToGbString() + "&";
            }

            if (telemetry.Voltage.HasValue)
            {
                input += "voltage=" + telemetry.Voltage.Value.ToGbString() + "&";
            }

            string completeURL = BASE_URL + input;

            WebRequest request = WebRequest.Create(completeURL); // Request said URL.
            WebResponse response = request.GetResponse(); // The response gathered from the request.

            Stream data = response.GetResponseStream(); // Get the stream.

            string returnString = ""; // This is to contain whatever information gotten from the request.

            using (StreamReader sr = new StreamReader(data))
            {
                returnString = sr.ReadToEnd();
            }

            Parse(returnString); // Parse the request.
        }

        // ---------- Properties         ---------- \\


        // ---------- Private methods    ---------- \\
        private void Parse(string returnString)
        {
            string message;
            switch (returnString)
            {
                case "OK":
                    message = "Last upload OK.";
                    break;
                case "ERROR0":
                    message = "Could not append data into table.";
                    break;
                case "ERROR1":
                    message = "Time was missing in last request.";
                    break;
                case "ERROR2":
                    message = "Last used password was wrong.";
                    break;
                case "ERROR3":
                    message = "Password was missing in last request.";
                    break;
                case "ERROR4":
                    message = "Error connecting to database.";
                    break;
                default:
                    message = "Unknown error message: " + returnString;
                    break;
            }
            Response(this, message); // Triggers Response event, with an informative error message.
        }
    }
}
