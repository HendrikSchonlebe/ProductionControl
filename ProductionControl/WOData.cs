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

        // Work Order Entity

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
