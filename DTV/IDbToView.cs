using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DXD.DTV
{
    /// <summary>
    /// 读取数据库中的数据供窗体的控件调用
    /// </summary>
    interface IDbToView
    {
        DataTable LoadReport(int query_id);
        DataTable LoadFeedback(int query_id);
        DataTable LoadCompare(int query_id);
        DataTable LoadCompareResult(int query_id);

        Dictionary<string, string> CalcResult(Dictionary<string, DataTable> dictionary);
        string SaveCompareResult(Dictionary<string,DataTable> dictionary,int query_id);
    }
}
