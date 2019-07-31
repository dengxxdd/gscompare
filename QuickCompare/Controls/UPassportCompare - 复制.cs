using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DXD.BLL;
using DXD.DTV;

namespace DXD.QuickCompare.Controls
{
    public partial class UPassportCompare : UserControlBase
    {        
        public UPassportCompare()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加个人报告持证记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            using (DXD.QuickCompare.FrmAddPassportReport frm = new FrmAddPassportReport())
            {
                frm.ShowDialog(this);
                if (frm.DialogResult == DialogResult.OK)
                {
                    DataTable dTable = (DataTable)dgvPassportReport.DataSource;
                    DataRow dr = dTable.NewRow();
                    Model.passport_report model = frm.model;
                    dr["id"] = 0;
                    dr["query_id"] = query_id;
                    dr["passport_no"] = model.passport_no;
                    Model.code_detail codeModel = (new BLL.code_detail()).GetModel(model.passport_type, true);
                    dr["passport_type"] = codeModel.code_name;
                    dr["issuing_date"] = model.issuing_date;
                    dr["valid_date"] = model.valid_date;
                    dr["is_match"] = false;
                    dr["add_time"] = DateTime.Now;
                    dTable.Rows.Add(dr);
                    dgvPassportReport.DataSource = dTable;
                    dgvPassportReport.Sort(dgvPassportReport.Columns["rep_add_time"], ListSortDirection.Ascending);
                    dgvPassportFeedback.ClearSelection();
                    dgvPassportReport.ClearSelection();
                }
            }
        }

        private void UPassportCompare_Load(object sender, EventArgs e)
        {
            //DTV.Passport passport = new DTV.Passport();
            //BLL.code_detail cibll = new DXD.BLL.code_detail();

            ////载入证件反馈数据
            //DataSet ds = passport.LoadFeedback(query_id);
            //ds = cibll.CodeConvert(ds, "passport_type");
            //dgvPassportFeedback.DataSource = ds.Tables[0];

            //ds = cibll.GetAllList();
            ////载入证件个人报告数据
            //ds = passport.LoadReport(query_id);
            //ds = cibll.CodeConvert(ds, "passport_type");
            //dgvPassportReport.DataSource = ds.Tables[0];

            ////载入比对匹配数据
            //ds = passport.LoadCompare(query_id);
            //ds = cibll.CodeConvert(ds, "rep_passport_type");
            //ds = cibll.CodeConvert(ds, "fee_passport_type");
            //dgvPassportCompare.DataSource = ds.Tables[0];

            //this.dgvPassportCompare.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            //this.dgvPassportCompare.ColumnHeadersHeight = this.dgvPassportCompare.ColumnHeadersHeight * 2;
            //this.dgvPassportCompare.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            //this.dgvPassportCompare.CellPainting += new DataGridViewCellPaintingEventHandler(dgvPassportCompare_CellPainting);
            //this.dgvPassportCompare.Paint += new PaintEventHandler(dgvPassportCompare_Paint);

            //dgvPassportReport.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd";
            //dgvPassportReport.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            //dgvPassportFeedback.ClearSelection();
            //dgvPassportReport.ClearSelection();
            //dgvPassportCompare.ClearSelection();

            ////载入比对结果数据
            //DataTable dt = passport.LoadCompareResult(query_id).Tables[0];
            //if (dt.Rows.Count == 0)
            //{
            //    CalcCompareResult();
            //}
        }

        /// <summary>
        /// 计算比对结果
        /// </summary>
        void CalcCompareResult()
        {
            DTV.Passport passport = new DTV.Passport();
            Dictionary<string, DataTable> dictionary = new Dictionary<string, DataTable>();
            dictionary.Add("Report", DgvToTable(dgvPassportReport));
            dictionary.Add("Feedback", DgvToTable(dgvPassportFeedback));
            dictionary.Add("Compare", DgvToTable(dgvPassportCompare));
            Dictionary<string, string> result = passport.CalcResult(dictionary);
            tbReport.Text = result["hzreport"] + result["gtreport"];
            tbFeedback.Text = result["hzfeedback"] + result["gtfeedback"];
            tbCompare.Text = result["hzcompare"] + result["gtcompare"];
        }

