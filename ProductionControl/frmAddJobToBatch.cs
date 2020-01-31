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
    public partial class frmAddJobToBatch : Form
    {
        public System.Data.SqlClient.SqlConnection VPSConnection;
        public Int32 productionLineId;
        public DataGridView dgProgress;

        private String ErrorMessage = string.Empty;

        private PLINEData myPLine = new PLINEData();
        private JOBData myJOBData = new JOBData();
        Boolean movedFromOtherLine = false;

        public frmAddJobToBatch()
        {
            InitializeComponent();
        }

        private void frmAddJobToBatch_Load(object sender, EventArgs e)
        {
            myPLine.myVPSConnection = VPSConnection;
            myJOBData.myVPSConnection = VPSConnection;
            cmbInsert.Items.Clear();
            cmbInsert.Items.Add("At the End of the Queue");
            for (int i = 0; i < dgProgress.Rows.Count; i++)
            {
                if (dgProgress.Rows[i].Cells["ProgressLoadStart"].Value.ToString() == "")
                    cmbInsert.Items.Add("Before Job # " + dgProgress.Rows[i].Cells["ProgressJobNumber"].Value.ToString());
            }
            cmbInsert.Text = cmbInsert.Items[0].ToString();
            txtJobDetails.Text = string.Empty;
            txtJobNumber.Text = string.Empty;
            btnAdd.Enabled = false;
            txtJobNumber.Focus();
        }
        private void frmAddJobToBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) & (btnAdd.Enabled == true))
                btnAdd_Click(sender, e);
            else if ((e.KeyCode == Keys.F2) | (e.KeyCode == Keys.Escape))
                btnCancel_Click(sender, e);
        }

        private void txtJobNumber_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtJobNumber_TextChanged(object sender, EventArgs e)
        { 
            if (txtJobNumber.Text.Trim().Length < 8)
            {
                txtJobDetails.Text = string.Empty;
                btnAdd.Enabled = false;
            }
        }
        private void txtJobNumber_Leave(object sender, EventArgs e)
        {
            String jobNumber = string.Empty;
            Boolean canMove = false;
            
            if (txtJobNumber.Text.Trim().Length > 0)
            {
                jobNumber = txtJobNumber.Text.Trim();
                if (jobNumber.Length < 8)
                    jobNumber = "J" + "0000000".Substring(0, 7- jobNumber.Length) + jobNumber;
                if (myJOBData.Get_Job(jobNumber, productionLineId) == true)
                {
                    if (myJOBData.Get_Progress_Record(myJOBData.JobId) == false)
                    {
                        txtJobNumber.Text = myJOBData.JobNumber;
                        txtJobDetails.Text = myJOBData.CustomerName;
                        txtJobDetails.Text = txtJobDetails.Text + "\r\n" + myJOBData.CustomerOrder;
                        txtJobDetails.Text = txtJobDetails.Text + "\r\n" + myJOBData.WorkOrderNumber;
                        txtJobDetails.Text = txtJobDetails.Text + "\r\n" + myJOBData.SupplierProductGroupCode + " / " + myJOBData.SupplierPaintProductCode;
                        txtJobDetails.Text = txtJobDetails.Text + "\r\n" + myJOBData.ColourName;
                        if (myJOBData.PaintSystemProcessCode != "0")
                        {
                            txtJobDetails.Text = txtJobDetails.Text + "\r\nMulti Coat Job - " + (Convert.ToInt32(myJOBData.PaintSystemProcessCode) + 1).ToString() + " Coats to be processed !";
                        }
                        btnAdd.Enabled = true;
                        btnCancel.Focus();
                    }
                    else if (myJOBData.ProgressCoats == 1)
                    {
                        btnAdd.Enabled = false;
                        if (myJOBData.ProductionLineId == productionLineId)
                            MessageBox.Show("** Operator **\r\n\r\nThis Job has already been queued on this Production Line !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtJobNumber.Text = string.Empty;
                        txtJobNumber.Focus();
                    }
                    else
                    {
                        if (myJOBData.Get_MultiCoat_Progress_Records(myJOBData.JobId) == myJOBData.ProgressCoats)
                        {
                            btnAdd.Enabled = false;
                            if (myJOBData.ProductionLineId == productionLineId)
                                MessageBox.Show("** Operator **\r\n\r\nThis Multi Coat Job has already been queued on this Production Line !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtJobNumber.Text = string.Empty;
                            txtJobNumber.Focus();
                        }
                        else
                        {
                            txtJobNumber.Text = myJOBData.JobNumber;
                            txtJobDetails.Text = myJOBData.CustomerName;
                            txtJobDetails.Text = txtJobDetails.Text + "\r\n" + myJOBData.CustomerOrder;
                            txtJobDetails.Text = txtJobDetails.Text + "\r\n" + myJOBData.WorkOrderNumber;
                            txtJobDetails.Text = txtJobDetails.Text + "\r\n" + myJOBData.SupplierProductGroupCode + " / " + myJOBData.SupplierPaintProductCode;
                            txtJobDetails.Text = txtJobDetails.Text + "\r\n" + myJOBData.ColourName;
                            txtJobDetails.Text = txtJobDetails.Text + "\r\nMulti Coat Job - " + ((Convert.ToInt32(myJOBData.PaintSystemProcessCode) + 1) - myJOBData.Get_MultiCoat_Progress_Records(myJOBData.JobId)).ToString() + " Coats of " + (Convert.ToInt32(myJOBData.PaintSystemProcessCode) + 1).ToString() + " to be processed !";
                            btnAdd.Enabled = true;
                            btnCancel.Focus();
                        }
                    }
                }
                else
                {
                    btnAdd.Enabled = false;
                    MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (myJOBData.ProductionLineId != productionLineId)
                    {
                        if (myJOBData.Get_Progress_Record(myJOBData.JobId) == false)
                        {
                            canMove = true;
                        }
                        else
                        {
                            if (myJOBData.ProgressLoadStart == DateTime.MinValue)
                                canMove = true;
                        }

                        if (canMove == true)
                        {
                            if (MessageBox.Show("Do you wish to move this Job to this Production Line ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                movedFromOtherLine = true;
                                btnAdd.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Job has already been started on another production Line and cannot be moved !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    txtJobNumber.Text = string.Empty;
                    txtJobNumber.Focus();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean isOk = true;
            Int32 multiCoatCount = 1;

            if (MessageBox.Show("Add this Job to the current Batch ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                System.Data.SqlClient.SqlTransaction  trnEnvelope = VPSConnection.BeginTransaction();

                if (movedFromOtherLine == true)
                {

                }
                else
                {
                    myJOBData.ProgressCoats = myJOBData.PaintSystemCoats;
                    //if (myJOBData.PaintSystemProcessCode == "1")
                    //    myJOBData.ProgressCoats = 2;
                    //else if (myJOBData.PaintSystemProcessCode == "2")
                    //    myJOBData.ProgressCoats = 3;
                    //else if (myJOBData.PaintSystemProcessCode == "3")
                    //    myJOBData.ProgressCoats = 4;
                    //else if (myJOBData.PaintSystemProcessCode == "4")
                    //    myJOBData.ProgressCoats = 5;

                    if (myJOBData.ProgressCoats > 1)
                        multiCoatCount = myJOBData.Get_MultiCoat_Progress_Records(myJOBData.JobId, trnEnvelope) + 1;

                    for (int i = multiCoatCount; i <= myJOBData.ProgressCoats; i++)
                    {
                        myJOBData.ProgressThisCoat = i;

                        if (myJOBData.Insert_Progress_Record(myJOBData.JobId, productionLineId, trnEnvelope) == true)
                        {
                            if (cmbInsert.Text != cmbInsert.Items[0].ToString())
                            {
                                // Job to be inserted in the list but not at the end
                                String[] followingJob = cmbInsert.Text.Split('#');
                                try
                                {
                                    // Get Job in front of which this Job is to be inserted
                                    DataTable myFollower = new DataTable();
                                    String strSQL = "SELECT * FROM Jobs WHERE JobNumber = '" + followingJob[1].Trim() + "'";
                                    System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, VPSConnection, trnEnvelope);
                                    System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                                    if (rdrGet.HasRows == true)
                                    {
                                        myFollower.Load(rdrGet);
                                    }
                                    else
                                    {
                                        isOk = false;
                                        break;
                                    }
                                    rdrGet.Close();
                                    cmdGet.Dispose();
                                    // Update this Job with Schedule Date & Sequence
                                    if (isOk == true)
                                    {
                                        if (myFollower.Rows.Count > 0)
                                        {
                                            strSQL = "UPDATE Jobs SET ScheduleDate = CONVERT(datetime, '" + Convert.ToDateTime(myFollower.Rows[0]["ScheduleDate"]).ToString() + "', 103), ";
                                            strSQL = strSQL + "ScheduleSeq = " + (Convert.ToInt32(myFollower.Rows[0]["ScheduleSeq"]) - 1).ToString() + " ";
                                            strSQL = strSQL + "WHERE JobId = " + myJOBData.JobId.ToString();
                                            System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand(strSQL, VPSConnection, trnEnvelope);
                                            cmdUpdate.ExecuteNonQuery();
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    isOk = false;
                                    break;
                                }
                            }

                        }
                        else
                        {
                            isOk = false;
                            break;
                        }
                    }

                    if (isOk == true)
                    {
                        trnEnvelope.Commit();
                        this.DialogResult = DialogResult.Yes;
                        this.Hide();
                    }
                    else
                    {
                        trnEnvelope.Rollback();
                        MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                txtJobNumber.Text = string.Empty;
                txtJobNumber.Focus();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Hide();
        }

    }
}
