using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DXD.QuickCompare
{
    public partial class FrmImportPerson : FrmUnMax {
        private int list_id;
        public FrmImportPerson()
        {
            InitializeComponent();
        }
        public FrmImportPerson(int id)
        {
            InitializeComponent();
            list_id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "请选择要导入的Excel文件";
            openFileDialog.Filter = "Excel files（*.xls,*.xlsx）|*.xls;*.xlsx";
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFilename.Text = openFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //文件选择有错，直接取消并返回
            if(tbFilename.Text=="")
            {
                this.DialogResult=DialogResult.Cancel;
                return;
            }
            if (!File.Exists(tbFilename.Text))
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            string extension = Path.GetExtension(tbFilename.Text).ToLower();
            if(extension!=".xls"&&extension!=".xlsx")
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            DTD.query_detail dtd = new DTD.query_detail();
            DTD.DTDParameter parameter = new DTD.DTDParameter();
            parameter.filename = tbFilename.Text;
            parameter.list_id = list_id;
            string resultstr = dtd.FileToDb(parameter);
            MessageBox.Show(resultstr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (resultstr == "导入成功！")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
