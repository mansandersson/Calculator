/*
    Copyright (c) 2011, Måns Andersson <mail@mansandersson.se>

    Permission to use, copy, modify, and/or distribute this software for any
    purpose with or without fee is hereby granted, provided that the above
    copyright notice and this permission notice appear in all copies.

    THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
    WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
    MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
    ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
    WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
    ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
    OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
*/
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
