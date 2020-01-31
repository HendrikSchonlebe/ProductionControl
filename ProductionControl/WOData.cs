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

    }
}
