namespace DXD.QuickCompare
{
    partial class FrmPersonList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgvPersonList = new System.Windows.Forms.DataGridView();
            this.pl_numid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_list_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_card_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_work_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_post = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_pol_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_is_compare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_is_match = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_parent_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_appellation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_is_together = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_add_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_add_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(874, 56);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(72, 53);
            this.toolStripButton1.Text = "导出所选项";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dgvPersonList
            // 
            this.dgvPersonList.AllowUserToAddRows = false;
            this.dgvPersonList.AllowUserToDeleteRows = false;
            this.dgvPersonList.AllowUserToResizeColumns = false;
            this.dgvPersonList.AllowUserToResizeRows = false;
            this.dgvPersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pl_numid,
            this.pl_id,
            this.pl_list_id,
            this.pl_full_name,
            this.pl_sex,
            this.pl_card_no,
            this.pl_work_unit,
            this.pl_post,
            this.pl_pol_status,
            this.pl_is_compare,
            this.pl_is_match,
            this.pl_parent_id,
            this.pl_appellation,
            this.pl_is_together,
            this.pl_add_user,
            this.pl_add_time});
            this.dgvPersonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonList.Location = new System.Drawing.Point(0, 56);
            this.dgvPersonList.Name = "dgvPersonList";
            this.dgvPersonList.ReadOnly = true;
            this.dgvPersonList.RowTemplate.Height = 23;
            this.dgvPersonList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonList.Size = new System.Drawing.Size(874, 403);
            this.dgvPersonList.TabIndex = 1;
            this.dgvPersonList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonList_CellDoubleClick);
            this.dgvPersonList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPersonList_CellPainting);
            this.dgvPersonList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPersonList_RowPostPaint);
            // 
            // pl_numid
            // 
            this.pl_numid.HeaderText = "序号";
            this.pl_numid.Name = "pl_numid";
            this.pl_numid.ReadOnly = true;
            // 
            // pl_id
            // 
            this.pl_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pl_id.DataPropertyName = "id";
            this.pl_id.HeaderText = "ID";
            this.pl_id.MinimumWidth = 50;
            this.pl_id.Name = "pl_id";
            this.pl_id.ReadOnly = true;
            this.pl_id.Visible = false;
            // 
            // pl_list_id
            // 
            this.pl_list_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pl_list_id.DataPropertyName = "list_id";
            this.pl_list_id.HeaderText = "ListID";
            this.pl_list_id.MinimumWidth = 80;
            this.pl_list_id.Name = "pl_list_id";
            this.pl_list_id.ReadOnly = true;
            this.pl_list_id.Visible = false;
            // 
            // pl_full_name
            // 
            this.pl_full_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pl_full_name.DataPropertyName = "full_name";
            this.pl_full_name.HeaderText = "姓名";
            this.pl_full_name.MinimumWidth = 100;
            this.pl_full_name.Name = "pl_full_name";
            this.pl_full_name.ReadOnly = true;
            // 
            // pl_sex
            // 
            this.pl_sex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pl_sex.DataPropertyName = "sex";
            this.pl_sex.HeaderText = "性别";
            this.pl_sex.MinimumWidth = 60;
            this.pl_sex.Name = "pl_sex";
            this.pl_sex.ReadOnly = true;
            // 
            // pl_card_no
            // 
            this.pl_card_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pl_card_no.DataPropertyName = "card_no";
            this.pl_card_no.HeaderText = "身份证号";
            this.pl_card_no.MinimumWidth = 150;
            this.pl_card_no.Name = "pl_card_no";
            this.pl_card_no.ReadOnly = true;
            // 
            // pl_work_unit
            // 
            this.pl_work_unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pl_work_unit.DataPropertyName = "work_unit";
            this.pl_work_unit.HeaderText = "工作单位";
            this.pl_work_unit.MinimumWidth = 150;
            this.pl_work_unit.Name = "pl_work_unit";
            this.pl_work_unit.ReadOnly = true;
            // 
            // pl_post
            // 
            this.pl_post.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pl_post.DataPropertyName = "post";
            this.pl_post.HeaderText = "职务";
            this.pl_post.MinimumWidth = 80;
            this.pl_post.Name = "pl_post";
            this.pl_post.ReadOnly = true;
            // 
            // pl_pol_status
            // 
            this.pl_pol_status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pl_pol_status.DataPropertyName = "pol_status";
            this.pl_pol_status.HeaderText = "政治面貌";
            this.pl_pol_status.MinimumWidth = 100;
            this.pl_pol_status.Name = "pl_pol_status";
            this.pl_pol_status.ReadOnly = true;
            // 
            // pl_is_compare
            // 
            this.pl_is_compare.DataPropertyName = "is_compare";
            this.pl_is_compare.HeaderText = "是否比对";
            this.pl_is_compare.Name = "pl_is_compare";
            this.pl_is_compare.ReadOnly = true;
            this.pl_is_compare.Visible = false;
            // 
            // pl_is_match
            // 
            this.pl_is_match.DataPropertyName = "is_match";
            this.pl_is_match.HeaderText = "是否一致";
            this.pl_is_match.Name = "pl_is_match";
            this.pl_is_match.ReadOnly = true;
            this.pl_is_match.Visible = false;
            // 
            // pl_parent_id
            // 
            this.pl_parent_id.DataPropertyName = "parent_id";
            this.pl_parent_id.HeaderText = "所属对象";
            this.pl_parent_id.Name = "pl_parent_id";
            this.pl_parent_id.ReadOnly = true;
            this.pl_parent_id.Visible = false;
            // 
            // pl_appellation
            // 
            this.pl_appellation.DataPropertyName = "appellation";
            this.pl_appellation.HeaderText = "关系";
            this.pl_appellation.Name = "pl_appellation";
            this.pl_appellation.ReadOnly = true;
            this.pl_appellation.Visible = false;
            // 
            // pl_is_together
            // 
            this.pl_is_together.DataPropertyName = "is_together";
            this.pl_is_together.HeaderText = "是否共同生活";
            this.pl_is_together.Name = "pl_is_together";
            this.pl_is_together.ReadOnly = true;
            this.pl_is_together.Visible = false;
            // 
            // pl_add_user
            // 
            this.pl_add_user.DataPropertyName = "add_user";
            this.pl_add_user.HeaderText = "添加用户";
            this.pl_add_user.Name = "pl_add_user";
            this.pl_add_user.ReadOnly = true;
            this.pl_add_user.Visible = false;
            // 
            // pl_add_time
            // 
            this.pl_add_time.DataPropertyName = "add_time";
            this.pl_add_time.HeaderText = "添加时间";
            this.pl_add_time.Name = "pl_add_time";
            this.pl_add_time.ReadOnly = true;
            this.pl_add_time.Visible = false;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 53);
            this.toolStripButton2.Text = "导出全部";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // FrmPersonList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 459);
            this.Controls.Add(this.dgvPersonList);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "FrmPersonList";
            this.Text = "比对对象列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPersonList_FormClosed);
            this.Load += new System.EventHandler(this.FrmPersonList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dgvPersonList;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_numid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_list_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_card_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_work_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_post;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_pol_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_is_compare;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_is_match;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_parent_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_appellation;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_is_together;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_add_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn pl_add_time;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}