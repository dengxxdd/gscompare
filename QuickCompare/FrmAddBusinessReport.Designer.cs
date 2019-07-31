namespace DXD.QuickCompare {
    partial class FrmAddBusinessReport {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddBusinessReport));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbBusName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbBusOwner = new System.Windows.Forms.ComboBox();
            this.cbbBusType = new System.Windows.Forms.ComboBox();
            this.tbSubscribe = new System.Windows.Forms.TextBox();
            this.tbProportion = new System.Windows.Forms.TextBox();
            this.tbOffice = new System.Windows.Forms.TextBox();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.validBusName = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.validOffice = new CustomValidatorsLibrary.RequiredFieldValidator();
            this.validSubscribe = new CustomValidatorsLibrary.RegularExpressionValidator();
            this.validProportion = new CustomValidatorsLibrary.RegularExpressionValidator();
            this.validOwner = new CustomValidatorsLibrary.CustomValidator();
            this.validBusType = new CustomValidatorsLibrary.CustomValidator();
            this.validStatus = new CustomValidatorsLibrary.CustomValidator();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.39394F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.60606F));
            this.tableLayoutPanel1.Controls.Add(this.tbBusName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbbBusOwner, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbBusType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbSubscribe, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbProportion, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbOffice, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbbStatus, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 250);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tbBusName
            // 
            this.tbBusName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbBusName.Location = new System.Drawing.Point(133, 33);
            this.tbBusName.Name = "tbBusName";
            this.tbBusName.Size = new System.Drawing.Size(152, 21);
            this.tbBusName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "投资人姓名：";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "企业名称：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "企业类型：";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 34);
            this.panel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(175, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(78, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "认缴出资（万元）：";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "出资比例（%）：";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "职务：";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "状态：";
            // 
            // cbbBusOwner
            // 
            this.cbbBusOwner.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbbBusOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBusOwner.FormattingEnabled = true;
            this.cbbBusOwner.Location = new System.Drawing.Point(133, 3);
            this.cbbBusOwner.Name = "cbbBusOwner";
            this.cbbBusOwner.Size = new System.Drawing.Size(152, 20);
            this.cbbBusOwner.TabIndex = 13;
            // 
            // cbbBusType
            // 
            this.cbbBusType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbbBusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBusType.FormattingEnabled = true;
            this.cbbBusType.Location = new System.Drawing.Point(133, 63);
            this.cbbBusType.Name = "cbbBusType";
            this.cbbBusType.Size = new System.Drawing.Size(152, 20);
            this.cbbBusType.TabIndex = 14;
            // 
            // tbSubscribe
            // 
            this.tbSubscribe.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbSubscribe.Location = new System.Drawing.Point(133, 93);
            this.tbSubscribe.Name = "tbSubscribe";
            this.tbSubscribe.Size = new System.Drawing.Size(152, 21);
            this.tbSubscribe.TabIndex = 15;
            // 
            // tbProportion
            // 
            this.tbProportion.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbProportion.Location = new System.Drawing.Point(133, 123);
            this.tbProportion.Name = "tbProportion";
            this.tbProportion.Size = new System.Drawing.Size(152, 21);
            this.tbProportion.TabIndex = 16;
            // 
            // tbOffice
            // 
            this.tbOffice.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbOffice.Location = new System.Drawing.Point(133, 153);
            this.tbOffice.Name = "tbOffice";
            this.tbOffice.Size = new System.Drawing.Size(152, 21);
            this.tbOffice.TabIndex = 17;
            // 
            // cbbStatus
            // 
            this.cbbStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Location = new System.Drawing.Point(133, 183);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(152, 20);
            this.cbbStatus.TabIndex = 18;
            // 
            // validBusName
            // 
            this.validBusName.ControlToValidate = this.tbBusName;
            this.validBusName.ErrorMessage = "企业名称不能为空";
            this.validBusName.Icon = ((System.Drawing.Icon)(resources.GetObject("validBusName.Icon")));
            // 
            // validOffice
            // 
            this.validOffice.ControlToValidate = this.tbOffice;
            this.validOffice.ErrorMessage = "职务不能为空";
            this.validOffice.Icon = ((System.Drawing.Icon)(resources.GetObject("validOffice.Icon")));
            // 
            // validSubscribe
            // 
            this.validSubscribe.ControlToValidate = this.tbSubscribe;
            this.validSubscribe.ErrorMessage = "认缴出资必须为数字";
            this.validSubscribe.Icon = ((System.Drawing.Icon)(resources.GetObject("validSubscribe.Icon")));
            this.validSubscribe.ValidationExpression = "^(-?\\d+)(\\.\\d+)?$";
            // 
            // validProportion
            // 
            this.validProportion.ControlToValidate = this.tbProportion;
            this.validProportion.ErrorMessage = "出资比例必须为数字";
            this.validProportion.Icon = ((System.Drawing.Icon)(resources.GetObject("validProportion.Icon")));
            this.validProportion.ValidationExpression = "^(-?\\d+)(\\.\\d+)?$";
            // 
            // validOwner
            // 
            this.validOwner.ControlToValidate = this.cbbBusOwner;
            this.validOwner.ErrorMessage = "请选择投资人";
            this.validOwner.Icon = ((System.Drawing.Icon)(resources.GetObject("validOwner.Icon")));
            this.validOwner.Validating += new CustomValidatorsLibrary.CustomValidator.ValidatingEventHandler(this.validOwner_Validating);
            // 
            // validBusType
            // 
            this.validBusType.ControlToValidate = this.cbbBusType;
            this.validBusType.ErrorMessage = "请选择企业类型";
            this.validBusType.Icon = ((System.Drawing.Icon)(resources.GetObject("validBusType.Icon")));
            this.validBusType.Validating += new CustomValidatorsLibrary.CustomValidator.ValidatingEventHandler(this.validBusType_Validating);
            // 
            // validStatus
            // 
            this.validStatus.ControlToValidate = this.cbbStatus;
            this.validStatus.ErrorMessage = "请选择企业状态";
            this.validStatus.Icon = ((System.Drawing.Icon)(resources.GetObject("validStatus.Icon")));
            this.validStatus.Validating += new CustomValidatorsLibrary.CustomValidator.ValidatingEventHandler(this.validStatus_Validating);
            // 
            // FrmAddBusinessReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 250);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAddBusinessReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加企业";
            this.Load += new System.EventHandler(this.FrmAddBusinessReport_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbBusOwner;
        private System.Windows.Forms.ComboBox cbbBusType;
        private System.Windows.Forms.TextBox tbSubscribe;
        private System.Windows.Forms.TextBox tbProportion;
        private System.Windows.Forms.TextBox tbOffice;
        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.TextBox tbBusName;
        private CustomValidatorsLibrary.RequiredFieldValidator validBusName;
        private CustomValidatorsLibrary.RequiredFieldValidator validOffice;
        private CustomValidatorsLibrary.RegularExpressionValidator validSubscribe;
        private CustomValidatorsLibrary.RegularExpressionValidator validProportion;
        private CustomValidatorsLibrary.CustomValidator validOwner;
        private CustomValidatorsLibrary.CustomValidator validBusType;
        private CustomValidatorsLibrary.CustomValidator validStatus;
    }
}