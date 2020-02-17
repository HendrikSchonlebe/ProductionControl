namespace ProductionControl
{
    partial class frmLabelPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabelPrint));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nupdnCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJobDetails = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label Format";
            // 
            // cmbFormat
            // 
            this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(206, 172);
            this.cmbFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(444, 28);
            this.cmbFormat.TabIndex = 1;
            this.cmbFormat.SelectedValueChanged += new System.EventHandler(this.cmbFormat_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Labels";
            // 
            // nupdnCount
            // 
            this.nupdnCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupdnCount.Location = new System.Drawing.Point(206, 211);
            this.nupdnCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nupdnCount.Name = "nupdnCount";
            this.nupdnCount.Size = new System.Drawing.Size(69, 26);
            this.nupdnCount.TabIndex = 4;
            this.nupdnCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupdnCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupdnCount.ValueChanged += new System.EventHandler(this.nupdnCount_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Job Details";
            // 
            // txtJobDetails
            // 
            this.txtJobDetails.BackColor = System.Drawing.SystemColors.Info;
            this.txtJobDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobDetails.Location = new System.Drawing.Point(130, 11);
            this.txtJobDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtJobDetails.Multiline = true;
            this.txtJobDetails.Name = "txtJobDetails";
            this.txtJobDetails.ReadOnly = true;
            this.txtJobDetails.Size = new System.Drawing.Size(520, 142);
            this.txtJobDetails.TabIndex = 6;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.Color.PaleGreen;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(135, 285);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(111, 56);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "F2-Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.MistyRose;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(539, 285);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(111, 56);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Esc-Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnItems
            // 
            this.btnItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnItems.BackColor = System.Drawing.Color.AliceBlue;
            this.btnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.Location = new System.Drawing.Point(18, 285);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(111, 56);
            this.btnItems.TabIndex = 9;
            this.btnItems.Text = "F1-Items";
            this.btnItems.UseVisualStyleBackColor = false;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // frmLabelPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 353);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtJobDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nupdnCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFormat);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLabelPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmLabelPrint";
            this.Load += new System.EventHandler(this.frmLabelPrint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLabelPrint_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.nupdnCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupdnCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJobDetails;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnItems;
    }
}