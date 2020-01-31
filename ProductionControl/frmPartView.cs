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
    public partial class frmPartView : Form
    {
        public System.Data.SqlClient.SqlConnection myVPSConnection;
        public String myPartCode;

        private DataTable myPart = new DataTable();
        private Boolean abortDisplay = false;
        
        public frmPartView()
        {
            InitializeComponent();
        }

        private void frmPartView_Load(object sender, EventArgs e)
        {
            String errorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT * FROM Parts WHERE PartCode = '" + myPartCode + "'";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myPart.Load(rdrGet);
                }
                else
                {
                    errorMessage = "Part " + myPartCode + " not Found !";
                    abortDisplay = true;
                }
                rdrGet.Close();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                abortDisplay = true;
            }

            if (abortDisplay == false)
            {
                if (String.IsNullOrEmpty(myPart.Rows[0]["PartPicture"].ToString()) == false)
                {
                    System.IO.MemoryStream myStream = new System.IO.MemoryStream((byte []) myPart.Rows[0]["PartPicture"]);
                    pbPart.Image = Image.FromStream(myStream);
                }
                else
                {
                    MessageBox.Show("** Operator **\r\n\r\nNo Picture available !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("** Operator **\r\n\r\n" + errorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
