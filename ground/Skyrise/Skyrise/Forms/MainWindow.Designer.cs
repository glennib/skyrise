namespace Skyrise
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTempHumidity = new System.Windows.Forms.TextBox();
            this.txtHumidity = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTempPressure = new System.Windows.Forms.TextBox();
            this.txtPressure = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSpin = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHeading = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAccZ = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAccY = new System.Windows.Forms.TextBox();
            this.txtAccX = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSatellites = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAltitude = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVoltage = new System.Windows.Forms.TextBox();
            this.txtTimestamp = new System.Windows.Forms.TextBox();
            this.btnOpenTables = new System.Windows.Forms.Button();
            this.cboSerialPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnRawData = new System.Windows.Forms.Button();
            this.ttError = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtLatestError = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnOpenDirection = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 288);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Received Data";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.txtTempHumidity);
            this.groupBox8.Controls.Add(this.txtHumidity);
            this.groupBox8.Location = new System.Drawing.Point(301, 217);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(286, 60);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Humidity sensor (External)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Relative humidity";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(143, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Temperature";
            // 
            // txtTempHumidity
            // 
            this.txtTempHumidity.Location = new System.Drawing.Point(146, 32);
            this.txtTempHumidity.Name = "txtTempHumidity";
            this.txtTempHumidity.ReadOnly = true;
            this.txtTempHumidity.Size = new System.Drawing.Size(130, 20);
            this.txtTempHumidity.TabIndex = 2;
            this.txtTempHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHumidity
            // 
            this.txtHumidity.Location = new System.Drawing.Point(6, 32);
            this.txtHumidity.Name = "txtHumidity";
            this.txtHumidity.ReadOnly = true;
            this.txtHumidity.Size = new System.Drawing.Size(134, 20);
            this.txtHumidity.TabIndex = 0;
            this.txtHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.txtTempPressure);
            this.groupBox7.Controls.Add(this.txtPressure);
            this.groupBox7.Location = new System.Drawing.Point(6, 217);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(289, 60);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Pressure sensor (Internal)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Pressure";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(143, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Temperature";
            // 
            // txtTempPressure
            // 
            this.txtTempPressure.Location = new System.Drawing.Point(146, 32);
            this.txtTempPressure.Name = "txtTempPressure";
            this.txtTempPressure.ReadOnly = true;
            this.txtTempPressure.Size = new System.Drawing.Size(134, 20);
            this.txtTempPressure.TabIndex = 2;
            this.txtTempPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPressure
            // 
            this.txtPressure.Location = new System.Drawing.Point(6, 32);
            this.txtPressure.Name = "txtPressure";
            this.txtPressure.ReadOnly = true;
            this.txtPressure.Size = new System.Drawing.Size(134, 20);
            this.txtPressure.TabIndex = 0;
            this.txtPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.txtSpin);
            this.groupBox6.Location = new System.Drawing.Point(405, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(182, 60);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Gyro";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Spin";
            // 
            // txtSpin
            // 
            this.txtSpin.Location = new System.Drawing.Point(6, 32);
            this.txtSpin.Name = "txtSpin";
            this.txtSpin.ReadOnly = true;
            this.txtSpin.Size = new System.Drawing.Size(166, 20);
            this.txtSpin.TabIndex = 0;
            this.txtSpin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtHeading);
            this.groupBox5.Location = new System.Drawing.Point(220, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(179, 60);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Magnetometer";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Heading";
            // 
            // txtHeading
            // 
            this.txtHeading.Location = new System.Drawing.Point(6, 32);
            this.txtHeading.Name = "txtHeading";
            this.txtHeading.ReadOnly = true;
            this.txtHeading.Size = new System.Drawing.Size(167, 20);
            this.txtHeading.TabIndex = 0;
            this.txtHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtAccZ);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtAccY);
            this.groupBox4.Controls.Add(this.txtAccX);
            this.groupBox4.Location = new System.Drawing.Point(6, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(581, 60);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Accelerometer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Z";
            // 
            // txtAccZ
            // 
            this.txtAccZ.Location = new System.Drawing.Point(384, 32);
            this.txtAccZ.Name = "txtAccZ";
            this.txtAccZ.ReadOnly = true;
            this.txtAccZ.Size = new System.Drawing.Size(187, 20);
            this.txtAccZ.TabIndex = 4;
            this.txtAccZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(194, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Y";
            // 
            // txtAccY
            // 
            this.txtAccY.Location = new System.Drawing.Point(195, 32);
            this.txtAccY.Name = "txtAccY";
            this.txtAccY.ReadOnly = true;
            this.txtAccY.Size = new System.Drawing.Size(183, 20);
            this.txtAccY.TabIndex = 2;
            this.txtAccY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAccX
            // 
            this.txtAccX.Location = new System.Drawing.Point(6, 32);
            this.txtAccX.Name = "txtAccX";
            this.txtAccX.ReadOnly = true;
            this.txtAccX.Size = new System.Drawing.Size(183, 20);
            this.txtAccX.TabIndex = 0;
            this.txtAccX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtSatellites);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtAltitude);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtLongitude);
            this.groupBox3.Controls.Add(this.txtLatitude);
            this.groupBox3.Location = new System.Drawing.Point(6, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 60);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GPS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(512, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Satellites";
            // 
            // txtSatellites
            // 
            this.txtSatellites.Location = new System.Drawing.Point(512, 32);
            this.txtSatellites.Name = "txtSatellites";
            this.txtSatellites.ReadOnly = true;
            this.txtSatellites.Size = new System.Drawing.Size(59, 20);
            this.txtSatellites.TabIndex = 6;
            this.txtSatellites.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Altitude";
            // 
            // txtAltitude
            // 
            this.txtAltitude.Location = new System.Drawing.Point(344, 32);
            this.txtAltitude.Name = "txtAltitude";
            this.txtAltitude.ReadOnly = true;
            this.txtAltitude.Size = new System.Drawing.Size(163, 20);
            this.txtAltitude.TabIndex = 4;
            this.txtAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Latitude";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Longitude";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(175, 32);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.ReadOnly = true;
            this.txtLongitude.Size = new System.Drawing.Size(163, 20);
            this.txtLongitude.TabIndex = 2;
            this.txtLongitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(6, 32);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.ReadOnly = true;
            this.txtLatitude.Size = new System.Drawing.Size(163, 20);
            this.txtLatitude.TabIndex = 0;
            this.txtLatitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtVoltage);
            this.groupBox2.Controls.Add(this.txtTimestamp);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 60);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Timestamp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Voltage";
            // 
            // txtVoltage
            // 
            this.txtVoltage.Location = new System.Drawing.Point(141, 32);
            this.txtVoltage.Name = "txtVoltage";
            this.txtVoltage.ReadOnly = true;
            this.txtVoltage.Size = new System.Drawing.Size(59, 20);
            this.txtVoltage.TabIndex = 2;
            this.txtVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTimestamp
            // 
            this.txtTimestamp.Location = new System.Drawing.Point(6, 32);
            this.txtTimestamp.Name = "txtTimestamp";
            this.txtTimestamp.ReadOnly = true;
            this.txtTimestamp.Size = new System.Drawing.Size(129, 20);
            this.txtTimestamp.TabIndex = 0;
            // 
            // btnOpenTables
            // 
            this.btnOpenTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenTables.Location = new System.Drawing.Point(505, 380);
            this.btnOpenTables.Name = "btnOpenTables";
            this.btnOpenTables.Size = new System.Drawing.Size(103, 23);
            this.btnOpenTables.TabIndex = 1;
            this.btnOpenTables.Text = "Open Tables";
            this.btnOpenTables.UseVisualStyleBackColor = true;
            this.btnOpenTables.Click += new System.EventHandler(this.btnOpenTables_Click);
            // 
            // cboSerialPort
            // 
            this.cboSerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboSerialPort.FormattingEnabled = true;
            this.cboSerialPort.Location = new System.Drawing.Point(12, 380);
            this.cboSerialPort.Name = "cboSerialPort";
            this.cboSerialPort.Size = new System.Drawing.Size(92, 21);
            this.cboSerialPort.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConnect.Location = new System.Drawing.Point(110, 380);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.txtMessage);
            this.groupBox9.Controls.Add(this.label16);
            this.groupBox9.Location = new System.Drawing.Point(12, 12);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(295, 64);
            this.groupBox9.TabIndex = 11;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Online Database";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(6, 32);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(283, 20);
            this.txtMessage.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Message";
            // 
            // btnRawData
            // 
            this.btnRawData.Location = new System.Drawing.Point(191, 380);
            this.btnRawData.Name = "btnRawData";
            this.btnRawData.Size = new System.Drawing.Size(107, 23);
            this.btnRawData.TabIndex = 12;
            this.btnRawData.Text = "See Raw Data";
            this.btnRawData.UseVisualStyleBackColor = true;
            this.btnRawData.Click += new System.EventHandler(this.btnRawData_Click);
            // 
            // ttError
            // 
            this.ttError.IsBalloon = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.txtLatestError);
            this.groupBox10.Controls.Add(this.label17);
            this.groupBox10.Location = new System.Drawing.Point(313, 12);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(295, 64);
            this.groupBox10.TabIndex = 13;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Local";
            // 
            // txtLatestError
            // 
            this.txtLatestError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLatestError.Location = new System.Drawing.Point(6, 32);
            this.txtLatestError.Name = "txtLatestError";
            this.txtLatestError.ReadOnly = true;
            this.txtLatestError.Size = new System.Drawing.Size(283, 20);
            this.txtLatestError.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Latest error";
            // 
            // btnOpenDirection
            // 
            this.btnOpenDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDirection.Location = new System.Drawing.Point(396, 380);
            this.btnOpenDirection.Name = "btnOpenDirection";
            this.btnOpenDirection.Size = new System.Drawing.Size(103, 23);
            this.btnOpenDirection.TabIndex = 14;
            this.btnOpenDirection.Text = "Open Direction";
            this.btnOpenDirection.UseVisualStyleBackColor = true;
            this.btnOpenDirection.Click += new System.EventHandler(this.btnOpenDirection_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 415);
            this.Controls.Add(this.btnOpenDirection);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.btnRawData);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cboSerialPort);
            this.Controls.Add(this.btnOpenTables);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Skyrise";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimestamp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTempHumidity;
        private System.Windows.Forms.TextBox txtHumidity;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTempPressure;
        private System.Windows.Forms.TextBox txtPressure;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSpin;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtHeading;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAccZ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAccY;
        private System.Windows.Forms.TextBox txtAccX;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSatellites;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAltitude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVoltage;
        private System.Windows.Forms.Button btnOpenTables;
        private System.Windows.Forms.ComboBox cboSerialPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnRawData;
        private System.Windows.Forms.ToolTip ttError;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox txtLatestError;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnOpenDirection;
    }
}

