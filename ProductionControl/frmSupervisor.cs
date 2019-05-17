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
    public partial class frmSupervisor : Form
    {
        public System.Data.SqlClient.SqlConnection VPSConnection;

        private String ErrorMessage = string.Empty;

        private PLINEData myPLine = new PLINEData();
        private JOBData myJOBData = new JOBData();
        private String lineStatus = "00";

        public frmSupervisor()
        {
            InitializeComponent();
        }

        private void frmSupervisor_Load(object sender, EventArgs e)
        {
            myPLine.myVPSConnection = VPSConnection;
            myJOBData.myVPSConnection = VPSConnection;

            if (myPLine.Get_Production_Lines() == true)
            {
                tbcLines.ItemSize = new Size(400, 50);
                tbcLines.SizeMode = TabSizeMode.Fixed;
                tbcLines.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);

                for (int i = 0; i < myPLine.ProductionLines.Rows.Count; i++)
                {
                    if (i > 1)
                        tbcLines.TabPages.Add(myPLine.ProductionLines.Rows[i]["Description"].ToString());
                    else
                        tbcLines.TabPages[i].Text = myPLine.ProductionLines.Rows[i]["Description"].ToString();
                }
            }
            else
            {
                MessageBox.Show(myPLine.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
        private void frmSupervisor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
