using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductionControl
{
    public partial class frmLabelPrint : Form
    {
        public String customerName;
        public String orderNumber;
        public String jobNumber;
        public String colourName;

        public frmLabelPrint()
        {
            InitializeComponent();
        }

        private void frmLabelPrint_Load(object sender, EventArgs e)
        {
            this.Text = "VPS - Production Line Packing Label Print";
            txtJobDetails.Text = "Customer : " + customerName + "\r\nOrder # : " + orderNumber + "\r\nJob # : " + jobNumber + "\r\nColour : " + colourName;
            cmbFormat.Items.Clear();
            cmbFormat.Items.Add("1 - Basic Label");
            cmbFormat.Text = cmbFormat.Items[0].ToString();
            nupdnCount.Value = 1;
            nupdnCount.Focus();
        }

        private void frmLabelPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) & (btnPrint.Visible == true))
                btnPrint_Click(sender, e);
            else if (e.KeyCode == Keys.Escape)
                btnExit_Click(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nupdnCount_ValueChanged(object sender, EventArgs e)
        {
            if (nupdnCount.Value > 0)
                btnPrint.Visible = true;
            else
                btnPrint.Visible = false;
        }
    }
}
