﻿namespace ProductionControl
{
    partial class frmPartView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartView));
            this.pbPart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPart)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPart
            // 
            this.pbPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPart.Location = new System.Drawing.Point(0, 0);
            this.pbPart.Name = "pbPart";
            this.pbPart.Size = new System.Drawing.Size(800, 450);
            this.pbPart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPart.TabIndex = 0;
            this.pbPart.TabStop = false;
            // 
            // frmPartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbPart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPartView";
            this.Text = "frmPartView";
            this.Load += new System.EventHandler(this.frmPartView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPart;
    }
}