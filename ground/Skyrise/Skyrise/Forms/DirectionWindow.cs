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
    public partial class DirectionWindow : Form
    {        
        // ---------- Instance variables ---------- \\
        double _groundLatitude, _groundLongitude, _groundAltitude;
        double _payloadLatitude, _payloadLongitude, _payloadAltitude;
        long _selectedID;


        // ---------- Statics and events ---------- \\


        // ---------- Constructors       ---------- \\
        public DirectionWindow()
        {
            InitializeComponent();
        }

        

        // ---------- Public methods     ---------- \\


        // ---------- Properties         ---------- \\


        // ---------- Private methods    ---------- \\
        private void txtGroundLatitude_TextChanged(object sender, EventArgs e)
        {
            btnGroundApply.Enabled = true;
        }

        private void txtGroundLongitude_TextChanged(object sender, EventArgs e)
        {
            btnGroundApply.Enabled = true;
        }

        private void txtGroundAltitude_TextChanged(object sender, EventArgs e)
        {
            btnGroundApply.Enabled = true;
        }

        private void btnGroundApply_Click(object sender, EventArgs e)
        {
            double latitude, longitude, altitude;
            if (double.TryParse(txtGroundLatitude.Text, out latitude))
            {
                if (double.TryParse(txtGroundLongitude.Text, out longitude))
                {
                    if (double.TryParse(txtGroundAltitude.Text, out altitude))
                    {
                        ApplyGroundPosition(latitude, longitude, altitude);
                        btnGroundApply.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("Altitude must be a number.", "Format Error");
                    }
                }
                else
                {
                    MessageBox.Show("Longitude must be a number.", "Format Error");
                }
            }
            else
            {
                MessageBox.Show("Latitude must be a number.", "Format Error");
            }
        }

        private void ApplyGroundPosition(double latitude, double longitude, double altitude)
        {
            _groundLatitude = latitude;
            _groundLongitude = longitude;
            _groundAltitude = altitude;

            Calculate();
        }

        private void RefreshPayloadPosition()
        {
            if (rdoLatest.Checked)
            {
                Telemetry telemetry;
                using (dbSkyriseDataContext db = new dbSkyriseDataContext())
                {
                    try
                    {
                        long highestID = db.Telemetries.Max(x => x.ID);
                        telemetry = db.Telemetries.First(x => x.ID == highestID);
                        ApplyPayloadPosition(telemetry.Latitude.Value, telemetry.Longitude.Value, telemetry.Altitude.Value);
                    }
                    catch (Exception)
                    {
                        rdoManual.Checked = true;
                        MessageBox.Show("No entries in telemetry table.", "Empty Table");                        
                    }
                    
                }
            }
            else if (rdoManual.Checked)
            {
                double latitude, longitude, altitude;
                if (double.TryParse(txtPayloadLatitude.Text, out latitude))
                {
                    if (double.TryParse(txtPayloadLongitude.Text, out longitude))
                    {
                        if (double.TryParse(txtPayloadAltitude.Text, out altitude))
                        {
                            ApplyPayloadPosition(latitude, longitude, altitude);
                            btnPayloadApply.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Altitude must be a number.", "Format Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Longitude must be a number.", "Format Error");
                    }
                }
                else
                {
                    MessageBox.Show("Latitude must be a number.", "Format Error");
                }
            }
            else //rdoEntry is checked
            {
                if (long.TryParse(txtEntryID.Text, out _selectedID))
                {
                    using (dbSkyriseDataContext db = new dbSkyriseDataContext())
                    {
                        Telemetry telemetry;
                        try
                        {
                            telemetry = db.Telemetries.First(x => x.ID == _selectedID);
                            if (telemetry == null)
                            {
                                MessageBox.Show("No entry with ID " + _selectedID.ToString() + " found. Please check that you entered correct ID.", "ID Not Found");
                            }
                            else
                            {
                                ApplyPayloadPosition(telemetry.Latitude.Value, telemetry.Longitude.Value, telemetry.Altitude.Value);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No entries in telemetry table.", "Empty Table");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Entry ID must be a number.", "Format Error");
                }
            }
            Calculate();
        }

        private void rdoManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoManual.Checked)
            {
                txtPayloadLatitude.ReadOnly = false;
                txtPayloadLongitude.ReadOnly = false;
                txtPayloadAltitude.ReadOnly = false;
                btnPayloadApply.Enabled = true;
            }
            else
            {
                txtPayloadLatitude.ReadOnly = true;
                txtPayloadLongitude.ReadOnly = true;
                txtPayloadAltitude.ReadOnly = true;
                btnPayloadApply.Enabled = false;
            }
        }

        private void rdoEntry_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEntry.Checked)
            {
                txtEntryID.ReadOnly = false;
                btnPayloadApply.Enabled = true;
            }
            else
            {
                txtEntryID.ReadOnly = true;
                btnPayloadApply.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Calculate()
        {
            double azimuth = DirectionMath.Azimuth(_groundLatitude.ToRadians(), _groundLongitude.ToRadians(), _payloadLatitude.ToRadians(),
                _payloadLongitude.ToRadians()).ToDegrees();
            double elevation = DirectionMath.Elevation(_groundLatitude.ToRadians(), _groundLongitude.ToRadians(), _groundAltitude,
                _payloadLatitude.ToRadians(), _payloadLongitude.ToRadians(), _payloadAltitude).ToDegrees();

            txtAzimuth.Text = Convert.ToString(azimuth);
            txtElevation.Text = Convert.ToString(elevation);
        }

        private void btnPayloadApply_Click(object sender, EventArgs e)
        {
            RefreshPayloadPosition();
        }

        private void ApplyPayloadPosition(double latitude, double longitude, double altitude)
        {
            _payloadLatitude = latitude;
            _payloadLongitude = longitude;
            _payloadAltitude = altitude;

            txtPayloadLatitude.Text = Convert.ToString(_payloadLatitude);
            txtPayloadLongitude.Text = Convert.ToString(_payloadLongitude);
            txtPayloadAltitude.Text = Convert.ToString(_payloadAltitude);
        }

        private void txtPayloadLatitude_TextChanged(object sender, EventArgs e)
        {
            if (rdoManual.Checked)
            {
                btnPayloadApply.Enabled = true;
            }
        }

        private void txtPayloadLongitude_TextChanged(object sender, EventArgs e)
        {
            if (rdoManual.Checked)
            {
                btnPayloadApply.Enabled = true;
            }
        }

        private void txtPayloadAltitude_TextChanged(object sender, EventArgs e)
        {
            if (rdoManual.Checked)
            {
                btnPayloadApply.Enabled = true;
            }
        }

        private void tmrGetLatest_Tick(object sender, EventArgs e)
        {
            if (rdoLatest.Checked)
            {
                RefreshPayloadPosition();
            }
        }
    }
}
