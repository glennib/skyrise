using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyrise
{
    public class Logger
    {
        // ---------- Instance variables ---------- \\


        // ---------- Statics and events ---------- \\
        public delegate void DebugLogEventHandler(object sender, string message);
        public event DebugLogEventHandler NewDebugLog;

        // ---------- Constructors       ---------- \\
        public Logger()
        {
            
        }

        // ---------- Public methods     ---------- \\
        public void AppendTelemetry(Telemetry telemetry)
        {
            using (dbSkyriseDataContext db = new dbSkyriseDataContext())
            {
                db.Telemetries.InsertOnSubmit(telemetry);
                db.SubmitChanges();
            }
        }

        public void AppendDebugLog(DebugLog debug)
        {
            using (dbSkyriseDataContext db = new dbSkyriseDataContext())
            {
                db.DebugLogs.InsertOnSubmit(debug);
                db.SubmitChanges();
                NewDebugLog(this, debug.Type + ": " + debug.Description);
            }
        }

        // ---------- Properties         ---------- \\


        // ---------- Private methods    ---------- \\

    }
}
