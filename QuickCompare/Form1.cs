using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DXD.BLL;
using System.Reflection;
using DXD.SQLiteDAL;
using System.Configuration;

namespace  DXD.QuickCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BLL.query_list bll = new BLL.query_list();
            //Model.query_list model = new Model.query_list();
            //model.query_title = "查询对象批次4";
            //model.batch = "2018[04]号";
            //model.client = "市林业局";
            //model.entrust_date = DateTime.Today;
            //model.add_user = "admin";
            //model.add_time = DateTime.Now;
            //bll.Add(model

            OpenFileDialog fileDialog=new OpenFileDialog();
            if(fileDialog.ShowDialog()==DialogResult.OK)
            {
                DXD.DTD.query_detail query_detail = new DTD.query_detail();                
            }
        }
    }
}
