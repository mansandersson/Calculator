using System;
using System.Collections.Generic;
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
    }
}
