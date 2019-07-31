namespace DXD.QuickCompare
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvCompare = new System.Windows.Forms.DataGridView();
            this.comr_passport_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comr_passport_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comr_out_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comr_in_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comr_destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comf_passport_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comf_passport_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comf_out_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comf_in_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comf_destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compare_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.un_match = new System.Windows.Forms.DataGridViewButtonColumn();
            this.com_query_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_report_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_feedback_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.com_add_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvCompare
            // 
            this.dgvCompare.AllowUserToAddRows = false;
            this.dgvCompare.AllowUserToDeleteRows = false;
            this.dgvCompare.AllowUserToResizeColumns = false;
            this.dgvCompare.AllowUserToResizeRows = false;
            this.dgvCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.comr_passport_no,
            this.comr_passport_type,
            this.comr_out_date,
            this.comr_in_date,
            this.comr_destination,
            this.comf_passport_no,
            this.comf_passport_type,
            this.comf_out_date,
            this.comf_in_date,
            this.comf_destination,
            this.compare_type,
            this.com_id,
            this.un_match,
            this.com_query_id,
            this.com_report_id,
            this.com_feedback_id,
            this.com_add_time});
            this.dgvCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompare.Location = new System.Drawing.Point(0, 0);
            this.dgvCompare.Name = "dgvCompare";
            this.dgvCompare.ReadOnly = true;
            this.dgvCompare.RowTemplate.Height = 23;
            this.dgvCompare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompare.Size = new System.Drawing.Size(800, 450);
            this.dgvCompare.TabIndex = 1;
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
            // comr_out_date
            // 
            this.comr_out_date.DataPropertyName = "rep_out_date";
            this.comr_out_date.HeaderText = "出境日期";
            this.comr_out_date.Name = "comr_out_date";
            this.comr_out_date.ReadOnly = true;
            // 
            // comr_in_date
            // 
            this.comr_in_date.DataPropertyName = "rep_in_date";
            this.comr_in_date.HeaderText = "入境日期";
            this.comr_in_date.Name = "comr_in_date";
            this.comr_in_date.ReadOnly = true;
            // 
            // comr_destination
            // 
            this.comr_destination.DataPropertyName = "rep_destination";
            this.comr_destination.HeaderText = "目的地";
            this.comr_destination.Name = "comr_destination";
            this.comr_destination.ReadOnly = true;
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
            // comf_out_date
            // 
            this.comf_out_date.DataPropertyName = "fee_out_date";
            this.comf_out_date.HeaderText = "出境日期";
            this.comf_out_date.Name = "comf_out_date";
            this.comf_out_date.ReadOnly = true;
            // 
            // comf_in_date
            // 
            this.comf_in_date.DataPropertyName = "fee_in_date";
            this.comf_in_date.HeaderText = "入境日期";
            this.comf_in_date.Name = "comf_in_date";
            this.comf_in_date.ReadOnly = true;
            // 
            // comf_destination
            // 
            this.comf_destination.DataPropertyName = "fee_destination";
            this.comf_destination.HeaderText = "目的地";
            this.comf_destination.Name = "comf_destination";
            this.comf_destination.ReadOnly = true;
            // 
            // compare_type
            // 
            this.compare_type.DataPropertyName = "compare_type";
            this.compare_type.HeaderText = "匹配结果";
            this.compare_type.Name = "compare_type";
            this.compare_type.ReadOnly = true;
            // 
            // com_id
            // 
            this.com_id.DataPropertyName = "id";
            this.com_id.HeaderText = "ID";
            this.com_id.Name = "com_id";
            this.com_id.ReadOnly = true;
            this.com_id.Visible = false;
            // 
            // un_match
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "取消";
            this.un_match.DefaultCellStyle = dataGridViewCellStyle1;
            this.un_match.HeaderText = "取消匹配";
            this.un_match.Name = "un_match";
            this.un_match.ReadOnly = true;
            this.un_match.Text = "取消";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCompare);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvCompare;
        private System.Windows.Forms.DataGridViewTextBoxColumn comr_passport_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn comr_passport_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn comr_out_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn comr_in_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn comr_destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn comf_passport_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn comf_passport_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn comf_out_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn comf_in_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn comf_destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn compare_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_id;
        private System.Windows.Forms.DataGridViewButtonColumn un_match;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_query_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_report_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_feedback_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn com_add_time;
    }
}

