namespace ProductionControl
{
    partial class frmLabelItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgParts = new System.Windows.Forms.DataGridView();
            this.PartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThisLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgParts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgParts
            // 
            this.dgParts.AllowUserToAddRows = false;
            this.dgParts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgParts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartCode,
            this.PartDescription,
            this.Length,
            this.PartQty,
            this.ThisLabel});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgParts.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgParts.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgParts.Location = new System.Drawing.Point(0, 0);
            this.dgParts.Name = "dgParts";
            this.dgParts.ReadOnly = true;
            this.dgParts.Size = new System.Drawing.Size(1124, 408);
            this.dgParts.TabIndex = 1;
            this.dgParts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgParts_CellEndEdit);
            this.dgParts.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgParts_CellEnter);
            // 
            // PartCode
            // 
            this.PartCode.HeaderText = "Part Code";
            this.PartCode.Name = "PartCode";
            this.PartCode.ReadOnly = true;
            // 
            // PartDescription
            // 
            this.PartDescription.HeaderText = "Description";
            this.PartDescription.MinimumWidth = 650;
            this.PartDescription.Name = "PartDescription";
            this.PartDescription.ReadOnly = true;
            this.PartDescription.Width = 650;
            // 
            // Length
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.Length.DefaultCellStyle = dataGridViewCellStyle2;
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            // 
            // PartQty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.PartQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.PartQty.HeaderText = "Quantity";
            this.PartQty.Name = "PartQty";
            this.PartQty.ReadOnly = true;
            // 
            // ThisLabel
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ThisLabel.DefaultCellStyle = dataGridViewCellStyle4;
            this.ThisLabel.HeaderText = "This Set of Labels";
            this.ThisLabel.Name = "ThisLabel";
            this.ThisLabel.ReadOnly = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(0, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1124, 37);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLabelItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgParts);
            this.KeyPreview = true;
            this.Name = "frmLabelItems";
            this.Load += new System.EventHandler(this.frmLabelItems_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLabelItems_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgParts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dgParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThisLabel;
        private System.Windows.Forms.Button btnClose;
    }
}