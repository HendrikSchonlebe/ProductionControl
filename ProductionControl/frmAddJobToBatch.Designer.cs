namespace ProductionControl
{
    partial class frmAddJobToBatch
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobDetails = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbInsert = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job Number";
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobNumber.Location = new System.Drawing.Point(164, 22);
            this.txtJobNumber.MaxLength = 8;
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(172, 29);
            this.txtJobNumber.TabIndex = 1;
            this.txtJobNumber.TextChanged += new System.EventHandler(this.txtJobNumber_TextChanged);
            this.txtJobNumber.Enter += new System.EventHandler(this.txtJobNumber_Enter);
            this.txtJobNumber.Leave += new System.EventHandler(this.txtJobNumber_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Job Details";
            // 
            // txtJobDetails
            // 
            this.txtJobDetails.BackColor = System.Drawing.SystemColors.Info;
            this.txtJobDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobDetails.Location = new System.Drawing.Point(26, 106);
            this.txtJobDetails.Multiline = true;
            this.txtJobDetails.Name = "txtJobDetails";
            this.txtJobDetails.ReadOnly = true;
            this.txtJobDetails.Size = new System.Drawing.Size(749, 263);
            this.txtJobDetails.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.LawnGreen;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(26, 448);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 58);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "F1-Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.Tomato;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(140, 448);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 58);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "F2-Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Insert";
            // 
            // cmbInsert
            // 
            this.cmbInsert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInsert.FormattingEnabled = true;
            this.cmbInsert.Location = new System.Drawing.Point(89, 393);
            this.cmbInsert.Name = "cmbInsert";
            this.cmbInsert.Size = new System.Drawing.Size(308, 28);
            this.cmbInsert.TabIndex = 7;
            // 
            // frmAddJobToBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.cmbInsert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtJobDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJobNumber);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frmAddJobToBatch";
            this.Text = "frmAddJobToBatch";
            this.Load += new System.EventHandler(this.frmAddJobToBatch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddJobToBatch_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJobDetails;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbInsert;
    }
}