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
    public partial class frmLabelItems : Form
    {
        public JOBData myJobData;
        public String thisJobNumber;
        public String labelFormat;
        public Int32 productionLineId;

        private Int32 maxLines = 6;
        private Boolean isValid = true;

        public frmLabelItems()
        {
            InitializeComponent();
        }

        private void frmLabelItems_Load(object sender, EventArgs e)
        {
            if (labelFormat == "2")
                maxLines = 5;

            if (myJobData.Get_Job(thisJobNumber.ToString(), productionLineId) == true)
            {
                if (myJobData.Get_Job_Details(myJobData.JobId) == true)
                {
                    dgParts.Rows.Clear();
                    for (int i = 0; i < myJobData.myJobDetails.Rows.Count; i++)
                    {
                        String[] thisPart = myJobData.myJobDetails.Rows[i]["PartDescription"].ToString().Split('*');
                        dgParts.Rows.Add(myJobData.myJobDetails.Rows[i]["PartCode"].ToString(), thisPart[0].Trim(), Convert.ToDouble(myJobData.myJobDetails.Rows[i]["Properties_Length"]), Convert.ToInt32(myJobData.myJobDetails.Rows[i]["Qty"]), 1, 0);
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

        private void frmLabelItems_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) & (btnClose.Enabled == true))
                btnClose_Click(sender, e);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgParts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if ((e.ColumnIndex == 4) | (e.ColumnIndex == 5))
                    dgParts.ReadOnly = false;
                else
                    dgParts.ReadOnly = true;
            }
        }

        private void dgParts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int lineCount = 0;
            int labelCount = 0;

            btnClose.Enabled = true;

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    if (dgParts.CurrentCell.EditedFormattedValue.ToString().Trim().Replace("$", "").Replace(",", "").Length > 0)
                    {
                        if (Int32.Parse(dgParts.CurrentCell.EditedFormattedValue.ToString().Trim().Replace("$", "").Replace(",", "")) <= 0)
                        {
                            btnClose.Enabled = false;
                            MessageBox.Show("** Operator **\r\n\r\nLabel Number must be greater than zero !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dgParts.CurrentCell.Value = "1";
                            btnClose.Enabled = true;
                        }
                    }
                }
                else if (e.ColumnIndex == 5)
                {
                    if (dgParts.CurrentCell.EditedFormattedValue.ToString().Trim().Replace("$", "").Replace(",", "").Length > 0)
                    {
                        if (Int32.Parse(dgParts.CurrentCell.EditedFormattedValue.ToString().Trim().Replace("$", "").Replace(",", "")) >= 0)
                        {
                            if (Convert.ToInt32(dgParts.Rows[e.RowIndex].Cells["PartQty"].Value) < Convert.ToInt32(dgParts.CurrentCell.Value))
                            {
                                btnClose.Enabled = false;
                                MessageBox.Show("** Operator **\r\n\r\nPacked Quantity exceeds Quantity Processed !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dgParts.CurrentCell.Value = "0";
                                btnClose.Enabled = true;
                            }
                        }
                    }
                }
            }

            // Find different number of Labels
            for (int i = 0; i < dgParts.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgParts.Rows[i].Cells["LabelNo"].Value) > labelCount)
                    labelCount++;
            }

            for (int j = 0; j < labelCount; j++)
            {
                lineCount = 0;

                for (int i = 0; i < dgParts.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgParts.Rows[i].Cells["LabelNo"].Value) == (j + 1))
                    {
                        if (Convert.ToInt32(dgParts.Rows[i].Cells["ThisLabel"].Value) > 0)
                            lineCount++;
                    }
                }

                if (lineCount > maxLines)
                {
                    btnClose.Enabled = false;
                    MessageBox.Show("** Operator **\r\n\r\nLabel # " + (j + 1).ToString() + "\r\nYou have selected more lines than what the label can hold !\r\nMaximium line count for the selected label format is " + maxLines.ToString() + "\r\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
