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
    public partial class RawDataWindow : Form
    {
        // ---------- Instance variables ---------- \\
        Communicator _communicator;


        // ---------- Statics and events ---------- \\


        // ---------- Constructors       ---------- \\
        public RawDataWindow(Communicator communicator)
        {
            InitializeComponent();
            _communicator = communicator;
            _communicator.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(_communicator_DataReceived);
        }

        private void _communicator_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            txtRawData.SetTextSafe(_communicator.AllData);
        }
        

        // ---------- Public methods     ---------- \\


        // ---------- Properties         ---------- \\


        // ---------- Private methods    ---------- \\


    }
}
