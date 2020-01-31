using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionControl
{
    class PLINEData
    {
        // Data Base Connection
        public System.Data.SqlClient.SqlConnection myVPSConnection { get; set; }

        // Error Message
        public String ErrorMessage { get; set; }

        // Production Line Defaults
        public TimeSpan DefaultStartTime { get; set; }
        public TimeSpan DefaultStopTime { get; set; }

        public Boolean Get_Line_Defaults()
        {
            Boolean isSuccessful = true;
            System.Data.DataTable myDefaults = new System.Data.DataTable();

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT * FROM SystemDefaults";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myDefaults.Load(rdrGet);
                    DefaultStartTime = Convert.ToDateTime(myDefaults.Rows[0]["ProductionStartTime"].ToString()).TimeOfDay;
                    DefaultStopTime = Convert.ToDateTime(myDefaults.Rows[0]["ProductionFinishTime"].ToString()).TimeOfDay;
                }
                else
                {
                    isSuccessful = false;
                    ErrorMessage = "Get Production Line Defaults - Not Found !";
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Production Line Defaults - " + ex.Message;
            }

            return isSuccessful;
        }

        // Utilisation Entity
        public Int32 UtilisationId { get; set; }
        public Int32 UtilisationLineId { get; set; }
        public DateTime UtilisationWorkDayDate { get; set; }
        public TimeSpan UtilisationLineStarted { get; set; }
        public TimeSpan UtilisationLineStopped { get; set; }
        public System.Data.DataTable UtilisationRecord = new System.Data.DataTable();

        public Boolean Insert_Utilisation_Record(System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "INSERT INTO ProductionLineUtilisation (";
                strSQL = strSQL + "LineUtilisationLineId, ";
                strSQL = strSQL + "LineUtilisationWorkDate, ";
                strSQL = strSQL + "LineUtilisationLineStart, ";
                strSQL = strSQL + "LineUtilisationLineStop) VALUES (";
                strSQL = strSQL + UtilisationLineId.ToString() + ", ";
                strSQL = strSQL + "CONVERT(datetime, '" + UtilisationWorkDayDate.ToShortDateString() + " 00:00:00', 103), ";
                strSQL = strSQL + "'" + UtilisationLineStarted.ToString() + "', ";
                strSQL = strSQL + "'" + UtilisationLineStopped.ToString() + "')";
                System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Insert Production Line Utilisation Record - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Update_Utilisation_Start(Int32 lineId, DateTime workDay, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "UPDATE ProductionLineUtilisation SET LineUtilisationLineStart = '" + UtilisationLineStarted.ToString() + "' ";
                strSQL = strSQL + "WHERE LineUtilisationLineId = " + lineId.ToString() + " ";
                strSQL = strSQL + "AND LineUtilisationWorkDate = Convert(datetime, '" + workDay.ToShortDateString() + " 00:00:00', 103)";
                System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Update Production Line Utilisation Record Start Time - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Update_Utilisation_Stop(Int32 lineId, DateTime workDay, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "UPDATE ProductionLineUtilisation SET LineUtilisationLineStop = '" + UtilisationLineStopped.ToString() + "' ";
                strSQL = strSQL + "WHERE LineUtilisationLineId = " + lineId.ToString() + " ";
                strSQL = strSQL + "AND LineUtilisationWorkDate = Convert(datetime, '" + workDay.ToShortDateString() + " 00:00:00', 103)";
                System.Data.SqlClient.SqlCommand cmdUpdateU = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                cmdUpdateU.ExecuteNonQuery();

                strSQL = "UPDATE JobProgress SET ProgressLineStopped = CONVERT(datetime, '" + workDay.ToShortDateString() + " " + UtilisationLineStopped.ToString() + "', 103) ";
                strSQL = strSQL + "WHERE ProgressProductionLineId = " + lineId.ToString() + " ";
                strSQL = strSQL + "AND ProgressLineStarted = CONVERT(datetime, '" + workDay.ToShortDateString() + " " + UtilisationLineStarted.ToString() + "', 103)";
                System.Data.SqlClient.SqlCommand cmdUpdateP = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                cmdUpdateP.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Update Production Line Utilisation Record Stop Time - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Update_Utilisation_Start_Change(Int32 lineId, TimeSpan prevStartTime, DateTime workDay, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "UPDATE ProductionLineUtilisation SET LineUtilisationLineStart = '" + UtilisationLineStarted.ToString() + "' ";
                strSQL = strSQL + "WHERE LineUtilisationLineId = " + lineId.ToString() + " ";
                strSQL = strSQL + "AND LineUtilisationWorkDate = Convert(datetime, '" + workDay.ToShortDateString() + " 00:00:00', 103)";
                System.Data.SqlClient.SqlCommand cmdUpdateU = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                cmdUpdateU.ExecuteNonQuery();

                strSQL = "UPDATE JobProgress SET ProgressLineStarted = CONVERT(datetime, '" + workDay.ToShortDateString() + " " + UtilisationLineStarted.ToString() + "', 103) ";
                strSQL = strSQL + "WHERE ProgressProductionLineId = " + lineId.ToString() + " ";
                strSQL = strSQL + "AND ProgressLineStarted = CONVERT(datetime, '" + workDay.ToShortDateString() + " " + prevStartTime.ToString() + "', 103)";
                System.Data.SqlClient.SqlCommand cmdUpdateP = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                cmdUpdateP.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Update Production Line Utilisation Record Stop Time - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Get_Utilisation_Record(Int32 lineId, DateTime workDay)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT * FROM ProductionLineUtilisation WHERE LineUtilisationLineId = " + lineId.ToString() + " AND LineUtilisationWorkDate = CONVERT(datetime,'" + workDay.ToShortDateString() + " 00:00:00', 103)";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    UtilisationRecord.Clear();
                    UtilisationRecord.Load(rdrGet);
                    isSuccessful = Gather_Utilisation_Record();
                }
                else
                {
                    isSuccessful = false;
                    ErrorMessage = "Get Production Line Utilisation Record - Not Found !";
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Production Line Utilisation Record - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Gather_Utilisation_Record()
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                UtilisationId = Convert.ToInt32(UtilisationRecord.Rows[0]["LineUtilisationId"]);
                UtilisationLineId = Convert.ToInt32(UtilisationRecord.Rows[0]["LineUtilisationLineId"]);
                UtilisationWorkDayDate = Convert.ToDateTime(UtilisationRecord.Rows[0]["LineUtilisationWorkDate"]);
                UtilisationLineStarted = Convert.ToDateTime(UtilisationRecord.Rows[0]["LineUtilisationLineStart"].ToString()).TimeOfDay;
                UtilisationLineStopped = Convert.ToDateTime(UtilisationRecord.Rows[0]["LineUtilisationLineStop"].ToString()).TimeOfDay;
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Gather Production Line Utilisation Record - " + ex.Message;
            }

            return isSuccessful;
        }



        // Production Line Entity
        public Int32 ProductionLineId { get; set; }
        public String ProductionLineName { get; set; }
        public System.Data.DataTable ProductionLineRecord { get; set; } = new System.Data.DataTable();
        public System.Data.DataTable ProductionLines { get; set; } = new System.Data.DataTable();


        public Boolean Get_Production_Line(Int32 plId)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                ProductionLineRecord.Clear();

                String strSQL = "SELECT * FROM ProductionLines WHERE ProductionLineId = " + plId.ToString();
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    ProductionLineRecord.Load(rdrGet);
                    isSuccessful = Gather_Production_Line();
                }
                else
                {
                    isSuccessful = false;
                    ErrorMessage = "Get Production Line - production Line with Id " + plId.ToString() + " not found !";
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Production Line - " + ex.Message;
            }

            return isSuccessful;
        }
        private Boolean Gather_Production_Line()
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                ProductionLineId = Convert.ToInt32(ProductionLineRecord.Rows[0]["ProductionLineId"]);
                ProductionLineName = ProductionLineRecord.Rows[0]["Description"].ToString();

            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Gather Production Line - " + ex.Message;
            }

            return isSuccessful;
        }
        public Boolean Get_Production_Lines()
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                ProductionLines.Clear();

                String strSQL = "SELECT * FROM ProductionLines ORDER BY DisplayOrder";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    ProductionLines.Load(rdrGet);
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "Get Production Lines - " + ex.Message;
            }

            return isSuccessful;
        }
    }
}
