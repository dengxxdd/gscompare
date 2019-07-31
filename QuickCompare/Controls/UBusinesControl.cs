using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXD.QuickCompare.Controls
{
    public partial class UBusinesControl : UserControlBase
    {
        public UBusinesControl()
        {
            InitializeComponent();
        }

        private void UBusinesControl_Load(object sender, EventArgs e)
        {
            //设置匹配表格格式
            dgvCompare.AutoGenerateColumns = false;
            dgvFeedback.AutoGenerateColumns = false;
            dgvReport.AutoGenerateColumns = false;
            this.dgvCompare.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCompare.ColumnHeadersHeight = this.dgvCompare.ColumnHeadersHeight * 2;
            this.dgvCompare.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            //DTV.Business business = new DTV.Business();

            ////载入反馈数据
            //dgvFeedback.DataSource = business.LoadFeedback(query_id);

            ////载入个人报告数据            
            //dgvReport.DataSource = business.LoadReport(query_id);

            ////载入比对匹配数据            
            //dgvCompare.DataSource = business.LoadCompare(query_id);
            //dgvFeedback.ClearSelection();
            //dgvReport.ClearSelection();
            //dgvCompare.ClearSelection();

            ////载入比对结果数据
            //DataTable dt = business.LoadCompareResult(query_id);

            //if (dt.Rows.Count == 1)
            //{ 
            //    tbReport.Text = dt.Rows[0]["report_str"].ToString();
            //    tbFeedback.Text = dt.Rows[0]["feedback_str"].ToString();
            //    tbCompare.Text = dt.Rows[0]["compare_str"].ToString();
            //}

            //if (dt.Rows.Count == 0)
            //{
            //    GetCompareResult();
            //}
        }

        private void dgvFeedback_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (dgvFeedback.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string feeFullName = dgvFeedback.Rows[e.RowIndex].Cells["fee_full_name"].Value.ToString();
                    string feeBusName = dgvFeedback.Rows[e.RowIndex].Cells["fee_bus_name"].Value.ToString();
                    DataTable dtReport = (DataTable)dgvReport.DataSource;                    
                    if (dgvFeedback.Rows[e.RowIndex].Cells["fee_is_match"] != null && Convert.ToBoolean(dgvFeedback.Rows[e.RowIndex].Cells["fee_is_match"].Value))
                    {
                        MessageBox.Show("本记录已匹配成功，不能添加或隐藏！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvFeedback.ClearSelection();
                        return;
                    }

                    if (dgvFeedback.Columns[e.ColumnIndex].Name == "btnHidden")
                    {
                        int feedback_id;
                        int.TryParse(dgvFeedback.Rows[e.RowIndex].Cells["fee_id"].Value.ToString(), out feedback_id);
                        BLL.business_feedback bll = new BLL.business_feedback();
                        Model.business_feedback model = bll.GetModel(feedback_id);
                        model.is_hidden = true;
                        bll.Update(model);
                        DTV.Business business = new DTV.Business();

                        //载入反馈数据
                        DataTable dt = (DataTable)dgvFeedback.DataSource;
                        dt.Rows.Remove(dt.Select(string.Format("id={0}", feedback_id))[0]);
                        dgvFeedback.DataSource = dt;
                        dgvFeedback.Refresh();
                    }

                    if (dgvFeedback.Columns[e.ColumnIndex].Name == "btnToReport")//左移
                    {
                        if (dtReport.Select(string.Format("full_name='{0}' and bus_name='{1}'", feeFullName, feeBusName)).Length > 0)
                        {
                            MessageBox.Show("个人报告数据中已有记录，不能添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvFeedback.ClearSelection();
                            return;
                        }

                        //添加数据到个人报告数据表中

                        DataRow drReport = dtReport.NewRow();
                        drReport["id"] = 0;
                        drReport["query_id"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_query_id"].Value;
                        drReport["full_name"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_full_name"].Value;
                        drReport["bus_name"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_bus_name"].Value;
                        drReport["bus_type"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_bus_type"].Value;
                        drReport["subscribe"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_subscribe"].Value;
                        drReport["proportion"]= dgvFeedback.Rows[e.RowIndex].Cells["fee_proportion"].Value;
                        drReport["office"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_office"].Value;
                        drReport["status"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_status"].Value;
                        drReport["is_match"] = true;
                        drReport["is_import"] = false;
                        drReport["feedback_id"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_id"].Value;
                        dtReport.Rows.Add(drReport);
                        dtReport.DefaultView.Sort = "feedback_id";
                        dgvReport.DataSource = dtReport;
                        dgvFeedback.ClearSelection();
                        dgvReport.ClearSelection();

                        //添加数据到匹配数据表中
                        DataTable dtCompare = (DataTable)dgvCompare.DataSource;
                        DataRow drCompare = dtCompare.NewRow();
                        drCompare["id"] = 0;
                        drCompare["query_id"] = Convert.ToInt32(dgvFeedback.Rows[e.RowIndex].Cells["fee_query_id"].Value);
                        drCompare["report_id"] = drReport["id"];
                        drCompare["feedback_id"] = Convert.ToInt32(dgvFeedback.Rows[e.RowIndex].Cells["fee_id"].Value);
                        drCompare["rep_full_name"] = drReport["full_name"];
                        drCompare["rep_bus_name"] = drReport["bus_name"];
                        drCompare["rep_bus_type"] = drReport["bus_type"];
                        drCompare["rep_subscribe"] = drReport["subscribe"];
                        drCompare["rep_proportion"] = drReport["proportion"];
                        drCompare["rep_office"] = drReport["office"];
                        drCompare["rep_status"] = drReport["status"];
                        drCompare["fee_full_name"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_full_name"].Value;
                        drCompare["fee_bus_name"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_bus_name"].Value;
                        drCompare["fee_bus_type"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_bus_type"].Value;
                        drCompare["fee_subscribe"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_subscribe"].Value;
                        drCompare["fee_proportion"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_proportion"].Value;
                        drCompare["fee_office"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_office"].Value;
                        drCompare["fee_status"] = dgvFeedback.Rows[e.RowIndex].Cells["fee_status"].Value;

                        drCompare["compare_type"] = "一致";
                        drCompare["less_value"] = 0;
                        dtCompare.Rows.Add(drCompare);
                        dgvCompare.DataSource = dtCompare;
                        dgvCompare.ClearSelection();

                        dgvFeedback.Rows[e.RowIndex].Cells["fee_is_match"].Value = true;
                        GetCompareResult();
                    }
                }
            }
        }

        private void dgvFeedback_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string repFullName = "";
            string repBusName = "";

            //dgvFeedback.DefaultCellStyle.SelectionBackColor = Color.Moccasin;//单击时将选择行变回蓝色

            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                if (row.Cells["rep_full_name"].Value != null&& row.Cells["rep_bus_name"].Value != null)
                {
                    repFullName = row.Cells["rep_full_name"].Value.ToString();
                    repBusName = row.Cells["rep_bus_name"].Value.ToString();
                }
                if (repFullName == dgvFeedback.Rows[e.RowIndex].Cells["fee_full_name"].Value.ToString()&&
                    repBusName == dgvFeedback.Rows[e.RowIndex].Cells["fee_bus_name"].Value.ToString())
                {
                    dgvReport.Rows[row.Index].Selected = true;
                    //dgvReport.Rows[row.Index].DefaultCellStyle.SelectionBackColor = Color.PowderBlue;
                    //dgvReport.DefaultCellStyle.SelectionBackColor = Color.PowderBlue;
                    return;
                }
            }
        }

        private void dgvFeedback_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Boolean isMatch = false;
                if (this.dgvFeedback.Rows[e.RowIndex].Cells["fee_is_match"].Value != DBNull.Value)
                {
                    isMatch = Convert.ToBoolean(this.dgvFeedback.Rows[e.RowIndex].Cells["fee_is_match"].Value);
                }
                if (isMatch)
                {
                    dgvFeedback.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                else
                {
                    dgvFeedback.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void dgvReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string feeFullName = "";
            string feeBusName = "";

           // dgvReport.DefaultCellStyle.SelectionBackColor = Color.Moccasin;//单击时将选择行变回蓝色

            foreach (DataGridViewRow row in dgvFeedback.Rows)
            {
                if (row.Cells["fee_full_name"].Value != null && row.Cells["fee_bus_name"].Value != null)
                {
                    feeFullName = row.Cells["fee_full_name"].Value.ToString();
                    feeBusName = row.Cells["fee_bus_name"].Value.ToString();
                }
                if (feeFullName == dgvReport.Rows[e.RowIndex].Cells["rep_full_name"].Value.ToString() &&
                    feeBusName == dgvReport.Rows[e.RowIndex].Cells["rep_bus_name"].Value.ToString())
                {
                    dgvFeedback.Rows[row.Index].Selected = true;
                    //dgvFeedback.Rows[row.Index].DefaultCellStyle.SelectionBackColor = Color.PowderBlue;
                    //dgvFeedback.DefaultCellStyle.SelectionBackColor = Color.PowderBlue;
                    return;
                }
            }
        }

        private void dgvReport_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string dataProName = dgvReport.Columns[e.ColumnIndex].DataPropertyName;
            string reportValue = dgvReport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int repFeedbackId;
            int.TryParse(dgvReport.Rows[e.RowIndex].Cells["rep_feedback_id"].Value.ToString(), out repFeedbackId);
            if (repFeedbackId != 0)//说明已经匹配到了反馈数据
            {
                DataTable dtCompare = (DataTable)dgvCompare.DataSource;
                DataRow[] dataRows = dtCompare.Select(string.Format("feedback_id={0}", repFeedbackId));
                if (dataRows.Length > 0)
                {
                    dataRows[0]["rep_" + dataProName] = reportValue;
                    if (reportValue != dataRows[0]["fee_" + dataProName].ToString())
                    {
                        dataRows[0]["compare_type"] = "不一致";
                    }
                    else
                    {
                        dataRows[0]["compare_type"] = "一致";
                    }
                    if (dataProName == "subscribe")
                    {
                        decimal repSubscribe = decimal.Parse(dataRows[0]["rep_subscribe"].ToString());
                        decimal feeSubscribe = decimal.Parse(dataRows[0]["fee_subscribe"].ToString());
                        dataRows[0]["less_value"] = feeSubscribe - repSubscribe;
                    }
                    GetCompareResult();
                }
            }
        }

        private void dgvReport_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Boolean isMatch = false;
                if (this.dgvReport.Rows[e.RowIndex].Cells["rep_is_match"].Value != DBNull.Value)
                {
                    isMatch = Convert.ToBoolean(this.dgvReport.Rows[e.RowIndex].Cells["rep_is_match"].Value);
                }
                if (isMatch)
                {
                    dgvReport.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                else
                {
                    dgvReport.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        private void dgvCompare_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (dgvCompare.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (dgvCompare.Columns[e.ColumnIndex].Name == "btnUnmatch")
                    {
                        string repFullName = "";
                        string repBusName = "";
                        string repBusType = "";
                        decimal repSubscribe = 0;
                        string repOffice = "";
                        if (dgvCompare.Rows[e.RowIndex].Cells["comr_full_name"].Value != null &&
                            dgvCompare.Rows[e.RowIndex].Cells["comr_bus_name"].Value != null &&
                            dgvCompare.Rows[e.RowIndex].Cells["comr_bus_type"].Value != null &&
                            dgvCompare.Rows[e.RowIndex].Cells["comr_subscribe"].Value != null &&
                            dgvCompare.Rows[e.RowIndex].Cells["comr_office"].Value != null)
                        {
                            repFullName = dgvCompare.Rows[e.RowIndex].Cells["comr_full_name"].Value.ToString();
                            repBusName = dgvCompare.Rows[e.RowIndex].Cells["comr_bus_name"].Value.ToString();
                            repBusType = dgvCompare.Rows[e.RowIndex].Cells["comr_bus_type"].Value.ToString();
                            repSubscribe = Convert.ToDecimal(dgvCompare.Rows[e.RowIndex].Cells["comr_subscribe"].Value.ToString());
                            repOffice = dgvCompare.Rows[e.RowIndex].Cells["comr_office"].Value.ToString();                            
                        }

                        int feedback_id = 0;
                        int.TryParse(dgvCompare.Rows[e.RowIndex].Cells["com_feedback_id"].Value.ToString(), out feedback_id);

                        DataTable dtReport = (DataTable)dgvReport.DataSource;
                        DataRow[] dataRows = dtReport.Select(string.Format("full_name='{0}' and bus_name='{1}' and " +
                            "bus_type='{2}' and subscribe={3} and office='{4}'",
                            repFullName, repBusName, repBusType, repSubscribe, repOffice));
                        if (dataRows.Length > 0)
                        {
                            dataRows[0]["is_match"] = false;
                        }
                        dgvReport.DataSource = dtReport;

                        DataTable dtFeedback = (DataTable)dgvFeedback.DataSource;

                        dataRows = dtFeedback.Select(string.Format("id={0}", feedback_id));
                        if (dataRows.Length > 0)
                        {
                            dataRows[0]["is_match"] = false;
                        }

                        dgvFeedback.DataSource = dtFeedback;
                        dgvFeedback.ClearSelection();
                        dgvReport.ClearSelection();

                        //删除匹配数据表中的数据
                        DataTable dtCompare = (DataTable)dgvCompare.DataSource;
                        dataRows = dtCompare.Select(string.Format("feedback_id={0}", feedback_id));
                        if (dataRows.Length > 0)
                        {
                            dtCompare.Rows.Remove(dataRows[0]);
                        }
                        dgvCompare.DataSource = dtCompare;
                        dgvCompare.ClearSelection();
                        dgvFeedback.Refresh();
                        dgvReport.Refresh();
                        dgvCompare.Refresh();

                    }
                    if (dgvCompare.Columns[e.ColumnIndex].Name == "btnToMatch")
                    {
                        dgvCompare.SelectedRows[0].Cells["com_compare_type"].Value = "一致";
                        dgvCompare.Refresh();
                    }
                    GetCompareResult();
                }
            }
        }

        private void dgvCompare_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                e.PaintBackground(e.CellBounds, false);
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintContent(r2);
                e.Handled = true;
                if (e.ColumnIndex == 18 || e.ColumnIndex == 19)
                {
                    SolidBrush brush = new SolidBrush(Color.Yellow);
                    Rectangle r1 = this.dgvCompare.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    e.Graphics.FillRectangle(brush, r1);
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(dgvCompare.Columns[e.ColumnIndex].HeaderText,
                        this.dgvCompare.ColumnHeadersDefaultCellStyle.Font,
                        new SolidBrush(this.dgvCompare.ColumnHeadersDefaultCellStyle.ForeColor),
                        r1,
                        format);
                }
            }
            if (e.RowIndex > -1)
            {
                string matchstr = dgvCompare.Rows[e.RowIndex].Cells["com_compare_type"].Value.ToString();
                if (matchstr == "不一致")
                {
                    dgvCompare.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
                }
                else
                {
                    dgvCompare.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void dgvCompare_Paint(object sender, PaintEventArgs e)
        {
            string[] headers = { "个人报告", "查询反馈" };
            for (int j = 4; j < 16;)
            {
                
                Rectangle r1 = this.dgvCompare.GetCellDisplayRectangle(j, -1, true); //get the column header cell
                r1.X += 1;
                r1.Y += 1;
                r1.Width = 510 - 2;   //610是5个比对列的总宽度
                r1.Height = r1.Height / 2 - 2;
                SolidBrush brush = new SolidBrush(Color.ForestGreen);
                if (j == 4)
                {
                    brush = new SolidBrush(Color.GreenYellow);
                }
                e.Graphics.FillRectangle(brush, r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(headers[j / 7],
                    this.dgvCompare.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(this.dgvCompare.ColumnHeadersDefaultCellStyle.ForeColor),
                    r1,
                    format);
                j += 7;
            }
        }

        private void btnUnhidden_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("取消隐藏将会自动保存比对结果，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //saveResult();

            BLL.business_feedback bll = new BLL.business_feedback();

            bll.UpdateAll("is_hidden=0");

            DTV.Business business = new DTV.Business();
            //载入出入境反馈数据            
            dgvFeedback.DataSource = business.LoadFeedback(query_id);
            dgvFeedback.Refresh();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (dgvReport.SelectedRows.Count < 1 || dgvFeedback.SelectedRows.Count < 1)
            {
                MessageBox.Show("请先选择要匹配的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvFeedback.ClearSelection();
                dgvReport.ClearSelection();
                return;
            }

            bool report_match = Convert.ToBoolean(dgvReport.SelectedRows[0].Cells["rep_is_match"].Value);
            bool feedback_match = Convert.ToBoolean(dgvFeedback.SelectedRows[0].Cells["fee_is_match"].Value);
            if (report_match || feedback_match)
            {
                MessageBox.Show("不能匹配已经匹配的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvFeedback.ClearSelection();
                dgvReport.ClearSelection();
                return;
            }

            //添加数据到匹配数据表中
            DataTable dtCompare = (DataTable)dgvCompare.DataSource;
            DataRow drCompare = dtCompare.NewRow();

            drCompare["id"] = 0;
            drCompare["query_id"] = Convert.ToInt32(dgvFeedback.SelectedRows[0].Cells["fee_query_id"].Value);
            drCompare["report_id"] = dgvReport.SelectedRows[0].Cells["rep_id"].Value;
            drCompare["feedback_id"] = Convert.ToInt32(dgvFeedback.SelectedRows[0].Cells["fee_id"].Value);
            drCompare["rep_full_name"] = dgvReport.SelectedRows[0].Cells["rep_full_name"].Value;
            drCompare["rep_bus_name"] = dgvReport.SelectedRows[0].Cells["rep_bus_name"].Value;
            drCompare["rep_bus_type"] = dgvReport.SelectedRows[0].Cells["rep_bus_type"].Value;
            drCompare["rep_subscribe"] = dgvReport.SelectedRows[0].Cells["rep_subscribe"].Value;
            drCompare["rep_office"] = dgvReport.SelectedRows[0].Cells["rep_office"].Value;
            drCompare["rep_status"] = dgvReport.SelectedRows[0].Cells["rep_status"].Value;

            drCompare["fee_full_name"] = dgvFeedback.SelectedRows[0].Cells["fee_full_name"].Value;
            drCompare["fee_bus_name"] = dgvFeedback.SelectedRows[0].Cells["fee_bus_name"].Value;
            drCompare["fee_bus_type"] = dgvFeedback.SelectedRows[0].Cells["fee_bus_type"].Value;
            drCompare["fee_subscribe"] = dgvFeedback.SelectedRows[0].Cells["fee_subscribe"].Value;
            drCompare["fee_office"] = dgvFeedback.SelectedRows[0].Cells["fee_office"].Value;
            drCompare["fee_status"] = dgvFeedback.SelectedRows[0].Cells["fee_status"].Value;
            drCompare["compare_type"] = "一致";
            drCompare["less_value"] = 0;


            if (!(drCompare["rep_full_name"].ToString() == drCompare["fee_full_name"].ToString() &&
                drCompare["rep_bus_name"].ToString() == drCompare["fee_bus_name"].ToString() &&
                drCompare["rep_bus_type"].ToString() == drCompare["fee_bus_type"].ToString() &&
                drCompare["rep_subscribe"].ToString() == drCompare["fee_subscribe"].ToString() &&
                drCompare["rep_office"].ToString() == drCompare["fee_office"].ToString()))            
            {
                drCompare["compare_type"] = "不一致";
                decimal repSubscribe = decimal.Parse(drCompare["rep_subscribe"].ToString());
                decimal feeSubscribe = decimal.Parse(drCompare["fee_subscribe"].ToString());
                drCompare["less_value"] = feeSubscribe - repSubscribe;
            }

            dtCompare.Rows.Add(drCompare);
            dgvCompare.DataSource = dtCompare;
            dgvFeedback.SelectedRows[0].Cells["fee_is_match"].Value = true;
            dgvReport.SelectedRows[0].Cells["rep_is_match"].Value = true;
            dgvReport.SelectedRows[0].Cells["rep_feedback_id"].Value = dgvFeedback.SelectedRows[0].Cells["fee_id"].Value;
            dgvFeedback.Refresh();
            dgvReport.Refresh();
            dgvFeedback.ClearSelection();
            dgvReport.ClearSelection();
            dgvCompare.ClearSelection();
            GetCompareResult();
        }

        Dictionary<string, string> CalcCompareResult()
        {
            DTV.Business business  = new DTV.Business();
            business.query_id = this.query_id;
            Dictionary<string, DataTable> dictionary = new Dictionary<string, DataTable>();
            dictionary.Add("Report", DgvToTable(dgvReport));
            dictionary.Add("Feedback", DgvToTable(dgvFeedback));
            dictionary.Add("Compare", DgvToTable(dgvCompare));
            return business.CalcResult(dictionary);
        }

        void GetCompareResult() {
            Dictionary<string, string> result = CalcCompareResult();
            tbReport.Text = result["Report"];
            tbFeedback.Text = result["Feedback"];
            tbCompare.Text = result["Compare"];
        }

        private void tsbSaveResult_Click(object sender, EventArgs e) {
            string resultstr = saveResult();
            MessageBox.Show(resultstr);
            if (resultstr== "写入成功！")
            {
                FrmPersonList frmOwner = (FrmPersonList)this.ParentForm.Owner;
                frmOwner.RefreshForm();                
            }
            DTV.Business business = new DTV.Business();
            dgvReport.DataSource = business.LoadReport(query_id);
            dgvReport.Refresh();
        }

        private string saveResult() {
            Dictionary<string, DataTable> dictionary = new Dictionary<string, DataTable>();
            dictionary.Add("Report", DgvToTable(dgvReport));
            dictionary.Add("Feedback", DgvToTable(dgvFeedback));
            dictionary.Add("Compare", DgvToTable(dgvCompare));

            DTV.Business business = new DTV.Business();

            Dictionary<string, string> result = CalcCompareResult();

            //比对结果数据
            DataTable dt = new DataTable();
            dt.Columns.Add("Type", Type.GetType("System.String"));
            dt.Columns.Add("Report", Type.GetType("System.String"));
            dt.Columns.Add("Feedback", Type.GetType("System.String"));
            dt.Columns.Add("Compare", Type.GetType("System.String"));
            dt.Columns.Add("RepLock", Type.GetType("System.Boolean"));
            DataRow newRow = dt.NewRow();
            newRow["Type"] = "工商";
            newRow["Report"] = result["Report"];
            newRow["Feedback"] = result["Feedback"];
            newRow["Compare"] = result["Compare"];
            newRow["RepLock"] = false;
            dt.Rows.Add(newRow);
            dictionary.Add("Result", dt);
            return business.SaveCompareResult(dictionary, query_id);
        }

        private void button1_Click(object sender, EventArgs e) {
            using (DXD.QuickCompare.FrmAddBusinessReport frm = new FrmAddBusinessReport(query_id))
            {
                frm.ShowDialog(this);
                if (frm.DialogResult == DialogResult.OK)
                {
                    DataTable dTable = (DataTable)dgvReport.DataSource;
                    DataRow dr = dTable.NewRow();
                    dr["id"] = 0;
                    dr["query_id"] = frm.model.query_id;
                    dr["feedback_id"] = 0;
                    dr["full_name"] = frm.fullName;
                    dr["bus_name"] =frm.model.bus_name;
                    dr["bus_type"] = frm.model.bus_type;
                    dr["subscribe"] = frm.model.subscribe;
                    dr["proportion"] = frm.model.proportion;
                    dr["office"] = frm.model.office;
                    dr["status"] = frm.model.status;
                    dr["is_match"] = false;
                    dr["is_import"] = false;
                    dTable.Rows.Add(dr);
                    dgvReport.DataSource = dTable;                    
                    dgvFeedback.ClearSelection();
                    dgvReport.ClearSelection();
                }
            }
            GetCompareResult();
        }        
    }
}
