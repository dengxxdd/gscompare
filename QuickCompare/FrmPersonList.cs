using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace DXD.QuickCompare
{
    public partial class FrmPersonList : FrmUnMax {
        int list_id;        
        public FrmPersonList()
        {
            InitializeComponent();
        }
        public FrmPersonList(int id)
        {
            InitializeComponent();
            list_id = id;
        }

        private void FrmPersonList_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void FrmPersonList_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.Owner!=null)
                this.Owner.Show();
        }

        /// <summary>
        /// 用于刷新数据
        /// </summary>
        public void RefreshForm()
        {
            BLL.query_detail bll = new BLL.query_detail();            
            DataSet ds = bll.GetList("where list_id="+list_id.ToString()+" and appellation='301'");
            DXD.BLL.code_detail cibll = new DXD.BLL.code_detail();
            dgvPersonList.DataSource = ds.Tables[0];
            dgvPersonList.ClearSelection();
        }

        private void dgvPersonList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (e.RowIndex > -1)
            {
                int id = Convert.ToInt32(this.dgvPersonList.Rows[e.RowIndex].Cells["pl_id"].Value);
                FrmCompare frm = new FrmCompare(id);
                frm.Show(this);
                RefreshForm();
                this.Hide();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DTD.CompareToFile toFile = new DTD.CompareToFile();            
            BLL.query_list bList = new BLL.query_list();
            Model.query_list mList = bList.GetModel(list_id);
            string targetDir = Directory.GetCurrentDirectory() + "\\比对结果\\" + DateTime.Now.ToString("yyyyMMdd") + mList.query_title;
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            string msg = "";
            foreach (DataGridViewRow dr in dgvPersonList.SelectedRows)
            {
                msg = toFile.PersonToFile(targetDir + string.Format("\\{0}.xlsx", dr.Cells["pl_full_name"].Value.ToString()),
                    Convert.ToInt32(dr.Cells["pl_id"].Value));
                if (msg != "OK")
                {
                    break;
                }
            }
            MessageBox.Show(msg);

        }

        private void dgvPersonList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
            foreach (DataGridViewRow row in dgvPersonList.Rows)
            {
                row.Cells[0].Value = row.Index + 1;
                Boolean flag = Convert.ToBoolean(row.Cells["pl_is_match"].Value);
                if (!flag)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    continue;
                }
                flag = Convert.ToBoolean(row.Cells["pl_is_compare"].Value);
                if (flag)
                {
                    row.DefaultCellStyle.BackColor = Color.GreenYellow;
                    continue;
                }                
            }
        }

        private void dgvPersonList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DTD.CompareToFile toFile = new DTD.CompareToFile();
            BLL.query_list bList = new BLL.query_list();
            Model.query_list mList = bList.GetModel(list_id);
            string targetDir = Directory.GetCurrentDirectory() + "\\比对结果\\" + DateTime.Now.ToString("yyyyMMdd") + mList.query_title;
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            string msg = ""; 
            msg = toFile.CollectToFile(targetDir, list_id);            
            MessageBox.Show((IWin32Window)this, msg);
        }
    }
}
