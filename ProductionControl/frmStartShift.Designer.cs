namespace ProductionControl
{
    partial class frmStartShift
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
            this.lblProductionLine = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStarted = new System.Windows.Forms.DateTimePicker();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblProductionLine
            // 
            this.lblProductionLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductionLine.Location = new System.Drawing.Point(0, 0);
            this.lblProductionLine.Name = "lblProductionLine";
            this.lblProductionLine.Size = new System.Drawing.Size(533, 38);
            this.lblProductionLine.TabIndex = 0;
            this.lblProductionLine.Text = "label1";
            this.lblProductionLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Production Line Started at :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpStarted
            // 
            this.dtpStarted.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStarted.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStarted.Location = new System.Drawing.Point(306, 82);
            this.dtpStarted.Name = "dtpStarted";
            this.dtpStarted.ShowUpDown = true;
            this.dtpStarted.Size = new System.Drawing.Size(204, 26);
            this.dtpStarted.TabIndex = 2;
            this.dtpStarted.Enter += new System.EventHandler(this.dtpStarted_Enter);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Chartreuse;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(16, 151);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(115, 59);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "F1-Start";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Tomato;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(395, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 59);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Esc-Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmStartShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(533, 227);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.dtpStarted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProductionLine);
            this.KeyPreview = true;
            this.Name = "frmStartShift";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmStartShift_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStartShift_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProductionLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStarted;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnCancel;
    }
}