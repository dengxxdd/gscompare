using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DXD.QuickCompare {
    public partial class FrmAddBusinessReport : FrmUnMax {
        public Model.business_report model;
        public string fullName;
        private int query_id;
        public FrmAddBusinessReport(int query_id) {
            InitializeComponent();
            this.query_id = query_id;
        }

        private void FrmAddBusinessReport_Load(object sender, EventArgs e) {
            List<Model.query_detail> query_Details = (new BLL.query_detail()).GetModelList(
                string.Format("where id={0} or id in (select id from query_detail where parent_id={0})", query_id));
            this.cbbBusOwner.DataSource = query_Details;
            this.cbbBusOwner.DisplayMember = "full_name";
            this.cbbBusOwner.ValueMember = "id";
            this.cbbBusOwner.SelectedIndex = -1;

            List<Model.code_detail> code_Details = (new BLL.code_detail()).GetCodeList("企业类型");
            this.cbbBusType.DataSource = code_Details;
            this.cbbBusType.DisplayMember = "code_name";
            this.cbbBusType.ValueMember = "code_id";
            this.cbbBusType.SelectedIndex = -1;
            code_Details = (new BLL.code_detail()).GetCodeList("企业状态");
            this.cbbStatus.DataSource = code_Details;
            this.cbbStatus.DisplayMember = "code_name";
            this.cbbStatus.ValueMember = "code_id";
            this.cbbStatus.SelectedIndex = -1;
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            try
            {
                if (validOwner.IsValid&&validBusName.IsValid &&validBusType.IsValid&& validSubscribe.IsValid 
                    && validProportion.IsValid&&validOffice.IsValid&&validStatus.IsValid)
                {
                    model = new Model.business_report();
                    fullName = ((DXD.Model.query_detail)cbbBusOwner.SelectedItem).full_name;
                    model.query_id = int.Parse(cbbBusOwner.SelectedValue.ToString());
                    model.bus_name = tbBusName.Text;
                    model.bus_type = ((DXD.Model.code_detail)cbbBusType.SelectedItem).code_name;
                    model.subscribe = decimal.Parse(tbSubscribe.Text.ToString());
                    model.proportion = decimal.Parse(tbProportion.Text.ToString());
                    model.office = tbOffice.Text;
                    model.status = ((DXD.Model.code_detail)cbbStatus.SelectedItem).code_name;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!validOwner.IsValid)
                    {
                        validOwner.Validate();
                    }
                    if (!validBusName.IsValid)
                    {
                        validBusName.Validate();
                    }
                    if (!validBusType.IsValid)
                    {
                        validBusType.Validate();
                    }
                    if (!validSubscribe.IsValid)
                    {
                        validSubscribe.Validate();
                    }
                    if (!validProportion.IsValid)
                    {
                        validProportion.Validate();
                    }
                    if (!validOffice.IsValid)
                    {
                        validOffice.Validate();
                    }                    
                    if (!validStatus.IsValid)
                    {
                        validStatus.Validate();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("程序出错:{0}", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void validOwner_Validating(object sender, CustomValidatorsLibrary.CustomValidator.ValidatingCancelEventArgs e) {
            if (cbbBusOwner.SelectedIndex == -1)
            {
                e.Valid = false;
            }
            else
            {
                e.Valid = true;
            }
        }

        private void validBusType_Validating(object sender, CustomValidatorsLibrary.CustomValidator.ValidatingCancelEventArgs e) {
            if (cbbBusType.SelectedIndex == -1)
            {
                e.Valid = false;
            }
            else
            {
                e.Valid = true;
            }
        }

        private void validStatus_Validating(object sender, CustomValidatorsLibrary.CustomValidator.ValidatingCancelEventArgs e) {
            if (cbbStatus.SelectedIndex == -1)
            {
                e.Valid = false;
            }
            else
            {
                e.Valid = true;
            }
        }
    }
}
