/*
    Copyright (c) 2011-2012, Måns Andersson <mail@mansandersson.se>

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
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Main Window
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Window size (only textbox visible)
        /// </summary>
        private Size NullSize = new Size(467, 76);
        /// <summary>
        /// Window size (textbox + decimal value visible)
        /// </summary>
        private Size HalfSize = new Size(467, 110);
        /// <summary>
        /// Window size (textbox + decimal, hex, binary value visible)
        /// </summary>
        private Size FullSize = new Size(467, 186);

        /// <summary>
        /// Constructor, init form
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ClearLabels();
        }

        /// <summary>
        /// Clear all labels and set size to null
        /// </summary>
        private void ClearLabels()
        {
            this.Size = NullSize;
            txtInput.BackColor = Color.Silver;
            lblResultDecimal.Text = "";
            lblResultHex.Text = "";
            lblResultBits.Text = "";
        }

        /// <summary>
        /// Text input has changed, re-evaluate and calculate
        /// </summary>
        /// <param name="sender">sending object</param>
        /// <param name="e">event arguments</param>
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            ClearLabels();
            if (String.IsNullOrWhiteSpace(txtInput.Text))
                return;

            Calculator calc = new Calculator(txtInput.Text);
            double? result = null;
            try
            {
                result = calc.Calculate();
            }
            catch (Exception)
            {
                result = null;
            }

            if (result.HasValue)
            {
                Int64 intResult = (Int64)result;

                lblResultDecimal.Text = result.ToString();

                if (result == ((double)intResult))
                {
                    // This is a whole number
                    lblResultHex.Text = "0x" + intResult.ToString("X");

                    lblResultBits.Text = "0b" + Convert.ToString(intResult, 2);

                    this.Size = FullSize;
                }
                else
                {
                    this.Size = HalfSize;
                }
            }
            else
            {
                txtInput.BackColor = Color.Salmon;
            }
        }
    }
}
