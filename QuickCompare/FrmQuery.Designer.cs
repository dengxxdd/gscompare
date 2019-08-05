namespace DXD.QuickCompare
{
    partial class FrmQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvQueryList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QueryTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QueryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntrustDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedback_passport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.feedback_leave = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.feedback_house1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.feedback_house2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.feedback_security = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.feedback_insurance = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.feedback_business = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsImport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 56);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 53);
            this.toolStripButton1.Text = "新建任务";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(84, 53);
            this.toolStripButton2.Text = "导入反馈数据";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // dgvQueryList
            // 
            this.dgvQueryList.AllowUserToAddRows = false;
            this.dgvQueryList.AllowUserToDeleteRows = false;
            this.dgvQueryList.AllowUserToResizeColumns = false;
            this.dgvQueryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.AddUser,
            this.AddTime,
            this.QueryTitle,
            this.Batch,
            this.Client,
            this.QueryType,
            this.EntrustDate,
            this.feedback_passport,
            this.feedback_leave,
            this.feedback_house1,
            this.feedback_house2,
            this.feedback_security,
            this.feedback_insurance,
            this.feedback_business,
            this.IsImport,
            this.Count});
            this.dgvQueryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQueryList.Location = new System.Drawing.Point(0, 56);
            this.dgvQueryList.MultiSelect = false;
            this.dgvQueryList.Name = "dgvQueryList";
            this.dgvQueryList.ReadOnly = true;
            this.dgvQueryList.RowTemplate.Height = 23;
            this.dgvQueryList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueryList.Size = new System.Drawing.Size(800, 394);
            this.dgvQueryList.TabIndex = 1;
            this.dgvQueryList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQueryList_CellDoubleClick);
            this.dgvQueryList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvQueryList_CellPainting);
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "序号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Visible = false;
            // 
            // AddUser
            // 
            this.AddUser.DataPropertyName = "add_user";
            this.AddUser.HeaderText = "AddUser";
            this.AddUser.Name = "AddUser";
            this.AddUser.ReadOnly = true;
            this.AddUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AddUser.Visible = false;
            // 
            // AddTime
            // 
            this.AddTime.DataPropertyName = "add_time";
            this.AddTime.HeaderText = "AddTime";
            this.AddTime.Name = "AddTime";
            this.AddTime.ReadOnly = true;
            this.AddTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AddTime.Visible = false;
            // 
            // QueryTitle
            // 
            this.QueryTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QueryTitle.DataPropertyName = "query_title";
            this.QueryTitle.HeaderText = "比对任务名称";
            this.QueryTitle.MinimumWidth = 220;
            this.QueryTitle.Name = "QueryTitle";
            this.QueryTitle.ReadOnly = true;
            this.QueryTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Batch
            // 
            this.Batch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Batch.DataPropertyName = "batch";
            this.Batch.HeaderText = "任务编号";
            this.Batch.MinimumWidth = 90;
            this.Batch.Name = "Batch";
            this.Batch.ReadOnly = true;
            this.Batch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Client
            // 
            this.Client.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Client.DataPropertyName = "client";
            this.Client.HeaderText = "比对单位";
            this.Client.MinimumWidth = 125;
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            this.Client.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // QueryType
            // 
            this.QueryType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QueryType.DataPropertyName = "query_type";
            this.QueryType.HeaderText = "比对类型";
            this.QueryType.MinimumWidth = 80;
            this.QueryType.Name = "QueryType";
            this.QueryType.ReadOnly = true;
            this.QueryType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EntrustDate
            // 
            this.EntrustDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EntrustDate.DataPropertyName = "entrust_date";
            this.EntrustDate.HeaderText = "建立日期";
            this.EntrustDate.MinimumWidth = 80;
            this.EntrustDate.Name = "EntrustDate";
            this.EntrustDate.ReadOnly = true;
            this.EntrustDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // feedback_passport
            // 
            this.feedback_passport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.feedback_passport.DataPropertyName = "feedback_passport";
            this.feedback_passport.HeaderText = "持证记录";
            this.feedback_passport.MinimumWidth = 80;
            this.feedback_passport.Name = "feedback_passport";
            this.feedback_passport.ReadOnly = true;
            this.feedback_passport.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.feedback_passport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // feedback_leave
            // 
            this.feedback_leave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.feedback_leave.DataPropertyName = "feedback_leave";
            this.feedback_leave.HeaderText = "出入境记录";
            this.feedback_leave.MinimumWidth = 100;
            this.feedback_leave.Name = "feedback_leave";
            this.feedback_leave.ReadOnly = true;
            this.feedback_leave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.feedback_leave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // feedback_house1
            // 
            this.feedback_house1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.feedback_house1.DataPropertyName = "feedback_house1";
            this.feedback_house1.HeaderText = "住建";
            this.feedback_house1.MinimumWidth = 60;
            this.feedback_house1.Name = "feedback_house1";
            this.feedback_house1.ReadOnly = true;
            this.feedback_house1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.feedback_house1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // feedback_house2
            // 
            this.feedback_house2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.feedback_house2.DataPropertyName = "feedback_house2";
            this.feedback_house2.FillWeight = 80F;
            this.feedback_house2.HeaderText = "国土";
            this.feedback_house2.MinimumWidth = 60;
            this.feedback_house2.Name = "feedback_house2";
            this.feedback_house2.ReadOnly = true;
            this.feedback_house2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.feedback_house2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // feedback_security
            // 
            this.feedback_security.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.feedback_security.DataPropertyName = "feedback_security";
            this.feedback_security.FillWeight = 60F;
            this.feedback_security.HeaderText = "证券";
            this.feedback_security.MinimumWidth = 60;
            this.feedback_security.Name = "feedback_security";
            this.feedback_security.ReadOnly = true;
            this.feedback_security.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.feedback_security.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // feedback_insurance
            // 
            this.feedback_insurance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.feedback_insurance.DataPropertyName = "feedback_insurance";
            this.feedback_insurance.HeaderText = "保险";
            this.feedback_insurance.MinimumWidth = 60;
            this.feedback_insurance.Name = "feedback_insurance";
            this.feedback_insurance.ReadOnly = true;
            this.feedback_insurance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.feedback_insurance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // feedback_business
            // 
            this.feedback_business.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.feedback_business.DataPropertyName = "feedback_business";
            this.feedback_business.HeaderText = "工商";
            this.feedback_business.MinimumWidth = 60;
            this.feedback_business.Name = "feedback_business";
            this.feedback_business.ReadOnly = true;
            this.feedback_business.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.feedback_business.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsImport
            // 
            this.IsImport.DataPropertyName = "is_import";
            this.IsImport.HeaderText = "IsImport";
            this.IsImport.Name = "IsImport";
            this.IsImport.ReadOnly = true;
            this.IsImport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IsImport.Visible = false;
            // 
            // Count
            // 
            this.Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Count.DataPropertyName = "count";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Count.DefaultCellStyle = dataGridViewCellStyle1;
            this.Count.HeaderText = "总人数";
            this.Count.MinimumWidth = 80;
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(84, 53);
            this.toolStripButton3.Text = "导入填报数据";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // FrmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvQueryList);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "FrmQuery";
            this.Text = "比对批次管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmQuery_FormClosed);
            this.Load += new System.EventHandler(this.FrmQuery_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridView dgvQueryList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn QueryTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn QueryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntrustDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn feedback_passport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn feedback_leave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn feedback_house1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn feedback_house2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn feedback_security;
        private System.Windows.Forms.DataGridViewCheckBoxColumn feedback_insurance;
        private System.Windows.Forms.DataGridViewCheckBoxColumn feedback_business;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}