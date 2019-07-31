namespace DXD.QuickCompare
{
    partial class FrmAddQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddQuery));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbQueryName = new System.Windows.Forms.TextBox();
            this.tbBatch = new System.Windows.Forms.TextBox();
            this.tbClient = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dtpEntrustDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.validQueryName = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.validBatch = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.validClient = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.validType = new CustomValidatorsLibrary.CustomValidator();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.11368F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.88632F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbQueryName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbBatch, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbClient, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.dtpEntrustDate, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbType, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(473, 315);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "比对任务名称：";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "比对编号：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "比对单位：";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "比对类型：";
            // 
            // tbQueryName
            // 
            this.tbQueryName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbQueryName.Location = new System.Drawing.Point(188, 16);
            this.tbQueryName.Name = "tbQueryName";
            this.tbQueryName.Size = new System.Drawing.Size(200, 21);
            this.tbQueryName.TabIndex = 5;
            // 
            // tbBatch
            // 
            this.tbBatch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbBatch.Location = new System.Drawing.Point(188, 69);
            this.tbBatch.Name = "tbBatch";
            this.tbBatch.Size = new System.Drawing.Size(200, 21);
            this.tbBatch.TabIndex = 6;
            // 
            // tbClient
            // 
            this.tbClient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbClient.Location = new System.Drawing.Point(188, 122);
            this.tbClient.Name = "tbClient";
            this.tbClient.Size = new System.Drawing.Size(200, 21);
            this.tbClient.TabIndex = 7;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(274, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(116, 10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dtpEntrustDate
            // 
            this.dtpEntrustDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpEntrustDate.Location = new System.Drawing.Point(188, 228);
            this.dtpEntrustDate.Name = "dtpEntrustDate";
            this.dtpEntrustDate.Size = new System.Drawing.Size(200, 21);
            this.dtpEntrustDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "比对日期：";
            // 
            // cmbType
            // 
            this.cmbType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbType.DropDownWidth = 150;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(188, 175);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(200, 20);
            this.cmbType.TabIndex = 11;
            // 
            // validQueryName
            // 
            this.validQueryName.ControlToValidate = this.tbQueryName;
            this.validQueryName.ErrorMessage = "任务名称不能为空";
            this.validQueryName.Icon = ((System.Drawing.Icon)(resources.GetObject("validQueryName.Icon")));
            // 
            // validBatch
            // 
            this.validBatch.ControlToValidate = this.tbBatch;
            this.validBatch.ErrorMessage = "比对编号不能为空";
            this.validBatch.Icon = ((System.Drawing.Icon)(resources.GetObject("validBatch.Icon")));
            // 
            // validClient
            // 
            this.validClient.ControlToValidate = this.tbClient;
            this.validClient.ErrorMessage = "比对单位不能为空";
            this.validClient.Icon = ((System.Drawing.Icon)(resources.GetObject("validClient.Icon")));
            // 
            // validType
            // 
            this.validType.ControlToValidate = this.cmbType;
            this.validType.ErrorMessage = "请选择比对类型";
            this.validType.Icon = ((System.Drawing.Icon)(resources.GetObject("validType.Icon")));
            this.validType.Validating += new CustomValidatorsLibrary.CustomValidator.ValidatingEventHandler(this.validType_Validating);
            // 
            // FrmAddQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 315);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "FrmAddQuery";
            this.Text = "新建比对任务";
            this.Load += new System.EventHandler(this.FrmAddQuery_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbQueryName;
        private System.Windows.Forms.TextBox tbBatch;
        private System.Windows.Forms.TextBox tbClient;
        private System.Windows.Forms.DateTimePicker dtpEntrustDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private CustomValidatorsLibrary.RequiredFieldValidator validQueryName;
        private CustomValidatorsLibrary.RequiredFieldValidator validBatch;
        private CustomValidatorsLibrary.RequiredFieldValidator validClient;
        private CustomValidatorsLibrary.CustomValidator validType;
    }
}