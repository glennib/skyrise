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
    public partial class DataWindow : Form
    {
        // ---------- Instance variables ---------- \\


        // ---------- Statics and events ---------- \\


        // ---------- Constructors       ---------- \\
        public DataWindow()
        {
            InitializeComponent();
        }

        // ---------- Public methods     ---------- \\


        // ---------- Properties         ---------- \\


        // ---------- Private methods    ---------- \\
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataWindow_Load(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void RefreshDataSource()
        {
            using (dbSkyriseDataContext db = new dbSkyriseDataContext())
            {
                telemetryBindingSource.DataSource =
                    from telemetry in db.Telemetries
                    orderby telemetry.ID
                    select telemetry;

                debugLogBindingSource.DataSource =
                    from debug in db.DebugLogs
                    orderby debug.ID
                    select debug;
            }
            
            telemetryDataGridView.Sort(telemetryDataGridView.Columns[0], ListSortDirection.Descending);
            debugLogDataGridView.Sort(debugLogDataGridView.Columns[0], ListSortDirection.Descending);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataSource();
        }
    }
}
