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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtResultDecimal = new System.Windows.Forms.TextBox();
            this.txtResultHex = new global::Calculator.NoSpaceCopyTextBox();
            this.txtResultBits = new global::Calculator.NoSpaceCopyTextBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblBinary = new System.Windows.Forms.Label();
            this.lblHexadecimal = new System.Windows.Forms.Label();
            this.lblDecimal = new System.Windows.Forms.Label();
            this.timer_bitTooltip = new System.Windows.Forms.Timer(this.components);
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.txtStore = new System.Windows.Forms.TextBox();
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
            // txtResultDecimal
            // 
            this.txtResultDecimal.BackColor = System.Drawing.Color.DimGray;
            this.txtResultDecimal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResultDecimal.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtResultDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultDecimal.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtResultDecimal.Location = new System.Drawing.Point(18, 53);
            this.txtResultDecimal.Name = "txtResultDecimal";
            this.txtResultDecimal.ReadOnly = true;
            this.txtResultDecimal.Size = new System.Drawing.Size(19, 19);
            this.txtResultDecimal.TabIndex = 2;
            this.txtResultDecimal.TabStop = false;
            this.txtResultDecimal.Text = "0";
            this.txtResultDecimal.TextChanged += new System.EventHandler(this.AdjustResultBoxToSizes);
            // 
            // txtResultHex
            // 
            this.txtResultHex.BackColor = System.Drawing.Color.DimGray;
            this.txtResultHex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResultHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultHex.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtResultHex.Location = new System.Drawing.Point(18, 87);
            this.txtResultHex.Name = "txtResultHex";
            this.txtResultHex.ReadOnly = true;
            this.txtResultHex.Size = new System.Drawing.Size(19, 19);
            this.txtResultHex.TabIndex = 3;
            this.txtResultHex.TabStop = false;
            this.txtResultHex.Text = "0";
            this.txtResultHex.TextChanged += new System.EventHandler(this.AdjustResultBoxToSizes);
            // 
            // txtResultBits
            // 
            this.txtResultBits.BackColor = System.Drawing.Color.DimGray;
            this.txtResultBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResultBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultBits.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtResultBits.Location = new System.Drawing.Point(18, 123);
            this.txtResultBits.Multiline = true;
            this.txtResultBits.Name = "txtResultBits";
            this.txtResultBits.ReadOnly = true;
            this.txtResultBits.Size = new System.Drawing.Size(421, 84);
            this.txtResultBits.TabIndex = 4;
            this.txtResultBits.TabStop = false;
            this.txtResultBits.Text = "0";
            this.txtResultBits.TextChanged += new System.EventHandler(this.AdjustResultBoxToSizes);
            this.txtResultBits.MouseLeave += new System.EventHandler(this.txtResultBits_MouseLeave);
            this.txtResultBits.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtResultBits_MouseMove);
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
            // lblBinary
            // 
            this.lblBinary.AutoSize = true;
            this.lblBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBinary.ForeColor = System.Drawing.Color.White;
            this.lblBinary.Location = new System.Drawing.Point(0, 128);
            this.lblBinary.Name = "lblBinary";
            this.lblBinary.Size = new System.Drawing.Size(15, 9);
            this.lblBinary.TabIndex = 7;
            this.lblBinary.Text = "bin";
            // 
            // lblHexadecimal
            // 
            this.lblHexadecimal.AutoSize = true;
            this.lblHexadecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHexadecimal.ForeColor = System.Drawing.Color.White;
            this.lblHexadecimal.Location = new System.Drawing.Point(0, 92);
            this.lblHexadecimal.Name = "lblHexadecimal";
            this.lblHexadecimal.Size = new System.Drawing.Size(17, 9);
            this.lblHexadecimal.TabIndex = 8;
            this.lblHexadecimal.Text = "hex";
            // 
            // lblDecimal
            // 
            this.lblDecimal.AutoSize = true;
            this.lblDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecimal.ForeColor = System.Drawing.Color.White;
            this.lblDecimal.Location = new System.Drawing.Point(0, 58);
            this.lblDecimal.Name = "lblDecimal";
            this.lblDecimal.Size = new System.Drawing.Size(17, 9);
            this.lblDecimal.TabIndex = 9;
            this.lblDecimal.Text = "dec";
            // 
            // timer_bitTooltip
            // 
            this.timer_bitTooltip.Tick += new System.EventHandler(this.timer_bitTooltip_Tick);
            // 
            // txtStore
            // 
            this.txtStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStore.BackColor = System.Drawing.Color.Silver;
            this.txtStore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStore.Location = new System.Drawing.Point(12, 36);
            this.txtStore.Name = "txtStore";
            this.txtStore.Size = new System.Drawing.Size(439, 26);
            this.txtStore.TabIndex = 10;
            this.txtStore.Visible = false;
            this.txtStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStore_KeyDown);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(467, 161);
            this.Controls.Add(this.txtStore);
            this.Controls.Add(this.lblDecimal);
            this.Controls.Add(this.lblHexadecimal);
            this.Controls.Add(this.lblBinary);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.txtResultBits);
            this.Controls.Add(this.txtResultHex);
            this.Controls.Add(this.txtResultDecimal);
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
        private System.Windows.Forms.TextBox txtResultDecimal;
        private NoSpaceCopyTextBox txtResultHex;
        private NoSpaceCopyTextBox txtResultBits;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblBinary;
        private System.Windows.Forms.Label lblHexadecimal;
        private System.Windows.Forms.Label lblDecimal;
        private System.Windows.Forms.Timer timer_bitTooltip;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.TextBox txtStore;
    }
}

