using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;


namespace DXD.DTV
{    
    public abstract class DbToViewBase :IDbToView
    {   
        public static string compareYear = ConfigurationManager.AppSettings["CompareYear"];
        public static string connectionString = DXD.DBUtility.PubConstant.ConnectionString;
        public int query_id = 0;
        public abstract DataTable LoadReport(int query_id);
        public abstract DataTable LoadFeedback(int query_id);
        public abstract DataTable LoadCompare(int query_id);
        public abstract DataTable LoadCompareResult(int query_id);
        public abstract string SaveCompareResult(Dictionary<string, DataTable> dictionary,int query_id);
        public abstract Dictionary<string, string> CalcResult(Dictionary<string, DataTable> dictionary);
    }
}
