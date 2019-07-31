using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace DXD.QuickCompare
{    
    public partial class FrmImportCompare : FrmUnMax {
        private int list_id;
        public delegate void RefreshDelegate();
        public event RefreshDelegate refresh;
        public FrmImportCompare()
        {
            InitializeComponent();
        }
        public FrmImportCompare(int id)
        {
            InitializeComponent();
            list_id = id;
        }        

        private void button7_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbBusiness.Text = openFileDialog.FileName;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string getFilename(TextBox tb)
        {
            bool flag = false;
            if (tb.Text == "")
            {
                return "";
            }
            if (!File.Exists(tb.Text))
            {
                flag = true;
            }
            string extension = Path.GetExtension(tb.Text).ToLower();
            if (extension != ".xls" && extension != ".xlsx")
            {
                flag = true;
            }
            if(flag)
            {
                this.DialogResult = DialogResult.Cancel;
                return "";
            }
            return tb.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //文件选择有错，直接取消并返回
            Dictionary<string, string> files = new Dictionary<string, string>();
            
            files.Add("Business", getFilename(tbBusiness));

            if (this.DialogResult == DialogResult.Cancel)
            {                
                MessageBox.Show("文件选择错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string result = "";
            foreach (KeyValuePair<string,string> kv in files)
            {
                DTD.DTDParameter parameter = new DTD.DTDParameter();
                DTD.IXlsTDb dtd = null;
                if (kv.Value == "")
                    continue;
                if (kv.Key.IndexOf("House")>=0)//House1,House2的类名是House
                {
                    dtd = (DTD.IXlsTDb)Assembly.Load("DXD.DTD").CreateInstance("DXD.DTD." + kv.Key.Substring(0, 5));
                }
                else
                {
                    dtd = (DTD.IXlsTDb)Assembly.Load("DXD.DTD").CreateInstance("DXD.DTD." + kv.Key);
                }                
                parameter.filename = kv.Value;
                parameter.list_id = list_id;
                result = dtd.FileToDb(parameter);
                if (result != "导入成功！")
                {
                    MessageBox.Show(result, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Abort;
                    return;                    
                }
            }
            if(result=="")
            {
                this.DialogResult = DialogResult.Abort;
                MessageBox.Show("必须选择文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("导入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
