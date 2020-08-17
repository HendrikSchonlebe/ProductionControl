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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionLine));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblProductionLine = new System.Windows.Forms.Label();
            this.dgJobs = new System.Windows.Forms.DataGridView();
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
            this.pnlCheat = new System.Windows.Forms.Panel();
            this.txtDeferral = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnDefer = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkPacked = new System.Windows.Forms.CheckBox();
            this.dtpFinishUnloading = new System.Windows.Forms.DateTimePicker();
            this.dtpStartUnloading = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpFinishLoading = new System.Windows.Forms.DateTimePicker();
            this.dtpStartLoading = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.txtAP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPaintSystem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColour = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.txtWorkOrder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkClearStartLoad = new System.Windows.Forms.CheckBox();
            this.chkClearFinishLoad = new System.Windows.Forms.CheckBox();
            this.chkClearStartUnload = new System.Windows.Forms.CheckBox();
            this.chkClearFinishUnload = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgJobs)).BeginInit();
            this.pnlTasks.SuspendLayout();
            this.pnlParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgParts)).BeginInit();
            this.pnlCheat.SuspendLayout();
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
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.PowderBlue;
            this.dgJobs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dgJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
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
            this.dgJobs.Size = new System.Drawing.Size(1900, 437);
            this.dgJobs.TabIndex = 1;
            this.dgJobs.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgJobs_CellMouseClick);
            this.dgJobs.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgJobs_CellMouseDoubleClick);
            this.dgJobs.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgJobs_CellPainting);
            this.dgJobs.SelectionChanged += new System.EventHandler(this.dgJobs_SelectionChanged);
            this.dgJobs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgJobs_KeyDown);
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
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.Format = "d";
            dataGridViewCellStyle24.NullValue = null;
            this.ScheduledDate.DefaultCellStyle = dataGridViewCellStyle24;
            this.ScheduledDate.HeaderText = "Date";
            this.ScheduledDate.MinimumWidth = 80;
            this.ScheduledDate.Name = "ScheduledDate";
            this.ScheduledDate.ReadOnly = true;
            this.ScheduledDate.Width = 80;
            // 
            // ProgressJobNumber
            // 
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressJobNumber.DefaultCellStyle = dataGridViewCellStyle25;
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
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer.DefaultCellStyle = dataGridViewCellStyle26;
            this.Customer.HeaderText = "Customer Name";
            this.Customer.MinimumWidth = 240;
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            this.Customer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Customer.Width = 240;
            // 
            // WorkOrder
            // 
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkOrder.DefaultCellStyle = dataGridViewCellStyle27;
            this.WorkOrder.HeaderText = "Work Order #";
            this.WorkOrder.MinimumWidth = 85;
            this.WorkOrder.Name = "WorkOrder";
            this.WorkOrder.ReadOnly = true;
            this.WorkOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WorkOrder.Width = 85;
            // 
            // CustomerRef
            // 
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerRef.DefaultCellStyle = dataGridViewCellStyle28;
            this.CustomerRef.HeaderText = "Cust. Order #";
            this.CustomerRef.Name = "CustomerRef";
            this.CustomerRef.ReadOnly = true;
            // 
            // Product
            // 
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Product.DefaultCellStyle = dataGridViewCellStyle29;
            this.Product.HeaderText = "Paint Product";
            this.Product.MinimumWidth = 125;
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product.Width = 125;
            // 
            // ColourName
            // 
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColourName.DefaultCellStyle = dataGridViewCellStyle30;
            this.ColourName.HeaderText = "Colour Name";
            this.ColourName.MinimumWidth = 240;
            this.ColourName.Name = "ColourName";
            this.ColourName.ReadOnly = true;
            this.ColourName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColourName.Width = 240;
            // 
            // PaintSystem
            // 
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaintSystem.DefaultCellStyle = dataGridViewCellStyle31;
            this.PaintSystem.HeaderText = "Paint System";
            this.PaintSystem.MinimumWidth = 80;
            this.PaintSystem.Name = "PaintSystem";
            this.PaintSystem.ReadOnly = true;
            this.PaintSystem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PaintSystem.Width = 80;
            // 
            // AP
            // 
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.Format = "N3";
            dataGridViewCellStyle32.NullValue = null;
            this.AP.DefaultCellStyle = dataGridViewCellStyle32;
            this.AP.HeaderText = "AP (m2)";
            this.AP.MinimumWidth = 70;
            this.AP.Name = "AP";
            this.AP.ReadOnly = true;
            this.AP.Width = 70;
            // 
            // Area
            // 
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.Format = "N3";
            dataGridViewCellStyle33.NullValue = null;
            this.Area.DefaultCellStyle = dataGridViewCellStyle33;
            this.Area.HeaderText = "CP (m2)";
            this.Area.MinimumWidth = 70;
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 70;
            // 
            // Time
            // 
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.Format = "N0";
            dataGridViewCellStyle34.NullValue = null;
            this.Time.DefaultCellStyle = dataGridViewCellStyle34;
            this.Time.HeaderText = "Est. Time";
            this.Time.MinimumWidth = 45;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 45;
            // 
            // ProgressLoadStart
            // 
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressLoadStart.DefaultCellStyle = dataGridViewCellStyle35;
            this.ProgressLoadStart.HeaderText = "Start Loading";
            this.ProgressLoadStart.MinimumWidth = 145;
            this.ProgressLoadStart.Name = "ProgressLoadStart";
            this.ProgressLoadStart.ReadOnly = true;
            this.ProgressLoadStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProgressLoadStart.Width = 145;
            // 
            // FinishLoading
            // 
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishLoading.DefaultCellStyle = dataGridViewCellStyle36;
            this.FinishLoading.HeaderText = "Finish Loading";
            this.FinishLoading.MinimumWidth = 145;
            this.FinishLoading.Name = "FinishLoading";
            this.FinishLoading.ReadOnly = true;
            this.FinishLoading.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FinishLoading.Width = 145;
            // 
            // StartUnloading
            // 
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartUnloading.DefaultCellStyle = dataGridViewCellStyle37;
            this.StartUnloading.HeaderText = "Start Unloading";
            this.StartUnloading.MinimumWidth = 145;
            this.StartUnloading.Name = "StartUnloading";
            this.StartUnloading.ReadOnly = true;
            this.StartUnloading.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartUnloading.Width = 145;
            // 
            // EndUnloading
            // 
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndUnloading.DefaultCellStyle = dataGridViewCellStyle38;
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
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgParts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
            this.dgParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartCode,
            this.PartDescription,
            this.PartQty,
            this.PartPicture});
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgParts.DefaultCellStyle = dataGridViewCellStyle42;
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
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle40.Format = "N0";
            dataGridViewCellStyle40.NullValue = null;
            this.PartQty.DefaultCellStyle = dataGridViewCellStyle40;
            this.PartQty.HeaderText = "Quantity";
            this.PartQty.Name = "PartQty";
            // 
            // PartPicture
            // 
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PartPicture.DefaultCellStyle = dataGridViewCellStyle41;
            this.PartPicture.HeaderText = "Picture";
            this.PartPicture.Name = "PartPicture";
            // 
            // pnlCheat
            // 
            this.pnlCheat.BackColor = System.Drawing.Color.PeachPuff;
            this.pnlCheat.Controls.Add(this.chkClearFinishUnload);
            this.pnlCheat.Controls.Add(this.chkClearStartUnload);
            this.pnlCheat.Controls.Add(this.chkClearFinishLoad);
            this.pnlCheat.Controls.Add(this.chkClearStartLoad);
            this.pnlCheat.Controls.Add(this.txtDeferral);
            this.pnlCheat.Controls.Add(this.label14);
            this.pnlCheat.Controls.Add(this.btnQuit);
            this.pnlCheat.Controls.Add(this.btnDefer);
            this.pnlCheat.Controls.Add(this.btnSave);
            this.pnlCheat.Controls.Add(this.chkPacked);
            this.pnlCheat.Controls.Add(this.dtpFinishUnloading);
            this.pnlCheat.Controls.Add(this.dtpStartUnloading);
            this.pnlCheat.Controls.Add(this.label13);
            this.pnlCheat.Controls.Add(this.dtpFinishLoading);
            this.pnlCheat.Controls.Add(this.dtpStartLoading);
            this.pnlCheat.Controls.Add(this.label12);
            this.pnlCheat.Controls.Add(this.label11);
            this.pnlCheat.Controls.Add(this.label10);
            this.pnlCheat.Controls.Add(this.txtCP);
            this.pnlCheat.Controls.Add(this.txtAP);
            this.pnlCheat.Controls.Add(this.label9);
            this.pnlCheat.Controls.Add(this.txtPaintSystem);
            this.pnlCheat.Controls.Add(this.label8);
            this.pnlCheat.Controls.Add(this.txtOrderNumber);
            this.pnlCheat.Controls.Add(this.label7);
            this.pnlCheat.Controls.Add(this.txtCustomer);
            this.pnlCheat.Controls.Add(this.label6);
            this.pnlCheat.Controls.Add(this.txtColour);
            this.pnlCheat.Controls.Add(this.txtProduct);
            this.pnlCheat.Controls.Add(this.label5);
            this.pnlCheat.Controls.Add(this.txtJob);
            this.pnlCheat.Controls.Add(this.txtWorkOrder);
            this.pnlCheat.Controls.Add(this.label4);
            this.pnlCheat.Location = new System.Drawing.Point(71, 181);
            this.pnlCheat.Name = "pnlCheat";
            this.pnlCheat.Size = new System.Drawing.Size(724, 374);
            this.pnlCheat.TabIndex = 15;
            this.pnlCheat.Visible = false;
            // 
            // txtDeferral
            // 
            this.txtDeferral.Location = new System.Drawing.Point(196, 244);
            this.txtDeferral.MaxLength = 1900;
            this.txtDeferral.Multiline = true;
            this.txtDeferral.Name = "txtDeferral";
            this.txtDeferral.Size = new System.Drawing.Size(508, 80);
            this.txtDeferral.TabIndex = 29;
            this.txtDeferral.TextChanged += new System.EventHandler(this.txtDeferral_TextChanged);
            this.txtDeferral.Enter += new System.EventHandler(this.txtDeferral_Enter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Deferral Comment";
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(629, 339);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 32;
            this.btnQuit.Text = "Exit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnDefer
            // 
            this.btnDefer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefer.Location = new System.Drawing.Point(103, 339);
            this.btnDefer.Name = "btnDefer";
            this.btnDefer.Size = new System.Drawing.Size(75, 23);
            this.btnDefer.TabIndex = 31;
            this.btnDefer.Text = "Defer";
            this.btnDefer.UseVisualStyleBackColor = true;
            this.btnDefer.Click += new System.EventHandler(this.btnDefer_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(22, 339);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkPacked
            // 
            this.chkPacked.AutoSize = true;
            this.chkPacked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPacked.Location = new System.Drawing.Point(20, 221);
            this.chkPacked.Name = "chkPacked";
            this.chkPacked.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPacked.Size = new System.Drawing.Size(191, 17);
            this.chkPacked.TabIndex = 27;
            this.chkPacked.Text = "          Job Has been Packed";
            this.chkPacked.UseVisualStyleBackColor = true;
            // 
            // dtpFinishUnloading
            // 
            this.dtpFinishUnloading.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtpFinishUnloading.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinishUnloading.Location = new System.Drawing.Point(432, 195);
            this.dtpFinishUnloading.Name = "dtpFinishUnloading";
            this.dtpFinishUnloading.Size = new System.Drawing.Size(151, 20);
            this.dtpFinishUnloading.TabIndex = 25;
            // 
            // dtpStartUnloading
            // 
            this.dtpStartUnloading.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtpStartUnloading.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartUnloading.Location = new System.Drawing.Point(196, 195);
            this.dtpStartUnloading.Name = "dtpStartUnloading";
            this.dtpStartUnloading.Size = new System.Drawing.Size(151, 20);
            this.dtpStartUnloading.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Unloading";
            // 
            // dtpFinishLoading
            // 
            this.dtpFinishLoading.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtpFinishLoading.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinishLoading.Location = new System.Drawing.Point(432, 169);
            this.dtpFinishLoading.Name = "dtpFinishLoading";
            this.dtpFinishLoading.Size = new System.Drawing.Size(151, 20);
            this.dtpFinishLoading.TabIndex = 20;
            // 
            // dtpStartLoading
            // 
            this.dtpStartLoading.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtpStartLoading.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartLoading.Location = new System.Drawing.Point(196, 169);
            this.dtpStartLoading.Name = "dtpStartLoading";
            this.dtpStartLoading.Size = new System.Drawing.Size(151, 20);
            this.dtpStartLoading.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Loading";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(429, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(231, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Finish";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(193, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(224, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Start";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(353, 130);
            this.txtCP.Name = "txtCP";
            this.txtCP.ReadOnly = true;
            this.txtCP.Size = new System.Drawing.Size(151, 20);
            this.txtCP.TabIndex = 14;
            this.txtCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAP
            // 
            this.txtAP.Location = new System.Drawing.Point(196, 130);
            this.txtAP.Name = "txtAP";
            this.txtAP.ReadOnly = true;
            this.txtAP.Size = new System.Drawing.Size(151, 20);
            this.txtAP.TabIndex = 13;
            this.txtAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Area (m2) AP / CP";
            // 
            // txtPaintSystem
            // 
            this.txtPaintSystem.Location = new System.Drawing.Point(196, 108);
            this.txtPaintSystem.Name = "txtPaintSystem";
            this.txtPaintSystem.ReadOnly = true;
            this.txtPaintSystem.Size = new System.Drawing.Size(151, 20);
            this.txtPaintSystem.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Paint System";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(196, 84);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.ReadOnly = true;
            this.txtOrderNumber.Size = new System.Drawing.Size(151, 20);
            this.txtOrderNumber.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Customer Order #";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(196, 61);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(508, 20);
            this.txtCustomer.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Customer";
            // 
            // txtColour
            // 
            this.txtColour.Location = new System.Drawing.Point(353, 39);
            this.txtColour.Name = "txtColour";
            this.txtColour.ReadOnly = true;
            this.txtColour.Size = new System.Drawing.Size(351, 20);
            this.txtColour.TabIndex = 5;
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(196, 39);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.ReadOnly = true;
            this.txtProduct.Size = new System.Drawing.Size(151, 20);
            this.txtProduct.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Colour";
            // 
            // txtJob
            // 
            this.txtJob.Location = new System.Drawing.Point(353, 17);
            this.txtJob.Name = "txtJob";
            this.txtJob.ReadOnly = true;
            this.txtJob.Size = new System.Drawing.Size(151, 20);
            this.txtJob.TabIndex = 2;
            // 
            // txtWorkOrder
            // 
            this.txtWorkOrder.Location = new System.Drawing.Point(196, 17);
            this.txtWorkOrder.Name = "txtWorkOrder";
            this.txtWorkOrder.ReadOnly = true;
            this.txtWorkOrder.Size = new System.Drawing.Size(151, 20);
            this.txtWorkOrder.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Work Order / Job Number";
            // 
            // chkClearStartLoad
            // 
            this.chkClearStartLoad.AutoSize = true;
            this.chkClearStartLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClearStartLoad.Location = new System.Drawing.Point(362, 172);
            this.chkClearStartLoad.Name = "chkClearStartLoad";
            this.chkClearStartLoad.Size = new System.Drawing.Size(55, 17);
            this.chkClearStartLoad.TabIndex = 19;
            this.chkClearStartLoad.Text = "Clear";
            this.chkClearStartLoad.UseVisualStyleBackColor = true;
            // 
            // chkClearFinishLoad
            // 
            this.chkClearFinishLoad.AutoSize = true;
            this.chkClearFinishLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClearFinishLoad.Location = new System.Drawing.Point(605, 172);
            this.chkClearFinishLoad.Name = "chkClearFinishLoad";
            this.chkClearFinishLoad.Size = new System.Drawing.Size(55, 17);
            this.chkClearFinishLoad.TabIndex = 21;
            this.chkClearFinishLoad.Text = "Clear";
            this.chkClearFinishLoad.UseVisualStyleBackColor = true;
            // 
            // chkClearStartUnload
            // 
            this.chkClearStartUnload.AutoSize = true;
            this.chkClearStartUnload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClearStartUnload.Location = new System.Drawing.Point(362, 199);
            this.chkClearStartUnload.Name = "chkClearStartUnload";
            this.chkClearStartUnload.Size = new System.Drawing.Size(55, 17);
            this.chkClearStartUnload.TabIndex = 24;
            this.chkClearStartUnload.Text = "Clear";
            this.chkClearStartUnload.UseVisualStyleBackColor = true;
            // 
            // chkClearFinishUnload
            // 
            this.chkClearFinishUnload.AutoSize = true;
            this.chkClearFinishUnload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClearFinishUnload.Location = new System.Drawing.Point(605, 196);
            this.chkClearFinishUnload.Name = "chkClearFinishUnload";
            this.chkClearFinishUnload.Size = new System.Drawing.Size(55, 17);
            this.chkClearFinishUnload.TabIndex = 26;
            this.chkClearFinishUnload.Text = "Clear";
            this.chkClearFinishUnload.UseVisualStyleBackColor = true;
            // 
            // frmProductionLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1924, 555);
            this.Controls.Add(this.pnlCheat);
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
            this.pnlCheat.ResumeLayout(false);
            this.pnlCheat.PerformLayout();
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
        private System.Windows.Forms.Panel pnlCheat;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.TextBox txtWorkOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtColour;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.TextBox txtAP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPaintSystem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnDefer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkPacked;
        private System.Windows.Forms.DateTimePicker dtpFinishUnloading;
        private System.Windows.Forms.DateTimePicker dtpStartUnloading;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpFinishLoading;
        private System.Windows.Forms.DateTimePicker dtpStartLoading;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDeferral;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkClearFinishUnload;
        private System.Windows.Forms.CheckBox chkClearStartUnload;
        private System.Windows.Forms.CheckBox chkClearFinishLoad;
        private System.Windows.Forms.CheckBox chkClearStartLoad;
    }
}