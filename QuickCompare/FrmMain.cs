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
    public partial class FrmMain : FrmUnMax
    {

        Sunisoft.IrisSkin.SkinEngine s;
        private FrmQuery frmQuery;
        public FrmMain()
        {
            InitializeComponent();
            s = new Sunisoft.IrisSkin.SkinEngine();
            s.SkinFile = System.Environment.CurrentDirectory + "\\Skins\\office2007.ssk";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            if (frmQuery == null||frmQuery.IsDisposed)
            {
                frmQuery = new FrmQuery();//将主窗体对象传递过去
                frmQuery.Show(this);//显示窗体二
                this.Hide();
            }
            else
            {
                frmQuery.Activate();
            }
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            if(MessageBox.Show("是否退出程序？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==
                DialogResult.Yes)
            {
                Application.Exit();
            }            
        }
    }
}
