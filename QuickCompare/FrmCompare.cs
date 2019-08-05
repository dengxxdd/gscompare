using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace DXD.QuickCompare
{

    public partial class FrmCompare : FrmUnMax {        
        //private int query_id;
        #region 窗体初始化及自动加载
        public FrmCompare()
        {
            InitializeComponent();
        }

        public FrmCompare(int query_id)
        {
            InitializeComponent();
            this.uBusinesControl1.query_id = query_id;
        }

        private void FrmCompare_Load(object sender, EventArgs e)
        {
            BLL.query_detail bll = new BLL.query_detail();
            Model.query_detail model = bll.GetModel(this.uBusinesControl1.query_id);
            this.Text = String.Format("数据比对（姓名：{0}，工作单位：{1}，职务：{2}", model.full_name, model.work_unit,
                model.post);
        }
        #endregion
        private void FrmCompare_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

    }
}
