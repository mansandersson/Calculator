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
using System.Text.RegularExpressions;
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
        /// Window size (textbox + decimal, hex, binary (2 lines) value visible)
        /// </summary>
        private Size FullSizeTwoBinaryLines = new Size(467, 175);
        /// <summary>
        /// Window size (textbox + decimal, hex, binary (3 lines) value visible)
        /// </summary>
        private Size FullSizeThreeBinaryLines = new Size(467, 200);

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
            txtResultDecimal.Text = "";
            txtResultHex.Text = "";
            txtResultBits.Text = "";

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

                txtResultDecimal.Text = result.ToString();

                if (result == ((double)intResult))
                {
                    // This is a whole number
                    txtResultHex.Text = String.Join(" ", intResult.ToString("X").Reverse().SplitEveryNth(4)).Reverse();

                    txtResultBits.Text = String.Join(" ", Convert.ToString(intResult, 2).Reverse().SplitEveryNth(4)).Reverse();

                    if (txtResultBits.Text.Length > 100)
                        this.ClientSize = FullSizeThreeBinaryLines;
                    else if (txtResultBits.Text.Length > 50)
                        this.ClientSize = FullSizeTwoBinaryLines;
                    else
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
            txtResultDecimal.Width = (int)Math.Abs((txtResultDecimal.Text.Length) * (txtResultDecimal.Font.Size+1));
            //txtResultBits.Width = (int)Math.Abs((txtResultBits.Text.Length) * (txtResultBits.Font.Size+1));
            txtResultHex.Width = (int)Math.Abs((txtResultHex.Text.Length) * (txtResultHex.Font.Size+1));
        }

        /// <summary>
        /// Handle event when mouse is moved on top of the bits textbox and present a tooltip of the hovered value
        /// </summary>
        /// <param name="sender">calling object</param>
        /// <param name="e">event arguments</param>
        private void txtResultBits_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer_bitTooltip.Enabled)
            {
                Int32? bit = txtResultBits.GetBit(e.Location, 4);
                if (bit.HasValue)
                {
                    tooltip.ToolTipTitle = String.Format("Bit {0}", bit.Value);
                    Point p = txtResultBits.Location;
                    tooltip.Show(String.Format("1<<{0}={1}", bit.Value, 1<<bit.Value), this, p.X + e.X, p.Y + e.Y + 32);

                    timer_bitTooltip.Interval = 50;
                    timer_bitTooltip.Enabled = true;
                }
                else
                {
                    tooltip.Hide(this);
                }
            }
        }

        /// <summary>
        /// Handle event when mouse is mouved off from the bits textbox, hiding the tooltip
        /// </summary>
        /// <param name="sender">calling object</param>
        /// <param name="e">event arguments</param>
        private void txtResultBits_MouseLeave(object sender, EventArgs e)
        {
            tooltip.Hide(this);
        }

        /// <summary>
        /// Handle fire event on tooltip timer. The tooltip timer prevents the tooltip from redrawing too often
        /// </summary>
        /// <param name="sender">calling object</param>
        /// <param name="e">event arguments</param>
        private void timer_bitTooltip_Tick(object sender, EventArgs e)
        {
            timer_bitTooltip.Enabled = false;
        }
    }
}
