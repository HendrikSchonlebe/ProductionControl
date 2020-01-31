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
    public partial class frmLabelPrint : Form
    {
        public String customerName;
        public String orderNumber;
        public String jobNumber;
        public String colourName;
        public String customerOrder;
        public String labelPrinterName;

        private String myLabel = string.Empty;

        public frmLabelPrint()
        {
            InitializeComponent();
        }

        private void frmLabelPrint_Load(object sender, EventArgs e)
        {
            this.Text = "VPS - Production Line Packing Label Print";
            txtJobDetails.Text = "Customer : " + customerName + "\r\nOrder # : " + orderNumber + "\r\nJob # : " + jobNumber + "\r\nColour : " + colourName;
            cmbFormat.Items.Clear();
            cmbFormat.Items.Add("1 - Pre-Printed");
            cmbFormat.Items.Add("2 - Basic Label");
            cmbFormat.Text = cmbFormat.Items[0].ToString();
            nupdnCount.Value = 1;
            nupdnCount.Focus();
        }

        private void frmLabelPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) & (btnPrint.Visible == true))
                btnPrint_Click(sender, e);
            else if (e.KeyCode == Keys.Escape)
                btnExit_Click(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < nupdnCount.Value; i++)
            {
                if (labelPrinterName.Trim().Length == 0)
                {
                    labelPrinterName = "ZDesigner ZT230-200dpi EPL";
                }
                if (USBPrinterHelper.RawPrinterHelper.SendStringToPrinter(labelPrinterName, myLabel) == false)
                {
                    MessageBox.Show("Printer Error !");
                    break;
                }
            }

            //ZebraUSBPrint.Zebra myPrintJob = new ZebraUSBPrint.Zebra();
            //myPrintJob.labelData = myLabel;

            //for (int i = 0; i < nupdnCount.Value ; i++)
            //{
            //    if (myPrintJob.Print_Label() == false)
            //    {
            //        MessageBox.Show(myPrintJob.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        break;
            //    }
            //}

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nupdnCount_ValueChanged(object sender, EventArgs e)
        {
            if (nupdnCount.Value > 0)
                btnPrint.Visible = true;
            else
                btnPrint.Visible = false;
        }

        private void cmbFormat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (customerName.Trim().Length > 30)
                customerName = customerName.Substring(0, 30);

            if ((labelPrinterName.Trim().Length == 0) | (labelPrinterName.Contains("EPL") == true))
            {
                if (cmbFormat.Text.Substring(0, 1) == "1")
                {
                    myLabel = "N\r\n";
                    myLabel = myLabel + "A140,320,1,4,1,1,N,\"" + colourName.Trim() + "\"\r\n";
                    myLabel = myLabel + "A200,50,1,3,1,1,N,\"______________________________________________________________________________\"\r\n";
                    myLabel = myLabel + "A250,50,1,3,1,1,N,\"______________________________________________________________________________\"\r\n";
                    myLabel = myLabel + "A300,50,1,3,1,1,N,\"______________________________________________________________________________\"\r\n";
                    myLabel = myLabel + "A350,50,1,3,1,1,N,\"______________________________________________________________________________\"\r\n";
                    myLabel = myLabel + "A400,50,1,3,1,1,N,\"______________________________________________________________________________\"\r\n";
                    myLabel = myLabel + "A450,50,1,3,1,1,N,\"______________________________________________________________________________\"\r\n";
                    myLabel = myLabel + "A560,310,1,3,2,2,N,\"" + customerOrder.Trim() + "\"\r\n";
                    myLabel = myLabel + "A560,900,1,3,2,2,N,\"" + orderNumber.Trim() + "\"\r\n";
                    myLabel = myLabel + "A610,350,1,3,2,2,N,\"" + customerName.Trim() + "\"\r\n";
                    myLabel = myLabel + "P1\r\n";
                }
                else if (cmbFormat.Text.Substring(0, 1) == "2")
                {
                    myLabel = "N\r\n";
                    myLabel = myLabel + "A20,50,1,3,1,1,N,\"** GOODS MUST BE STORED AWAY FROM DIRECT SUNLIGHT IN A DRY VENTILATED AREA **\"\r\n";
                    myLabel = myLabel + "A80,50,1,3,2,2,R,\"Packed By :\"\r\n";
                    myLabel = myLabel + "A80,370,1,3,2,2,N,\"________\"\r\n";
                    myLabel = myLabel + "A80,630,1,3,2,2,R,\"Checked By:\"\r\n";
                    myLabel = myLabel + "A80,950,1,3,2,2,N,\"_________\"\r\n";
                    myLabel = myLabel + "A130,50,1,3,2,2,R,\"Colour :\"\r\n";
                    myLabel = myLabel + "A130,320,1,4,1,1,N,\"" + colourName.Trim() + "\"\r\n";
                    myLabel = myLabel + "A180,50,1,3,1,1,N,\"______________________________\"\r\n";
                    myLabel = myLabel + "A180,500,1,3,1,1,N,\"_________________________\"\r\n";
                    myLabel = myLabel + "A180,900,1,3,1,1,N,\"__________________\"\r\n";
                    myLabel = myLabel + "A250,50,1,3,1,1,N,\"______________________________\"\r\n";
                    myLabel = myLabel + "A250,500,1,3,1,1,N,\"_________________________\"\r\n";
                    myLabel = myLabel + "A250,900,1,3,1,1,N,\"__________________\"\r\n";
                    myLabel = myLabel + "A320,50,1,3,1,1,N,\"______________________________\"\r\n";
                    myLabel = myLabel + "A320,500,1,3,1,1,N,\"_________________________\"\r\n";
                    myLabel = myLabel + "A320,900,1,3,1,1,N,\"__________________\"\r\n";
                    myLabel = myLabel + "A390,50,1,3,1,1,N,\"______________________________\"\r\n";
                    myLabel = myLabel + "A390,500,1,3,1,1,N,\"_________________________\"\r\n";
                    myLabel = myLabel + "A390,900,1,3,1,1,N,\"__________________\"\r\n";
                    myLabel = myLabel + "A460,50,1,3,1,1,N,\"______________________________\"\r\n";
                    myLabel = myLabel + "A460,500,1,3,1,1,N,\"_________________________\"\r\n";
                    myLabel = myLabel + "A460,900,1,3,1,1,N,\"__________________\"\r\n";
                    myLabel = myLabel + "A530,50,1,4,1,1,R,\"Item :\"\r\n";
                    myLabel = myLabel + "A530,500,1,4,1,1,R,\"Qty :\"\r\n";
                    myLabel = myLabel + "A530,900,1,4,1,1,R,\"Length :\"\r\n";
                    myLabel = myLabel + "A600,50,1,3,2,2,R,\"Skip/Case:\"\r\n";
                    myLabel = myLabel + "A600,350,1,3,2,2,N,\"______\"\r\n";
                    myLabel = myLabel + "A600,550,1,3,2,2,R,\"Pack:\"\r\n";
                    myLabel = myLabel + "A600,700,1,3,2,2,N,\"______\"\r\n";
                    myLabel = myLabel + "A600,900,1,3,2,2,R,\"Of:\"\r\n";
                    myLabel = myLabel + "A600,990,1,3,2,2,N,\"______\"\r\n";
                    myLabel = myLabel + "A650,50,1,3,2,2,R,\"Order No.:\"\r\n";
                    myLabel = myLabel + "A650,350,1,3,2,2,N,\"" + customerOrder.Trim() + "\"\r\n";
                    myLabel = myLabel + "A650,650,1,3,2,2,R,\"Job No.:\"\r\n";
                    myLabel = myLabel + "A650,900,1,3,2,2,N,\"" + jobNumber.Trim() + "\"\r\n";
                    myLabel = myLabel + "A700,50,1,3,2,2,R,\"Customer :\"\r\n";
                    myLabel = myLabel + "A700,350,1,3,2,2,N,\"" + customerName.Trim() + "\"\r\n";
                    myLabel = myLabel + "A780,80,1,3,3,3,N,\"Vertikote Powder Coating\"\r\n";
                    myLabel = myLabel + "P1\r\n";
                }
                else
                {
                    myLabel = "^XA";
                    myLabel = myLabel + "^FO730,80^ADR,32,32^FDVERTIKOTE Powder Coating^FS";
                    myLabel = myLabel + "^FO680,10^ADR,15,15^FDCustomer:^FS";
                    myLabel = myLabel + "^FO680,250^ADR,15,15^FD" + customerName.Trim() + "^FS";
                    myLabel = myLabel + "^FO630,10^ADR,15,15^FDOrder No:^FS";
                    myLabel = myLabel + "^FO630,260^ADR,15,15^FD" + customerOrder.Trim() + "^FS";
                    myLabel = myLabel + "^FO630,510^ADR,15,15^FDJob No:^FS";
                    myLabel = myLabel + "^FO630,690^ADR,15,15^FD" + jobNumber.Trim() + "^FS";
                    myLabel = myLabel + "^FO580,10^ADR,15,15^FDSkip/Case No:             Packs     of    ^FS";
                    myLabel = myLabel + "^FO500,10^ADR,15,15^FDItem:                     Qty:     Length:^FS";
                    myLabel = myLabel + "^FO450,10^ADR,15,15^FD........................  .......  .......^FS";
                    myLabel = myLabel + "^FO400,10^ADR,15,15^FD........................  .......  .......^FS";
                    myLabel = myLabel + "^FO350,10^ADR,15,15^FD........................  .......  .......^FS";
                    myLabel = myLabel + "^FO300,10^ADR,15,15^FD........................  .......  .......^FS";
                    myLabel = myLabel + "^FO250,10^ADR,15,15^FD........................  .......  .......^FS";
                    myLabel = myLabel + "^FO200,10^ADR,15,15^FDColour:^FS";
                    myLabel = myLabel + "^FO200,190^ADR,15,15^FD" + colourName.Trim() + "^FS";
                    myLabel = myLabel + "^FO100,10^ADR,15,15^FDPacked By:          Checked By:           ^FS";
                    myLabel = myLabel + "^FO50,10^ADR,12,12^FD** GOODS MUST BE STORED AWAY FROM DIRECT SUNLIGHT IN A DRY VENTILATED AREA **^FS";
                    myLabel = myLabel + "~TA-30";
                    myLabel = myLabel + "^XZ";
                }
            }
        }
    }
}
