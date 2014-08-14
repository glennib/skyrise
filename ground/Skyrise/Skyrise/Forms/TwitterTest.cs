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
    public partial class TwitterTest : Form
    {
        private Tweeter _tweeter;

        public TwitterTest()
        {
            InitializeComponent();
            _tweeter = new Tweeter(Properties.Settings.Default.apiKey, Properties.Settings.Default.apiSecret, Properties.Settings.Default.accessToken, Properties.Settings.Default.accessTokenSecret);
        }

        private void btnTweet_Click(object sender, EventArgs e)
        {
            _tweeter.Tweet(txtTweet.Text);
        }
    }
}
