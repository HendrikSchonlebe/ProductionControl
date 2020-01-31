using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionControl
{
    class JOBData
    {
        // Data Base Connection
        public System.Data.SqlClient.SqlConnection myVPSConnection { get; set; }

        // Error Message
        public String ErrorMessage { get; set; }

        // Job Entity
        public Int32 JobId { get; set; }
        public String JobNumber { get; set; }
        public String CustomerName { get; set; }
        public String ColourName { get; set; }
        public DateTime ScheduleDate { get; set; }
        public Int32 ProductionLineId { get; set; }
        public Int32 ScheduleSequence { get; set; }
        public DateTime CompletionDate { get; set; }
        public String WorkOrderNumber { get; set; }
        public Int32 SupplierPaintProductId { get; set; }
        public String SupplierPaintProductCode { get; set; }
        public String SupplierProductGroupCode { get; set; }
        public Int32 PaintSystemId { get; set; }
        public Int32 CustomerId { get; set; }
        public Int32 PaintSystemStep { get; set; }
        public Int32 DeliveryDocketId { get; set; }
        public Int32 PaintProductMovementId { get; set; }
        public String JobStatus { get; set; }
        public Boolean Printed { get; set; }
        public Boolean Invoiced { get; set; }
        public Boolean Approved { get; set; }
        public String Comments { get; set; }
        public String BatchNo1 { get; set; }
        public String BatchNo2 { get; set; }
        public String BatchNo3 { get; set; }
        public String BatchNo4 { get; set; }
        public String BatchNo5 { get; set; }
        public String CustomerOrder { get; set; }
        public String PaintSystemProcessCode { get; set; }
        public Int32 PaintSystemCoats { get; set; }
        public System.Data.DataTable myScheduledJobs { get; set; } = new System.Data.DataTable();
        public System.Data.DataTable myJobDetails { get; set; } = new System.Data.DataTable();
        public Boolean Job_Already_Completed(String jobNumber, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isCompleted = false;
            System.Data.DataTable thisJob = new System.Data.DataTable();

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT * FROM Jobs WHERE  JobNumber = '" + jobNumber + "'";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    thisJob.Load(rdrGet);
                    if (thisJob.Rows[0]["JobStatus"].ToString() == "Completed")
                        isCompleted = true;
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                ErrorMessage = "Check Job Completed - " + ex.Message;
            }

            return isCompleted;
        }
        public Boolean Update_Job_Status(String jobNumber, String jobStatus, DateTime timeStamp, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                if (Job_Already_Completed(jobNumber, trnEnvelope) == true)
                {
                    String strSQL = "INSERT INTO JobStatusLog (";
                    strSQL = strSQL + "JobNumber, ";
                    strSQL = strSQL + "JobStatus, ";
                    strSQL = strSQL + "Updated, ";
                    strSQL = strSQL + "Source) VALUES (";
                    strSQL = strSQL + "'" + jobNumber + "', ";
                    strSQL = strSQL + "'**********', ";
                    strSQL = strSQL + "CONVERT(datetime, '" + DateTime.Now.ToString() + "', 103), ";
                    strSQL = strSQL + "'Factory')";
                    System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                    cmdInsert.ExecuteNonQuery();
                }
                else
                {
                    String strSQL = "UPDATE Jobs SET ";
                    if (jobStatus == "Processed")
                        strSQL = strSQL + "CompletionDate = CONVERT(datetime, '" + timeStamp.ToString() + "', 103), ";
                    strSQL = strSQL + "JobStatus = '" + jobStatus + "' ";
                    strSQL = strSQL + "WHERE JobNumber = '" + jobNumber + "'";
                    System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                    if (cmdUpdate.ExecuteNonQuery() != 1)
                    {
                        isSuccessful = false;
                        ErrorMessage = "Update Job Status - More than one record would be updated !";
                    }
                    else
                    {
                        strSQL = "INSERT INTO JobStatusLog (";
                        strSQL = strSQL + "JobNumber, ";
                        strSQL = strSQL + "JobStatus, ";
                        strSQL = strSQL + "Updated, ";
                        strSQL = strSQL + "Source) VALUES (";
                        strSQL = strSQL + "'" + jobNumber + "', ";
                        strSQL = strSQL + "'" + jobStatus + "', ";
                        strSQL = strSQL + "CONVERT(datetime, '" + DateTime.Now.ToString() + "', 103), ";
                        strSQL = strSQL + "'Factory')";
                        System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Update Job Status - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Get_Scheduled_MultiCoat_Jobs(Int32 lineId, DateTime scheduledDay)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                myScheduledJobs.Clear();
                String strSQL = "SELECT * ";
                strSQL = strSQL + "FROM Jobs ";
                strSQL = strSQL + "INNER JOIN PaintSystems ON PaintSystems.PaintSystemId = Jobs.PaintSystemId ";
                strSQL = strSQL + "INNER JOIN PaintSystemProcesses ON PaintSystems.process_code = PaintSystemProcesses.process_code ";
                strSQL = strSQL + "LEFT JOIN JobProgress ON JobProgress.ProgressJobId = Jobs.JobId ";
                strSQL = strSQL + "WHERE (Jobs.JobStatus = 'Open' OR Jobs.JobStatus = 'Started')";
                strSQL = strSQL + "AND PaintSystemProcesses.Process_Coats > 1 ";
                strSQL = strSQL + "AND Jobs.ProductionLineId = " + lineId.ToString();
                strSQL = strSQL + "AND Jobs.ScheduleDate <= Convert(datetime,'" + scheduledDay.ToString() + "', 103) ";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myScheduledJobs.Load(rdrGet);
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Scheduled Jobs - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Get_Scheduled_Jobs(Int32 lineId, DateTime scheduledDay)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                myScheduledJobs.Clear();
                String strSQL = "SELECT * ";
                strSQL = strSQL + "FROM Jobs ";
                strSQL = strSQL + "INNER JOIN PaintSystems ON PaintSystems.PaintSystemId = Jobs.PaintSystemId ";
                strSQL = strSQL + "INNER JOIN PaintSystemProcesses ON PaintSystems.process_code = PaintSystemProcesses.process_code ";
                strSQL = strSQL + "LEFT JOIN JobProgress ON JobProgress.ProgressJobId = Jobs.JobId ";
                strSQL = strSQL + "WHERE Jobs.JobStatus = 'Open' ";
                strSQL = strSQL + "AND PaintSystemProcesses.Process_Coats = 1 ";
                strSQL = strSQL + "AND Jobs.ProductionLineId = " + lineId.ToString();
                strSQL = strSQL + "AND Jobs.ScheduleDate <= Convert(datetime,'" + scheduledDay.ToString() + "', 103) ";
                strSQL = strSQL + "AND IsNull(JobProgress.ProgressJobId, 0) = 0";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myScheduledJobs.Load(rdrGet);
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Scheduled Jobs - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Get_Job(String MyJobNumber, Int32 MyproductionLine)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT Jobs.*, ";
                strSQL = strSQL + "WorkOrders.WorkOrderNo, WorkOrders.CustomerRef, ";
                strSQL = strSQL + "PaintSystems.PaintSystemCode, PaintSystems.Process_Code, ";
                strSQL = strSQL + "PaintSystemProcesses.process_coats, ";
                strSQL = strSQL + "SupplierPaintProducts.SupplierPaintProductCode, ";
                strSQL = strSQL + "SupplierProductGroups.SupplierProductGroupCode ";
                strSQL = strSQL + "FROM Jobs ";
                strSQL = strSQL + "INNER JOIN WorkOrders ON Jobs.WorkOrderId = WorkOrders.WorkOrderId ";
                strSQL = strSQL + "INNER JOIN PaintSystems ON Jobs.PaintSystemId = PaintSystems.PaintSystemId ";
                strSQL = strSQL + "INNER JOIN PaintSystemProcesses ON PaintSystems.process_code = PaintSystemProcesses.process_code ";
                strSQL = strSQL + "INNER JOIN SupplierPaintProducts ON Jobs.SupplierPaintProductId = SupplierPaintProducts.SupplierPaintProductId ";
                strSQL = strSQL + "INNER JOIN SupplierProductGroups ON SupplierPaintProducts.SupplierProductgroupId = SupplierProductGroups.SupplierProductGroupId ";
                strSQL = strSQL + "WHERE JobNumber = '" + MyJobNumber + "'";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    System.Data.DataTable CurrentJob = new System.Data.DataTable();
                    CurrentJob.Load(rdrGet);

                    JobId = Convert.ToInt32(CurrentJob.Rows[0]["JobId"]);
                    JobNumber = CurrentJob.Rows[0]["JobNumber"].ToString();
                    CustomerName = CurrentJob.Rows[0]["CustomerName"].ToString();
                    ColourName = CurrentJob.Rows[0]["ColorName"].ToString();
                    JobStatus = CurrentJob.Rows[0]["JobStatus"].ToString();
                    WorkOrderNumber = CurrentJob.Rows[0]["WorkOrderNo"].ToString();
                    CustomerOrder = CurrentJob.Rows[0]["CustomerRef"].ToString();
                    SupplierPaintProductCode = CurrentJob.Rows[0]["SupplierPaintProductCode"].ToString();
                    SupplierProductGroupCode = CurrentJob.Rows[0]["SupplierProductGroupCode"].ToString();
                    ProductionLineId = Convert.ToInt32(CurrentJob.Rows[0]["ProductionLineId"]);
                    PaintSystemProcessCode = CurrentJob.Rows[0]["Process_Code"].ToString();
                    PaintSystemCoats = Convert.ToInt32(CurrentJob.Rows[0]["Process_Coats"]);
                    if (MyproductionLine > 0)
                    {
                        if (Convert.ToInt32(CurrentJob.Rows[0]["ProductionLineId"]) != MyproductionLine)
                        {
                            isSuccessful = false;
                            ErrorMessage = "Get Job - Job # " + MyJobNumber + " was not Scheduled for this Production Line !";
                        }
                    }
                }
                else
                {
                    isSuccessful = false;
                    ErrorMessage = "Get Job - Job # " + MyJobNumber + " not Found !";
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Job - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Get_Job(String MyJobNumber, Int32 MyproductionLine, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT Jobs.*, ";
                strSQL = strSQL + "WorkOrders.WorkOrderNo, WorkOrders.CustomerRef, ";
                strSQL = strSQL + "PaintSystems.PaintSystemCode, ";
                strSQL = strSQL + "PaintSystemProcesses.process_coats, ";
                strSQL = strSQL + "SupplierPaintProducts.SupplierPaintProductCode, ";
                strSQL = strSQL + "SupplierProductGroups.SupplierProductGroupCode ";
                strSQL = strSQL + "FROM Jobs ";
                strSQL = strSQL + "INNER JOIN WorkOrders ON Jobs.WorkOrderId = WorkOrders.WorkOrderId ";
                strSQL = strSQL + "INNER JOIN PaintSystems ON Jobs.PaintSystemId = PaintSystems.PaintSystemId ";
                strSQL = strSQL + "INNER JOIN PaintSystemProcesses ON PaintSystems.process_code = PaintSystemProcesses.process_code ";
                strSQL = strSQL + "INNER JOIN SupplierPaintProducts ON Jobs.SupplierPaintProductId = SupplierPaintProducts.SupplierPaintProductId ";
                strSQL = strSQL + "INNER JOIN SupplierProductGroups ON SupplierPaintProducts.SupplierProductgroupId = SupplierProductGroups.SupplierProductGroupId ";
                strSQL = strSQL + "WHERE JobNumber = '" + MyJobNumber + "'";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    System.Data.DataTable CurrentJob = new System.Data.DataTable();
                    CurrentJob.Load(rdrGet);

                    JobId = Convert.ToInt32(CurrentJob.Rows[0]["JobId"]);
                    JobNumber = CurrentJob.Rows[0]["JobNumber"].ToString();
                    CustomerName = CurrentJob.Rows[0]["CustomerName"].ToString();
                    ColourName = CurrentJob.Rows[0]["ColorName"].ToString();
                    JobStatus = CurrentJob.Rows[0]["JobStatus"].ToString();
                    WorkOrderNumber = CurrentJob.Rows[0]["WorkOrderNo"].ToString();
                    CustomerOrder = CurrentJob.Rows[0]["CustomerRef"].ToString();
                    SupplierPaintProductCode = CurrentJob.Rows[0]["SupplierPaintProductCode"].ToString();
                    SupplierProductGroupCode = CurrentJob.Rows[0]["SupplierProductGroupCode"].ToString();
                    ProductionLineId = Convert.ToInt32(CurrentJob.Rows[0]["ProductionLineId"]);
                    PaintSystemCoats = Convert.ToInt32(CurrentJob.Rows[0]["Process_Coats"]);

                    if (MyproductionLine > 0)
                    {
                        if (Convert.ToInt32(CurrentJob.Rows[0]["ProductionLineId"]) != MyproductionLine)
                        {
                            isSuccessful = false;
                            ErrorMessage = "Get Job - Job # " + MyJobNumber + " was not Scheduled for this Production Line !";
                        }
                    }
                }
                else
                {
                    isSuccessful = false;
                    ErrorMessage = "Get Job - Job # " + MyJobNumber + " not Found !";
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Job - " + ex.Message;
            }

            return isSuccessful;
        }
        // Job Details
        public Int32 Job_Estimated_Time(Int32 jobId)
        {
            Double totalM2 = Get_Job_Area(jobId, "PP");
            Double outstandingMaterial = 0;
            Int32 outstandingTime = 0;
            Double coverage = 0;
            Double coverageFactor = 0;
            Int32 minutesPB = 45;
            Boolean isPowder = false;

            String strSQL = "SELECT * FROM Jobs WHERE JobId = " + jobId.ToString();
            System.Data.SqlClient.SqlCommand cmdGetJ = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
            System.Data.SqlClient.SqlDataReader rdrGetJ = cmdGetJ.ExecuteReader();
            if (rdrGetJ.HasRows == true)
            {
                System.Data.DataTable myJob = new System.Data.DataTable();
                myJob.Load(rdrGetJ);

                Int32 myPaintProduct = Convert.ToInt32(myJob.Rows[0]["SupplierPaintProductId"]);
                Int32 myWorkOrder = Convert.ToInt32(myJob.Rows[0]["WorkOrderId"]);

                strSQL = "SELECT * FROM SupplierPaintProducts WHERE SupplierPaintProductId = " + myPaintProduct.ToString();
                System.Data.SqlClient.SqlCommand cmdGetP = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGetP = cmdGetP.ExecuteReader();
                if (rdrGetP.HasRows == true)
                {
                    System.Data.DataTable myProduct = new System.Data.DataTable();
                    myProduct.Load(rdrGetP);

                    Int32 myGroup = Convert.ToInt32(myProduct.Rows[0]["SupplierProductgroupId"]);

                    strSQL = "SELECT * FROM SupplierProductGroups WHERE SupplierProductgroupId = " + myGroup.ToString();
                    System.Data.SqlClient.SqlCommand cmdGetG = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                    System.Data.SqlClient.SqlDataReader rdrGetG = cmdGetG.ExecuteReader();
                    if (rdrGetG.HasRows == true)
                    {
                        System.Data.DataTable myProductGroup = new System.Data.DataTable();
                        myProductGroup.Load(rdrGetG);

                        coverage = Convert.ToDouble(myProductGroup.Rows[0]["Coverage"]);
                        coverageFactor = Convert.ToDouble(myProductGroup.Rows[0]["CoverageFactor"]);
                        Int32 myPaintType = Convert.ToInt32(myProductGroup.Rows[0]["PaintTypeId"]);

                        strSQL = "SELECT * FROM PaintTypes WHERE PaintTypeId = " + myPaintType.ToString();
                        System.Data.SqlClient.SqlCommand cmdGetT = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                        System.Data.SqlClient.SqlDataReader rdrGetT = cmdGetT.ExecuteReader();
                        if (rdrGetT.HasRows == true)
                        {
                            System.Data.DataTable myType = new System.Data.DataTable();
                            myType.Load(rdrGetT);

                            if (myType.Rows[0]["Description"].ToString().ToUpper().Contains("POWDER") == true)
                                isPowder = true;

                            strSQL = "SELECT * FROM WorkOrders WHERE WorkOrderId = " + myWorkOrder.ToString();
                            System.Data.SqlClient.SqlCommand cmdGetO = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                            System.Data.SqlClient.SqlDataReader rdrGetO = cmdGetO.ExecuteReader();
                            if (rdrGetO.HasRows == true)
                            {
                                System.Data.DataTable myOrder = new System.Data.DataTable();
                                myOrder.Load(rdrGetO);

                                Int32 myPPgroup = Convert.ToInt32(myOrder.Rows[0]["PaintProductGroupId"]);

                                strSQL = "SELECT * FROM PaintProductGroups WHERE PaintProductGroupId = " + myPPgroup.ToString();
                                System.Data.SqlClient.SqlCommand cmdGetB = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                                System.Data.SqlClient.SqlDataReader rdrGetB = cmdGetB.ExecuteReader();
                                if (rdrGetB.HasRows == true)
                                {
                                    System.Data.DataTable myPPrecord = new System.Data.DataTable();
                                    myPPrecord.Load(rdrGetB);

                                    minutesPB = Convert.ToInt32(myPPrecord.Rows[0]["MinutesPerBag"]);
                                }
                                rdrGetB.Close();
                                cmdGetB.Dispose();
                            }
                            rdrGetO.Close();
                            cmdGetO.Dispose();
                        }
                        rdrGetT.Close();
                        cmdGetT.Dispose();
                    }
                    rdrGetG.Close();
                    cmdGetG.Dispose();
                }
                rdrGetP.Close();
                cmdGetP.Dispose();
            }
            rdrGetJ.Close();
            cmdGetJ.Dispose();


            if (coverage > 0)
            {
                outstandingMaterial = Math.Round((totalM2 / coverage) * coverageFactor, 3);
            }

            if (isPowder == true)
                outstandingTime = Convert.ToInt32((outstandingMaterial / 20) * minutesPB);
            else
                outstandingTime = 0;

            return outstandingTime;
        }
        public Double Get_Job_Area(Int32 jobId, String areaType)
        {
            Double myArea = 0;
            System.Data.DataTable myDetails = new System.Data.DataTable();

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT * FROM JobDetails ";
                strSQL = strSQL + "INNER JOIN WorkOrderDetails ON JobDetails.WorkOrderDetailId = WorkOrderDetails.WorkorderDetailId ";
                strSQL = strSQL + "WHERE Jobdetails.Jobid = " + jobId.ToString();
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myDetails.Clear();
                    myDetails.Load(rdrGet);
                }
                rdrGet.Close();
                cmdGet.Dispose();

                for (int i = 0; i < myDetails.Rows.Count; i++)
                {
                    if (areaType == "AP")
                        myArea = myArea + Convert.ToInt32(myDetails.Rows[i]["Qty"]) * Convert.ToDouble(myDetails.Rows[i]["UnitAreaPrice"]);
                    else
                        myArea = myArea + Convert.ToInt32(myDetails.Rows[i]["Qty"]) * Convert.ToDouble(myDetails.Rows[i]["UnitAreaStock"]);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Get Job Area - " + ex.Message;
            }

            return myArea;
        }
        public Boolean Get_Job_Details(Int32 jobId)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT * FROM JobDetails ";
                strSQL = strSQL + "INNER JOIN WorkOrderDetails ON JobDetails.WorkOrderDetailId = WorkOrderDetails.WorkorderDetailId ";
                strSQL = strSQL + "INNER JOIN Parts ON WorkOrderDetails.PartId = Parts.PartId ";
                strSQL = strSQL + "WHERE JobDetails.Jobid = " + jobId.ToString();
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myJobDetails.Clear();
                    myJobDetails.Load(rdrGet);
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Job Details - " + ex.Message;
            }

            return isSuccessful;
        }

        // Progress Entity
        public Int32 ProgressId { get; set; }
        public Int32 ProgressJobId { get; set; }
        public Int32 ProgressProductionLineId { get; set; }
        public DateTime ProgressLoadStart { get; set; }
        public DateTime ProgressLoadEnd { get; set; }
        public DateTime ProgressUnloadStart { get; set; }
        public DateTime ProgressUnloadEnd { get; set; }
        public Boolean ProgressPacked { get; set; }
        public DateTime ProgressLineStart { get; set; }
        public DateTime ProgressLineStop { get; set; }
        public Int32 ProgressCoats { get; set; }
        public Int32 ProgressThisCoat { get; set; }
        public System.Data.DataTable myJobsInProgress { get; set; } = new System.Data.DataTable();

        public Boolean Insert_Progress_Record(Int32 jobId, Int32 lineId, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                myJobsInProgress.Clear();
                String strSQL = "INSERT INTO JobProgress (";
                strSQL = strSQL + "ProgressJobId, ";
                strSQL = strSQL + "ProgressProductionLineId, ";
                strSQL = strSQL + "ProgressCoats, ";
                strSQL = strSQL + "ProgressThisCoat, ";
                strSQL = strSQL + "ProgressCompleted, ";
                strSQL = strSQL + "ProgressPacked) VALUES (";
                strSQL = strSQL + jobId.ToString() + ", ";
                strSQL = strSQL + lineId.ToString() + ", ";
                strSQL = strSQL + ProgressCoats.ToString() + ", ";
                strSQL = strSQL + ProgressThisCoat.ToString() + ", ";
                strSQL = strSQL + "'False', ";
                strSQL = strSQL + "'False')";
                System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                if (cmdInsert.ExecuteNonQuery() != 1)
                {
                    isSuccessful = false;
                    ErrorMessage = "Insert Progress Record - More than one record would be inserted !";
                }
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Insert Progress Record - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Get_Progress_Record(Int32 jobId, Int32 lineId)
        {
            Boolean isSuccessful = true;
            System.Data.DataTable myProgressRecord = new System.Data.DataTable();

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT * FROM JobProgress WHERE ProgressJobId = " + jobId.ToString() + " AND ProgressProductionLineId = " + lineId.ToString();
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myProgressRecord.Load(rdrGet);
                    isSuccessful = Gather_Progress_Record(myProgressRecord);
                }
                else
                {
                    isSuccessful = false;
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Progress Record - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Get_Progress_Record(Int32 jobId)
        {
            Boolean isSuccessful = true;
            System.Data.DataTable myProgressRecord = new System.Data.DataTable();

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT * FROM JobProgress WHERE ProgressJobId = " + jobId.ToString();
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myProgressRecord.Load(rdrGet);
                    isSuccessful = Gather_Progress_Record(myProgressRecord);
                }
                else
                {
                    isSuccessful = false;
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Progress Record - " + ex.Message;
            }

            return isSuccessful;
        }
        private Boolean Gather_Progress_Record(System.Data.DataTable myProgressRecord)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                ProgressId = Convert.ToInt32(myProgressRecord.Rows[0]["ProgressId"]);
                ProgressJobId = Convert.ToInt32(myProgressRecord.Rows[0]["ProgressJobId"]);
                ProgressProductionLineId = Convert.ToInt32(myProgressRecord.Rows[0]["ProgressproductionLineId"]);
                ProgressCoats = Convert.ToInt32(myProgressRecord.Rows[0]["ProgressCoats"]);
                ProgressThisCoat = Convert.ToInt32(myProgressRecord.Rows[0]["ProgressThisCoat"]);
                if (myProgressRecord.Rows[0]["ProgressLoadStart"] != DBNull.Value)
                    ProgressLoadStart = Convert.ToDateTime(myProgressRecord.Rows[0]["ProgressLoadStart"]);
                else
                    ProgressLoadStart = DateTime.MinValue;
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Gather Progress Record - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Update_Progress_Record(Int32 recordId, DateTime timeStamp, Int32 taskId, System.Data.SqlClient.SqlTransaction trnEnvelope, DateTime lineStart, DateTime lineStop)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "UPDATE JobProgress SET ";
                if (taskId == -1)
                    strSQL = strSQL + "ProgressLoadStart = NULL, ProgressLineStarted = NULL, ProgressLineStopped = NULL ";
                else if (taskId == 1)
                    strSQL = strSQL + "ProgressLoadStart = CONVERT(datetime, '" + timeStamp.ToString() + "', 103), ProgressLineStarted = CONVERT(datetime, '" + lineStart.ToString() + "', 103), ProgressLineStopped = CONVERT(datetime, '" + lineStop.ToString() + "', 103) ";
                else if (taskId == 2)
                    strSQL = strSQL + "ProgressLoadEnd = CONVERT(datetime, '" + timeStamp.ToString() + "', 103) ";
                else if (taskId == -3)
                    strSQL = strSQL + "ProgressUnloadStart = NULL ";
                else if (taskId == 3)
                    strSQL = strSQL + "ProgressUnloadStart = CONVERT(datetime, '" + timeStamp.ToString() + "', 103) ";
                else if (taskId == 4)
                    strSQL = strSQL + "ProgressUnloadEnd = CONVERT(datetime, '" + timeStamp.ToString() + "', 103) ";
                else if (taskId == 5)
                    strSQL = strSQL + "ProgressPacked = 'True' ";
                else if (taskId == 6)
                    strSQL = strSQL + "ProgressUnloadEnd = CONVERT(datetime, '" + timeStamp.ToString() + "', 103),  ProgressPacked = 'True', ProgressCompleted = 'True' ";
                else if (taskId == 7)
                    strSQL = strSQL + "ProgressCompleted = 'True' ";
                strSQL = strSQL + "WHERE ProgressId = " + recordId.ToString();
                System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                if (cmdUpdate.ExecuteNonQuery() != 1)
                {
                    isSuccessful = false;
                    ErrorMessage = "Update Progress Record - More than one record would be updated !";
                }
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Update Progress Record - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Delete_Progress_Record(Int32 progressId, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "DELETE FROM JobProgress WHERE ProgressId = " + progressId.ToString();
                System.Data.SqlClient.SqlCommand cmdDelete = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                if (cmdDelete.ExecuteNonQuery() != 1)
                {
                    isSuccessful = false;
                    ErrorMessage = "Delete Progress Record - More than one record would be deleted !";
                }
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Delete Progress Record - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Get_Unfinished_Jobs(Int32 lineId)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                myJobsInProgress.Clear();
                String strSQL = "SELECT JobProgress.*, ";
                strSQL = strSQL + "Jobs.*, ";
                strSQL = strSQL + "WorkOrders.WorkOrderNo, WorkOrders.CustomerRef, ";
                strSQL = strSQL + "PaintSystems.PaintSystemCode, ";
                strSQL = strSQL + "SupplierPaintProducts.SupplierPaintProductCode, ";
                strSQL = strSQL + "SupplierProductGroups.SupplierProductGroupCode ";
                strSQL = strSQL + "FROM JobProgress ";
                strSQL = strSQL + "INNER JOIN Jobs ON JobProgress.ProgressJobId = Jobs.JobId ";
                strSQL = strSQL + "INNER JOIN WorkOrders ON Jobs.WorkOrderId = WorkOrders.WorkOrderId ";
                strSQL = strSQL + "INNER JOIN PaintSystems ON Jobs.PaintSystemId = PaintSystems.PaintSystemId ";
                strSQL = strSQL + "INNER JOIN SupplierPaintProducts ON Jobs.SupplierPaintProductId = SupplierPaintProducts.SupplierPaintProductId ";
                strSQL = strSQL + "INNER JOIN SupplierProductGroups ON SupplierPaintProducts.SupplierProductgroupId = SupplierProductGroups.SupplierProductGroupId ";
                strSQL = strSQL + "WHERE JobProgress.ProgressCompleted = 'False' ";
                strSQL = strSQL + "AND JobProgress.ProgressProductionLineId = " + lineId.ToString() + " ";
                strSQL = strSQL + "ORDER BY Jobs.ScheduleDate, Jobs.ScheduleSeq, Jobs.JobId, JobProgress.ProgressThisCoat";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myJobsInProgress.Load(rdrGet);
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Unfinished Jobs - " + ex.Message;
            }

            return isSuccessful;
        }
        // Multi Coat
        public Int32 Get_MultiCoat_Progress_Records(Int32 jobId)
        {
            Int32 recordCount = 0;
            System.Data.DataTable myMCProgress = new System.Data.DataTable();

            ErrorMessage = string.Empty;

            try
            {
                myMCProgress.Clear();
                String strSQL = "SELECT JobProgress.*, ";
                strSQL = strSQL + "Jobs.*, ";
                strSQL = strSQL + "WorkOrders.WorkOrderNo, WorkOrders.CustomerRef, ";
                strSQL = strSQL + "PaintSystems.PaintSystemCode, ";
                strSQL = strSQL + "SupplierPaintProducts.SupplierPaintProductCode, ";
                strSQL = strSQL + "SupplierProductGroups.SupplierProductGroupCode ";
                strSQL = strSQL + "FROM JobProgress ";
                strSQL = strSQL + "INNER JOIN Jobs ON JobProgress.ProgressJobId = Jobs.JobId ";
                strSQL = strSQL + "INNER JOIN WorkOrders ON Jobs.WorkOrderId = WorkOrders.WorkOrderId ";
                strSQL = strSQL + "INNER JOIN PaintSystems ON Jobs.PaintSystemId = PaintSystems.PaintSystemId ";
                strSQL = strSQL + "INNER JOIN SupplierPaintProducts ON Jobs.SupplierPaintProductId = SupplierPaintProducts.SupplierPaintProductId ";
                strSQL = strSQL + "INNER JOIN SupplierProductGroups ON SupplierPaintProducts.SupplierProductgroupId = SupplierProductGroups.SupplierProductGroupId ";
                strSQL = strSQL + "WHERE JobProgress.ProgressJobId = " + jobId.ToString() + " ";
                strSQL = strSQL + "ORDER BY Jobs.ScheduleDate, Jobs.ScheduleSeq";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myMCProgress.Load(rdrGet);
                    recordCount = myMCProgress.Rows.Count;
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                ErrorMessage = "Get Multi-Coat Job Progress Records - " + ex.Message;
            }

            return recordCount;
        }
        public Int32 Get_MultiCoat_Progress_Records(Int32 jobId, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Int32 recordCount = 0;
            System.Data.DataTable myMCProgress = new System.Data.DataTable();

            ErrorMessage = string.Empty;

            try
            {
                myMCProgress.Clear();
                String strSQL = "SELECT JobProgress.*, ";
                strSQL = strSQL + "Jobs.*, ";
                strSQL = strSQL + "WorkOrders.WorkOrderNo, WorkOrders.CustomerRef, ";
                strSQL = strSQL + "PaintSystems.PaintSystemCode, ";
                strSQL = strSQL + "SupplierPaintProducts.SupplierPaintProductCode, ";
                strSQL = strSQL + "SupplierProductGroups.SupplierProductGroupCode ";
                strSQL = strSQL + "FROM JobProgress ";
                strSQL = strSQL + "INNER JOIN Jobs ON JobProgress.ProgressJobId = Jobs.JobId ";
                strSQL = strSQL + "INNER JOIN WorkOrders ON Jobs.WorkOrderId = WorkOrders.WorkOrderId ";
                strSQL = strSQL + "INNER JOIN PaintSystems ON Jobs.PaintSystemId = PaintSystems.PaintSystemId ";
                strSQL = strSQL + "INNER JOIN SupplierPaintProducts ON Jobs.SupplierPaintProductId = SupplierPaintProducts.SupplierPaintProductId ";
                strSQL = strSQL + "INNER JOIN SupplierProductGroups ON SupplierPaintProducts.SupplierProductgroupId = SupplierProductGroups.SupplierProductGroupId ";
                strSQL = strSQL + "WHERE JobProgress.ProgressJobId = " + jobId.ToString() + " ";
                strSQL = strSQL + "ORDER BY Jobs.ScheduleDate, Jobs.ScheduleSeq";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myMCProgress.Load(rdrGet);
                    recordCount = myMCProgress.Rows.Count;
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                ErrorMessage = "Get Multi-Coat Job Progress Records - " + ex.Message;
            }

            return recordCount;
        }
        public String MultiCoat_PaintProduct(Int32 sequence, Int32 workOrderId)
        {
            String myPrimer = string.Empty;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT WorkOrdersPrimer.*, PaintSystemSteps.ProcessSeq, SupplierPaintProducts.SupplierPaintProductCode, ColorName.Description as ColourName, SupplierProductGroups.SupplierProductGroupCode ";
                strSQL = strSQL + "FROM WorkOrdersPrimer ";
                strSQL = strSQL + "INNER JOIN PaintSystemSteps ON WorkOrdersPrimer.PaintSystemStepId = PaintSystemSteps.PaintSystemStepId ";
                strSQL = strSQL + "INNER JOIN SupplierPaintProducts ON WorkOrdersPrimer.SupplierPaintProductId = SupplierPaintProducts.SupplierPaintProductId ";
                strSQL = strSQL + "INNER JOIN ColorName ON SupplierPaintProducts.ColorNameId = ColorName.ColorNameId ";
                strSQL = strSQL + "INNER JOIN SupplierProductGroups ON SupplierPaintProducts.SupplierProductGroupId = SupplierProductGroups.SupplierProductGroupId ";
                strSQL = strSQL + "WHERE WorkOrdersPrimer.WorkOrderId = " + workOrderId.ToString() + " ";
                strSQL = strSQL + "ORDER BY PaintSystemSteps.ProcessSeq";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows)
                {
                    System.Data.DataTable myPrimers = new System.Data.DataTable();
                    myPrimers.Load(rdrGet);
                    if (sequence == 1)
                    {
                        myPrimer = myPrimers.Rows[0]["SupplierProductGroupCode"].ToString() + ",";
                        myPrimer = myPrimer + myPrimers.Rows[0]["SupplierPaintProductCode"].ToString() + ",";
                        myPrimer = myPrimer + myPrimers.Rows[0]["ColourName"].ToString();
                    }
                    else if (sequence == 2)
                    {
                        myPrimer = myPrimers.Rows[1]["SupplierProductGroupCode"].ToString() + ",";
                        myPrimer = myPrimer + myPrimers.Rows[1]["SupplierPaintProductCode"].ToString() + ",";
                        myPrimer = myPrimer + myPrimers.Rows[1]["ColourName"].ToString();
                    }
                    else if (sequence == 3)
                    {
                        myPrimer = myPrimers.Rows[2]["SupplierProductGroupCode"].ToString() + ",";
                        myPrimer = myPrimer + myPrimers.Rows[2]["SupplierPaintProductCode"].ToString() + ",";
                        myPrimer = myPrimer + myPrimers.Rows[2]["ColourName"].ToString();
                    }
                    else if (sequence == 4)
                    {
                        myPrimer = myPrimers.Rows[3]["SupplierProductGroupCode"].ToString() + ",";
                        myPrimer = myPrimer + myPrimers.Rows[3]["SupplierPaintProductCode"].ToString() + ",";
                        myPrimer = myPrimer + myPrimers.Rows[3]["ColourName"].ToString();
                    }
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                myPrimer = string.Empty;
                ErrorMessage = "Get Multi Coat Records - " + ex.Message;
            }

            return myPrimer;
        }
    }
}
