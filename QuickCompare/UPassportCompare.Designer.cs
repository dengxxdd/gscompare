namespace DXD.QuickCompare.Controls
{
    partial class UPassportCompare
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UPassportCompare));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPassportFeedback = new System.Windows.Forms.DataGridView();
            this.fee_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee_query_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee_passport_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee_passport_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee_issuing_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee_valid_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnToReport = new System.Windows.Forms.DataGridViewButtonColumn();
            this.fee_is_match = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fee_add_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPassportReport = new System.Windows.Forms.DataGridView();
            this.rep_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rep_query_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rep_passport_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rep_passport_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rep_issuing_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rep_valid_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rep_is_match = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rep_add_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rep_feedback_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPassportCompare = new System.Windows.Forms.DataGridView();
            this.comr_passport_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comr_passport_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comr_issuing_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comr_valid_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comf_passport_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comf_passport_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comf_issuing_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comf_valid_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compare_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.un_match = new System.Windows.Forms.DataGridViewButtonColumn();
            this.com_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_query_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_report_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_feedback_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_add_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbReport = new System.Windows.Forms.TextBox();
            this.tbFeedback = new System.Windows.Forms.TextBox();
            this.tbCompare = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSaveResult = new System.Windows.Forms.ToolStripButton();
            this.btnCompare = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassportFeedback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassportReport)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassportCompare)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.dgvPassportFeedback, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.dgvPassportReport, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCompare, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1177, 487);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(631, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "查询反馈数据：";
            // 
            // dgvPassportFeedback
            // 
            this.dgvPassportFeedback.AllowUserToAddRows = false;
            this.dgvPassportFeedback.AllowUserToDeleteRows = false;
            this.dgvPassportFeedback.AllowUserToResizeColumns = false;
            this.dgvPassportFeedback.AllowUserToResizeRows = false;
            this.dgvPassportFeedback.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassportFeedback.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fee_id,
            this.fee_query_id,
            this.fee_passport_no,
            this.fee_passport_type,
            this.fee_issuing_date,
            this.fee_valid_date,
            this.btnToReport,
            this.fee_is_match,
            this.fee_add_time});
            this.dgvPassportFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPassportFeedback.Location = new System.Drawing.Point(631, 63);
            this.dgvPassportFeedback.MultiSelect = false;
            this.dgvPassportFeedback.Name = "dgvPassportFeedback";
            this.dgvPassportFeedback.ReadOnly = true;
            this.dgvPassportFeedback.RowTemplate.Height = 23;
            this.dgvPassportFeedback.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPassportFeedback.Size = new System.Drawing.Size(543, 123);
            this.dgvPassportFeedback.TabIndex = 3;
            this.dgvPassportFeedback.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPassportFeedback_CellContentClick);
            this.dgvPassportFeedback.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPassportFeedback_CellPainting);
            // 
            // fee_id
            // 
            this.fee_id.DataPropertyName = "id";
            this.fee_id.HeaderText = "Id";
            this.fee_id.Name = "fee_id";
            this.fee_id.ReadOnly = true;
            this.fee_id.Visible = false;
            // 
            // fee_query_id
            // 
            this.fee_query_id.DataPropertyName = "query_id";
            this.fee_query_id.HeaderText = "QueryId";
            this.fee_query_id.Name = "fee_query_id";
            this.fee_query_id.ReadOnly = true;
            this.fee_query_id.Visible = false;
            // 
            // fee_passport_no
            // 
            this.fee_passport_no.DataPropertyName = "passport_no";
            this.fee_passport_no.HeaderText = "证件号码";
            this.fee_passport_no.Name = "fee_passport_no";
            this.fee_passport_no.ReadOnly = true;
            this.fee_passport_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fee_passport_no.Width = 120;
            // 
            // fee_passport_type
            // 
            this.fee_passport_type.DataPropertyName = "passport_type";
            this.fee_passport_type.HeaderText = "证件类型";
            this.fee_passport_type.Name = "fee_passport_type";
            this.fee_passport_type.ReadOnly = true;
            this.fee_passport_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fee_passport_type.Width = 150;
            // 
            // fee_issuing_date
            // 
            this.fee_issuing_date.DataPropertyName = "issuing_date";
            this.fee_issuing_date.HeaderText = "签发日期";
            this.fee_issuing_date.Name = "fee_issuing_date";
            this.fee_issuing_date.ReadOnly = true;
            this.fee_issuing_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fee_valid_date
            // 
            this.fee_valid_date.DataPropertyName = "valid_date";
            this.fee_valid_date.HeaderText = "有效期至";
            this.fee_valid_date.Name = "fee_valid_date";
            this.fee_valid_date.ReadOnly = true;
            this.fee_valid_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnToReport
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "<<左移";
            this.btnToReport.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnToReport.HeaderText = "移至个人报告";
            this.btnToReport.Name = "btnToReport";
            this.btnToReport.ReadOnly = true;
            this.btnToReport.Text = "<<左移";
            // 
            // fee_is_match
            // 
            this.fee_is_match.DataPropertyName = "is_match";
            this.fee_is_match.HeaderText = "是否匹配";
            this.fee_is_match.Name = "fee_is_match";
            this.fee_is_match.ReadOnly = true;
            this.fee_is_match.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fee_is_match.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fee_is_match.Visible = false;
            // 
            // fee_add_time
            // 
            this.fee_add_time.DataPropertyName = "add_time";
            this.fee_add_time.HeaderText = "AddTime";
            this.fee_add_time.Name = "fee_add_time";
            this.fee_add_time.ReadOnly = true;
            this.fee_add_time.Visible = false;
            // 
            // dgvPassportReport
            // 
            this.dgvPassportReport.AllowUserToAddRows = false;
            this.dgvPassportReport.AllowUserToDeleteRows = false;
            this.dgvPassportReport.AllowUserToResizeColumns = false;
            this.dgvPassportReport.AllowUserToResizeRows = false;
            this.dgvPassportReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassportReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rep_id,
            this.rep_query_id,
            this.rep_passport_no,
            this.rep_passport_type,
            this.rep_issuing_date,
            this.rep_valid_date,
            this.rep_is_match,
            this.rep_add_time,
            this.rep_feedback_id});
            this.dgvPassportReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPassportReport.Location = new System.Drawing.Point(3, 63);
            this.dgvPassportReport.MultiSelect = false;
            this.dgvPassportReport.Name = "dgvPassportReport";
            this.dgvPassportReport.RowTemplate.Height = 23;
            this.dgvPassportReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPassportReport.Size = new System.Drawing.Size(542, 123);
            this.dgvPassportReport.TabIndex = 4;
            this.dgvPassportReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPassportReport_CellContentClick);
            this.dgvPassportReport.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPassportReport_CellEndEdit);
            this.dgvPassportReport.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPassportReport_CellPainting);
            // 
            // rep_id
            // 
            this.rep_id.DataPropertyName = "id";
            this.rep_id.HeaderText = "Id";
            this.rep_id.Name = "rep_id";
            this.rep_id.Visible = false;
            // 
            // rep_query_id
            // 
            this.rep_query_id.DataPropertyName = "query_id";
            this.rep_query_id.HeaderText = "QueryId";
            this.rep_query_id.Name = "rep_query_id";
            this.rep_query_id.Visible = false;
            // 
            // rep_passport_no
            // 
            this.rep_passport_no.DataPropertyName = "passport_no";
            this.rep_passport_no.HeaderText = "证件号码";
            this.rep_passport_no.Name = "rep_passport_no";
            this.rep_passport_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rep_passport_no.Width = 120;
            // 
            // rep_passport_type
            // 
            this.rep_passport_type.DataPropertyName = "passport_type";
            this.rep_passport_type.HeaderText = "证件类型";
            this.rep_passport_type.Name = "rep_passport_type";
            this.rep_passport_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rep_passport_type.Width = 150;
            // 
            // rep_issuing_date
            // 
            this.rep_issuing_date.DataPropertyName = "issuing_date";
            this.rep_issuing_date.HeaderText = "签发日期";
            this.rep_issuing_date.Name = "rep_issuing_date";
            this.rep_issuing_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // rep_valid_date
            // 
            this.rep_valid_date.DataPropertyName = "valid_date";
            this.rep_valid_date.HeaderText = "有效期至";
            this.rep_valid_date.Name = "rep_valid_date";
            this.rep_valid_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // rep_is_match
            // 
            this.rep_is_match.DataPropertyName = "is_match";
            this.rep_is_match.HeaderText = "是否匹配";
            this.rep_is_match.Name = "rep_is_match";
            this.rep_is_match.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rep_is_match.Visible = false;
            // 
            // rep_add_time
            // 
            this.rep_add_time.DataPropertyName = "add_time";
            this.rep_add_time.HeaderText = "addtime";
            this.rep_add_time.Name = "rep_add_time";
            this.rep_add_time.Visible = false;
            // 
            // rep_feedback_id
            // 
            this.rep_feedback_id.DataPropertyName = "feedback_id";
            this.rep_feedback_id.HeaderText = "FeedbackId";
            this.rep_feedback_id.Name = "rep_feedback_id";
            this.rep_feedback_id.Visible = false;
            // 
            // panel2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this.dgvPassportCompare);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1171, 123);
            this.panel2.TabIndex = 5;
            // 
            // dgvPassportCompare
            // 
            this.dgvPassportCompare.AllowUserToAddRows = false;
            this.dgvPassportCompare.AllowUserToDeleteRows = false;
            this.dgvPassportCompare.AllowUserToResizeColumns = false;
            this.dgvPassportCompare.AllowUserToResizeRows = false;
            this.dgvPassportCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassportCompare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.comr_passport_no,
            this.comr_passport_type,
            this.comr_issuing_date,
            this.comr_valid_date,
            this.comf_passport_no,
            this.comf_passport_type,
            this.comf_issuing_date,
            this.comf_valid_date,
            this.compare_type,
            this.un_match,
            this.com_id,
            this.com_query_id,
            this.com_report_id,
            this.com_feedback_id,
            this.com_add_time});
            this.dgvPassportCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPassportCompare.Location = new System.Drawing.Point(0, 0);
            this.dgvPassportCompare.Name = "dgvPassportCompare";
            this.dgvPassportCompare.ReadOnly = true;
            this.dgvPassportCompare.RowTemplate.Height = 23;
            this.dgvPassportCompare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPassportCompare.Size = new System.Drawing.Size(1171, 123);
            this.dgvPassportCompare.TabIndex = 0;
            this.dgvPassportCompare.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPassportCompare_CellContentClick);
            // 
            // comr_passport_no
            // 
            this.comr_passport_no.DataPropertyName = "rep_passport_no";
            this.comr_passport_no.HeaderText = "证件号码";
            this.comr_passport_no.Name = "comr_passport_no";
            this.comr_passport_no.ReadOnly = true;
            // 
            // comr_passport_type
            // 
            this.comr_passport_type.DataPropertyName = "rep_passport_type";
            this.comr_passport_type.HeaderText = "证件类型";
            this.comr_passport_type.Name = "comr_passport_type";
            this.comr_passport_type.ReadOnly = true;
            this.comr_passport_type.Width = 150;
            // 
            // comr_issuing_date
            // 
            this.comr_issuing_date.DataPropertyName = "rep_issuing_date";
            this.comr_issuing_date.HeaderText = "签发日期";
            this.comr_issuing_date.Name = "comr_issuing_date";
            this.comr_issuing_date.ReadOnly = true;
            // 
            // comr_valid_date
            // 
            this.comr_valid_date.DataPropertyName = "rep_valid_date";
            this.comr_valid_date.HeaderText = "有效期至";
            this.comr_valid_date.Name = "comr_valid_date";
            this.comr_valid_date.ReadOnly = true;
            // 
            // comf_passport_no
            // 
            this.comf_passport_no.DataPropertyName = "fee_passport_no";
            this.comf_passport_no.HeaderText = "证件号码";
            this.comf_passport_no.Name = "comf_passport_no";
            this.comf_passport_no.ReadOnly = true;
            // 
            // comf_passport_type
            // 
            this.comf_passport_type.DataPropertyName = "fee_passport_type";
            this.comf_passport_type.HeaderText = "证件类型";
            this.comf_passport_type.Name = "comf_passport_type";
            this.comf_passport_type.ReadOnly = true;
            this.comf_passport_type.Width = 150;
            // 
            // comf_issuing_date
            // 
            this.comf_issuing_date.DataPropertyName = "fee_issuing_date";
            this.comf_issuing_date.HeaderText = "签发日期";
            this.comf_issuing_date.Name = "comf_issuing_date";
            this.comf_issuing_date.ReadOnly = true;
            // 
            // comf_valid_date
            // 
            this.comf_valid_date.DataPropertyName = "fee_valid_date";
            this.comf_valid_date.HeaderText = "有效期至";
            this.comf_valid_date.Name = "comf_valid_date";
            this.comf_valid_date.ReadOnly = true;
            // 
            // compare_type
            // 
            this.compare_type.DataPropertyName = "compare_type";
            this.compare_type.HeaderText = "匹配结果";
            this.compare_type.Name = "compare_type";
            this.compare_type.ReadOnly = true;
            // 
            // un_match
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "取消";
            this.un_match.DefaultCellStyle = dataGridViewCellStyle2;
            this.un_match.HeaderText = "取消匹配";
            this.un_match.Name = "un_match";
            this.un_match.ReadOnly = true;
            this.un_match.Text = "取消";
            // 
            // com_id
            // 
            this.com_id.DataPropertyName = "id";
            this.com_id.HeaderText = "ID";
            this.com_id.Name = "com_id";
            this.com_id.ReadOnly = true;
            this.com_id.Visible = false;
            // 
            // com_query_id
            // 
            this.com_query_id.DataPropertyName = "query_id";
            this.com_query_id.HeaderText = "QueryId";
            this.com_query_id.Name = "com_query_id";
            this.com_query_id.ReadOnly = true;
            this.com_query_id.Visible = false;
            // 
            // com_report_id
            // 
            this.com_report_id.DataPropertyName = "report_id";
            this.com_report_id.HeaderText = "ReportId";
            this.com_report_id.Name = "com_report_id";
            this.com_report_id.ReadOnly = true;
            this.com_report_id.Visible = false;
            // 
            // com_feedback_id
            // 
            this.com_feedback_id.DataPropertyName = "feedback_id";
            this.com_feedback_id.HeaderText = "FeedbackId";
            this.com_feedback_id.Name = "com_feedback_id";
            this.com_feedback_id.ReadOnly = true;
            this.com_feedback_id.Visible = false;
            // 
            // com_add_time
            // 
            this.com_add_time.DataPropertyName = "add_time";
            this.com_add_time.HeaderText = "AddTime";
            this.com_add_time.Name = "com_add_time";
            this.com_add_time.ReadOnly = true;
            this.com_add_time.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "数据匹配情况：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(542, 24);
            this.panel3.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "添加";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "个人报告数据：";
            // 
            // panel4
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel4, 3);
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 361);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1171, 123);
            this.panel4.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbReport, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tbFeedback, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.tbCompare, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1171, 123);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "个人报告情况：";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "反馈情况：";
            // 
            // tbReport
            // 
            this.tbReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReport.Location = new System.Drawing.Point(3, 23);
            this.tbReport.Multiline = true;
            this.tbReport.Name = "tbReport";
            this.tbReport.Size = new System.Drawing.Size(377, 97);
            this.tbReport.TabIndex = 3;
            // 
            // tbFeedback
            // 
            this.tbFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFeedback.Location = new System.Drawing.Point(396, 23);
            this.tbFeedback.Multiline = true;
            this.tbFeedback.Name = "tbFeedback";
            this.tbFeedback.Size = new System.Drawing.Size(377, 97);
            this.tbFeedback.TabIndex = 4;
            // 
            // tbCompare
            // 
            this.tbCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCompare.Location = new System.Drawing.Point(789, 23);
            this.tbCompare.Multiline = true;
            this.tbCompare.Name = "tbCompare";
            this.tbCompare.Size = new System.Drawing.Size(379, 97);
            this.tbCompare.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(789, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(379, 14);
            this.panel5.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "比对结果：";
            // 
            // panel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 24);
            this.panel1.TabIndex = 11;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveResult});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1171, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSaveResult
            // 
            this.tsbSaveResult.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSaveResult.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveResult.Image")));
            this.tsbSaveResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveResult.Name = "tsbSaveResult";
            this.tsbSaveResult.Size = new System.Drawing.Size(84, 22);
            this.tsbSaveResult.Text = "保存比对结果";
            this.tsbSaveResult.Click += new System.EventHandler(this.tsbSaveResult_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(551, 63);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(74, 23);
            this.btnCompare.TabIndex = 12;
            this.btnCompare.Text = "匹配";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // UPassportCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "UPassportCompare";
            this.Size = new System.Drawing.Size(1177, 487);
            this.Load += new System.EventHandler(this.UPassportCompare_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassportFeedback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassportReport)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassportCompare)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPassportFeedback;
        private System.Windows.Forms.DataGridView dgvPassportReport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPassportCompare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbReport;
        private System.Windows.Forms.TextBox tbFeedback;
        private System.Windows.Forms.TextBox tbCompare;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSaveResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee_query_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee_passport_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee_passport_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee_issuing_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee_valid_date;
        private System.Windows.Forms.DataGridViewButtonColumn btnToReport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fee_is_match;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee_add_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn rep_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn rep_query_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn rep_passport_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn rep_passport_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn rep_issuing_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn rep_valid_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn rep_is_match;
        private System.Windows.Forms.DataGridViewTextBoxColumn rep_add_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn rep_feedback_id;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.DataGridViewTextBoxColumn comr_passport_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn comr_passport_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn comr_issuing_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn comr_valid_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn comf_passport_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn comf_passport_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn comf_issuing_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn comf_valid_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn compare_type;
        private System.Windows.Forms.DataGridViewButtonColumn un_match;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_query_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_report_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_feedback_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_add_time;
    }
}
