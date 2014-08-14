namespace Skyrise
{
    partial class TwitterTest
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
            this.txtTweet = new System.Windows.Forms.TextBox();
            this.btnTweet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTweet
            // 
            this.txtTweet.Location = new System.Drawing.Point(12, 12);
            this.txtTweet.Multiline = true;
            this.txtTweet.Name = "txtTweet";
            this.txtTweet.Size = new System.Drawing.Size(158, 92);
            this.txtTweet.TabIndex = 0;
            // 
            // btnTweet
            // 
            this.btnTweet.Location = new System.Drawing.Point(12, 110);
            this.btnTweet.Name = "btnTweet";
            this.btnTweet.Size = new System.Drawing.Size(158, 23);
            this.btnTweet.TabIndex = 1;
            this.btnTweet.Text = "Tweet";
            this.btnTweet.UseVisualStyleBackColor = true;
            this.btnTweet.Click += new System.EventHandler(this.btnTweet_Click);
            // 
            // TwitterTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 143);
            this.Controls.Add(this.btnTweet);
            this.Controls.Add(this.txtTweet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TwitterTest";
            this.Text = "Twitter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTweet;
        private System.Windows.Forms.Button btnTweet;
    }
}