        void dgvPassportCompare_Paint(object sender, PaintEventArgs e)
        {
            string[] headers = { "个人报告", "查询反馈" };
            for (int j = 4; j < 10;)
            {
                Rectangle r1 = this.dgvPassportCompare.GetCellDisplayRectangle(j, -1, true); //get the column header cell
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width * 4 - 2 + 50;   //因为证件种类的宽度是150，默认为100，增加了50，所以要加50
                r1.Height = r1.Height / 2 - 2;
                SolidBrush brush = new SolidBrush(Color.ForestGreen);
                if (j == 4)
                {
                    brush = new SolidBrush(Color.GreenYellow);
                }
                e.Graphics.FillRectangle(brush, r1);
                //e.Graphics.FillRectangle(new SolidBrush(this.dgvPassportCompare.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(headers[(j - 4) / 4],
                    this.dgvPassportCompare.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(this.dgvPassportCompare.ColumnHeadersDefaultCellStyle.ForeColor),
                    r1,
                    format);
                j += 5;
            }
        }
        void dgvPassportCompare_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.PaintBackground(e.CellBounds, false);
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintContent(r2);
                e.Handled = true;
                if (e.ColumnIndex == 13)
                {
                    SolidBrush brush = new SolidBrush(Color.Yellow);
                    Rectangle r1 = this.dgvPassportCompare.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    e.Graphics.FillRectangle(brush, r1);
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(dgvPassportCompare.Columns[e.ColumnIndex].HeaderText,
                        this.dgvPassportCompare.ColumnHeadersDefaultCellStyle.Font,
                        new SolidBrush(this.dgvPassportCompare.ColumnHeadersDefaultCellStyle.ForeColor),
                        r1,
                        format);
                }
            }
            if (e.RowIndex > -1)
            {
                string matchstr = dgvPassportCompare.Rows[e.RowIndex].Cells["compare_type"].Value.ToString();
                if (matchstr == "不一致")
                {
                    dgvPassportCompare.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
                }
            }
        }

        private void dgvPassportReport_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Boolean isMatch = false;
                if (this.dgvPassportReport.Rows[e.RowIndex].Cells["rep_is_match"].Value != DBNull.Value)
                {
                    isMatch = Convert.ToBoolean(this.dgvPassportReport.Rows[e.RowIndex].Cells["rep_is_match"].Value);
                }
                if (isMatch)
                {
                    dgvPassportReport.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                else
                {
                    dgvPassportReport.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void dgvPassportFeedback_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Boolean isMatch = false;
                if (this.dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_is_match"].Value != DBNull.Value)
                {
                    isMatch = Convert.ToBoolean(this.dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_is_match"].Value);
                }
                if (isMatch)
                {
                    dgvPassportFeedback.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                else
                {
                    dgvPassportFeedback.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void dgvPassportFeedback_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvPassportFeedback.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string cellValue = "";
                    foreach (DataGridViewRow row in dgvPassportReport.Rows)
                    {
                        if (row.Cells["rep_passport_no"].Value != null)
                        {
                            cellValue = row.Cells["rep_passport_no"].Value.ToString();
                        }
                        if (cellValue == dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_passport_no"].Value.ToString())
                        {
                            MessageBox.Show("个人报告数据中已有相同证件号码，不能重复添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvPassportFeedback.ClearSelection();
                            return;
                        }
                        if (dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_is_match"] != null && Convert.ToBoolean(dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_is_match"].Value))
                        {
                            MessageBox.Show("本记录已匹配成功，不能添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvPassportFeedback.ClearSelection();
                            return;
                        }
                    }

                    //添加数据到个人报告数据表中                    
                    DataTable dTable = (DataTable)dgvPassportReport.DataSource;
                    DataRow drReport = dTable.NewRow();
                    drReport["id"] = 0;
                    drReport["query_id"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_query_id"].Value;
                    drReport["passport_no"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_passport_no"].Value;
                    drReport["passport_type"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_passport_type"].Value;
                    drReport["issuing_date"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_issuing_date"].Value;
                    drReport["valid_date"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_valid_date"].Value;
                    drReport["is_match"] = true;
                    drReport["add_time"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_add_time"].Value;
                    drReport["feedback_id"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_id"].Value;
                    dTable.Rows.Add(drReport);
                    dgvPassportReport.DataSource = dTable;

                    dgvPassportReport.Sort(dgvPassportReport.Columns["rep_add_time"], ListSortDirection.Ascending);
                    dgvPassportFeedback.ClearSelection();
                    dgvPassportReport.ClearSelection();


                    //添加数据到匹配数据表中
                    dTable = (DataTable)dgvPassportCompare.DataSource;
                    DataRow drCompare = dTable.NewRow();
                    drCompare["id"] = 0;
                    drCompare["query_id"] = Convert.ToInt32(dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_query_id"].Value);
                    drCompare["report_id"] = drReport["id"];
                    drCompare["feedback_id"] = Convert.ToInt32(dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_id"].Value);
                    drCompare["rep_passport_no"] = drReport["passport_no"];
                    drCompare["rep_passport_type"] = drReport["passport_type"];
                    drCompare["rep_issuing_date"] = drReport["issuing_date"];
                    drCompare["rep_valid_date"] = drReport["valid_date"];
                    drCompare["fee_passport_no"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_passport_no"].Value;
                    drCompare["fee_passport_type"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_passport_type"].Value;
                    drCompare["fee_issuing_date"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_issuing_date"].Value;
                    drCompare["fee_valid_date"] = dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_valid_date"].Value;
                    drCompare["compare_type"] = "一致";
                    drCompare["add_time"] = DateTime.Now;
                    dTable.Rows.Add(drCompare);
                    dgvPassportCompare.DataSource = dTable;
                    dgvPassportCompare.ClearSelection();

                    dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_is_match"].Value = true;
                    CalcCompareResult();
                }
                else
                {
                    string cellValue = "";
                    foreach (DataGridViewRow row in dgvPassportReport.Rows)
                    {
                        if (row.Cells["rep_passport_no"].Value != null)
                        {
                            cellValue = row.Cells["rep_passport_no"].Value.ToString();
                        }
                        if (cellValue == dgvPassportFeedback.Rows[e.RowIndex].Cells["fee_passport_no"].Value.ToString())
                        {
                            dgvPassportReport.Rows[row.Index].Selected = true;
                            return;
                        }
                    }
                    dgvPassportReport.ClearSelection();
                }
            }
        }
        private void tsbSaveResult_Click(object sender, EventArgs e)
        {
            Dictionary<string, DataTable> dictionary = new Dictionary<string, DataTable>();
            DataTable dt = DgvToTable(dgvPassportReport);
            dictionary.Add("Report", dt);
            dt = DgvToTable(dgvPassportFeedback);
            dictionary.Add("Feedback", dt);
            dt = DgvToTable(dgvPassportCompare);
            dictionary.Add("Compare", dt);

            DTV.Passport passport = new DTV.Passport();

            Dictionary<string, string> result = passport.CalcResult(dictionary);
            dt = new DataTable();
            dt.Columns.Add("Type", Type.GetType("System.String"));
            dt.Columns.Add("Report", Type.GetType("System.String"));
            dt.Columns.Add("Feedback", Type.GetType("System.String"));
            dt.Columns.Add("Compare", Type.GetType("System.String"));

            DataRow newRow;
            newRow = dt.NewRow();
            newRow["Type"] = "护照";
            newRow["Report"] = result["hzreport"];
            newRow["Feedback"] = result["hzfeedback"];
            newRow["Compare"] = result["hzcompare"];
            dt.Rows.Add(newRow);
            newRow = dt.NewRow();
            newRow["Type"] = "港澳台通行证";
            newRow["Report"] = result["gtreport"];
            newRow["Feedback"] = result["gtfeedback"];
            newRow["Compare"] = result["gtcompare"];
            dt.Rows.Add(newRow);
            dictionary.Add("Result", dt);

            MessageBox.Show(passport.SaveCompareResult(dictionary));
        }

        private void dgvPassportReport_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string dataProName = dgvPassportReport.Columns[e.ColumnIndex].DataPropertyName;
            string reportValue = dgvPassportReport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int repFeedbackId;
            int.TryParse(dgvPassportReport.Rows[e.RowIndex].Cells["rep_feedback_id"].Value.ToString(), out repFeedbackId);
            if (repFeedbackId != 0)
            {
                DataTable dt = (DataTable)dgvPassportCompare.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    if (int.Parse(dr["feedback_id"].ToString()) == repFeedbackId)
                    {
                        if (reportValue != dr["fee_" + dataProName].ToString())
                        {
                            dr["compare_type"] = "不一致";
                        }
                        else
                        {
                            dr["compare_type"] = "一致";
                        }
                    }
                }
            }
        }

        private void dgvPassportCompare_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvPassportCompare.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string rep_passport_no = "";
                    int feedback_id = 0;
                    rep_passport_no = dgvPassportCompare.Rows[e.RowIndex].Cells["comr_passport_no"].Value.ToString();
                    int.TryParse(dgvPassportCompare.Rows[e.RowIndex].Cells["com_feedback_id"].Value.ToString(), out feedback_id);

                    DataTable dtReport = (DataTable)dgvPassportReport.DataSource;
                    foreach (DataRow dr in dtReport.Rows)
                    {
                        if (dr["passport_no"].ToString() == rep_passport_no)
                        {
                            dr["is_match"] = false;
                            break;
                        }
                    }
                    dgvPassportReport.DataSource = dtReport;

                    DataTable dtFeedback = (DataTable)dgvPassportFeedback.DataSource;
                    foreach (DataRow dr in dtFeedback.Rows)
                    {
                        if (Convert.ToInt32(dr["id"]) == feedback_id)
                        {
                            dr["is_match"] = false;
                            break;
                        }
                    }
                    dgvPassportFeedback.DataSource = dtFeedback;
                    dgvPassportFeedback.ClearSelection();
                    dgvPassportReport.ClearSelection();

                    //添加数据到匹配数据表中
                    DataTable dtCompare = (DataTable)dgvPassportCompare.DataSource;
                    foreach (DataRow dr in dtCompare.Rows)
                    {
                        if (Convert.ToInt32(dr["feedback_id"]) == feedback_id)
                        {
                            dtCompare.Rows.Remove(dr);
                            break;
                        }
                    }
                    dgvPassportCompare.DataSource = dtCompare;
                    dgvPassportCompare.ClearSelection();
                    dgvPassportFeedback.Refresh();
                    dgvPassportReport.Refresh();
                    dgvPassportCompare.Refresh();
                    CalcCompareResult();
                }
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            //string dataProName = dgvPassportReport.Columns[e.ColumnIndex].DataPropertyName;
            if (dgvPassportReport.SelectedRows.Count < 1 || dgvPassportFeedback.SelectedRows.Count < 1)
            {
                MessageBox.Show("请先选择要匹配的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPassportFeedback.ClearSelection();
                dgvPassportReport.ClearSelection();
                return;
            }

            bool report_match = Convert.ToBoolean(dgvPassportReport.SelectedRows[0].Cells["rep_is_match"].Value);
            bool feedback_match = Convert.ToBoolean(dgvPassportFeedback.SelectedRows[0].Cells["fee_is_match"].Value);
            if (report_match || feedback_match)
            {
                MessageBox.Show("不能匹配已经匹配的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPassportFeedback.ClearSelection();
                dgvPassportReport.ClearSelection();
                return;
            }
            //添加数据到匹配数据表中
            DataTable dTable = (DataTable)dgvPassportCompare.DataSource;
            DataRow drCompare = dTable.NewRow();
            drCompare["id"] = 0;
            drCompare["query_id"] = Convert.ToInt32(dgvPassportFeedback.SelectedRows[0].Cells["fee_query_id"].Value);
            drCompare["report_id"] = dgvPassportReport.SelectedRows[0].Cells["rep_id"].Value;
            drCompare["feedback_id"] = Convert.ToInt32(dgvPassportFeedback.SelectedRows[0].Cells["fee_id"].Value);
            drCompare["rep_passport_no"] = dgvPassportReport.SelectedRows[0].Cells["rep_passport_no"].Value;
            drCompare["rep_passport_type"] = dgvPassportReport.SelectedRows[0].Cells["rep_passport_type"].Value;
            drCompare["rep_issuing_date"] = dgvPassportReport.SelectedRows[0].Cells["rep_issuing_date"].Value;
            drCompare["rep_valid_date"] = dgvPassportReport.SelectedRows[0].Cells["rep_valid_date"].Value;
            drCompare["fee_passport_no"] = dgvPassportFeedback.SelectedRows[0].Cells["fee_passport_no"].Value;
            drCompare["fee_passport_type"] = dgvPassportFeedback.SelectedRows[0].Cells["fee_passport_type"].Value;
            drCompare["fee_issuing_date"] = dgvPassportFeedback.SelectedRows[0].Cells["fee_issuing_date"].Value;
            drCompare["fee_valid_date"] = dgvPassportFeedback.SelectedRows[0].Cells["fee_valid_date"].Value;

            if (drCompare["rep_passport_no"].ToString() == drCompare["fee_passport_no"].ToString())
            {
                drCompare["compare_type"] = "一致";
            }
            else
            {
                drCompare["compare_type"] = "不一致";
            }

            drCompare["add_time"] = DateTime.Now;
            dTable.Rows.Add(drCompare);
            dgvPassportCompare.DataSource = dTable;
            dgvPassportFeedback.SelectedRows[0].Cells["fee_is_match"].Value = true;
            dgvPassportReport.SelectedRows[0].Cells["rep_is_match"].Value = true;
            dgvPassportFeedback.Refresh();
            dgvPassportReport.Refresh();
            dgvPassportFeedback.ClearSelection();
            dgvPassportReport.ClearSelection();
            dgvPassportCompare.ClearSelection();
            CalcCompareResult();
        }

        private void dgvPassportReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = "";
            foreach (DataGridViewRow row in dgvPassportFeedback.Rows)
            {
                if (row.Cells["fee_passport_no"].Value != null)
                {
                    cellValue = row.Cells["fee_passport_no"].Value.ToString();
                }
                if (cellValue == dgvPassportReport.Rows[e.RowIndex].Cells["rep_passport_no"].Value.ToString())
                {
                    dgvPassportFeedback.Rows[row.Index].Selected = true;
                    return;
                }
            }
            dgvPassportFeedback.ClearSelection();
        }
    }
}
