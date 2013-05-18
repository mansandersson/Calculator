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
        private Size NullSize = new Size(467, 50);
        /// <summary>
        /// Window size (textbox + decimal value visible)
        /// </summary>
        private Size HalfSize = new Size(467, 83);
        /// <summary>
        /// Window size (textbox + decimal, hex, binary value visible)
        /// </summary>
        private Size FullSize = new Size(467, 150);

        /// <summary>
        /// Operational mode for expression evaluation
        /// </summary>
        private CalculatorMode Mode { get; set; }

        /// <summary>
        /// Constructor, init form
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ClearLabels();
            this.Mode = CalculatorMode.Mathematics;
        }

        /// <summary>
        /// Clear all labels and set size to null
        /// </summary>
        private void ClearLabels()
        {
            this.ClientSize = NullSize;
            txtInput.BackColor = Color.Silver;
            lblResultDecimal.Text = "";
            lblResultHex.Text = "";
            lblResultBits.Text = "";

            switch (this.Mode)
            {
                default:
                case CalculatorMode.Mathematics:
                    lblMode.Text = "M";
                    lblMode.BackColor = Color.Green;
                    break;
                case CalculatorMode.Programming:
                    lblMode.Text = "P";
                    lblMode.BackColor = Color.RoyalBlue;
                    break;
            }
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
            calc.Mode = this.Mode;
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

                    this.ClientSize = FullSize;
                }
                else
                {
                    this.ClientSize = HalfSize;
                }
            }
            else
            {
                txtInput.BackColor = Color.Salmon;
            }
        }

        /// <summary>
        /// Handle input of commands
        /// </summary>
        /// <param name="sender">calling object</param>
        /// <param name="e">event arguments</param>
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                bool handled = false;
                switch (txtInput.Text)
                {
                    // Set to mathematics mode
                    case "m":
                        this.Mode = CalculatorMode.Mathematics;
                        handled = true;
                        break;
                    // Set to programming mode
                    case "p":
                        this.Mode = CalculatorMode.Programming;
                        handled = true;
                        break;
                }
                if (handled)
                    txtInput.Clear();
            }
        }

        private void AdjustResultBoxToSizes(object sender, EventArgs e)
        {
            lblResultDecimal.Width = (int)Math.Abs((lblResultDecimal.Text.Length) * (lblResultDecimal.Font.Size+1));
            lblResultBits.Width = (int)Math.Abs((lblResultBits.Text.Length) * (lblResultBits.Font.Size+1));
            lblResultHex.Width = (int)Math.Abs((lblResultHex.Text.Length) * (lblResultHex.Font.Size+1));
        }
    }
}
