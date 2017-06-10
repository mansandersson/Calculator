using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public class NoSpaceCopyTextBox : System.Windows.Forms.TextBox
    {
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x301: //WM_COPY
                    {
                        Clipboard.SetText(this.Text.Replace(" ", ""));
                        return;
                    }
            }

            base.WndProc(ref m);
        }

        public Int32? GetBit(Point location, Int32 grouping)
        {
            int index = this.GetCharIndexFromPosition(location);

            string text = this.Text;
            char c = text[index];
            if (c == ' ')
            {
                return null;
            }

            text = text.Substring(index).Replace(" ", String.Empty);
            return text.Length - 1;
        }
    }
}
