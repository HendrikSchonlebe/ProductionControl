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
    public partial class frmLabelSelect : Form
    {
        public JOBData myJobData;
        public String customerName;
        public String orderNumber;
        public String jobNumber;
        public String colourName;
        public String customerOrder;
        public String labelPrinterName;
        public Int32 productionLineId;

        private List<LabelObject> myLabels = new List<LabelObject>();
        private String myLabel = string.Empty;
        private Int32 labelQuantity = 0;


        public frmLabelSelect()
        {
            InitializeComponent();
        }

        private void frmLabelSelect_Load(object sender, EventArgs e)
        {
            this.Text = "VPS - Production Line Packing Label Print";
            txtJobDetails.Text = "Customer : " + customerName + "\r\nOrder # : " + orderNumber + "\r\nJob # : " + jobNumber + "\r\nColour : " + colourName;
            cmbFormat.Items.Clear();
            cmbFormat.Items.Add("1 - Pre-Printed");
            cmbFormat.Items.Add("2 - Basic Label");
            cmbFormat.Text = cmbFormat.Items[0].ToString();
            Form_Clear();

            if (myJobData.Get_Job(jobNumber.ToString(), productionLineId) == true)
            {
                if (myJobData.Get_Job_Details(myJobData.JobId) == true)
                {
                    dgParts.Rows.Clear();
                    for (int i = 0; i < myJobData.myJobDetails.Rows.Count; i++)
                    {
                        String[] thisPart = myJobData.myJobDetails.Rows[i]["PartDescription"].ToString().Split('*');
                        String thisPartGuid = Guid.NewGuid().ToString();
                        dgParts.Rows.Add(myJobData.myJobDetails.Rows[i]["PartCode"].ToString(), thisPart[0].Trim(), Convert.ToDouble(myJobData.myJobDetails.Rows[i]["Properties_Length"]), Convert.ToInt32(myJobData.myJobDetails.Rows[i]["Qty"]), Convert.ToInt32(myJobData.myJobDetails.Rows[i]["Qty"]), thisPartGuid);
                    }
                }
                else
                {
                    MessageBox.Show(myJobData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(myJobData.ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmLabelSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void cmbFormat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbFormat.Text.Substring(0, 1) == "1")
            {
                txtPartDescription16.Visible = true;
                txtPartLength16.Visible = true;
                txtQuantity16.Visible = true;
                btnClear16.Visible = true;
                txtPartDescription26.Visible = true;
                txtPartLength26.Visible = true;
                txtQuantity26.Visible = true;
                btnClear26.Visible = true;
                txtPartDescription36.Visible = true;
                txtPartLength36.Visible = true;
                txtQuantity36.Visible = true;
                btnClear36.Visible = true;
                txtPartDescription46.Visible = true;
                txtPartLength46.Visible = true;
                txtQuantity46.Visible = true;
                btnClear46.Visible = true;
                txtPartDescription56.Visible = true;
                txtPartLength56.Visible = true;
                txtQuantity56.Visible = true;
                btnClear56.Visible = true;
            }
            else
            {
                txtPartDescription16.Visible = false;
                txtPartLength16.Visible = false;
                txtQuantity16.Visible = false;
                btnClear16.Visible = false;
                txtPartDescription26.Visible = false;
                txtPartLength26.Visible = false;
                txtQuantity26.Visible = false;
                btnClear26.Visible = false;
                txtPartDescription36.Visible = false;
                txtPartLength36.Visible = false;
                txtQuantity36.Visible = false;
                btnClear36.Visible = false;
                txtPartDescription46.Visible = false;
                txtPartLength46.Visible = false;
                txtQuantity46.Visible = false;
                btnClear46.Visible = false;
                txtPartDescription56.Visible = false;
                txtPartLength56.Visible = false;
                txtQuantity56.Visible = false;
                btnClear56.Visible = false;
            }
        }
        private void Form_Clear()
        {
            myLabels.Clear();           // Clear Label Objects List

            // Clear Label Items
            txtPartDescription11.Text = string.Empty;
            txtPartLength11.Text = string.Empty;
            txtQuantity11.Text = "0";
            txtGUID11.Text = string.Empty;
            txtPartDescription12.Text = string.Empty;
            txtPartLength12.Text = string.Empty;
            txtQuantity12.Text = "0";
            txtGUID12.Text = string.Empty;
            txtPartDescription13.Text = string.Empty;
            txtPartLength13.Text = string.Empty;
            txtQuantity13.Text = "0";
            txtGUID13.Text = string.Empty;
            txtPartDescription14.Text = string.Empty;
            txtPartLength14.Text = string.Empty;
            txtQuantity14.Text = "0";
            txtGUID14.Text = string.Empty;
            txtPartDescription15.Text = string.Empty;
            txtPartLength15.Text = string.Empty;
            txtQuantity15.Text = "0";
            txtGUID15.Text = string.Empty;
            txtPartDescription16.Text = string.Empty;
            txtPartLength16.Text = string.Empty;
            txtQuantity16.Text = "0";
            txtGUID16.Text = string.Empty;

            txtPartDescription21.Text = string.Empty;
            txtPartLength21.Text = string.Empty;
            txtQuantity21.Text = "0";
            txtGUID21.Text = string.Empty;
            txtPartDescription22.Text = string.Empty;
            txtPartLength22.Text = string.Empty;
            txtQuantity22.Text = "0";
            txtGUID22.Text = string.Empty;
            txtPartDescription23.Text = string.Empty;
            txtPartLength23.Text = string.Empty;
            txtQuantity23.Text = "0";
            txtGUID23.Text = string.Empty;
            txtPartDescription24.Text = string.Empty;
            txtPartLength24.Text = string.Empty;
            txtQuantity24.Text = "0";
            txtGUID24.Text = string.Empty;
            txtPartDescription25.Text = string.Empty;
            txtPartLength25.Text = string.Empty;
            txtQuantity25.Text = "0";
            txtGUID25.Text = string.Empty;
            txtPartDescription26.Text = string.Empty;
            txtPartLength26.Text = string.Empty;
            txtQuantity26.Text = "0";
            txtGUID26.Text = string.Empty;

            txtPartDescription31.Text = string.Empty;
            txtPartLength31.Text = string.Empty;
            txtQuantity31.Text = "0";
            txtGUID31.Text = string.Empty;
            txtPartDescription32.Text = string.Empty;
            txtPartLength32.Text = string.Empty;
            txtQuantity32.Text = "0";
            txtGUID32.Text = string.Empty;
            txtPartDescription33.Text = string.Empty;
            txtPartLength33.Text = string.Empty;
            txtQuantity33.Text = "0";
            txtGUID33.Text = string.Empty;
            txtPartDescription34.Text = string.Empty;
            txtPartLength34.Text = string.Empty;
            txtQuantity34.Text = "0";
            txtGUID34.Text = string.Empty;
            txtPartDescription35.Text = string.Empty;
            txtPartLength35.Text = string.Empty;
            txtQuantity35.Text = "0";
            txtGUID35.Text = string.Empty;
            txtPartDescription36.Text = string.Empty;
            txtPartLength36.Text = string.Empty;
            txtQuantity36.Text = "0";
            txtGUID36.Text = string.Empty;

            txtPartDescription41.Text = string.Empty;
            txtPartLength41.Text = string.Empty;
            txtQuantity41.Text = "0";
            txtGUID41.Text = string.Empty;
            txtPartDescription42.Text = string.Empty;
            txtPartLength42.Text = string.Empty;
            txtQuantity42.Text = "0";
            txtGUID42.Text = string.Empty;
            txtPartDescription43.Text = string.Empty;
            txtPartLength43.Text = string.Empty;
            txtQuantity43.Text = "0";
            txtGUID43.Text = string.Empty;
            txtPartDescription44.Text = string.Empty;
            txtPartLength44.Text = string.Empty;
            txtQuantity44.Text = "0";
            txtGUID44.Text = string.Empty;
            txtPartDescription45.Text = string.Empty;
            txtPartLength45.Text = string.Empty;
            txtQuantity45.Text = "0";
            txtGUID45.Text = string.Empty;
            txtPartDescription46.Text = string.Empty;
            txtPartLength46.Text = string.Empty;
            txtQuantity46.Text = "0";
            txtGUID46.Text = string.Empty;

            txtPartDescription51.Text = string.Empty;
            txtPartLength51.Text = string.Empty;
            txtQuantity51.Text = "0";
            txtGUID51.Text = string.Empty;
            txtPartDescription52.Text = string.Empty;
            txtPartLength52.Text = string.Empty;
            txtQuantity52.Text = "0";
            txtGUID52.Text = string.Empty;
            txtPartDescription53.Text = string.Empty;
            txtPartLength53.Text = string.Empty;
            txtQuantity53.Text = "0";
            txtGUID53.Text = string.Empty;
            txtPartDescription54.Text = string.Empty;
            txtPartLength54.Text = string.Empty;
            txtQuantity54.Text = "0";
            txtGUID54.Text = string.Empty;
            txtPartDescription55.Text = string.Empty;
            txtPartLength55.Text = string.Empty;
            txtQuantity55.Text = "0";
            txtGUID55.Text = string.Empty;
            txtPartDescription56.Text = string.Empty;
            txtPartLength56.Text = string.Empty;
            txtQuantity56.Text = "0";
            txtGUID56.Text = string.Empty;

            Form_Validate();
        }
        private void Form_Validate()
        {
            Boolean somethingToPrint = false;

            if (txtPartDescription11.Text.Trim().Length > 0)
            {
                txtQuantity11.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity11.Enabled = false;
            if (txtPartDescription12.Text.Trim().Length > 0)
            {
                txtQuantity12.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity12.Enabled = false;
            if (txtPartDescription13.Text.Trim().Length > 0)
            {
                txtQuantity13.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity13.Enabled = false;
            if (txtPartDescription14.Text.Trim().Length > 0)
            {
                txtQuantity14.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity14.Enabled = false;
            if (txtPartDescription15.Text.Trim().Length > 0)
            {
                txtQuantity15.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity15.Enabled = false;
            if (txtPartDescription16.Text.Trim().Length > 0)
            {
                txtQuantity16.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity16.Enabled = false;

            if (txtPartDescription21.Text.Trim().Length > 0)
            {
                txtQuantity21.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity21.Enabled = false;
            if (txtPartDescription22.Text.Trim().Length > 0)
            {
                txtQuantity22.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity22.Enabled = false;
            if (txtPartDescription23.Text.Trim().Length > 0)
            {
                txtQuantity23.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity23.Enabled = false;
            if (txtPartDescription24.Text.Trim().Length > 0)
            {
                txtQuantity24.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity24.Enabled = false;
            if (txtPartDescription25.Text.Trim().Length > 0)
            {
                txtQuantity25.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity25.Enabled = false;
            if (txtPartDescription26.Text.Trim().Length > 0)
            {
                txtQuantity26.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity26.Enabled = false;

            if (txtPartDescription31.Text.Trim().Length > 0)
            {
                txtQuantity31.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity31.Enabled = false;
            if (txtPartDescription32.Text.Trim().Length > 0)
            {
                txtQuantity32.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity32.Enabled = false;
            if (txtPartDescription33.Text.Trim().Length > 0)
            {
                txtQuantity33.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity33.Enabled = false;
            if (txtPartDescription34.Text.Trim().Length > 0)
            {
                txtQuantity34.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity34.Enabled = false;
            if (txtPartDescription35.Text.Trim().Length > 0)
            {
                txtQuantity35.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity35.Enabled = false;
            if (txtPartDescription36.Text.Trim().Length > 0)
            {
                txtQuantity36.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity36.Enabled = false;

            if (txtPartDescription41.Text.Trim().Length > 0)
            {
                txtQuantity41.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity41.Enabled = false;
            if (txtPartDescription42.Text.Trim().Length > 0)
            {
                txtQuantity42.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity42.Enabled = false;
            if (txtPartDescription43.Text.Trim().Length > 0)
            {
                txtQuantity43.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity43.Enabled = false;
            if (txtPartDescription44.Text.Trim().Length > 0)
            {
                txtQuantity44.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity44.Enabled = false;
            if (txtPartDescription45.Text.Trim().Length > 0)
            {
                txtQuantity45.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity45.Enabled = false;
            if (txtPartDescription46.Text.Trim().Length > 0)
            {
                txtQuantity46.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity46.Enabled = false;

            if (txtPartDescription51.Text.Trim().Length > 0)
            {
                txtQuantity51.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity51.Enabled = false;
            if (txtPartDescription52.Text.Trim().Length > 0)
            {
                txtQuantity52.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity52.Enabled = false;
            if (txtPartDescription53.Text.Trim().Length > 0)
            {
                txtQuantity53.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity53.Enabled = false;
            if (txtPartDescription55.Text.Trim().Length > 0)
            {
                txtQuantity55.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity55.Enabled = false;
            if (txtPartDescription55.Text.Trim().Length > 0)
            {
                txtQuantity55.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity55.Enabled = false;
            if (txtPartDescription56.Text.Trim().Length > 0)
            {
                txtQuantity56.Enabled = true;
                somethingToPrint = true;
            }
            else
                txtQuantity56.Enabled = false;


            btnPrint.Visible = somethingToPrint;
        }


        private void dgParts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Assign_Item(tabLabels.SelectedIndex + 1, e.RowIndex);
            }
        }

        private void Assign_Item(Int32 labelIndex, Int32 gridRow)
        {
            if (labelIndex == 1)
            {
                if (Is_Already_On_Label(labelIndex, gridRow) == false)
                {
                    if (txtPartDescription11.Text.Trim().Length <= 0)
                    {
                        txtPartDescription11.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength11.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity11.Text = "0";
                        txtGUID11.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription12.Text.Trim().Length <= 0)
                    {
                        txtPartDescription12.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength12.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity12.Text = "0";
                        txtGUID12.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription13.Text.Trim().Length <= 0)
                    {
                        txtPartDescription13.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength13.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity13.Text = "0";
                        txtGUID13.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription14.Text.Trim().Length <= 0)
                    {
                        txtPartDescription14.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength14.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity14.Text = "0";
                        txtGUID14.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription15.Text.Trim().Length <= 0)
                    {
                        txtPartDescription15.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength15.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity15.Text = "0";
                        txtGUID15.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription16.Text.Trim().Length <= 0)
                    {
                        txtPartDescription16.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength16.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity16.Text = "0";
                        txtGUID16.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nMaximum Line Count reached.\r\nUse another Label !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Form_Validate();
                }
                else
                {
                    MessageBox.Show("** Operator **\r\n\r\nItem : " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString() + "\r\nLength " + Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3") + "\r\nIs already on this Label !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (labelIndex == 2)
            {
                if (Is_Already_On_Label(labelIndex, gridRow) == false)
                {
                    if (txtPartDescription21.Text.Trim().Length <= 0)
                    {
                        txtPartDescription21.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength21.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity21.Text = "0";
                        txtGUID21.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription22.Text.Trim().Length <= 0)
                    {
                        txtPartDescription22.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength22.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity22.Text = "0";
                        txtGUID22.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription23.Text.Trim().Length <= 0)
                    {
                        txtPartDescription23.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength23.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity23.Text = "0";
                        txtGUID23.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription24.Text.Trim().Length <= 0)
                    {
                        txtPartDescription24.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength24.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity24.Text = "0";
                        txtGUID24.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription25.Text.Trim().Length <= 0)
                    {
                        txtPartDescription25.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength25.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity25.Text = "0";
                        txtGUID25.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription26.Text.Trim().Length <= 0)
                    {
                        txtPartDescription26.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength26.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity26.Text = "0";
                        txtGUID26.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nMaximum Line Count reached.\r\nUse another Label !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Form_Validate();
                }
            }
            else if (labelIndex == 3)
            {
                if (Is_Already_On_Label(labelIndex, gridRow) == false)
                {
                    if (txtPartDescription31.Text.Trim().Length <= 0)
                    {
                        txtPartDescription31.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength31.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity31.Text = "0";
                        txtGUID31.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription32.Text.Trim().Length <= 0)
                    {
                        txtPartDescription32.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength32.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity32.Text = "0";
                        txtGUID32.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription33.Text.Trim().Length <= 0)
                    {
                        txtPartDescription33.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength33.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity33.Text = "0";
                        txtGUID33.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription34.Text.Trim().Length <= 0)
                    {
                        txtPartDescription34.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength34.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity34.Text = "0";
                        txtGUID34.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription35.Text.Trim().Length <= 0)
                    {
                        txtPartDescription35.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength35.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity35.Text = "0";
                        txtGUID35.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription36.Text.Trim().Length <= 0)
                    {
                        txtPartDescription36.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength36.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity36.Text = "0";
                        txtGUID36.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nMaximum Line Count reached.\r\nUse another Label !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Form_Validate();
                }
            }
            else if (labelIndex == 4)
            {
                if (Is_Already_On_Label(labelIndex, gridRow) == false)
                {
                    if (txtPartDescription41.Text.Trim().Length <= 0)
                    {
                        txtPartDescription41.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength41.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity41.Text = "0";
                        txtGUID41.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription42.Text.Trim().Length <= 0)
                    {
                        txtPartDescription42.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength42.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity42.Text = "0";
                        txtGUID42.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription43.Text.Trim().Length <= 0)
                    {
                        txtPartDescription43.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength43.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity43.Text = "0";
                        txtGUID43.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription44.Text.Trim().Length <= 0)
                    {
                        txtPartDescription44.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength44.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity44.Text = "0";
                        txtGUID44.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription45.Text.Trim().Length <= 0)
                    {
                        txtPartDescription45.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength45.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity45.Text = "0";
                        txtGUID45.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription46.Text.Trim().Length <= 0)
                    {
                        txtPartDescription46.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength46.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity46.Text = "0";
                        txtGUID46.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nMaximum Line Count reached.\r\nUse another Label !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Form_Validate();
                }
            }
            else if (labelIndex == 5)
            {
                if (Is_Already_On_Label(labelIndex, gridRow) == false)
                {
                    if (txtPartDescription51.Text.Trim().Length <= 0)
                    {
                        txtPartDescription51.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength51.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity51.Text = "0";
                        txtGUID51.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription52.Text.Trim().Length <= 0)
                    {
                        txtPartDescription52.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength52.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity52.Text = "0";
                        txtGUID52.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription53.Text.Trim().Length <= 0)
                    {
                        txtPartDescription53.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength53.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity53.Text = "0";
                        txtGUID53.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription54.Text.Trim().Length <= 0)
                    {
                        txtPartDescription54.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength54.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity54.Text = "0";
                        txtGUID54.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription55.Text.Trim().Length <= 0)
                    {
                        txtPartDescription55.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength55.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity55.Text = "0";
                        txtGUID55.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else if (txtPartDescription56.Text.Trim().Length <= 0)
                    {
                        txtPartDescription56.Text = dgParts.Rows[gridRow].Cells["PartCode"].Value.ToString() + " " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString();
                        txtPartLength56.Text = Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3");
                        txtQuantity56.Text = "0";
                        txtGUID56.Text = dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nMaximum Line Count reached.\r\nUse another Label !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Form_Validate();
                }
                else
                {
                    MessageBox.Show("** Operator **\r\n\r\nItem : " + dgParts.Rows[gridRow].Cells["PartDescription"].Value.ToString() + "\r\nLength " + Convert.ToDouble(dgParts.Rows[gridRow].Cells["Length"].Value).ToString("N3") + "\r\nIs already on this Label !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private Boolean Is_Already_On_Label(Int32 labelIndex, Int32 gridRow)
        {
            Boolean isAlreadyOn = false;

            if (labelIndex == 1)
            {
                if (txtGUID11.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID12.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID13.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID14.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID15.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID16.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
            }
            else if (labelIndex == 2)
            {
                if (txtGUID21.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID22.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID23.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID24.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID25.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID26.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
            }
            else if (labelIndex == 3)
            {
                if (txtGUID31.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID32.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID33.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID34.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID35.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID36.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
            }
            else if (labelIndex == 4)
            {
                if (txtGUID41.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID42.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID43.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID44.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID45.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID46.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
            }
            else if (labelIndex == 5)
            {
                if (txtGUID51.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID52.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID53.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID54.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID55.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
                else if (txtGUID56.Text == dgParts.Rows[gridRow].Cells["PartGUID"].Value.ToString())
                    isAlreadyOn = true;
            }

            return isAlreadyOn;
        }


        private void btnClear11_Click(object sender, EventArgs e)
        {
            if (txtQuantity11.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity11.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity11.Text);
                    Change_Remaining(txtGUID11.Text, labelQuantity);
                    txtPartDescription11.Text = string.Empty;
                    txtPartLength11.Text = string.Empty;
                    txtQuantity11.Text = "0";
                    txtGUID11.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity11_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity11.Text);
            Change_Remaining(txtGUID11.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity11_Leave(object sender, EventArgs e)
        {
            if (txtQuantity11.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity11.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity11.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID11.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID11.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity11.Text = "0";
                        txtQuantity11.Focus();
                    }
                }
            }
        }
        private void btnClear12_Click(object sender, EventArgs e)
        {
            if (txtQuantity12.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity12.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity12.Text);
                    Change_Remaining(txtGUID12.Text, labelQuantity);
                    txtPartDescription12.Text = string.Empty;
                    txtPartLength12.Text = string.Empty;
                    txtQuantity12.Text = "0";
                    txtGUID12.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity12_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity12.Text);
            Change_Remaining(txtGUID12.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity12_Leave(object sender, EventArgs e)
        {
            if (txtQuantity12.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity12.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity12.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID12.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID12.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity12.Text = "0";
                        txtQuantity12.Focus();
                    }
                }
            }
        }
        private void btnClear13_Click(object sender, EventArgs e)
        {
            if (txtQuantity13.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity13.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity13.Text);
                    Change_Remaining(txtGUID13.Text, labelQuantity);
                    txtPartDescription13.Text = string.Empty;
                    txtPartLength13.Text = string.Empty;
                    txtQuantity13.Text = "0";
                    txtGUID13.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity13_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity13.Text);
            Change_Remaining(txtGUID13.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity13_Leave(object sender, EventArgs e)
        {
            if (txtQuantity13.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity13.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity13.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID13.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID13.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity13.Text = "0";
                        txtQuantity13.Focus();
                    }
                }
            }
        }
        private void btnClear14_Click(object sender, EventArgs e)
        {
            if (txtQuantity14.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity14.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity14.Text);
                    Change_Remaining(txtGUID14.Text, labelQuantity);
                    txtPartDescription14.Text = string.Empty;
                    txtPartLength14.Text = string.Empty;
                    txtQuantity14.Text = "0";
                    txtGUID14.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity14_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity14.Text);
            Change_Remaining(txtGUID14.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity14_Leave(object sender, EventArgs e)
        {
            if (txtQuantity14.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity14.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity14.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID14.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID14.Text,  -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity14.Text = "0";
                        txtQuantity14.Focus();
                    }
                }
            }
        }
        private void btnClear15_Click(object sender, EventArgs e)
        {
            if (txtQuantity15.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity15.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity15.Text);
                    Change_Remaining(txtGUID15.Text, labelQuantity);
                    txtPartDescription15.Text = string.Empty;
                    txtPartLength15.Text = string.Empty;
                    txtQuantity15.Text = "0";
                    txtGUID15.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity15_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity15.Text);
            Change_Remaining(txtGUID15.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");

        }
        private void txtQuantity15_Leave(object sender, EventArgs e)
        {
            if (txtQuantity15.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity15.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity15.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID15.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID15.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity15.Text = "0";
                        txtQuantity15.Focus();
                    }
                }
            }
        }
        private void btnClear16_Click(object sender, EventArgs e)
        {
            if (txtQuantity16.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity16.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity16.Text);
                    Change_Remaining(txtGUID16.Text, labelQuantity);
                    txtPartDescription16.Text = string.Empty;
                    txtPartLength16.Text = string.Empty;
                    txtQuantity16.Text = "0";
                    txtGUID16.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity16_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity16.Text);
            Change_Remaining(txtGUID16.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity16_Leave(object sender, EventArgs e)
        {
            if (txtQuantity16.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity16.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity16.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID16.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID16.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity16.Text = "0";
                        txtQuantity16.Focus();
                    }
                }
            }
        }
        private void btnClear21_Click(object sender, EventArgs e)
        {
            if (txtQuantity21.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity21.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity21.Text);
                    Change_Remaining(txtGUID21.Text, labelQuantity);
                    txtPartDescription21.Text = string.Empty;
                    txtPartLength21.Text = string.Empty;
                    txtQuantity21.Text = "0";
                    txtGUID21.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity21_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity21.Text);
            Change_Remaining(txtGUID21.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity21_Leave(object sender, EventArgs e)
        {
            if (txtQuantity21.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity21.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity21.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID21.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID21.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity21.Text = "0";
                        txtQuantity21.Focus();
                    }
                }
            }
        }
        private void btnClear22_Click(object sender, EventArgs e)
        {
            if (txtQuantity22.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity22.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity22.Text);
                    Change_Remaining(txtGUID22.Text, labelQuantity);
                    txtPartDescription22.Text = string.Empty;
                    txtPartLength22.Text = string.Empty;
                    txtQuantity22.Text = "0";
                    txtGUID22.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity22_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity22.Text);
            Change_Remaining(txtGUID22.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity22_Leave(object sender, EventArgs e)
        {
            if (txtQuantity22.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity22.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity22.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID22.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID22.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity22.Text = "0";
                        txtQuantity22.Focus();
                    }
                }
            }
        }
        private void btnClear23_Click(object sender, EventArgs e)
        {
            if (txtQuantity23.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity23.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity23.Text);
                    Change_Remaining(txtGUID23.Text, labelQuantity);
                    txtPartDescription23.Text = string.Empty;
                    txtPartLength23.Text = string.Empty;
                    txtQuantity23.Text = "0";
                    txtGUID23.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity23_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity23.Text);
            Change_Remaining(txtGUID23.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity23_Leave(object sender, EventArgs e)
        {
            if (txtQuantity23.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity23.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity23.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID23.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID23.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity23.Text = "0";
                        txtQuantity23.Focus();
                    }
                }
            }
        }
        private void btnClear24_Click(object sender, EventArgs e)
        {
            if (txtQuantity24.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity24.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity24.Text);
                    Change_Remaining(txtGUID24.Text, labelQuantity);
                    txtPartDescription24.Text = string.Empty;
                    txtPartLength24.Text = string.Empty;
                    txtQuantity24.Text = "0";
                    txtGUID24.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity24_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity24.Text);
            Change_Remaining(txtGUID24.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity24_Leave(object sender, EventArgs e)
        {
            if (txtQuantity24.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity24.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity24.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID24.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID24.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity24.Text = "0";
                        txtQuantity24.Focus();
                    }
                }
            }
        }
        private void btnClear25_Click(object sender, EventArgs e)
        {
            if (txtQuantity25.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity25.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity25.Text);
                    Change_Remaining(txtGUID25.Text, labelQuantity);
                    txtPartDescription25.Text = string.Empty;
                    txtPartLength25.Text = string.Empty;
                    txtQuantity25.Text = "0";
                    txtGUID25.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity25_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity25.Text);
            Change_Remaining(txtGUID25.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity25_Leave(object sender, EventArgs e)
        {
            if (txtQuantity25.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity25.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity25.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID25.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID25.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity25.Text = "0";
                        txtQuantity25.Focus();
                    }
                }
            }
        }
        private void btnClear26_Click(object sender, EventArgs e)
        {
            if (txtQuantity26.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity26.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity26.Text);
                    Change_Remaining(txtGUID26.Text, labelQuantity);
                    txtPartDescription26.Text = string.Empty;
                    txtPartLength26.Text = string.Empty;
                    txtQuantity26.Text = "0";
                    txtGUID26.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity26_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity26.Text);
            Change_Remaining(txtGUID26.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity26_Leave(object sender, EventArgs e)
        {
            if (txtQuantity26.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity26.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity26.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID26.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID26.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity26.Text = "0";
                        txtQuantity26.Focus();
                    }
                }
            }
        }
        private void btnClear31_Click(object sender, EventArgs e)
        {
            if (txtQuantity31.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity31.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity31.Text);
                    Change_Remaining(txtGUID31.Text, labelQuantity);
                    txtPartDescription31.Text = string.Empty;
                    txtPartLength31.Text = string.Empty;
                    txtQuantity31.Text = "0";
                    txtGUID31.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity31_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity31.Text);
            Change_Remaining(txtGUID31.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity31_Leave(object sender, EventArgs e)
        {
            if (txtQuantity31.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity31.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity31.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID31.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID31.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity31.Text = "0";
                        txtQuantity31.Focus();
                    }
                }
            }
        }
        private void btnClear32_Click(object sender, EventArgs e)
        {
            if (txtQuantity32.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity32.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity32.Text);
                    Change_Remaining(txtGUID32.Text, labelQuantity);
                    txtPartDescription32.Text = string.Empty;
                    txtPartLength32.Text = string.Empty;
                    txtQuantity32.Text = "0";
                    txtGUID32.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity32_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity32.Text);
            Change_Remaining(txtGUID32.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity32_Leave(object sender, EventArgs e)
        {
            if (txtQuantity32.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity32.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity32.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID32.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID32.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity32.Text = "0";
                        txtQuantity32.Focus();
                    }
                }
            }
        }
        private void btnClear33_Click(object sender, EventArgs e)
        {
            if (txtQuantity33.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity33.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity33.Text);
                    Change_Remaining(txtGUID33.Text, labelQuantity);
                    txtPartDescription33.Text = string.Empty;
                    txtPartLength33.Text = string.Empty;
                    txtQuantity33.Text = "0";
                    txtGUID33.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity33_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity33.Text);
            Change_Remaining(txtGUID33.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity33_Leave(object sender, EventArgs e)
        {
            if (txtQuantity33.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity33.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity33.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID33.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID33.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity33.Text = "0";
                        txtQuantity33.Focus();
                    }
                }
            }
        }
        private void btnClear34_Click(object sender, EventArgs e)
        {
            if (txtQuantity34.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity34.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity34.Text);
                    Change_Remaining(txtGUID34.Text, labelQuantity);
                    txtPartDescription34.Text = string.Empty;
                    txtPartLength34.Text = string.Empty;
                    txtQuantity34.Text = "0";
                    txtGUID34.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity34_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity34.Text);
            Change_Remaining(txtGUID34.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity34_Leave(object sender, EventArgs e)
        {
            if (txtQuantity34.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity34.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity34.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID34.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID34.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity34.Text = "0";
                        txtQuantity34.Focus();
                    }
                }
            }
        }
        private void btnClear35_Click(object sender, EventArgs e)
        {
            if (txtQuantity35.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity35.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity35.Text);
                    Change_Remaining(txtGUID35.Text, labelQuantity);
                    txtPartDescription35.Text = string.Empty;
                    txtPartLength35.Text = string.Empty;
                    txtQuantity35.Text = "0";
                    txtGUID35.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity35_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity35.Text);
            Change_Remaining(txtGUID35.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity35_Leave(object sender, EventArgs e)
        {
            if (txtQuantity35.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity35.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity35.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID35.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID35.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity35.Text = "0";
                        txtQuantity35.Focus();
                    }
                }
            }
        }
        private void btnClear36_Click(object sender, EventArgs e)
        {
            if (txtQuantity36.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity36.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity36.Text);
                    Change_Remaining(txtGUID36.Text, labelQuantity);
                    txtPartDescription36.Text = string.Empty;
                    txtPartLength36.Text = string.Empty;
                    txtQuantity36.Text = "0";
                    txtGUID36.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity36_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity36.Text);
            Change_Remaining(txtGUID36.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity36_Leave(object sender, EventArgs e)
        {
            if (txtQuantity36.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity36.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity36.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID36.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID36.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity36.Text = "0";
                        txtQuantity36.Focus();
                    }
                }
            }
        }
        private void btnClear41_Click(object sender, EventArgs e)
        {
            if (txtQuantity41.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity41.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity41.Text);
                    Change_Remaining(txtGUID41.Text, labelQuantity);
                    txtPartDescription41.Text = string.Empty;
                    txtPartLength41.Text = string.Empty;
                    txtQuantity41.Text = "0";
                    txtGUID41.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity41_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity41.Text);
            Change_Remaining(txtGUID41.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity41_Leave(object sender, EventArgs e)
        {
            if (txtQuantity41.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity41.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity41.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID41.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID41.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity41.Text = "0";
                        txtQuantity41.Focus();
                    }
                }
            }
        }
        private void btnClear42_Click(object sender, EventArgs e)
        {
            if (txtQuantity42.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity42.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity42.Text);
                    Change_Remaining(txtGUID42.Text, labelQuantity);
                    txtPartDescription42.Text = string.Empty;
                    txtPartLength42.Text = string.Empty;
                    txtQuantity42.Text = "0";
                    txtGUID42.Text = string.Empty;
                    Form_Validate();
                }
            }
        }
        private void txtQuantity42_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity42.Text);
            Change_Remaining(txtGUID42.Text, labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity42_Leave(object sender, EventArgs e)
        {
            if (txtQuantity42.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity42.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity42.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtGUID42.Text, labelQuantity) == true)
                    {
                        Change_Remaining(txtGUID42.Text, -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity42.Text = "0";
                        txtQuantity42.Focus();
                    }
                }
            }
        }
        private void btnClear43_Click(object sender, EventArgs e)
        {
            if (txtQuantity43.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity43.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity43.Text);
                    Change_Remaining(txtPartDescription43.Text, Convert.ToDouble(txtPartLength43.Text), labelQuantity);
                    txtPartDescription43.Text = string.Empty;
                    txtPartLength43.Text = string.Empty;
                    txtQuantity43.Text = "0";

                    Form_Validate();
                }
            }
        }
        private void txtQuantity43_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity43.Text);
            Change_Remaining(txtPartDescription43.Text, Convert.ToDouble(txtPartLength43.Text), labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity43_Leave(object sender, EventArgs e)
        {
            if (txtQuantity43.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity43.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity43.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtPartDescription43.Text, Convert.ToDouble(txtPartLength43.Text), labelQuantity) == true)
                    {
                        Change_Remaining(txtPartDescription43.Text, Convert.ToDouble(txtPartLength43.Text), -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity43.Text = "0";
                        txtQuantity43.Focus();
                    }
                }
            }
        }
        private void btnClear44_Click(object sender, EventArgs e)
        {
            if (txtQuantity44.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity44.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity44.Text);
                    Change_Remaining(txtPartDescription44.Text, Convert.ToDouble(txtPartLength44.Text), labelQuantity);
                    txtPartDescription44.Text = string.Empty;
                    txtPartLength44.Text = string.Empty;
                    txtQuantity44.Text = "0";

                    Form_Validate();
                }
            }
        }
        private void txtQuantity44_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity44.Text);
            Change_Remaining(txtPartDescription44.Text, Convert.ToDouble(txtPartLength44.Text), labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity44_Leave(object sender, EventArgs e)
        {
            if (txtQuantity44.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity44.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity44.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtPartDescription44.Text, Convert.ToDouble(txtPartLength44.Text), labelQuantity) == true)
                    {
                        Change_Remaining(txtPartDescription44.Text, Convert.ToDouble(txtPartLength44.Text), -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity44.Text = "0";
                        txtQuantity44.Focus();
                    }
                }
            }
        }
        private void btnClear45_Click(object sender, EventArgs e)
        {
            if (txtQuantity45.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity45.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity45.Text);
                    Change_Remaining(txtPartDescription45.Text, Convert.ToDouble(txtPartLength45.Text), labelQuantity);
                    txtPartDescription45.Text = string.Empty;
                    txtPartLength45.Text = string.Empty;
                    txtQuantity45.Text = "0";

                    Form_Validate();
                }
            }
        }
        private void txtQuantity45_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity45.Text);
            Change_Remaining(txtPartDescription45.Text, Convert.ToDouble(txtPartLength45.Text), labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity45_Leave(object sender, EventArgs e)
        {
            if (txtQuantity45.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity45.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity45.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtPartDescription45.Text, Convert.ToDouble(txtPartLength45.Text), labelQuantity) == true)
                    {
                        Change_Remaining(txtPartDescription45.Text, Convert.ToDouble(txtPartLength45.Text), -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity45.Text = "0";
                        txtQuantity45.Focus();
                    }
                }
            }
        }
        private void btnClear46_Click(object sender, EventArgs e)
        {
            if (txtQuantity46.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity46.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity46.Text);
                    Change_Remaining(txtPartDescription46.Text, Convert.ToDouble(txtPartLength46.Text), labelQuantity);
                    txtPartDescription46.Text = string.Empty;
                    txtPartLength46.Text = string.Empty;
                    txtQuantity46.Text = "0";

                    Form_Validate();
                }
            }
        }
        private void txtQuantity46_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity46.Text);
            Change_Remaining(txtPartDescription46.Text, Convert.ToDouble(txtPartLength46.Text), labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity46_Leave(object sender, EventArgs e)
        {
            if (txtQuantity46.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity46.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity46.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtPartDescription46.Text, Convert.ToDouble(txtPartLength46.Text), labelQuantity) == true)
                    {
                        Change_Remaining(txtPartDescription46.Text, Convert.ToDouble(txtPartLength46.Text), -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity46.Text = "0";
                        txtQuantity46.Focus();
                    }
                }
            }
        }

        private void btnClear51_Click(object sender, EventArgs e)
        {
            if (txtQuantity51.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity51.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity51.Text);
                    Change_Remaining(txtPartDescription51.Text, Convert.ToDouble(txtPartLength51.Text), labelQuantity);
                    txtPartDescription51.Text = string.Empty;
                    txtPartLength51.Text = string.Empty;
                    txtQuantity51.Text = "0";

                    Form_Validate();
                }
            }
        }
        private void txtQuantity51_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity51.Text);
            Change_Remaining(txtPartDescription51.Text, Convert.ToDouble(txtPartLength51.Text), labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity51_Leave(object sender, EventArgs e)
        {
            if (txtQuantity51.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity51.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity51.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtPartDescription51.Text, Convert.ToDouble(txtPartLength51.Text), labelQuantity) == true)
                    {
                        Change_Remaining(txtPartDescription51.Text, Convert.ToDouble(txtPartLength51.Text), -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity51.Text = "0";
                        txtQuantity51.Focus();
                    }
                }
            }
        }
        private void btnClear52_Click(object sender, EventArgs e)
        {
            if (txtQuantity52.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity52.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity52.Text);
                    Change_Remaining(txtPartDescription52.Text, Convert.ToDouble(txtPartLength52.Text), labelQuantity);
                    txtPartDescription52.Text = string.Empty;
                    txtPartLength52.Text = string.Empty;
                    txtQuantity52.Text = "0";

                    Form_Validate();
                }
            }
        }
        private void txtQuantity52_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity52.Text);
            Change_Remaining(txtPartDescription52.Text, Convert.ToDouble(txtPartLength52.Text), labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity52_Leave(object sender, EventArgs e)
        {
            if (txtQuantity52.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity52.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity52.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtPartDescription52.Text, Convert.ToDouble(txtPartLength52.Text), labelQuantity) == true)
                    {
                        Change_Remaining(txtPartDescription52.Text, Convert.ToDouble(txtPartLength52.Text), -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity52.Text = "0";
                        txtQuantity52.Focus();
                    }
                }
            }
        }
        private void btnClear53_Click(object sender, EventArgs e)
        {
            if (txtQuantity53.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity53.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity53.Text);
                    Change_Remaining(txtPartDescription53.Text, Convert.ToDouble(txtPartLength53.Text), labelQuantity);
                    txtPartDescription53.Text = string.Empty;
                    txtPartLength53.Text = string.Empty;
                    txtQuantity53.Text = "0";

                    Form_Validate();
                }
            }
        }
        private void txtQuantity53_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity53.Text);
            Change_Remaining(txtPartDescription53.Text, Convert.ToDouble(txtPartLength53.Text), labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity53_Leave(object sender, EventArgs e)
        {
            if (txtQuantity53.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity53.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity53.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtPartDescription53.Text, Convert.ToDouble(txtPartLength53.Text), labelQuantity) == true)
                    {
                        Change_Remaining(txtPartDescription53.Text, Convert.ToDouble(txtPartLength53.Text), -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity53.Text = "0";
                        txtQuantity53.Focus();
                    }
                }
            }
        }
        private void btnClear54_Click(object sender, EventArgs e)
        {
            if (txtQuantity54.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity54.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity54.Text);
                    Change_Remaining(txtPartDescription54.Text, Convert.ToDouble(txtPartLength54.Text), labelQuantity);
                    txtPartDescription54.Text = string.Empty;
                    txtPartLength54.Text = string.Empty;
                    txtQuantity54.Text = "0";

                    Form_Validate();
                }
            }
        }
        private void txtQuantity54_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity54.Text);
            Change_Remaining(txtPartDescription54.Text, Convert.ToDouble(txtPartLength54.Text), labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity54_Leave(object sender, EventArgs e)
        {
            if (txtQuantity54.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity54.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity54.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtPartDescription54.Text, Convert.ToDouble(txtPartLength54.Text), labelQuantity) == true)
                    {
                        Change_Remaining(txtPartDescription54.Text, Convert.ToDouble(txtPartLength54.Text), -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity54.Text = "0";
                        txtQuantity54.Focus();
                    }
                }
            }
        }
        private void btnClear55_Click(object sender, EventArgs e)
        {
            if (txtQuantity55.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity55.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity55.Text);
                    Change_Remaining(txtPartDescription55.Text, Convert.ToDouble(txtPartLength55.Text), labelQuantity);
                    txtPartDescription55.Text = string.Empty;
                    txtPartLength55.Text = string.Empty;
                    txtQuantity55.Text = "0";

                    Form_Validate();
                }
            }
        }
        private void txtQuantity55_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity55.Text);
            Change_Remaining(txtPartDescription55.Text, Convert.ToDouble(txtPartLength55.Text), labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity55_Leave(object sender, EventArgs e)
        {
            if (txtQuantity55.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity55.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity55.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtPartDescription55.Text, Convert.ToDouble(txtPartLength55.Text), labelQuantity) == true)
                    {
                        Change_Remaining(txtPartDescription55.Text, Convert.ToDouble(txtPartLength55.Text), -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity55.Text = "0";
                        txtQuantity55.Focus();
                    }
                }
            }
        }
        private void btnClear56_Click(object sender, EventArgs e)
        {
            if (txtQuantity56.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity56.Text.Trim().Replace(",", "")) >= 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity56.Text);
                    Change_Remaining(txtPartDescription56.Text, Convert.ToDouble(txtPartLength56.Text), labelQuantity);
                    txtPartDescription56.Text = string.Empty;
                    txtPartLength56.Text = string.Empty;
                    txtQuantity56.Text = "0";

                    Form_Validate();
                }
            }
        }
        private void txtQuantity56_Enter(object sender, EventArgs e)
        {
            labelQuantity = Convert.ToInt32(txtQuantity56.Text);
            Change_Remaining(txtPartDescription56.Text, Convert.ToDouble(txtPartLength56.Text), labelQuantity);
            SendKeys.Send("{Home}+{End}");
        }
        private void txtQuantity56_Leave(object sender, EventArgs e)
        {
            if (txtQuantity56.Text.Trim().Replace(",", "").Length > 0)
            {
                if (Int32.Parse(txtQuantity56.Text.Trim().Replace(",", "")) > 0)
                {
                    labelQuantity = Convert.ToInt32(txtQuantity56.Text.Trim().Replace(",", ""));
                    if (Valid_Quantity(txtPartDescription56.Text, Convert.ToDouble(txtPartLength56.Text), labelQuantity) == true)
                    {
                        Change_Remaining(txtPartDescription56.Text, Convert.ToDouble(txtPartLength56.Text), -labelQuantity);
                    }
                    else
                    {
                        MessageBox.Show("** Operator **\r\n\r\nQuantity exceeds Available Quantity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantity56.Text = "0";
                        txtQuantity56.Focus();
                    }
                }
            }
        }


        private Boolean Valid_Quantity(String partDescription, Double partLength, Int32 quantityChange)
        {
            Boolean isValid = true;

            for (int i = 0; i < dgParts.Rows.Count; i++)
            {
                if ((partDescription == dgParts.Rows[i].Cells["PartDescription"].Value.ToString()) & (partLength == Convert.ToDouble(Convert.ToDouble(dgParts.Rows[i].Cells["Length"].Value))))
                {
                    if (Convert.ToInt32(dgParts.Rows[i].Cells["QtyLeft"].Value) < quantityChange)
                        isValid = false;
                    break;
                }
            }

            return isValid;
        }
        private Boolean Valid_Quantity(String partGUID, Int32 quantityChange)
        {
            Boolean isValid = true;

            for (int i = 0; i < dgParts.Rows.Count; i++)
            {
                if (partGUID == dgParts.Rows[i].Cells["PartGUID"].Value.ToString())
                {
                    if (Convert.ToInt32(dgParts.Rows[i].Cells["QtyLeft"].Value) < quantityChange)
                        isValid = false;
                    break;
                }
            }

            return isValid;
        }
        private void Change_Remaining(String partDescription, Double partLength, Int32 quantityChange)
        {
            for (int i = 0; i < dgParts.Rows.Count; i++)
            {
                if ((partDescription == dgParts.Rows[i].Cells["PartDescription"].Value.ToString()) & (partLength == Convert.ToDouble(Convert.ToDouble(dgParts.Rows[i].Cells["Length"].Value))))
                {
                    dgParts.Rows[i].Cells["QtyLeft"].Value = Convert.ToInt32(dgParts.Rows[i].Cells["QtyLeft"].Value) + quantityChange;
                    break;
                }
            }
        }
        private void Change_Remaining(String partGUID, Int32 quantityChange)
        {
            for (int i = 0; i < dgParts.Rows.Count; i++)
            {
                if (partGUID == dgParts.Rows[i].Cells["PartGUID"].Value.ToString())
                {
                    dgParts.Rows[i].Cells["QtyLeft"].Value = Convert.ToInt32(dgParts.Rows[i].Cells["QtyLeft"].Value) + quantityChange;
                    break;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Populate_Label_Object_List();

            foreach (LabelObject thisLabel in myLabels)
            {
                // Populate Label
                Populate_Label(thisLabel);

                for (int i = 0; i < thisLabel.numberOfCopies; i++)
                {
                    // Print Label
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
            }

        }
        private void btnBlank_Click(object sender, EventArgs e)
        {
            Populate_Blank_Label();

            if (labelPrinterName.Trim().Length == 0)
            {
                labelPrinterName = "ZDesigner ZT230-200dpi EPL";
            }
            if (USBPrinterHelper.RawPrinterHelper.SendStringToPrinter(labelPrinterName, myLabel) == false)
            {
                MessageBox.Show("Printer Error !");
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Populate_Label_Object_List()
        {
            myLabels.Clear();

            if ((txtPartDescription11.Text.Trim().Length > 0) | (txtPartDescription12.Text.Trim().Length > 0) | (txtPartDescription13.Text.Trim().Length > 0) | (txtPartDescription14.Text.Trim().Length > 0) | (txtPartDescription15.Text.Trim().Length > 0) | (txtPartDescription16.Text.Trim().Length > 0))
            {
                LabelObject thisLabel = new LabelObject();
                thisLabel.labelIndex = 1;
                thisLabel.partDescription[0] = txtPartDescription11.Text;
                thisLabel.partDescription[1] = txtPartDescription12.Text;
                thisLabel.partDescription[2] = txtPartDescription13.Text;
                thisLabel.partDescription[3] = txtPartDescription14.Text;
                thisLabel.partDescription[4] = txtPartDescription15.Text;
                thisLabel.partDescription[5] = txtPartDescription16.Text;
                thisLabel.partLenght[0] = txtPartLength11.Text;
                thisLabel.partLenght[1] = txtPartLength12.Text;
                thisLabel.partLenght[2] = txtPartLength13.Text;
                thisLabel.partLenght[3] = txtPartLength14.Text;
                thisLabel.partLenght[4] = txtPartLength15.Text;
                thisLabel.partLenght[5] = txtPartLength16.Text;
                thisLabel.partQuantity[0] = txtQuantity11.Text;
                thisLabel.partQuantity[1] = txtQuantity12.Text;
                thisLabel.partQuantity[2] = txtQuantity13.Text;
                thisLabel.partQuantity[3] = txtQuantity14.Text;
                thisLabel.partQuantity[4] = txtQuantity15.Text;
                thisLabel.partQuantity[5] = txtQuantity16.Text;
                thisLabel.numberOfCopies = Convert.ToInt32(nupdnCopies1.Value);
                myLabels.Add(thisLabel);
            }
            if ((txtPartDescription21.Text.Trim().Length > 0) | (txtPartDescription22.Text.Trim().Length > 0) | (txtPartDescription23.Text.Trim().Length > 0) | (txtPartDescription24.Text.Trim().Length > 0) | (txtPartDescription25.Text.Trim().Length > 0) | (txtPartDescription26.Text.Trim().Length > 0))
            {
                LabelObject thisLabel = new LabelObject();
                thisLabel.labelIndex = 2;
                thisLabel.partDescription[0] = txtPartDescription21.Text;
                thisLabel.partDescription[1] = txtPartDescription22.Text;
                thisLabel.partDescription[2] = txtPartDescription23.Text;
                thisLabel.partDescription[3] = txtPartDescription24.Text;
                thisLabel.partDescription[4] = txtPartDescription25.Text;
                thisLabel.partDescription[5] = txtPartDescription26.Text;
                thisLabel.partLenght[0] = txtPartLength21.Text;
                thisLabel.partLenght[1] = txtPartLength22.Text;
                thisLabel.partLenght[2] = txtPartLength23.Text;
                thisLabel.partLenght[3] = txtPartLength24.Text;
                thisLabel.partLenght[4] = txtPartLength25.Text;
                thisLabel.partLenght[5] = txtPartLength26.Text;
                thisLabel.partQuantity[0] = txtQuantity21.Text;
                thisLabel.partQuantity[1] = txtQuantity22.Text;
                thisLabel.partQuantity[2] = txtQuantity23.Text;
                thisLabel.partQuantity[3] = txtQuantity24.Text;
                thisLabel.partQuantity[4] = txtQuantity25.Text;
                thisLabel.partQuantity[5] = txtQuantity26.Text;
                thisLabel.numberOfCopies = Convert.ToInt32(nupdnCopies2.Value);
                myLabels.Add(thisLabel);
            }
            if ((txtPartDescription31.Text.Trim().Length > 0) | (txtPartDescription32.Text.Trim().Length > 0) | (txtPartDescription33.Text.Trim().Length > 0) | (txtPartDescription34.Text.Trim().Length > 0) | (txtPartDescription35.Text.Trim().Length > 0) | (txtPartDescription36.Text.Trim().Length > 0))
            {
                LabelObject thisLabel = new LabelObject();
                thisLabel.labelIndex = 3;
                thisLabel.partDescription[0] = txtPartDescription31.Text;
                thisLabel.partDescription[1] = txtPartDescription32.Text;
                thisLabel.partDescription[2] = txtPartDescription33.Text;
                thisLabel.partDescription[3] = txtPartDescription34.Text;
                thisLabel.partDescription[4] = txtPartDescription35.Text;
                thisLabel.partDescription[5] = txtPartDescription36.Text;
                thisLabel.partLenght[0] = txtPartLength31.Text;
                thisLabel.partLenght[1] = txtPartLength32.Text;
                thisLabel.partLenght[2] = txtPartLength33.Text;
                thisLabel.partLenght[3] = txtPartLength34.Text;
                thisLabel.partLenght[4] = txtPartLength35.Text;
                thisLabel.partLenght[5] = txtPartLength36.Text;
                thisLabel.partQuantity[0] = txtQuantity31.Text;
                thisLabel.partQuantity[1] = txtQuantity32.Text;
                thisLabel.partQuantity[2] = txtQuantity33.Text;
                thisLabel.partQuantity[3] = txtQuantity34.Text;
                thisLabel.partQuantity[4] = txtQuantity35.Text;
                thisLabel.partQuantity[5] = txtQuantity36.Text;
                thisLabel.numberOfCopies = Convert.ToInt32(nupdnCopies3.Value);
                myLabels.Add(thisLabel);
            }
            if ((txtPartDescription41.Text.Trim().Length > 0) | (txtPartDescription42.Text.Trim().Length > 0) | (txtPartDescription43.Text.Trim().Length > 0) | (txtPartDescription44.Text.Trim().Length > 0) | (txtPartDescription45.Text.Trim().Length > 0) | (txtPartDescription46.Text.Trim().Length > 0))
            {
                LabelObject thisLabel = new LabelObject();
                thisLabel.labelIndex = 4;
                thisLabel.partDescription[0] = txtPartDescription41.Text;
                thisLabel.partDescription[1] = txtPartDescription42.Text;
                thisLabel.partDescription[2] = txtPartDescription43.Text;
                thisLabel.partDescription[3] = txtPartDescription44.Text;
                thisLabel.partDescription[4] = txtPartDescription45.Text;
                thisLabel.partDescription[5] = txtPartDescription46.Text;
                thisLabel.partLenght[0] = txtPartLength41.Text;
                thisLabel.partLenght[1] = txtPartLength42.Text;
                thisLabel.partLenght[2] = txtPartLength43.Text;
                thisLabel.partLenght[3] = txtPartLength44.Text;
                thisLabel.partLenght[4] = txtPartLength45.Text;
                thisLabel.partLenght[5] = txtPartLength46.Text;
                thisLabel.partQuantity[0] = txtQuantity41.Text;
                thisLabel.partQuantity[1] = txtQuantity42.Text;
                thisLabel.partQuantity[2] = txtQuantity43.Text;
                thisLabel.partQuantity[3] = txtQuantity44.Text;
                thisLabel.partQuantity[4] = txtQuantity45.Text;
                thisLabel.partQuantity[5] = txtQuantity46.Text;
                thisLabel.numberOfCopies = Convert.ToInt32(nupdnCopies4.Value);
                myLabels.Add(thisLabel);
            }
            if ((txtPartDescription51.Text.Trim().Length > 0) | (txtPartDescription52.Text.Trim().Length > 0) | (txtPartDescription53.Text.Trim().Length > 0) | (txtPartDescription54.Text.Trim().Length > 0) | (txtPartDescription55.Text.Trim().Length > 0) | (txtPartDescription56.Text.Trim().Length > 0))
            {
                LabelObject thisLabel = new LabelObject();
                thisLabel.labelIndex = 5;
                thisLabel.partDescription[0] = txtPartDescription51.Text;
                thisLabel.partDescription[1] = txtPartDescription52.Text;
                thisLabel.partDescription[2] = txtPartDescription53.Text;
                thisLabel.partDescription[3] = txtPartDescription54.Text;
                thisLabel.partDescription[4] = txtPartDescription55.Text;
                thisLabel.partDescription[5] = txtPartDescription56.Text;
                thisLabel.partLenght[0] = txtPartLength51.Text;
                thisLabel.partLenght[1] = txtPartLength52.Text;
                thisLabel.partLenght[2] = txtPartLength53.Text;
                thisLabel.partLenght[3] = txtPartLength54.Text;
                thisLabel.partLenght[4] = txtPartLength55.Text;
                thisLabel.partLenght[5] = txtPartLength56.Text;
                thisLabel.partQuantity[0] = txtQuantity51.Text;
                thisLabel.partQuantity[1] = txtQuantity52.Text;
                thisLabel.partQuantity[2] = txtQuantity53.Text;
                thisLabel.partQuantity[3] = txtQuantity54.Text;
                thisLabel.partQuantity[4] = txtQuantity55.Text;
                thisLabel.partQuantity[5] = txtQuantity56.Text;
                thisLabel.numberOfCopies = Convert.ToInt32(nupdnCopies5.Value);
                myLabels.Add(thisLabel);
            }
        }
        private void Populate_Label(LabelObject thisLabel)
        {
            myLabel = string.Empty;

            if (customerName.Trim().Length > 30)
                customerName = customerName.Substring(0, 30);

            if (cmbFormat.Text.Substring(0, 1) == "1")
            {
                myLabel = "N\r\n";
                myLabel = myLabel + "A150,320,1,4,1,1,N,\"" + colourName.Trim() + "\"\r\n";
                if (thisLabel.partDescription[5].Trim().Length > 0)
                {
                    myLabel = myLabel + "A185,80,1,4,1,1,N,\"" + thisLabel.partDescription[5].Trim() + "\"\r\n";
                    myLabel = myLabel + "A185,970,1,4,1,1,N,\"" + thisLabel.partQuantity[5].Trim() + "\"\r\n";
                    myLabel = myLabel + "A185,1100,1,4,1,1,N,\"" + thisLabel.partLenght[5].Trim() + "\"\r\n";
                }
                if (thisLabel.partDescription[4].Trim().Length > 0)
                {
                    myLabel = myLabel + "A235,80,1,4,1,1,N,\"" + thisLabel.partDescription[4].Trim() + "\"\r\n";
                    myLabel = myLabel + "A235,970,1,4,1,1,N,\"" + thisLabel.partQuantity[4].Trim() + "\"\r\n";
                    myLabel = myLabel + "A235,1100,1,4,1,1,N,\"" + thisLabel.partLenght[4].Trim() + "\"\r\n";
                }
                if (thisLabel.partDescription[3].Trim().Length > 0)
                {
                    myLabel = myLabel + "A285,80,1,4,1,1,N,\"" + thisLabel.partDescription[3].Trim() + "\"\r\n";
                    myLabel = myLabel + "A285,970,1,4,1,1,N,\"" + thisLabel.partQuantity[3].Trim() + "\"\r\n";
                    myLabel = myLabel + "A285,1100,1,4,1,1,N,\"" + thisLabel.partLenght[3].Trim() + "\"\r\n";
                }
                if (thisLabel.partDescription[2].Trim().Length > 0)
                {
                    myLabel = myLabel + "A335,80,1,4,1,1,N,\"" + thisLabel.partDescription[2].Trim() + "\"\r\n";
                    myLabel = myLabel + "A335,970,1,4,1,1,N,\"" + thisLabel.partQuantity[2].Trim() + "\"\r\n";
                    myLabel = myLabel + "A335,1100,1,4,1,1,N,\"" + thisLabel.partLenght[2].Trim() + "\"\r\n";
                }
                if (thisLabel.partDescription[1].Trim().Length > 0)
                {
                    myLabel = myLabel + "A385,80,1,4,1,1,N,\"" + thisLabel.partDescription[1].Trim() + "\"\r\n";
                    myLabel = myLabel + "A385,970,1,4,1,1,N,\"" + thisLabel.partQuantity[1].Trim() + "\"\r\n";
                    myLabel = myLabel + "A385,1100,1,4,1,1,N,\"" + thisLabel.partLenght[1].Trim() + "\"\r\n";
                }
                if (thisLabel.partDescription[0].Trim().Length > 0)
                {
                    myLabel = myLabel + "A435,80,1,4,1,1,N,\"" + thisLabel.partDescription[0].Trim() + "\"\r\n";
                    myLabel = myLabel + "A435,970,1,4,1,1,N,\"" + thisLabel.partQuantity[0].Trim() + "\"\r\n";
                    myLabel = myLabel + "A435,1100,1,4,1,1,N,\"" + thisLabel.partLenght[0].Trim() + "\"\r\n";
                }
                myLabel = myLabel + "A580,310,1,3,2,2,N,\"" + customerOrder.Trim() + "\"\r\n";
                myLabel = myLabel + "A580,900,1,3,2,2,N,\"" + orderNumber.Trim() + "\"\r\n";
                myLabel = myLabel + "A630,350,1,3,2,2,N,\"" + customerName.Trim() + "\"\r\n";
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
                if (thisLabel.partDescription[4].Trim().Length > 0)
                {
                    myLabel = myLabel + "A180,50,1,3,1,1,N,\"" + thisLabel.partDescription[4].Trim() + "\"\r\n";
                    myLabel = myLabel + "A180,500,1,3,1,1,N,\"" + thisLabel.partQuantity[4].Trim() + "\"\r\n";
                    myLabel = myLabel + "A180,900,1,3,1,1,N,\"" + thisLabel.partLenght[4].Trim() + "\"\r\n";
                }
                else
                {
                    myLabel = myLabel + "A180,50,1,3,1,1,N,\"______________________________\"\r\n";
                    myLabel = myLabel + "A180,500,1,3,1,1,N,\"_________________________\"\r\n";
                    myLabel = myLabel + "A180,900,1,3,1,1,N,\"__________________\"\r\n";
                }
                if (thisLabel.partDescription[3].Trim().Length > 0)
                {
                    myLabel = myLabel + "A250,50,1,3,1,1,N,\"" + thisLabel.partDescription[3].Trim() + "\"\r\n";
                    myLabel = myLabel + "A250,500,1,3,1,1,N,\"" + thisLabel.partQuantity[3].Trim() + "\"\r\n";
                    myLabel = myLabel + "A250,900,1,3,1,1,N,\"" + thisLabel.partLenght[3].Trim() + "\"\r\n";
                }
                else
                {
                    myLabel = myLabel + "A250,50,1,3,1,1,N,\"______________________________\"\r\n";
                    myLabel = myLabel + "A250,500,1,3,1,1,N,\"_________________________\"\r\n";
                    myLabel = myLabel + "A250,900,1,3,1,1,N,\"__________________\"\r\n";
                }
                if (thisLabel.partDescription[2].Trim().Length > 0)
                {
                    myLabel = myLabel + "A320,50,1,3,1,1,N,\"" + thisLabel.partDescription[2].Trim() + "\"\r\n";
                    myLabel = myLabel + "A320,500,1,3,1,1,N,\"" + thisLabel.partQuantity[2].Trim() + "\"\r\n";
                    myLabel = myLabel + "A320,900,1,3,1,1,N,\"" + thisLabel.partLenght[2].Trim() + "\"\r\n";
                }
                else
                {
                    myLabel = myLabel + "A320,50,1,3,1,1,N,\"______________________________\"\r\n";
                    myLabel = myLabel + "A320,500,1,3,1,1,N,\"_________________________\"\r\n";
                    myLabel = myLabel + "A320,900,1,3,1,1,N,\"__________________\"\r\n";
                }
                if (thisLabel.partDescription[1].Trim().Length > 0)
                {
                    myLabel = myLabel + "A390,50,1,3,1,1,N,\"" + thisLabel.partDescription[1].Trim() + "\"\r\n";
                    myLabel = myLabel + "A390,500,1,3,1,1,N,\"" + thisLabel.partQuantity[1].Trim() + "\"\r\n";
                    myLabel = myLabel + "A390,900,1,3,1,1,N,\"" + thisLabel.partLenght[1].Trim() + "\"\r\n";
                }
                else
                {
                    myLabel = myLabel + "A390,50,1,3,1,1,N,\"______________________________\"\r\n";
                    myLabel = myLabel + "A390,500,1,3,1,1,N,\"_________________________\"\r\n";
                    myLabel = myLabel + "A390,900,1,3,1,1,N,\"__________________\"\r\n";
                }
                if (thisLabel.partDescription[0].Trim().Length > 0)
                {
                    myLabel = myLabel + "A460,50,1,3,1,1,N,\"" + thisLabel.partDescription[0].Trim() + "\"\r\n";
                    myLabel = myLabel + "A460,500,1,3,1,1,N,\"" + thisLabel.partQuantity[0].Trim() + "\"\r\n";
                    myLabel = myLabel + "A460,900,1,3,1,1,N,\"" + thisLabel.partLenght[0].Trim() + "\"\r\n";
                }
                else
                {

                    myLabel = myLabel + "A460,50,1,3,1,1,N,\"______________________________\"\r\n";
                    myLabel = myLabel + "A460,500,1,3,1,1,N,\"_________________________\"\r\n";
                    myLabel = myLabel + "A460,900,1,3,1,1,N,\"__________________\"\r\n";
                }
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
        }
        private void Populate_Blank_Label()
        {
            myLabel = string.Empty;

            if (customerName.Trim().Length > 30)
                customerName = customerName.Substring(0, 30);

            if (cmbFormat.Text.Substring(0, 1) == "1")
            {
                myLabel = "N\r\n";
                myLabel = myLabel + "A150,320,1,4,1,1,N,\"" + colourName.Trim() + "\"\r\n";
                myLabel = myLabel + "A185,80,1,3,1,1,N,\"____________________________________________________________________________\"\r\n";
                myLabel = myLabel + "A235,80,1,3,1,1,N,\"____________________________________________________________________________\"\r\n";
                myLabel = myLabel + "A285,80,1,3,1,1,N,\"____________________________________________________________________________\"\r\n";
                myLabel = myLabel + "A335,80,1,3,1,1,N,\"____________________________________________________________________________\"\r\n";
                myLabel = myLabel + "A385,80,1,3,1,1,N,\"____________________________________________________________________________\"\r\n";
                myLabel = myLabel + "A435,80,1,3,1,1,N,\"____________________________________________________________________________\"\r\n";
                myLabel = myLabel + "A580,310,1,3,2,2,N,\"" + customerOrder.Trim() + "\"\r\n";
                myLabel = myLabel + "A580,900,1,3,2,2,N,\"" + orderNumber.Trim() + "\"\r\n";
                myLabel = myLabel + "A630,350,1,3,2,2,N,\"" + customerName.Trim() + "\"\r\n";
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
        }
    }
    public class LabelObject
    {
        public Int32 labelIndex;
        public String[] partDescription = { "", "", "", "", "", "" };
        public String[] partLenght = { "", "", "", "", "", "" };
        public String[] partQuantity = { "", "", "", "", "", "" };
        public Int32 numberOfCopies = 1;
    }
}
