using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductionControl
{
    public partial class frmProductionLine : Form
    {
        public System.Data.SqlClient.SqlConnection VPSConnection;
        public Int32 productionLineId;
        public Boolean viewOnly;
        public Boolean supervisorMode;
        public String labelPrinterName;

        private String ErrorMessage = string.Empty;

        private Boolean isLoaded = false;
        private PLINEData myPLine = new PLINEData();
        private JOBData myJOBData = new JOBData();
        private WOData myWOData = new WOData();
        private String lineStatus = "00";
        private DateTime currentStart = DateTime.Now;
        private String SourceEmailAddress = string.Empty;
        private String CustomerServicesEmailAddress = string.Empty;
        private String ProductionEmailAddress = string.Empty;
        private String SMTPHostName = string.Empty;
        private Int32 SMTPPort = 25;
        private Int32 currentProgressRecord = -1;
        private DateTime loadStart;
        private DateTime loadFinish;
        private DateTime unloadStart;
        private DateTime unloadFinish;

        public frmProductionLine()
        {
            InitializeComponent();
        }

        private void frmProductionLine_Load(object sender, EventArgs e)
        {
            this.Text = "VPS Production Line Control Monitor - " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            myPLine.myVPSConnection = VPSConnection;
            myJOBData.myVPSConnection = VPSConnection;
            myWOData.myVPSConnection = VPSConnection;

            Get_Control_Data();

            cmbProductionLine.Items.Clear();
            cmbProductionLine.Items.Add("1 - Aluminium Line");
            cmbProductionLine.Items.Add("2 - Steel Line");
            cmbProductionLine.Items.Add("3 - Batch Off Line");
            cmbProductionLine.Items.Add("9 - Vertikal Line");
            cmbProductionLine.Text = cmbProductionLine.Items[0].ToString();

            if (myPLine.Get_Production_Line(productionLineId) == true)
            {
                lblProductionLine.Text = myPLine.ProductionLineName;
                for (int i = 0; i < cmbProductionLine.Items.Count; i++)
                {
                    if (cmbProductionLine.Items[i].ToString().Substring(0, 1) == productionLineId.ToString().Trim())
                    {
                        cmbProductionLine.Text = cmbProductionLine.Items[i].ToString();
                        break;
                    }
                }
                isLoaded = true;
                myTimer.Enabled = true;
                if (viewOnly == false)
                {
                    myTimer.Interval = 300000;
                    btnRefresh.Visible = true;
                    if (Refresh_Production_Line_Start_Finish(true) == true)
                    {
                        currentStart = dtpStarted.Value;
                        if (pnlTasks.Visible == false)
                            Refresh_Jobs_Grid();
                    }
                    else
                        this.Close();
                }
                else
                {
                    myTimer.Interval = 60000;
                    btnRefresh.Visible = false;
                    Refresh_Production_Line_Start_Finish(false);
                    dtpStarted.Enabled = false;
                    dtpStopped.Enabled = false;
                    Refresh_Jobs_Grid();
                }
                btnLoad.Visible = !viewOnly;
                btnAdd.Visible = !viewOnly;
                btnRemove.Visible = !viewOnly;
            }
            else
            {
                MessageBox.Show(myPLine.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
        private Boolean Get_Control_Data()
        {
            Boolean isSuccessful = true;

            try
            {
                String strSQL = "SELECT * FROM SystemDefaults";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, VPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    DataTable myControl = new DataTable();
                    myControl.Load(rdrGet);

                    SourceEmailAddress = myControl.Rows[0]["SourceEmailAddress"].ToString();
                    ProductionEmailAddress = myControl.Rows[0]["productionEmailAddress"].ToString();
                    CustomerServicesEmailAddress = myControl.Rows[0]["customerServiceEmailAddress"].ToString();
                    SMTPHostName = myControl.Rows[0]["SMTPServer"].ToString();
                    SMTPPort = Convert.ToInt32(myControl.Rows[0]["SMTPPort"]);

                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isSuccessful;
        }
        private void frmProductionLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (viewOnly == false)
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
                else if ((e.KeyCode == Keys.F4) & (btnEndU.Visible == false))
                    btnRefresh_Click(sender, e);
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                    btnExit_Click(sender, e);
            }
        }
        private void dgJobs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgJobs.Rows[e.RowIndex].Cells["PaintSystem"].Value.ToString().Contains("(") == true)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }
        }
        private void dgJobs_KeyDown(object sender, KeyEventArgs e)
        {
            if (viewOnly == false)
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
        }
        private void dgJobs_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Display Parts on this Job
                    if (myJOBData.Get_Job(dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString(), productionLineId) == true)
                    {
                        if (myJOBData.Get_Job_Details(myJOBData.JobId) == true)
                        {
                            dgParts.Rows.Clear();
                            for (int i = 0; i < myJOBData.myJobDetails.Rows.Count; i++)
                            {
                                String[] thisPart = myJOBData.myJobDetails.Rows[i]["PartDescription"].ToString().Split('*');
                                String pictureButton = string.Empty;
                                if (string.IsNullOrEmpty(myJOBData.myJobDetails.Rows[i]["PartPicture"].ToString()) == false)
                                    pictureButton = "<View Part>";
                                dgParts.Rows.Add(myJOBData.myJobDetails.Rows[i]["PartCode"].ToString(), thisPart[0].Trim(), Convert.ToInt32(myJOBData.myJobDetails.Rows[i]["Qty"]), pictureButton);
                            }
                            pnlParts.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void dgJobs_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (viewOnly == false)
            {
                if (e.RowIndex >= 0)
                {
                    if (dgJobs.CurrentRow.Index >= 0)
                    {
                        Show_Tasks_Panel();
                    }
                }
            }
            else
            {
                if (Convert.ToBoolean(dgJobs.CurrentRow.Cells["Packed"].Value) == true)
                {
                    if (MessageBox.Show("Has Paperwork been received and checked ?\r\n\r\nHas Job production been completed ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

                        if (myJOBData.Update_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), DateTime.Now, 7, trnEnvelope, dtpStarted.Value, dtpStopped.Value) == true)
                        {
                            trnEnvelope.Commit();
                            dgJobs.Rows.Remove(dgJobs.CurrentRow);
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
                    if (supervisorMode == true)
                    {
                        if (e.RowIndex >= 0)
                        {
                            if (dgJobs.CurrentRow.Index >= 0)
                            {
                                Show_Cheat_Panel();
                            }
                        }
                    }
                }
            }
        }
        private void dgJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (viewOnly == false)
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
        }

        private Boolean Multi_Coat_Sequence(String jobNumber, Int32 coatNumber)
        {
            Boolean isOk = true;

            if (coatNumber > 1)
            {
                if (myJOBData.Get_Job(jobNumber, productionLineId) == true)
                {
                    DataTable myRecord = new DataTable();
                    String strSQL = "SELECT * FROM JobProgress WHERE ProgressJobId = " + myJOBData.JobId.ToString() + " AND ProgressThisCoat = " + (coatNumber - 1).ToString();
                    System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myJOBData.myVPSConnection);
                    System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                    if (rdrGet.HasRows == true)
                    {
                        myRecord.Load(rdrGet);
                        if (string.IsNullOrEmpty(myRecord.Rows[0]["ProgressUnloadEnd"].ToString()) == true)
                        {
                            isOk = false;
                            MessageBox.Show("Job : " + jobNumber + " Previous Coat Processing has not been completed !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        isOk = false;
                        MessageBox.Show("Job : " + jobNumber + " Progress Record not found !\r\n\r\nMulti Coat Job - Step is out of Sequence !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    rdrGet.Close();
                    cmdGet.Dispose();
                }
                else
                {
                    isOk = false;
                    MessageBox.Show("Job : " + jobNumber + " not found !\r\n\r\nMulti Coat Job - Step is out of Sequence !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isOk;
        }
        private void Show_Cheat_Panel()
        {
            currentProgressRecord = Convert.ToInt32(dgJobs.CurrentRow.Cells["ProgressId"].Value);

            txtWorkOrder.Text = dgJobs.CurrentRow.Cells["WorkOrder"].Value.ToString();
            txtJob.Text = dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString();
            txtProduct.Text = dgJobs.CurrentRow.Cells["Product"].Value.ToString();
            txtColour.Text = dgJobs.CurrentRow.Cells["ColourName"].Value.ToString();
            txtCustomer.Text = dgJobs.CurrentRow.Cells["Customer"].Value.ToString();
            txtOrderNumber.Text = dgJobs.CurrentRow.Cells["CustomerRef"].Value.ToString();
            txtPaintSystem.Text = dgJobs.CurrentRow.Cells["PaintSystem"].Value.ToString();
            txtAP.Text = dgJobs.CurrentRow.Cells["AP"].Value.ToString();
            txtCP.Text = dgJobs.CurrentRow.Cells["Area"].Value.ToString();
            if (dgJobs.CurrentRow.Cells["ProgressLoadStart"].Value.ToString().Trim().Length > 0)
                dtpStartLoading.Value = Convert.ToDateTime(dgJobs.CurrentRow.Cells["ProgressLoadStart"].Value);
            else
                dtpStartLoading.Value = DateTime.Now;
            if (dgJobs.CurrentRow.Cells["FinishLoading"].Value.ToString().Trim().Length > 0)
                dtpFinishLoading.Value = Convert.ToDateTime(dgJobs.CurrentRow.Cells["FinishLoading"].Value);
            else
                dtpFinishLoading.Value = DateTime.Now;
            if (dgJobs.CurrentRow.Cells["StartUnloading"].Value.ToString().Trim().Length > 0)
                dtpStartUnloading.Value = Convert.ToDateTime(dgJobs.CurrentRow.Cells["StartUnloading"].Value);
            else
                dtpStartUnloading.Value = DateTime.Now;
            if (dgJobs.CurrentRow.Cells["EndUnloading"].Value.ToString().Trim().Length > 0)
                dtpFinishUnloading.Value = Convert.ToDateTime(dgJobs.CurrentRow.Cells["EndUnloading"].Value);
            else
                dtpFinishUnloading.Value = DateTime.Now;
            chkPacked.Checked = Convert.ToBoolean(dgJobs.CurrentRow.Cells["Packed"].Value);
            txtDeferral.Text = string.Empty;
            btnDefer.Enabled = false;

            pnlCheat.Visible = true;
        }
        private void Show_Tasks_Panel()
        {
            Boolean loadStarted = false;
            Boolean loadFinished = false;
            Boolean unloadStarted = false;
            Boolean unloadFinished = false;
            Boolean jobPacked = false;
            Boolean canContinue = true;

            // Test for Multi Coat Job
            if (Convert.ToInt32(dgJobs.CurrentRow.Cells["Coats"].Value) > 1)
            {
                canContinue = Multi_Coat_Sequence(dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString(), Convert.ToInt32(dgJobs.CurrentRow.Cells["ThisCoat"].Value));
            }

            if (canContinue == true)
            {
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
                    btnPrint.Visible = true;
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
                if ((loadStarted == true) & (loadFinished == true) & (unloadStarted == true) & (unloadFinished == true) & (jobPacked == true))
                {
                    btnStartL.Visible = false;
                    btnEndL.Visible = false;
                    btnStartU.Visible = false;
                    btnEndU.Visible = false;
                    btnPrint.Visible = true;
                    btnPacked.Visible = false;
                    pnlTasks.Visible = true;
                }
            }
        }

        private Boolean Refresh_Production_Line_Start_Finish(Boolean setDateTime)
        {
            Boolean isSuccessful = true;

            if (myPLine.Get_Utilisation_Record(productionLineId, DateTime.Now) == true)
            {
                dtpStarted.Value = Convert.ToDateTime(myPLine.UtilisationWorkDayDate.ToShortDateString() + " " + myPLine.UtilisationLineStarted.ToString());
                dtpStopped.Value = Convert.ToDateTime(myPLine.UtilisationWorkDayDate.ToShortDateString() + " " + myPLine.UtilisationLineStopped.ToString());
            }
            else
            {
                if (setDateTime == true)
                {
                    frmStartShift startShift = new frmStartShift();
                    startShift.VPSConnection = VPSConnection;
                    startShift.productionLineId = productionLineId;
                    if (startShift.ShowDialog() == DialogResult.Yes)
                    {
                        startShift.Close();
                        Refresh_Production_Line_Start_Finish(setDateTime);
                    }
                    else
                    {
                        isSuccessful = false;
                        startShift.Close();
                        this.Close();
                    }
                }
            }

            return isSuccessful;
        }

        private void Refresh_Jobs_Grid()
        {
            Double jobTotalAreaPP = 0;
            Double jobTotalAreaAP = 0;
            String multiCoat = string.Empty;
            String ColourName = string.Empty;
            String PaintProduct = string.Empty;
            Int32 jobEstTime = 0;

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

                        jobTotalAreaPP = myJOBData.Get_Job_Area(Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["JobId"]), "PP");
                        jobTotalAreaAP = myJOBData.Get_Job_Area(Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["JobId"]), "AP");
                        jobEstTime = myJOBData.Job_Estimated_Time(Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["JobId"]));

                        if (Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["ProgressCoats"]) > 1)
                        {
                            multiCoat = "(" + Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["ProgressThisCoat"]).ToString() + ")";
                            if (Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["ProgressThisCoat"]) == Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["ProgressCoats"]))
                            {
                                PaintProduct = myJOBData.myJobsInProgress.Rows[i]["SupplierProductGroupCode"].ToString() + " / " + myJOBData.myJobsInProgress.Rows[i]["SupplierPaintProductCode"].ToString();
                                ColourName = myJOBData.myJobsInProgress.Rows[i]["ColorName"].ToString();
                            }
                            else
                            {
                                try
                                {
                                    String primerRecord = myJOBData.MultiCoat_PaintProduct(Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["ProgressThisCoat"]), Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["WorkOrderId"]));
                                    String[] paintUsed = primerRecord.Split(',');
                                    PaintProduct = paintUsed[0] + " / " + paintUsed[1];
                                    ColourName = paintUsed[2];
                                }
                                catch (Exception ex)
                                {
                                    ColourName = "Primer ?";
                                }
                            }
                        }
                        else
                        {
                            PaintProduct = myJOBData.myJobsInProgress.Rows[i]["SupplierProductGroupCode"].ToString() + " / " + myJOBData.myJobsInProgress.Rows[i]["SupplierPaintProductCode"].ToString();
                            ColourName = myJOBData.myJobsInProgress.Rows[i]["ColorName"].ToString();
                            multiCoat = string.Empty;
                        }

                        String myCustomerName = string.Empty;
                        if (myWOData.Get_WorkOrder(Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["WorkOrderId"])) == true)
                            myCustomerName = myWOData.CustomerName;

                        dgJobs.Rows.Add(Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["ProgressId"]),
                            Convert.ToDateTime(myJOBData.myJobsInProgress.Rows[i]["ScheduleDate"]),
                            myJOBData.myJobsInProgress.Rows[i]["JobNumber"].ToString(),
                            myCustomerName,
                            myJOBData.myJobsInProgress.Rows[i]["WorkOrderNo"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["CustomerRef"].ToString(),
                            PaintProduct,
                            ColourName,
                            myJOBData.myJobsInProgress.Rows[i]["PaintSystemCode"].ToString() + multiCoat,
                            jobTotalAreaAP,
                            jobTotalAreaPP,
                            jobEstTime,
                            myJOBData.myJobsInProgress.Rows[i]["ProgressLoadStart"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["ProgressLoadEnd"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["ProgressUnloadStart"].ToString(),
                            myJOBData.myJobsInProgress.Rows[i]["ProgressUnloadEnd"].ToString(),
                            Convert.ToBoolean(myJOBData.myJobsInProgress.Rows[i]["ProgressPacked"]),
                            Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["ProgressCoats"]),
                            Convert.ToInt32(myJOBData.myJobsInProgress.Rows[i]["ProgressThisCoat"])
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
            // Multi Coat Jobs
            Add_Multicoat_Batch(false);
            // Single Coat Jobs
            Add_Singlecoat_Batch(false);

            Refresh_Jobs_Grid();
        }
        private void Add_Multicoat_Batch(Boolean isAuto)
        {
            if (myJOBData.Get_Scheduled_MultiCoat_Jobs(productionLineId, DateTime.Now.AddDays(3)) == true)
            {
                Int32 multiCoatCount = 1;

                for (int i = 0; i < myJOBData.myScheduledJobs.Rows.Count; i++)
                {
                    Boolean isOk = true;

                    System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

                    myJOBData.ProgressCoats = Convert.ToInt32(myJOBData.myScheduledJobs.Rows[i]["process_coats"]);

                    if (myJOBData.ProgressCoats > 1)
                        multiCoatCount = myJOBData.Get_MultiCoat_Progress_Records(Convert.ToInt32(myJOBData.myScheduledJobs.Rows[i]["JobId"]), trnEnvelope) + 1;

                    for (int j = multiCoatCount; j <= myJOBData.ProgressCoats; j++)
                    {
                        myJOBData.ProgressThisCoat = j;
                        if (myJOBData.Insert_Progress_Record(Convert.ToInt32(myJOBData.myScheduledJobs.Rows[i]["JobId"]), productionLineId, trnEnvelope) == false)
                        {
                            isOk = false;
                            trnEnvelope.Rollback();
                            if (isAuto == false)
                                MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (isOk == true)
                        trnEnvelope.Commit();
                }
            }
        }
        private void Add_Singlecoat_Batch(Boolean isAuto)
        {
            if (myJOBData.Get_Scheduled_Jobs(productionLineId, DateTime.Now.AddDays(3)) == true)
            {
                if (myJOBData.myScheduledJobs.Rows.Count > 0)
                {
                    for (int i = 0; i < myJOBData.myScheduledJobs.Rows.Count; i++)
                    {
                        System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

                        myJOBData.ProgressCoats = 1;
                        myJOBData.ProgressThisCoat = 1;
                        if (myJOBData.Insert_Progress_Record(Convert.ToInt32(myJOBData.myScheduledJobs.Rows[i]["JobId"]), productionLineId, trnEnvelope) == false)
                        {
                            trnEnvelope.Rollback();
                            if (isAuto == false)
                                MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        trnEnvelope.Commit();
                    }
                }
            }
            else
            {
                if (isAuto == false)
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
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh_Jobs_Grid();
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
                            // Refresh_Jobs_Grid();
                            dgJobs.CurrentRow.Cells["ProgressLoadStart"].Value = DateTime.Now;
                            lineStatus = "1" + lineStatus.Substring(1, 1);
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
                                // Refresh_Jobs_Grid();
                                dgJobs.CurrentRow.Cells["ProgressLoadStart"].Value = "";
                                lineStatus = "0" + lineStatus.Substring(1, 1);
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
                // Refresh_Jobs_Grid();
                dgJobs.CurrentRow.Cells["FinishLoading"].Value = DateTime.Now;
                lineStatus = "0" + lineStatus.Substring(1, 1);
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
                    // Refresh_Jobs_Grid();
                    dgJobs.CurrentRow.Cells["StartUnloading"].Value = DateTime.Now;
                    lineStatus = lineStatus.Substring(0, 1) + "1";
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
                        // Refresh_Jobs_Grid();
                        dgJobs.CurrentRow.Cells["StartUnloading"].Value = "";
                        lineStatus = lineStatus.Substring(0, 1) + "0";
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
            Int32 progressUpdateCode = 4;

            System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

            // Test if this is a multi coat primer
            if (Convert.ToInt32(dgJobs.CurrentRow.Cells["ThisCoat"].Value) < Convert.ToInt32(dgJobs.CurrentRow.Cells["Coats"].Value))
                progressUpdateCode = 6;

            if (myJOBData.Update_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), DateTime.Now, progressUpdateCode, trnEnvelope, dtpStarted.Value, dtpStopped.Value) == true)
            {
                if (progressUpdateCode == 4)
                {
                    if (myJOBData.Update_Job_Status(dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString(), "Processed", DateTime.Now, trnEnvelope) == true)
                    {
                        trnEnvelope.Commit();
                        // Refresh_Jobs_Grid();
                        dgJobs.CurrentRow.Cells["EndUnloading"].Value = DateTime.Now;
                        lineStatus = lineStatus.Substring(0, 1) + "0";
                    }
                    else
                    {
                        trnEnvelope.Rollback();
                        MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    trnEnvelope.Commit();
                    Refresh_Jobs_Grid();
                }
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
            if (myJOBData.Get_Job(dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString(), productionLineId) == true)
            {
                String currentCustomer = dgJobs.CurrentRow.Cells["Customer"].Value.ToString().Trim();

                if (dgJobs.CurrentRow.Cells["Customer"].Value.ToString().ToUpper().Contains("CASH SALE") == true)
                {
                    String[] thisCustomer = dgJobs.CurrentRow.Cells["Customer"].Value.ToString().Split('-');
                    currentCustomer = thisCustomer[0].Trim();
                }

                frmLabelSelect PackingLabels = new frmLabelSelect();
                PackingLabels.myJobData = myJOBData;
                PackingLabels.customerName = currentCustomer;
                PackingLabels.orderNumber = dgJobs.CurrentRow.Cells["WorkOrder"].Value.ToString();
                PackingLabels.jobNumber = dgJobs.CurrentRow.Cells["ProgressJobNumber"].Value.ToString();
                PackingLabels.colourName = dgJobs.CurrentRow.Cells["Product"].Value.ToString() + " " + dgJobs.CurrentRow.Cells["ColourName"].Value.ToString();
                PackingLabels.customerOrder = myJOBData.CustomerOrder;
                PackingLabels.labelPrinterName = labelPrinterName;
                PackingLabels.productionLineId = productionLineId;
                PackingLabels.ShowDialog();
                pnlTasks.Visible = false;

            }
            else
            {
                MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPacked_Click(object sender, EventArgs e)
        {
            btnPacked.Visible = false;
            this.Cursor = Cursors.WaitCursor;
            System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();
            if (myJOBData.Update_Progress_Record(Convert.ToInt32(dgJobs.CurrentRow.Cells[0].Value), DateTime.Now, 5, trnEnvelope, dtpStarted.Value, dtpStopped.Value) == true)
            {
                trnEnvelope.Commit();
                Refresh_Jobs_Grid();
                Email_Office();
                this.Cursor = Cursors.Default;
            }
            else
            {
                trnEnvelope.Rollback();
                this.Cursor = Cursors.Default;
                MessageBox.Show(myJOBData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnPacked.Visible = true;
            pnlTasks.Visible = false;
        }
        private void Email_Office()
        {
            if ((CustomerServicesEmailAddress.Trim().Length > 0) & (SMTPHostName.Trim().Length > 0) & (SMTPPort > 0) & (SourceEmailAddress.Trim().Length > 0))
            {
                SMTPMailer myMailer = new SMTPMailer();

                myMailer.EmailTo.Add(CustomerServicesEmailAddress);
                myMailer.EmailSubject = dgJobs.CurrentRow.Cells["WorkOrder"].Value.ToString().Trim() + " - " + dgJobs.CurrentRow.Cells["Customer"].Value.ToString().Trim() + " - " + dgJobs.CurrentRow.Cells["ColourName"].Value.ToString().Trim() + " - " + dgJobs.CurrentRow.Cells["Product"].Value.ToString().Trim() + " - " + cmbProductionLine.Text.Trim() + " - Is Finished, Packed & Ready !";
                myMailer.SMTPHost = SMTPHostName;
                myMailer.SMTPPort = SMTPPort;
                myMailer.EmailFrom = ProductionEmailAddress;
                myMailer.EmailBodyText = "";
                myMailer.Send_Email_Message(false);
            }
            else
            {
                MessageBox.Show("Mailer Parameters not Set !\r\nCannot send Email Notifications !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                    if (viewOnly == false)
                        Refresh_Production_Line_Start_Finish(true);
                    else
                        Refresh_Production_Line_Start_Finish(false);

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
        private void dtpStarted_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan prevStartTime = currentStart.TimeOfDay;

            myPLine.UtilisationLineStarted = dtpStarted.Value.TimeOfDay;
            myPLine.UtilisationLineStopped = dtpStopped.Value.TimeOfDay;

            System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

            if (myPLine.Update_Utilisation_Start_Change(productionLineId, prevStartTime, DateTime.Now, trnEnvelope) == true)
            {
                currentStart = dtpStarted.Value;
                trnEnvelope.Commit();
            }
            else
            {
                trnEnvelope.Rollback();
            }
        }

        private void dtpStarted_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}{Right}{Right}");
        }

        private void dtpStopped_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}{Right}{Right}");
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            Log_Tick();

            if (viewOnly == true)
            {
                Refresh_Jobs_Grid();
            }
            else
            {
                Add_Singlecoat_Batch(true);
                Add_Multicoat_Batch(true);
                Refresh_Jobs_Grid();
            }
        }

        private void Log_Tick()
        {
            System.IO.StreamWriter myLog;

            if (System.IO.Directory.Exists("C:\\vps") == false)
                System.IO.Directory.CreateDirectory("C:\\vps");
            System.IO.FileStream myLogStream = new System.IO.FileStream("C:\\vps\\TickLog.txt", System.IO.FileMode.OpenOrCreate);
            myLog = new System.IO.StreamWriter(myLogStream);
            myLog.WriteLine(DateTime.Now.ToString() + "\r\n");
            myLog.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlParts.Visible = false;
        }

        private void dgParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3)
                {
                    if (dgParts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "<View Part>")
                    {
                        frmPartView showPicture = new frmPartView();
                        showPicture.Text = "Part Code : " + dgParts.CurrentRow.Cells["PartCode"].Value.ToString() + " Description : " + dgParts.CurrentRow.Cells["PartDescription"].Value.ToString();
                        showPicture.myVPSConnection = myJOBData.myVPSConnection;
                        showPicture.myPartCode = dgParts.CurrentRow.Cells["PartCode"].Value.ToString();
                        showPicture.Show(this);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nNo Picture available for this Part !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtDeferral_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtDeferral_TextChanged(object sender, EventArgs e)
        {
            if (txtDeferral.Text.Trim().Length > 0)
            {
                btnSave.Enabled = false;
                btnDefer.Enabled = true;
            }
            else
            {
                btnSave.Enabled = true;
                btnDefer.Enabled = false;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            pnlCheat.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String myMessage = "** Operator **\r\n\r\n";
            myMessage += "Do you really wish to Save the new Progress Settings for this Job ?";

            if (MessageBox.Show(myMessage, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

                try
                {
                    String strSQL = "UPDATE JobProgress SET ";
                    if (chkClearStartLoad.Checked == true)
                        strSQL += "ProgressLoadStart = NULL, ";
                    else
                        strSQL += "ProgressLoadStart = CONVERT(datetime, '" + dtpStartLoading.Value.ToString() + "', 103), ";
                    if (chkClearFinishLoad.Checked == true)
                        strSQL += "ProgressLoadEnd = NULL, ";
                    else
                        strSQL += "ProgressLoadEnd = CONVERT(datetime, '" + dtpFinishLoading.Value.ToString() + "', 103), ";
                    if (chkClearStartUnload.Checked == true)
                        strSQL += "ProgressUnloadStart = NULL, ";
                    else
                        strSQL += "ProgressUnloadStart = CONVERT(datetime, '" + dtpStartUnloading.Value.ToString() + "', 103), ";
                    if (chkClearFinishUnload.Checked == true)
                        strSQL += "ProgressUnloadEnd = NULL, ";
                    else
                        strSQL += "ProgressUnloadEnd = CONVERT(datetime, '" + dtpFinishUnloading.Value.ToString() + "', 103), ";
                    strSQL += "ProgressPacked = '" + chkPacked.Checked.ToString() + "' ";
                    strSQL += "WHERE ProgressId = " + currentProgressRecord.ToString();
                    System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand(strSQL, VPSConnection, trnEnvelope);
                    if (cmdUpdate.ExecuteNonQuery() == 1)
                    {
                        trnEnvelope.Commit();
                        pnlCheat.Visible = false;
                        Refresh_Jobs_Grid();
                    }
                    else
                    {
                        trnEnvelope.Rollback();
                        MessageBox.Show("More than one record would be updated !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    trnEnvelope.Rollback();
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDefer_Click(object sender, EventArgs e)
        {
            String myMessage = "** Operator **\r\n\r\n";
            myMessage += "If you select to defer this Job it will be removed from the current Progress List.\r\n";
            myMessage += "The Job will also be removed from its Work Order.\r\n\r\n";
            myMessage += "The associated work order will be flagged as 'Open' again.\r\n\r\n";
            myMessage += "Do you really wish to Defer this Job ?";


            if (MessageBox.Show(myMessage, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (myWOData.Get_WorkOrder(txtWorkOrder.Text) == true)
                {
                    System.Data.SqlClient.SqlTransaction trnEnvelope = VPSConnection.BeginTransaction();

                    if (myJOBData.Delete_Job_Record(txtJob.Text, DateTime.Now, trnEnvelope) == true)
                    {
                        if (myWOData.Update_Work_Order_Status(txtWorkOrder.Text, "Open", trnEnvelope) == true)
                        {
                            txtDeferral.Text = "Deferred Job : " + txtJob.Text + " Production Line : " + cmbProductionLine.Text.Trim() + "-" + txtDeferral.Text;

                            if (myWOData.Insert_WorkOrder_Comment(myWOData.WorkOrderId, myWOData.UserId, txtDeferral.Text, trnEnvelope) == true)
                            {
                                if (myJOBData.Delete_Progress_Record(currentProgressRecord, trnEnvelope) == true)
                                {
                                    trnEnvelope.Commit();
                                    pnlCheat.Visible = false;
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
                                MessageBox.Show(myWOData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                    MessageBox.Show(myWOData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

