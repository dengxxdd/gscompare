using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;


namespace DXD.QuickCompare.Controls
{
    public class UserControlBase: UserControl
    {
        #region 结构及变量定义
        protected struct ColumnStruct
        {
            public string name;
            public string headertext;
            public int width;
            public bool visible;
            public ColumnStruct(string p1, string p2, int p3)
            {
                name = p1;
                headertext = p2;
                width = p3;
                visible = true;
            }
            public ColumnStruct(string p1, string p2, int p3, bool p4)
            {
                name = p1;
                headertext = p2;
                width = p3;
                visible = p4;
            }
        }
        public int query_id;
        #endregion

        #region DataGridView数据转为DataTable

        /// <summary>
        /// 绑定DataGridView数据到DataTable
        /// </summary>
        /// <param name="dgv">复制数据的DataGridView</param>
        /// <returns>返回的绑定数据后的DataTable</returns>
        protected DataTable DgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {                
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                    if (dgv.Columns[countsub].DataPropertyName == "is_match")
                    {
                        dr[countsub] = Convert.ToBoolean(dgv.Rows[count].Cells[countsub].Value);
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion
    }
}
