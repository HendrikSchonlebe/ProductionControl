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
    public partial class frmStartShift : Form
    {
        public System.Data.SqlClient.SqlConnection VPSConnection;
        public Int32 productionLineId;

        private String ErrorMessage = string.Empty;

        private PLINEData myPLine = new PLINEData();

        public frmStartShift()
        {
            InitializeComponent();
        }

        private void frmStartShift_Load(object sender, EventArgs e)
        {
            myPLine.myVPSConnection = VPSConnection;
            if (myPLine.Get_Production_Line(productionLineId) == true)
            {
                lblProductionLine.Text = myPLine.ProductionLineName.Trim();
                if (myPLine.Get_Line_Defaults() == true)
                {
                    dtpStarted.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + myPLine.DefaultStartTime.ToString());
                    dtpStarted.Focus();
                }

            }
        }

        private void frmStartShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                btnContinue_Click(sender, e);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

            myPLine.UtilisationLineId = productionLineId;
            myPLine.UtilisationWorkDayDate = DateTime.Now;
            myPLine.UtilisationLineStarted = dtpStarted.Value.TimeOfDay;
            myPLine.UtilisationLineStopped = myPLine.DefaultStopTime;
            if (myPLine.Insert_Utilisation_Record(trnEnvelope) == true)
            {
                trnEnvelope.Commit();
                this.DialogResult = DialogResult.Yes;
                this.Hide();
            }
            else
                trnEnvelope.Rollback();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void dtpStarted_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT 3}");
        }
    }
}
