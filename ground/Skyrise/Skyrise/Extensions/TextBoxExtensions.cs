using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Skyrise.Extensions
{
    public static class TextBoxExtensions
    {
        public delegate void SetTextCallback(TextBox value, string text);

        public static void SetTextSafe(this TextBox value, string text)
        {
            if (value.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextSafe);
                value.Invoke(d, new object[] { value, text });
            }
            else
            {
                value.Text = text;
            }
        }
    }
}
