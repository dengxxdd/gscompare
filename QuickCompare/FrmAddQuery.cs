using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXD.QuickCompare
{
    public partial class FrmAddQuery : FrmUnMax {
        public delegate void RefreshDelegate();
        public event RefreshDelegate refresh;
        public FrmAddQuery()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddQuery_Load(object sender, EventArgs e)
        {
            List<Model.code_detail> code_Details = (new BLL.code_detail()).GetCodeList("委托类型");
            this.cmbType.DataSource = code_Details;
            this.cmbType.DisplayMember = "code_name";
            this.cmbType.ValueMember = "code_id";
            this.cmbType.SelectedIndex = -1;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (validQueryName.IsValid && validBatch.IsValid && validClient.IsValid && validType.IsValid)
            {
                BLL.query_list bll = new BLL.query_list();
                Model.query_list model = new Model.query_list();
                model.query_title = tbQueryName.Text;
                model.batch = tbBatch.Text;
                model.client = tbClient.Text;
                model.query_type = cmbType.SelectedValue.ToString();
                model.entrust_date = dtpEntrustDate.Value.Date;
                model.add_user = "admin";
                model.add_time = DateTime.Now;
                if (bll.Add(model) > 0)
                {
                    MessageBox.Show("添加成功！", "添加比对任务", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmQuery frm = (FrmQuery)this.Owner;
                    this.Close();
                    this.refresh();
                }
            }
            else
            {
                if (!validQueryName.IsValid)
                {
                    validQueryName.Validate();
                }
                if (!validBatch.IsValid)
                {
                    validBatch.Validate();
                }
                if (!validClient.IsValid)
                {
                    validClient.Validate();
                }
                if (!validType.IsValid)
                {
                    validType.Validate();
                }
            }
        }

        private void validType_Validating(object sender, CustomValidatorsLibrary.CustomValidator.ValidatingCancelEventArgs e) {
            if (cmbType.SelectedIndex == -1)
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
