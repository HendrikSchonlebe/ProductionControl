﻿using System;
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
    public partial class frmProductionControl : Form
    {
        private System.Data.SqlClient.SqlConnection VPSConnection;
        private String ErrorMessage = string.Empty;
        private Int32 productionLineId = 0;

        public frmProductionControl()
        {
            InitializeComponent();
        }

        private void frmProductionControl_Load(object sender, EventArgs e)
        {
            this.Text = "VPS Production Control Monitor - " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (Connect_To_Database() == true)
            {
                Get_Production_Line();

                // productionLineId = 2;

                if (productionLineId == 0)      // Supervisor Control Panel
                {
                    frmSupervisor myControlPanel = new frmSupervisor();
                    myControlPanel.Size = new Size(this.Width - 50, this.Height - 70);
                    myControlPanel.VPSConnection = VPSConnection;
                    myControlPanel.ShowDialog();
                    this.Close();
                }
                else                            // Production Line Control Panel
                {
                    frmProductionLine myProductionLine = new frmProductionLine();
                    myProductionLine.Size = new Size(this.Width - 50, this.Height - 70);
                    myProductionLine.VPSConnection = VPSConnection;
                    myProductionLine.productionLineId = productionLineId;
                    myProductionLine.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void frmProductionControl_KeyDown(object sender, KeyEventArgs e)
        {
        
        }


        private Boolean Connect_To_Database()
        {
            Boolean isSuccessful = true;
            String StrConnectionString = string.Empty;
            String SQLServer;
            String SQLUserName;
            String SQLPassword;

            // SQLServer = "UNITYSERVER\\SQL2014";
            SQLServer = "LAPTOP-GFF0PAR9\\SQLEXPRESS";
            SQLUserName = "sa";
            SQLPassword = "s3(r3!";
            //SQLServer = "VKC-SQL-01";
            //SQLUserName = "vpsuser";
            //SQLPassword = "vpsuser";

            try
            {
                StrConnectionString = "Data Source=" + SQLServer + ";" + "Initial Catalog=VPSLive;Persist Security Info=False;User ID=" + SQLUserName + ";Password=" + SQLPassword + ";";
                VPSConnection = new System.Data.SqlClient.SqlConnection(StrConnectionString);
                VPSConnection.Open();
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                ErrorMessage = "** Error ** Connecting to SQL Server or Data Base \r\n\r\n" + ex.Message;
            }

            return isSuccessful;
        }
        private void Get_Production_Line()
        {
            productionLineId = 0;

            if (System.IO.File.Exists("C:\\vps\\ProductionLine.ini"))
            {
                string text = System.IO.File.ReadAllText("C:\\vps\\ProductionLine.ini");
                productionLineId = Convert.ToInt32(text);
            }
        }

    }
}