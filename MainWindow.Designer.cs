namespace Calculator
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtResultDecimal = new System.Windows.Forms.TextBox();
            this.txtResultHex = new System.Windows.Forms.TextBox();
            this.txtResultBits = new System.Windows.Forms.TextBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.BackColor = System.Drawing.Color.Silver;
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(16, 15);
            this.txtInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(557, 30);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // txtResultDecimal
            // 
            this.txtResultDecimal.BackColor = System.Drawing.Color.DimGray;
            this.txtResultDecimal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResultDecimal.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtResultDecimal.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultDecimal.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtResultDecimal.Location = new System.Drawing.Point(40, 65);
            this.txtResultDecimal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResultDecimal.Name = "txtResultDecimal";
            this.txtResultDecimal.ReadOnly = true;
            this.txtResultDecimal.Size = new System.Drawing.Size(25, 20);
            this.txtResultDecimal.TabIndex = 2;
            this.txtResultDecimal.TabStop = false;
            this.txtResultDecimal.Text = "0";
            this.txtResultDecimal.TextChanged += new System.EventHandler(this.AdjustResultBoxToSizes);
            // 
            // txtResultHex
            // 
            this.txtResultHex.BackColor = System.Drawing.Color.DimGray;
            this.txtResultHex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResultHex.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultHex.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtResultHex.Location = new System.Drawing.Point(40, 107);
            this.txtResultHex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResultHex.Name = "txtResultHex";
            this.txtResultHex.ReadOnly = true;
            this.txtResultHex.Size = new System.Drawing.Size(25, 20);
            this.txtResultHex.TabIndex = 3;
            this.txtResultHex.TabStop = false;
            this.txtResultHex.Text = "0";
            this.txtResultHex.TextChanged += new System.EventHandler(this.AdjustResultBoxToSizes);
            // 
            // txtResultBits
            // 
            this.txtResultBits.BackColor = System.Drawing.Color.DimGray;
            this.txtResultBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResultBits.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultBits.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtResultBits.Location = new System.Drawing.Point(40, 151);
            this.txtResultBits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResultBits.Name = "txtResultBits";
            this.txtResultBits.ReadOnly = true;
            this.txtResultBits.Size = new System.Drawing.Size(25, 20);
            this.txtResultBits.TabIndex = 4;
            this.txtResultBits.TabStop = false;
            this.txtResultBits.Text = "0";
            this.txtResultBits.TextChanged += new System.EventHandler(this.AdjustResultBoxToSizes);
            // 
            // lblMode
            // 
            this.lblMode.BackColor = System.Drawing.Color.Green;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(569, 16);
            this.lblMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(32, 30);
            this.lblMode.TabIndex = 6;
            this.lblMode.Text = "M";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(623, 198);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.txtResultBits);
            this.Controls.Add(this.txtResultHex);
            this.Controls.Add(this.txtResultDecimal);
            this.Controls.Add(this.txtInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtResultDecimal;
        private System.Windows.Forms.TextBox txtResultHex;
        private System.Windows.Forms.TextBox txtResultBits;
        private System.Windows.Forms.Label lblMode;
    }
}

