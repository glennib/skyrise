namespace Skyrise
{
    partial class DirectionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectionWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGroundApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGroundAltitude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroundLongitude = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroundLatitude = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoManual = new System.Windows.Forms.RadioButton();
            this.txtEntryID = new System.Windows.Forms.TextBox();
            this.rdoEntry = new System.Windows.Forms.RadioButton();
            this.rdoLatest = new System.Windows.Forms.RadioButton();
            this.btnPayloadApply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPayloadAltitude = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPayloadLongitude = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPayloadLatitude = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtElevation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAzimuth = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tmrGetLatest = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnGroundApply);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGroundAltitude);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGroundLongitude);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGroundLatitude);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ground Position";
            // 
            // btnGroundApply
            // 
            this.btnGroundApply.Location = new System.Drawing.Point(390, 30);
            this.btnGroundApply.Name = "btnGroundApply";
            this.btnGroundApply.Size = new System.Drawing.Size(75, 23);
            this.btnGroundApply.TabIndex = 6;
            this.btnGroundApply.Text = "Apply";
            this.btnGroundApply.UseVisualStyleBackColor = true;
            this.btnGroundApply.Click += new System.EventHandler(this.btnGroundApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Altitude";
            // 
            // txtGroundAltitude
            // 
            this.txtGroundAltitude.Location = new System.Drawing.Point(262, 32);
            this.txtGroundAltitude.Name = "txtGroundAltitude";
            this.txtGroundAltitude.Size = new System.Drawing.Size(122, 20);
            this.txtGroundAltitude.TabIndex = 4;
            this.txtGroundAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGroundAltitude.TextChanged += new System.EventHandler(this.txtGroundAltitude_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Longitude";
            // 
            // txtGroundLongitude
            // 
            this.txtGroundLongitude.Location = new System.Drawing.Point(134, 32);
            this.txtGroundLongitude.Name = "txtGroundLongitude";
            this.txtGroundLongitude.Size = new System.Drawing.Size(122, 20);
            this.txtGroundLongitude.TabIndex = 2;
            this.txtGroundLongitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGroundLongitude.TextChanged += new System.EventHandler(this.txtGroundLongitude_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Latitude";
            // 
            // txtGroundLatitude
            // 
            this.txtGroundLatitude.Location = new System.Drawing.Point(6, 32);
            this.txtGroundLatitude.Name = "txtGroundLatitude";
            this.txtGroundLatitude.Size = new System.Drawing.Size(122, 20);
            this.txtGroundLatitude.TabIndex = 0;
            this.txtGroundLatitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGroundLatitude.TextChanged += new System.EventHandler(this.txtGroundLatitude_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rdoManual);
            this.groupBox2.Controls.Add(this.txtEntryID);
            this.groupBox2.Controls.Add(this.rdoEntry);
            this.groupBox2.Controls.Add(this.rdoLatest);
            this.groupBox2.Controls.Add(this.btnPayloadApply);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPayloadAltitude);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPayloadLongitude);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtPayloadLatitude);
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 90);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payload Position";
            // 
            // rdoManual
            // 
            this.rdoManual.AutoSize = true;
            this.rdoManual.Checked = true;
            this.rdoManual.Location = new System.Drawing.Point(69, 19);
            this.rdoManual.Name = "rdoManual";
            this.rdoManual.Size = new System.Drawing.Size(60, 17);
            this.rdoManual.TabIndex = 9;
            this.rdoManual.TabStop = true;
            this.rdoManual.Text = "Manual";
            this.rdoManual.UseVisualStyleBackColor = true;
            this.rdoManual.CheckedChanged += new System.EventHandler(this.rdoManual_CheckedChanged);
            // 
            // txtEntryID
            // 
            this.txtEntryID.Location = new System.Drawing.Point(207, 18);
            this.txtEntryID.Name = "txtEntryID";
            this.txtEntryID.ReadOnly = true;
            this.txtEntryID.Size = new System.Drawing.Size(100, 20);
            this.txtEntryID.TabIndex = 9;
            this.txtEntryID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rdoEntry
            // 
            this.rdoEntry.AutoSize = true;
            this.rdoEntry.Location = new System.Drawing.Point(135, 19);
            this.rdoEntry.Name = "rdoEntry";
            this.rdoEntry.Size = new System.Drawing.Size(66, 17);
            this.rdoEntry.TabIndex = 8;
            this.rdoEntry.Text = "Entry ID:";
            this.rdoEntry.UseVisualStyleBackColor = true;
            this.rdoEntry.CheckedChanged += new System.EventHandler(this.rdoEntry_CheckedChanged);
            // 
            // rdoLatest
            // 
            this.rdoLatest.AutoSize = true;
            this.rdoLatest.Location = new System.Drawing.Point(9, 19);
            this.rdoLatest.Name = "rdoLatest";
            this.rdoLatest.Size = new System.Drawing.Size(54, 17);
            this.rdoLatest.TabIndex = 7;
            this.rdoLatest.Text = "Latest";
            this.rdoLatest.UseVisualStyleBackColor = true;
            // 
            // btnPayloadApply
            // 
            this.btnPayloadApply.Location = new System.Drawing.Point(390, 54);
            this.btnPayloadApply.Name = "btnPayloadApply";
            this.btnPayloadApply.Size = new System.Drawing.Size(75, 23);
            this.btnPayloadApply.TabIndex = 6;
            this.btnPayloadApply.Text = "Apply";
            this.btnPayloadApply.UseVisualStyleBackColor = true;
            this.btnPayloadApply.Click += new System.EventHandler(this.btnPayloadApply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Altitude";
            // 
            // txtPayloadAltitude
            // 
            this.txtPayloadAltitude.Location = new System.Drawing.Point(262, 57);
            this.txtPayloadAltitude.Name = "txtPayloadAltitude";
            this.txtPayloadAltitude.Size = new System.Drawing.Size(122, 20);
            this.txtPayloadAltitude.TabIndex = 4;
            this.txtPayloadAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayloadAltitude.TextChanged += new System.EventHandler(this.txtPayloadAltitude_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Longitude";
            // 
            // txtPayloadLongitude
            // 
            this.txtPayloadLongitude.Location = new System.Drawing.Point(134, 57);
            this.txtPayloadLongitude.Name = "txtPayloadLongitude";
            this.txtPayloadLongitude.Size = new System.Drawing.Size(122, 20);
            this.txtPayloadLongitude.TabIndex = 2;
            this.txtPayloadLongitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayloadLongitude.TextChanged += new System.EventHandler(this.txtPayloadLongitude_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Latitude";
            // 
            // txtPayloadLatitude
            // 
            this.txtPayloadLatitude.Location = new System.Drawing.Point(6, 57);
            this.txtPayloadLatitude.Name = "txtPayloadLatitude";
            this.txtPayloadLatitude.Size = new System.Drawing.Size(122, 20);
            this.txtPayloadLatitude.TabIndex = 0;
            this.txtPayloadLatitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayloadLatitude.TextChanged += new System.EventHandler(this.txtPayloadLatitude_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtElevation);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtAzimuth);
            this.groupBox3.Location = new System.Drawing.Point(12, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(475, 68);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calculated Direction";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(235, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Elevation";
            // 
            // txtElevation
            // 
            this.txtElevation.Location = new System.Drawing.Point(238, 32);
            this.txtElevation.Name = "txtElevation";
            this.txtElevation.ReadOnly = true;
            this.txtElevation.Size = new System.Drawing.Size(227, 20);
            this.txtElevation.TabIndex = 2;
            this.txtElevation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Azimuth";
            // 
            // txtAzimuth
            // 
            this.txtAzimuth.Location = new System.Drawing.Point(6, 32);
            this.txtAzimuth.Name = "txtAzimuth";
            this.txtAzimuth.ReadOnly = true;
            this.txtAzimuth.Size = new System.Drawing.Size(226, 20);
            this.txtAzimuth.TabIndex = 0;
            this.txtAzimuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(408, 258);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tmrGetLatest
            // 
            this.tmrGetLatest.Enabled = true;
            this.tmrGetLatest.Interval = 1000;
            this.tmrGetLatest.Tick += new System.EventHandler(this.tmrGetLatest_Tick);
            // 
            // DirectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 293);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DirectionWindow";
            this.Text = "Direction";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGroundApply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGroundAltitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGroundLongitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGroundLatitude;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoManual;
        private System.Windows.Forms.TextBox txtEntryID;
        private System.Windows.Forms.RadioButton rdoEntry;
        private System.Windows.Forms.RadioButton rdoLatest;
        private System.Windows.Forms.Button btnPayloadApply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPayloadAltitude;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPayloadLongitude;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPayloadLatitude;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtElevation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAzimuth;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer tmrGetLatest;
    }
}