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
    public partial class frmProductionLine : Form
    {
        public System.Data.SqlClient.SqlConnection VPSConnection;
        public Int32 productionLineId;

        private String ErrorMessage = string.Empty;

        private Boolean isLoaded = false;
        private PLINEData myPLine = new PLINEData();
        private JOBData myJOBData = new JOBData();
        private WOData myWOData = new WOData();
        private String lineStatus = "00";

        public frmProductionLine()
        {
            InitializeComponent();
        }

        private void frmProductionLine_Load(object sender, EventArgs e)
        {
            myPLine.myVPSConnection = VPSConnection;
            myJOBData.myVPSConnection = VPSConnection;
            myWOData.myVPSConnection = VPSConnection;

            cmbProductionLine.Items.Clear();
            cmbProductionLine.Items.Add("1 - Aluminium Line");
            cmbProductionLine.Items.Add("2 - Steel Line");
            cmbProductionLine.Items.Add("3 - Batch Off Line");
            cmbProductionLine.Items.Add("9 - Vertikal Line");
            cmbProductionLine.Text = cmbProductionLine.Items[0].ToString();

            if (myPLine.Get_Production_Line(productionLineId) == true)
            {
                lblProductionLine.Text = myPLine.ProductionLineName;
                isLoaded = true;
                if (Refresh_Production_Line_Start_Finish() == true)
                    Refresh_Jobs_Grid();
                else
                    this.Close();
            }
            else
            {
                MessageBox.Show(myPLine.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void frmProductionLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnExit_Click(sender, e);
            else if ((e.KeyCode == Keys.F1) & (btnStartL.Visible == true) & (btnStartL.Enabled == true))
                btnStartL_Click(sender, e);
            else if ((e.KeyCode == Keys.F2) & (btnEndL.Visible == true) & (btnEndL.Enabled == true))
                btnEndL_Click(sender, e);
            else if ((e.KeyCode == Keys.F3) & (btnStartU.Visible == true) & (btnStartU.Enabled == true))
                btnStartU_Click(sender, e);
            else if ((e.KeyCode == Keys.F4) & (btnEndU.Visible == true) & (btnEndU.Enabled == true))
                btnEndU_Click(sender, e);
            else if ((e.KeyCode == Keys.F5) & (btnPrint.Visible == true) & (btnPrint.Enabled == true))
                btnPrint_Click(sender, e);
            else if ((e.KeyCode == Keys.F6) & (btnPacked.Visible == true) & (btnPacked.Enabled == true))
                btnPacked_Click(sender, e);
            else if ((e.KeyCode == Keys.F7) & (btnCancel.Visible == true) & (btnCancel.Enabled == true))
                btnCancel_Click(sender, e);
            else if (e.KeyCode == Keys.F1)
                btnLoad_Click(sender, e);
            else if (e.KeyCode == Keys.F2)
                btnAdd_Click(sender, e);
            else if ((e.KeyCode == Keys.F3) & (btnRemove.Visible == true))
                btnRemove_Click(sender, e);
        }

        private void dgJobs_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgJobs.CurrentRow != null)
            {
                if (dgJobs.CurrentRow.Index >= 0)
                {
                    if (e.KeyCode == Keys.Tab)
                        Show_Tasks_Panel();
                    else if (e.KeyCode == Keys.Insert)
                        btnAdd_Click(sender, e);
                    else if ((e.KeyCode == Keys.Delete) & (btnRemove.Visible == true))
                        btnRemove_Click(sender, e);
                }
            }
        }
        private void dgJobs_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgJobs.CurrentRow.Index >= 0)
                {
                    Show_Tasks_Panel();
                }
            }
        }
        private void dgJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgJobs.CurrentRow != null)
            {
                if (dgJobs.CurrentRow.Index >= 0)
                {
                    if (dgJobs.CurrentRow.Cells["ProgressLoadStart"].Value.ToString() != "")
                    {
                        btnRemove.Visible = false;
                    }
                    else
                    {
                        btnRemove.Visible = true;
                    }
                }
            }
        }

        private void Show_Tasks_Panel()
        {
            Boolean loadStarted = false;
            Boolean loadFinished = false;
            Boolean unloadStarted = false;
            Boolean unloadFinished = false;
            Boolean jobPacked = false;

            if (dgJobs.CurrentRow.Cells["ProgressLoadStart"].Value.ToString() != "")
                loadStarted = true;
            if (dgJobs.CurrentRow.Cells["FinishLoading"].Value.ToString() != "")
                loadFinished = true;
            if (dgJobs.CurrentRow.Cells["StartUnloading"].Value.ToString() != "")
                unloadStarted = true;
            if (dgJobs.CurrentRow.Cells["EndUnloading"].Value.ToString() != "")
                unloadFinished = true;
            jobPacked = Convert.ToBoolean(dgJobs.CurrentRow.Cells["Packed"].Value);

            if (loadStarted == false)
            {
                if (lineStatus.Substring(0, 1) == "1")
                {
                    MessageBox.Show("Another Job is still being loaded !");
                }
                else
                {
                    btnStartL.Text = "F1-Started Loading";
                    btnStartL.Visible = true;
                    btnEndL.Visible = false;
                    btnStartU.Visible = false;
                    btnEndU.Visible = false;
                    btnPrint.Visible = false;
                    btnPacked.Visible = false;
                    pnlTasks.Visible = true;
                }
            }
            if ((loadStarted == true) & (loadFinished == false))
            {
                btnStartL.Text = "F1-Cancel Loading";
                btnStartL.Visible = true;
                btnEndL.Visible = true;
                btnStartU.Visible = false;
                btnEndU.Visible = false;
                btnPrint.Visible = false;
                btnPacked.Visible = false;
                pnlTasks.Visible = true;
            }
            if ((loadStarted == true) & (loadFinished == true) & (unloadStarted == false))
            {
                if (lineStatus.Substring(1, 1) == "1")
                {
                    MessageBox.Show("Another Job is still being unloaded !");
                }
                else
                {
                    btnStartL.Visible = false;
                    btnEndL.Visible = false;
                    btnStartU.Text = "F3-Started Unloading";
                    btnStartU.Visible = true;
                    btnEndU.Visible = false;
                    btnPrint.Visible = false;
                    btnPacked.Visible = false;
                    pnlTasks.Visible = true;
                }
            }
            if ((loadStarted == true) & (loadFinished == true) & (unloadStarted == true) & (unloadFinished == false))
            {
                btnStartL.Visible = false;
                btnEndL.Visible = false;
                btnStartU.Text = "F3-Cancel Unloading";
                btnStartU.Visible = true;
                btnEndU.Visible = true;
                btnPrint.Visible = false;
                btnPacked.Visible = false;
                pnlTasks.Visible = true;
            }
            if ((loadStarted == true) & (loadFinished == true) & (unloadStarted == true) & (unloadFinished == true))
            {
                btnStartL.Visible = false;
                btnEndL.Visible = false;
                btnStartU.Visible = false;
                btnEndU.Visible = false;
                btnPrint.Visible = true;
                btnPacked.Visible = true;
                pnlTasks.Visible = true;
            }
        }

        private Boolean Refresh_Production_Line_Start_Finish()
        {
            Boolean isSuccessful = true;

            if (myPLine.Get_Utilisation_Record(productionLineId, DateTime.Now) == true)
            {
                dtpStarted.Value = Convert.ToDateTime(myPLine.UtilisationWorkDayDate.ToShortDateString() + " " + myPLine.UtilisationLineStarted.ToString());
                dtpStopped.Value = Convert.ToDateTime(myPLine.UtilisationWorkDayDate.ToShortDateString() + " " + myPLine.UtilisationLineStopped.ToString());
            }
            else
            {
                frmStartShift startShift = new frmStartShift();
                startShift.VPSConnection = VPSConnection;
                startShift.productionLineId = productionLineId;
                if (startShift.ShowDialog() == DialogResult.Yes)
                {
                    startShift.Close();
                    Refresh_Production_Line_Start_Finish();
                }
                else
                {
                    isSuccessful = false;
                    startShift.Close();
                    this.Close();
                }
            }

            return isSuccessful;
        }

        private void Refresh_Jobs_Grid()
        {
            double jobTotalArea = 0;

            if (myJOBData.Get_Unfinished_Jobs(productionLineId) == true)
            {
                lineStatus = "00";

                dgJobs.Rows.Clear();
                if (myJOBData.myJobsInProgress.Rows.Count > 0)
                {
                    for (int i = 0; i < myJOBData.myJobsInProgress.Rows.Count; i++)
                    {
                        if ((myJOBData.myJobsInProgress.Rows[i]["ProgressLoadStart"].ToString() != "") & (myJOBData.myJobsInProgress.Rows[i]["ProgressLoadEnd"].ToString() == ""))
                            lineStatus = "1" + lineStatus.Substring(1, 1);
                        if ((myJOBData.myJobsInProgress.Rows[i]["ProgressUnloadStart"].ToString() != "") & (myJOBData.myJobsInProgress.Rows[i]["ProgressUnloadEnd"].ToString() == ""))
                            lineStatus = lineStatus.Substring(0, 1) + "1";

                        jobTotalArea = myJOBData.Get_Job_Area(Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["JobId"]));

                        dgJobs.Rows.Add(Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["ProgressId"]),
                            Convert.ToDateTime(myJOBData.myJobsInProgress.Rows[i]["ScheduleDate"]),
                            myJOBData.myJobsInProgress.Rows[i]["JobNumber"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["CustomerName"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["WorkOrderNo"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["SupplierProductGroupCode"].ToString() + " / " + myJOBData.myJobsInProgress.Rows[i]["SupplierPaintProductCode"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["ColorName"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["PaintSystemCode"].ToString(),
                            jobTotalArea, 
                            myJOBData.myJobsInProgress.Rows[i]["ProgressLoadStart"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["ProgressLoadEnd"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["ProgressUnloadStart"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["ProgressUnloadEnd"].ToString(),
                            Convert.ToBoolean(myJOBData.myJobsInProgress.Rows[i]["ProgressPacked"])
                            );
                    }
                }
            }
            else
            {
                MessageBox.Show(myPLine.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (myJOBData.Get_Scheduled_Jobs(productionLineId, DateTime.Now.AddDays(3)) == true)
            {
                if (myJOBData.myScheduledJobs.Rows.Count > 0)
                {
                    for (int i = 0; i < myJOBData.myScheduledJobs.Rows.Count; i++)
                    {
                        System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();
                        if (myJOBData.Insert_Progress_Record(Convert.ToInt32(myJOBData.myScheduledJobs.Rows[i]["JobId"]), productionLineId, trnEnvelope) == true)
                            trnEnvelope.Commit();
                        else
                        {
                            trnEnvelope.Rollback();
                            MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    Refresh_Jobs_Grid();
                }
            }
            else
            {
                MessageBox.Show(myPLine.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddJobToBatch AddJob = new frmAddJobToBatch();
            AddJob.VPSConnection = VPSConnection;
            AddJob.productionLineId = productionLineId;
            AddJob.dgProgress = dgJobs;
            if (AddJob.ShowDialog() == DialogResult.Yes)
            {
                Refresh_Jobs_Grid();
            }
            AddJob.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("** Opereator **\r\n\r\nDo you really wish to remove Job # " + dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString() + " from this Production Batch ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

                if (myJOBData.Delete_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), trnEnvelope) == true)
                {
                    trnEnvelope.Commit();
                    Refresh_Jobs_Grid();
                }
                else
                {
                    trnEnvelope.Rollback();
                    MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ******** Task Buttons
        private void btnStartL_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();
            if (btnStartL.Text == "F1-Started Loading")
            {
                if (myJOBData.Update_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), DateTime.Now, 1, trnEnvelope, dtpStarted.Value, dtpStopped.Value) == true)
                {
                    if (myJOBData.Update_Job_Status(dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString(), "Started", DateTime.Now, trnEnvelope) == true)
                    {
                        if (myWOData.Update_Work_Order_Status(dgJobs.CurrentRow.Cells["WorkOrder"].Value.ToString(), "InProgress", trnEnvelope) == true)
                        {
                            trnEnvelope.Commit();
                            Refresh_Jobs_Grid();
                        }
                        else
                        {
                            trnEnvelope.Rollback();
                            MessageBox.Show(myWOData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        trnEnvelope.Rollback();
                        MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    trnEnvelope.Rollback();
                    MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (MessageBox.Show("** Operator **\r\n\r\nDo you really wish to cancel loading ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (myJOBData.Update_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), DateTime.Now, -1, trnEnvelope, dtpStarted.Value, dtpStopped.Value) == true)
                    {
                        if (myJOBData.Update_Job_Status(dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString(), "Open", DateTime.Now, trnEnvelope) == true)
                        {
                            if (myWOData.Update_Work_Order_Status(dgJobs.CurrentRow.Cells["WorkOrder"].Value.ToString(), "Open", trnEnvelope) == true)
                            {
                                trnEnvelope.Commit();
                                Refresh_Jobs_Grid();
                            }
                            else
                            {
                                trnEnvelope.Rollback();
                                MessageBox.Show(myWOData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            trnEnvelope.Rollback();
                            MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        trnEnvelope.Rollback();
                        MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            pnlTasks.Visible = false;
        }
        private void btnEndL_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

            if (myJOBData.Update_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), DateTime.Now, 2, trnEnvelope, dtpStarted.Value, dtpStopped.Value) == true)
            {
                trnEnvelope.Commit();
                Refresh_Jobs_Grid();
            }
            else
            {
                trnEnvelope.Rollback();
                MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pnlTasks.Visible = false;
        }
        private void btnStartU_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

            if (btnStartU.Text == "F3-Started Unloading")
            {
                if (myJOBData.Update_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), DateTime.Now, 3, trnEnvelope, dtpStarted.Value, dtpStopped.Value) == true)
                {
                    trnEnvelope.Commit();
                    Refresh_Jobs_Grid();
                }
                else
                {
                    trnEnvelope.Rollback();
                    MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (MessageBox.Show("** Operator **\r\n\r\nDo you really wish to cancel unloading ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (myJOBData.Update_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), DateTime.Now, -3, trnEnvelope, dtpStarted.Value, dtpStopped.Value) == true)
                    {
                        trnEnvelope.Commit();
                        Refresh_Jobs_Grid();
                    }
                    else
                    {
                        trnEnvelope.Rollback();
                        MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            pnlTasks.Visible = false;
        }
        private void btnEndU_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();
            if (myJOBData.Update_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), DateTime.Now, 4, trnEnvelope, dtpStarted.Value, dtpStopped.Value) == true)
            {
                trnEnvelope.Commit();
                Refresh_Jobs_Grid();
            }
            else
            {
                trnEnvelope.Rollback();
                MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pnlTasks.Visible = false;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmLabelPrint PrintLabels = new frmLabelPrint();
            PrintLabels.customerName = dgJobs.CurrentRow.Cells["Customer"].Value.ToString();
            PrintLabels.orderNumber = dgJobs.CurrentRow.Cells["WorkOrder"].Value.ToString();
            PrintLabels.jobNumber = dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString();
            PrintLabels.colourName = dgJobs.CurrentRow.Cells["ColourName"].Value.ToString();
            PrintLabels.ShowDialog();
            pnlTasks.Visible = false;
        }
        private void btnPacked_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();
            if (myJOBData.Update_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), DateTime.Now, 5, trnEnvelope, dtpStarted.Value, dtpStopped.Value) == true)
            {
                if (myJOBData.Update_Job_Status(dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString(), "Processed", DateTime.Now, trnEnvelope) == true)
                {
                    trnEnvelope.Commit();
                    Refresh_Jobs_Grid();
                }
                else
                {
                    trnEnvelope.Rollback();
                    MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                trnEnvelope.Rollback();
                MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pnlTasks.Visible = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlTasks.Visible = false;
        }

        private void cmbProductionLine_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isLoaded == true)
            {
                productionLineId = Convert.ToInt32(cmbProductionLine.Text.Substring(0, 1));

                if (myPLine.Get_Production_Line(productionLineId) == true)
                {
                    lblProductionLine.Text = myPLine.ProductionLineName;
                    Refresh_Production_Line_Start_Finish();
                    Refresh_Jobs_Grid();
                }
                else
                {
                    MessageBox.Show(myPLine.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
        private void dtpStopped_ValueChanged(object sender, EventArgs e)
        {
            myPLine.UtilisationLineStarted = dtpStarted.Value.TimeOfDay;
            myPLine.UtilisationLineStopped = dtpStopped.Value.TimeOfDay;

            System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

            if (myPLine.Update_Utilisation_Stop(productionLineId, DateTime.Now, trnEnvelope) == true)
                trnEnvelope.Commit();
            else
            {
                trnEnvelope.Rollback();
            }
        }
    }
}
