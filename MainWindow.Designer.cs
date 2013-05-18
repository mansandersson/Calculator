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
            this.lblResultDecimal = new System.Windows.Forms.TextBox();
            this.lblResultHex = new System.Windows.Forms.TextBox();
            this.lblResultBits = new System.Windows.Forms.TextBox();
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
            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(418, 26);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // lblResultDecimal
            // 
            this.lblResultDecimal.BackColor = System.Drawing.Color.DimGray;
            this.lblResultDecimal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblResultDecimal.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblResultDecimal.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultDecimal.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblResultDecimal.Location = new System.Drawing.Point(30, 53);
            this.lblResultDecimal.Name = "lblResultDecimal";
            this.lblResultDecimal.ReadOnly = true;
            this.lblResultDecimal.Size = new System.Drawing.Size(19, 16);
            this.lblResultDecimal.TabIndex = 2;
            this.lblResultDecimal.TabStop = false;
            this.lblResultDecimal.Text = "0";
            this.lblResultDecimal.TextChanged += new System.EventHandler(this.AdjustResultBoxToSizes);
            // 
            // lblResultHex
            // 
            this.lblResultHex.BackColor = System.Drawing.Color.DimGray;
            this.lblResultHex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblResultHex.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultHex.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblResultHex.Location = new System.Drawing.Point(30, 87);
            this.lblResultHex.Name = "lblResultHex";
            this.lblResultHex.ReadOnly = true;
            this.lblResultHex.Size = new System.Drawing.Size(19, 16);
            this.lblResultHex.TabIndex = 3;
            this.lblResultHex.TabStop = false;
            this.lblResultHex.Text = "0";
            this.lblResultHex.TextChanged += new System.EventHandler(this.AdjustResultBoxToSizes);
            // 
            // lblResultBits
            // 
            this.lblResultBits.BackColor = System.Drawing.Color.DimGray;
            this.lblResultBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblResultBits.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultBits.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblResultBits.Location = new System.Drawing.Point(30, 123);
            this.lblResultBits.Name = "lblResultBits";
            this.lblResultBits.ReadOnly = true;
            this.lblResultBits.Size = new System.Drawing.Size(19, 16);
            this.lblResultBits.TabIndex = 4;
            this.lblResultBits.TabStop = false;
            this.lblResultBits.Text = "0";
            this.lblResultBits.TextChanged += new System.EventHandler(this.AdjustResultBoxToSizes);
            // 
            // lblMode
            // 
            this.lblMode.BackColor = System.Drawing.Color.Green;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(427, 13);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(24, 24);
            this.lblMode.TabIndex = 6;
            this.lblMode.Text = "M";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(467, 161);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblResultBits);
            this.Controls.Add(this.lblResultHex);
            this.Controls.Add(this.lblResultDecimal);
            this.Controls.Add(this.txtInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox lblResultDecimal;
        private System.Windows.Forms.TextBox lblResultHex;
        private System.Windows.Forms.TextBox lblResultBits;
        private System.Windows.Forms.Label lblMode;
    }
}

