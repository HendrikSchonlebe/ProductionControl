namespace ProductionControl
{
    partial class frmProductionLine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionLine));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblProductionLine = new System.Windows.Forms.Label();
            this.dgJobs = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.pnlTasks = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPacked = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEndU = new System.Windows.Forms.Button();
            this.btnStartU = new System.Windows.Forms.Button();
            this.btnEndL = new System.Windows.Forms.Button();
            this.btnStartL = new System.Windows.Forms.Button();
            this.cmbProductionLine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStarted = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStopped = new System.Windows.Forms.DateTimePicker();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlParts = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgParts = new System.Windows.Forms.DataGridView();
            this.PartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduledDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressJobNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColourName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaintSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgressLoadStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishLoading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartUnloading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndUnloading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Packed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Coats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThisCoat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgJobs)).BeginInit();
            this.pnlTasks.SuspendLayout();
            this.pnlParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgParts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductionLine
            // 
            this.lblProductionLine.BackColor = System.Drawing.Color.PowderBlue;
            this.lblProductionLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductionLine.Location = new System.Drawing.Point(0, 0);
            this.lblProductionLine.Name = "lblProductionLine";
            this.lblProductionLine.Size = new System.Drawing.Size(1924, 52);
            this.lblProductionLine.TabIndex = 0;
            this.lblProductionLine.Text = "label1";
            this.lblProductionLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgJobs
            // 
            this.dgJobs.AllowUserToAddRows = false;
            this.dgJobs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            this.dgJobs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProgressId,
            this.ScheduledDate,
            this.ProgressJobNumber,
            this.Customer,
            this.WorkOrder,
            this.CustomerRef,
            this.Product,
            this.ColourName,
            this.PaintSystem,
            this.AP,
            this.Area,
            this.Time,
            this.ProgressLoadStart,
            this.FinishLoading,
            this.StartUnloading,
            this.EndUnloading,
            this.Packed,
            this.Coats,
            this.ThisCoat});
            this.dgJobs.Location = new System.Drawing.Point(24, 118);
            this.dgJobs.MultiSelect = false;
            this.dgJobs.Name = "dgJobs";
            this.dgJobs.ReadOnly = true;
            this.dgJobs.RowTemplate.Height = 40;
            this.dgJobs.RowTemplate.ReadOnly = true;
            this.dgJobs.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgJobs.Size = new System.Drawing.Size(1900, 332);
            this.dgJobs.TabIndex = 1;
            this.dgJobs.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgJobs_CellMouseClick);
            this.dgJobs.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgJobs_CellMouseDoubleClick);
            this.dgJobs.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgJobs_CellPainting);
            this.dgJobs.SelectionChanged += new System.EventHandler(this.dgJobs_SelectionChanged);
            this.dgJobs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgJobs_KeyDown);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(12, 55);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 57);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "F1 - New Batch";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Lime;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(130, 55);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 57);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "F2 - Add Job to Batch";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1800, 55);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 57);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Esc-Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Salmon;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(248, 55);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 57);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "F3 - Remove Job from Batch";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // pnlTasks
            // 
            this.pnlTasks.Controls.Add(this.btnCancel);
            this.pnlTasks.Controls.Add(this.btnPacked);
            this.pnlTasks.Controls.Add(this.btnPrint);
            this.pnlTasks.Controls.Add(this.btnEndU);
            this.pnlTasks.Controls.Add(this.btnStartU);
            this.pnlTasks.Controls.Add(this.btnEndL);
            this.pnlTasks.Controls.Add(this.btnStartL);
            this.pnlTasks.Location = new System.Drawing.Point(91, 217);
            this.pnlTasks.Name = "pnlTasks";
            this.pnlTasks.Size = new System.Drawing.Size(854, 100);
            this.pnlTasks.TabIndex = 6;
            this.pnlTasks.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Ivory;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(734, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 73);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "F7 - Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPacked
            // 
            this.btnPacked.BackColor = System.Drawing.Color.DarkOrange;
            this.btnPacked.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPacked.Location = new System.Drawing.Point(585, 15);
            this.btnPacked.Name = "btnPacked";
            this.btnPacked.Size = new System.Drawing.Size(108, 73);
            this.btnPacked.TabIndex = 5;
            this.btnPacked.Text = "F6 - Job Packed";
            this.btnPacked.UseVisualStyleBackColor = false;
            this.btnPacked.Click += new System.EventHandler(this.btnPacked_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.PowderBlue;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(471, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(108, 73);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "F5 - Print Packing Labels";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEndU
            // 
            this.btnEndU.BackColor = System.Drawing.Color.Lime;
            this.btnEndU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndU.Location = new System.Drawing.Point(357, 15);
            this.btnEndU.Name = "btnEndU";
            this.btnEndU.Size = new System.Drawing.Size(108, 73);
            this.btnEndU.TabIndex = 3;
            this.btnEndU.Text = "F4 -Finished Unloading";
            this.btnEndU.UseVisualStyleBackColor = false;
            this.btnEndU.Click += new System.EventHandler(this.btnEndU_Click);
            // 
            // btnStartU
            // 
            this.btnStartU.BackColor = System.Drawing.Color.PaleGreen;
            this.btnStartU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartU.Location = new System.Drawing.Point(243, 15);
            this.btnStartU.Name = "btnStartU";
            this.btnStartU.Size = new System.Drawing.Size(108, 73);
            this.btnStartU.TabIndex = 2;
            this.btnStartU.Text = "F3 - Unload Started";
            this.btnStartU.UseVisualStyleBackColor = false;
            this.btnStartU.Click += new System.EventHandler(this.btnStartU_Click);
            // 
            // btnEndL
            // 
            this.btnEndL.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnEndL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndL.Location = new System.Drawing.Point(129, 15);
            this.btnEndL.Name = "btnEndL";
            this.btnEndL.Size = new System.Drawing.Size(108, 73);
            this.btnEndL.TabIndex = 1;
            this.btnEndL.Text = "F2 - Finished Loading";
            this.btnEndL.UseVisualStyleBackColor = false;
            this.btnEndL.Click += new System.EventHandler(this.btnEndL_Click);
            // 
            // btnStartL
            // 
            this.btnStartL.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnStartL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartL.Location = new System.Drawing.Point(15, 15);
            this.btnStartL.Name = "btnStartL";
            this.btnStartL.Size = new System.Drawing.Size(108, 73);
            this.btnStartL.TabIndex = 0;
            this.btnStartL.Text = "F1 - Load Started";
            this.btnStartL.UseVisualStyleBackColor = false;
            this.btnStartL.Click += new System.EventHandler(this.btnStartL_Click);
            // 
            // cmbProductionLine
            // 
            this.cmbProductionLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductionLine.FormattingEnabled = true;
            this.cmbProductionLine.Location = new System.Drawing.Point(658, 69);
            this.cmbProductionLine.Name = "cmbProductionLine";
            this.cmbProductionLine.Size = new System.Drawing.Size(250, 28);
            this.cmbProductionLine.TabIndex = 7;
            this.cmbProductionLine.SelectedValueChanged += new System.EventHandler(this.cmbProductionLine_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(483, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Production Line";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(914, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Line Started";
            // 
            // dtpStarted
            // 
            this.dtpStarted.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStarted.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStarted.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStarted.Location = new System.Drawing.Point(1054, 53);
            this.dtpStarted.Name = "dtpStarted";
            this.dtpStarted.ShowUpDown = true;
            this.dtpStarted.Size = new System.Drawing.Size(182, 26);
            this.dtpStarted.TabIndex = 10;
            this.dtpStarted.ValueChanged += new System.EventHandler(this.dtpStarted_ValueChanged);
            this.dtpStarted.Enter += new System.EventHandler(this.dtpStarted_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(914, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Line Stopped";
            // 
            // dtpStopped
            // 
            this.dtpStopped.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStopped.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStopped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStopped.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStopped.Location = new System.Drawing.Point(1054, 84);
            this.dtpStopped.Name = "dtpStopped";
            this.dtpStopped.ShowUpDown = true;
            this.dtpStopped.Size = new System.Drawing.Size(184, 26);
            this.dtpStopped.TabIndex = 12;
            this.dtpStopped.ValueChanged += new System.EventHandler(this.dtpStopped_ValueChanged);
            this.dtpStopped.Enter += new System.EventHandler(this.dtpStopped_Enter);
            // 
            // myTimer
            // 
            this.myTimer.Enabled = true;
            this.myTimer.Interval = 60000;
            this.myTimer.Tick += new System.EventHandler(this.myTimer_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Azure;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(366, 55);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 57);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "F4 - Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlParts
            // 
            this.pnlParts.BackColor = System.Drawing.Color.MintCream;
            this.pnlParts.Controls.Add(this.btnClose);
            this.pnlParts.Controls.Add(this.dgParts);
            this.pnlParts.Location = new System.Drawing.Point(140, 166);
            this.pnlParts.Name = "pnlParts";
            this.pnlParts.Size = new System.Drawing.Size(1143, 272);
            this.pnlParts.TabIndex = 14;
            this.pnlParts.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(0, 225);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1143, 37);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgParts
            // 
            this.dgParts.AllowUserToAddRows = false;
            this.dgParts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgParts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartCode,
            this.PartDescription,
            this.PartQty,
            this.PartPicture});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgParts.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgParts.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgParts.Location = new System.Drawing.Point(0, 0);
            this.dgParts.Name = "dgParts";
            this.dgParts.Size = new System.Drawing.Size(1143, 228);
            this.dgParts.TabIndex = 0;
            this.dgParts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgParts_CellContentClick);
            // 
            // PartCode
            // 
            this.PartCode.HeaderText = "Part Code";
            this.PartCode.Name = "PartCode";
            // 
            // PartDescription
            // 
            this.PartDescription.HeaderText = "Description";
            this.PartDescription.MinimumWidth = 750;
            this.PartDescription.Name = "PartDescription";
            this.PartDescription.Width = 750;
            // 
            // PartQty
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N0";
            dataGridViewCellStyle19.NullValue = null;
            this.PartQty.DefaultCellStyle = dataGridViewCellStyle19;
            this.PartQty.HeaderText = "Quantity";
            this.PartQty.Name = "PartQty";
            // 
            // PartPicture
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PartPicture.DefaultCellStyle = dataGridViewCellStyle20;
            this.PartPicture.HeaderText = "Picture";
            this.PartPicture.Name = "PartPicture";
            // 
            // ProgressId
            // 
            this.ProgressId.HeaderText = "Progress Id";
            this.ProgressId.Name = "ProgressId";
            this.ProgressId.ReadOnly = true;
            this.ProgressId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProgressId.Visible = false;
            // 
            // ScheduledDate
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.ScheduledDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ScheduledDate.HeaderText = "Date";
            this.ScheduledDate.MinimumWidth = 80;
            this.ScheduledDate.Name = "ScheduledDate";
            this.ScheduledDate.ReadOnly = true;
            this.ScheduledDate.Width = 80;
            // 
            // ProgressJobNumber
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressJobNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.ProgressJobNumber.HeaderText = "Job Number";
            this.ProgressJobNumber.MinimumWidth = 75;
            this.ProgressJobNumber.Name = "ProgressJobNumber";
            this.ProgressJobNumber.ReadOnly = true;
            this.ProgressJobNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProgressJobNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProgressJobNumber.Width = 75;
            // 
            // Customer
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer.DefaultCellStyle = dataGridViewCellStyle5;
            this.Customer.HeaderText = "Customer Name";
            this.Customer.MinimumWidth = 240;
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            this.Customer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Customer.Width = 240;
            // 
            // WorkOrder
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkOrder.DefaultCellStyle = dataGridViewCellStyle6;
            this.WorkOrder.HeaderText = "Work Order #";
            this.WorkOrder.MinimumWidth = 85;
            this.WorkOrder.Name = "WorkOrder";
            this.WorkOrder.ReadOnly = true;
            this.WorkOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WorkOrder.Width = 85;
            // 
            // CustomerRef
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerRef.DefaultCellStyle = dataGridViewCellStyle7;
            this.CustomerRef.HeaderText = "Cust. Order #";
            this.CustomerRef.Name = "CustomerRef";
            this.CustomerRef.ReadOnly = true;
            // 
            // Product
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Product.DefaultCellStyle = dataGridViewCellStyle8;
            this.Product.HeaderText = "Paint Product";
            this.Product.MinimumWidth = 125;
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product.Width = 125;
            // 
            // ColourName
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColourName.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColourName.HeaderText = "Colour Name";
            this.ColourName.MinimumWidth = 240;
            this.ColourName.Name = "ColourName";
            this.ColourName.ReadOnly = true;
            this.ColourName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColourName.Width = 240;
            // 
            // PaintSystem
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaintSystem.DefaultCellStyle = dataGridViewCellStyle10;
            this.PaintSystem.HeaderText = "Paint System";
            this.PaintSystem.MinimumWidth = 80;
            this.PaintSystem.Name = "PaintSystem";
            this.PaintSystem.ReadOnly = true;
            this.PaintSystem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PaintSystem.Width = 80;
            // 
            // AP
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.Format = "N3";
            dataGridViewCellStyle11.NullValue = null;
            this.AP.DefaultCellStyle = dataGridViewCellStyle11;
            this.AP.HeaderText = "AP (m2)";
            this.AP.MinimumWidth = 70;
            this.AP.Name = "AP";
            this.AP.ReadOnly = true;
            this.AP.Width = 70;
            // 
            // Area
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.Format = "N3";
            dataGridViewCellStyle12.NullValue = null;
            this.Area.DefaultCellStyle = dataGridViewCellStyle12;
            this.Area.HeaderText = "CP (m2)";
            this.Area.MinimumWidth = 70;
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 70;
            // 
            // Time
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = null;
            this.Time.DefaultCellStyle = dataGridViewCellStyle13;
            this.Time.HeaderText = "Est. Time";
            this.Time.MinimumWidth = 45;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 45;
            // 
            // ProgressLoadStart
            // 
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressLoadStart.DefaultCellStyle = dataGridViewCellStyle14;
            this.ProgressLoadStart.HeaderText = "Start Loading";
            this.ProgressLoadStart.MinimumWidth = 145;
            this.ProgressLoadStart.Name = "ProgressLoadStart";
            this.ProgressLoadStart.ReadOnly = true;
            this.ProgressLoadStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProgressLoadStart.Width = 145;
            // 
            // FinishLoading
            // 
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishLoading.DefaultCellStyle = dataGridViewCellStyle15;
            this.FinishLoading.HeaderText = "Finish Loading";
            this.FinishLoading.MinimumWidth = 145;
            this.FinishLoading.Name = "FinishLoading";
            this.FinishLoading.ReadOnly = true;
            this.FinishLoading.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FinishLoading.Width = 145;
            // 
            // StartUnloading
            // 
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartUnloading.DefaultCellStyle = dataGridViewCellStyle16;
            this.StartUnloading.HeaderText = "Start Unloading";
            this.StartUnloading.MinimumWidth = 145;
            this.StartUnloading.Name = "StartUnloading";
            this.StartUnloading.ReadOnly = true;
            this.StartUnloading.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartUnloading.Width = 145;
            // 
            // EndUnloading
            // 
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndUnloading.DefaultCellStyle = dataGridViewCellStyle17;
            this.EndUnloading.HeaderText = "Finish Unloading";
            this.EndUnloading.MinimumWidth = 145;
            this.EndUnloading.Name = "EndUnloading";
            this.EndUnloading.ReadOnly = true;
            this.EndUnloading.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EndUnloading.Width = 145;
            // 
            // Packed
            // 
            this.Packed.HeaderText = "Packed";
            this.Packed.MinimumWidth = 60;
            this.Packed.Name = "Packed";
            this.Packed.ReadOnly = true;
            this.Packed.Width = 60;
            // 
            // Coats
            // 
            this.Coats.HeaderText = "Coats";
            this.Coats.Name = "Coats";
            this.Coats.ReadOnly = true;
            this.Coats.Visible = false;
            // 
            // ThisCoat
            // 
            this.ThisCoat.HeaderText = "This Coat";
            this.ThisCoat.Name = "ThisCoat";
            this.ThisCoat.ReadOnly = true;
            this.ThisCoat.Visible = false;
            // 
            // frmProductionLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1924, 450);
            this.Controls.Add(this.pnlParts);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtpStopped);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpStarted);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProductionLine);
            this.Controls.Add(this.pnlTasks);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgJobs);
            this.Controls.Add(this.lblProductionLine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmProductionLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProductionLine_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductionLine_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgJobs)).EndInit();
            this.pnlTasks.ResumeLayout(false);
            this.pnlParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductionLine;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.DataGridView dgJobs;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel pnlTasks;
        private System.Windows.Forms.Button btnStartL;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPacked;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEndU;
        private System.Windows.Forms.Button btnStartU;
        private System.Windows.Forms.Button btnEndL;
        private System.Windows.Forms.ComboBox cmbProductionLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStarted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStopped;
        private System.Windows.Forms.Timer myTimer;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlParts;
        private System.Windows.Forms.DataGridView dgParts;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgressId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduledDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgressJobNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColourName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaintSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn AP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgressLoadStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishLoading;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartUnloading;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndUnloading;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Packed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coats;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThisCoat;
    }
}