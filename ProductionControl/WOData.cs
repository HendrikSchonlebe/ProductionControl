using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionControl
{
    class WOData
    {
        // Data Base Connection
        public System.Data.SqlClient.SqlConnection myVPSConnection { get; set; }

        // Error Message
        public String ErrorMessage { get; set; }

        // Data
        public String CustomerName { get; set; }
        public Int32 WorkOrderId { get; set; }
        public Int32 UserId { get; set; }

        // Work Order Entity
        public Boolean Get_WorkOrder(Int32 woID)
        {
            Boolean isSuccessful = true;
            System.Data.DataTable myWO = new System.Data.DataTable();

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT WorkOrders.*, Customers.CustomerName FROM WorkOrders ";
                strSQL = strSQL + "INNER JOIN Customers ON WorkOrders.CustomerId = Customers.CustomerId ";
                strSQL = strSQL + "WHERE WorkOrderId = " + woID.ToString();
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myWO.Load(rdrGet);
                    WorkOrderId = Convert.ToInt32(myWO.Rows[0]["WorkOrderId"]);
                    UserId = Convert.ToInt32(myWO.Rows[0]["UserId"]);
                    if (myWO.Rows[0]["CustomerName"].ToString().ToUpper().Contains("CASH SALE"))
                        CustomerName = myWO.Rows[0]["Comments"].ToString().Trim() + " - Cash Sale";
                    else
                        CustomerName = myWO.Rows[0]["CustomerName"].ToString();
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                ErrorMessage = "Get Work Order - " + ex.Message;
                isSuccessful = false;
            }

            return isSuccessful;
        }
        public Boolean Get_WorkOrder(String woNumber)
        {
            Boolean isSuccessful = true;
            System.Data.DataTable myWO = new System.Data.DataTable();

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "SELECT WorkOrders.*, Customers.CustomerName FROM WorkOrders ";
                strSQL = strSQL + "INNER JOIN Customers ON WorkOrders.CustomerId = Customers.CustomerId ";
                strSQL = strSQL + "WHERE WorkOrderNo = '" + woNumber + "'";
                System.Data.SqlClient.SqlCommand cmdGet = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection);
                System.Data.SqlClient.SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    myWO.Load(rdrGet);
                    WorkOrderId = Convert.ToInt32(myWO.Rows[0]["WorkOrderId"]);
                    UserId = Convert.ToInt32(myWO.Rows[0]["UserId"]);
                    if (myWO.Rows[0]["CustomerName"].ToString().ToUpper().Contains("CASH SALE"))
                        CustomerName = myWO.Rows[0]["Comments"].ToString().Trim() + " - Cash Sale";
                    else
                        CustomerName = myWO.Rows[0]["CustomerName"].ToString();
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                ErrorMessage = "Get Work Order - " + ex.Message;
                isSuccessful = false;
            }

            return isSuccessful;
        }
        public Boolean Update_Work_Order_Status(String woNumber, String woStatus, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "UPDATE WorkOrders SET OrderStatus = '" + woStatus + "' WHERE WorkOrderNo = '" + woNumber + "'";
                System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorMessage = "Update Work Order Status - " + ex.Message;
                isSuccessful = false;
            }

            return isSuccessful;
        }
        public Boolean Insert_WorkOrder_Comment(Int32 woId, Int32 woUserId, String woComment, System.Data.SqlClient.SqlTransaction trnEnvelope)
        {
            Boolean isSuccessful = true;

            ErrorMessage = string.Empty;

            try
            {
                String strSQL = "INSERT INTO WorkOrderComments (";
                strSQL += "WorkOrderId, ";
                strSQL += "UserId, ";
                strSQL += "DateEntered, ";
                strSQL += "Comments, ";
                strSQL += "Private, ";
                strSQL += "JobCardOnly) VALUES (";
                strSQL += woId.ToString() + ",";
                strSQL += woUserId.ToString() + ",";
                strSQL += "CONVERT(dateTime, '" + DateTime.Now.ToString() + "', 103), ";
                strSQL += "'" + woComment + "',";
                strSQL += "'True',";
                strSQL += "'False')";

                System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand(strSQL, myVPSConnection, trnEnvelope);
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorMessage = "Insert Work Order Comment - " + ex.Message;
                isSuccessful = false;
            }

            return isSuccessful;
        }

    }
}
