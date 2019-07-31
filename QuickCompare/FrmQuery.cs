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
    public partial class FrmQuery : FrmUnMax {       

        public FrmQuery()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmAddQuery frmAddQuery = new FrmAddQuery();
            frmAddQuery.StartPosition = FormStartPosition.CenterParent;
            frmAddQuery.refresh += RefreshForm;
            frmAddQuery.ShowDialog();
        }

        private void FrmQuery_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        public void RefreshForm()
        {
            BLL.query_list bll = new BLL.query_list();
            DataSet ds = bll.GetList("order by add_time desc");
            DXD.BLL.code_detail cibll = new DXD.BLL.code_detail();
            DataTable dt = cibll.CodeConvert(ds.Tables[0], "query_type");
            dgvQueryList.DataSource = dt;
            dgvQueryList.ClearSelection();
        }

        private void dgvQueryList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Boolean isImport = Convert.ToBoolean(this.dgvQueryList.Rows[e.RowIndex].Cells["IsImport"].Value);
                if (isImport)
                {
                    dgvQueryList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
        }

        private void FrmQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void dgvQueryList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>-1)
            {
                int id =Convert.ToInt32(this.dgvQueryList.Rows[e.RowIndex].Cells["id"].Value);
                Boolean isImport = Convert.ToBoolean(this.dgvQueryList.Rows[e.RowIndex].Cells["IsImport"].Value);
                if(!isImport)
                {
                    if(MessageBox.Show("该批比对任务还未导入比对对象，是否现在导入？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        FrmImportPerson frmImport = new FrmImportPerson(id);
                        frmImport.ShowDialog();
                        if(frmImport.DialogResult==DialogResult.OK)
                        {
                            FrmPersonList frmPersonList = new FrmPersonList(id);                            
                            frmPersonList.Show(this);
                            RefreshForm();
                            this.Hide();
                        }                        
                    }
                }
                else
                {
                    FrmPersonList frmPersonList = new FrmPersonList(id);
                    frmPersonList.Show(this);
                    RefreshForm();
                    this.Hide();
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(dgvQueryList.CurrentRow.Cells["id"]!=null)
            {
                int list_id = Convert.ToInt32(dgvQueryList.CurrentRow.Cells["id"].Value);
                FrmImportCompare frm = new FrmImportCompare(list_id);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.refresh += RefreshForm;
                frm.ShowDialog();                
            }
            else
            {
                MessageBox.Show("请先选择一个比对任务！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }
    }
}
