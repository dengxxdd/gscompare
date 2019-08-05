using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SQLite;

namespace DXD.DTV
{
    public class Business : DbToViewBase
    {
        public static string CBusiness = "工商";
        static class appType {
            public const int Self = 0;
            public const int Spouse = 1;
            public const int Son = 2;
            public const int Daughter = 3;
            public const int Daughter_in_law = 4;
            public const int Son_in_law = 5;
        }        
        string[] strApps = { "本人", "配偶", "儿子","女儿","媳妇","女婿" };

        public override Dictionary<string, string> CalcResult(Dictionary<string, DataTable> dictionary)
        {
            DataTable dtReport = dictionary["Report"];
            DataTable dtFeedback = dictionary["Feedback"];
            DataTable dtCompare = dictionary["Compare"];

            string jsonfile = System.Environment.CurrentDirectory + "\\Templates\\CompareResult.json";
            Dictionary<string, string> templateBus = new Dictionary<string, string>();
            Dictionary<string, string> templatePart = new Dictionary<string, string>();

            //读取模板数据
            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    JToken a = o["Business"];
                    templateBus["Title"] = a["Title"].ToString();
                    templateBus["SubTitle"] = a["SubTitle"].ToString();
                    templateBus["UnreportStr"] = a["UnreportStr"].ToString();
                    templateBus["UnderreportStr"] = a["UnderreportStr"].ToString();
                    templateBus["EqualStr"] = a["EqualStr"].ToString();
                    templateBus["NoSuchStr"] = a["NoSuchStr"].ToString();
                    templateBus["TempStr"] = a["TempStr"].ToString();

                    a = o["PartTimeJob"];
                    templatePart["Title"] = a["Title"].ToString();
                    templatePart["UnreportStr"] = a["UnreportStr"].ToString();
                    templatePart["UnderreportStr"] = a["UnderreportStr"].ToString();
                    templatePart["EqualStr"] = a["EqualStr"].ToString();
                    templatePart["NoSuchStr"] = a["NoSuchStr"].ToString();
                    templatePart["TempStr"] = a["TempStr"].ToString();
                }
            }

            Dictionary<string, string> result = new Dictionary<string, string>();


            //计算反馈数据

            //计算本人兼职情况
            DataRow[] rows = dtFeedback.Select(string.Format("fee_subscribe=0", query_id));
            StringBuilder partTimeJobStr = new StringBuilder();
            
            if (rows.Length > 0)
            {
                partTimeJobStr.Append(templatePart["Title"].Replace("{Total}", rows.Length.ToString()));
                foreach (DataRow dr in rows)
                {
                    BLL.query_detail bll = new BLL.query_detail();
                    Model.query_detail model = bll.GetModel(int.Parse(dr["fee_query_id"].ToString()));
                    int appTypeIndex = 0;
                    switch (model.appellation)
                    {
                        case "301"://本人
                            appTypeIndex = appType.Self;
                            break;
                        case "302"://配偶
                            appTypeIndex = appType.Spouse;
                            break;
                        case "303"://儿子
                            appTypeIndex = appType.Son;
                            break;
                        case "304"://女儿  
                            appTypeIndex = appType.Daughter;
                            break;
                        case "305"://媳妇
                            appTypeIndex = appType.Daughter_in_law;
                            break;
                        case "306"://女婿 
                            appTypeIndex = appType.Son_in_law;
                            break;
                        default:
                            break;
                    }
                    if (appTypeIndex == appType.Self)
                    {
                        partTimeJobStr.Append(templatePart["TempStr"].Replace("{Appellation}",strApps[appTypeIndex]).Replace("{BusName}", dr["fee_bus_name"].ToString())
                                            .Replace("{Post}", dr["fee_office"].ToString()) + "、");
                    }
                    else
                    {
                        partTimeJobStr.Append(templatePart["TempStr"].Replace("{Appellation}",strApps[appTypeIndex]+dr["fee_full_name"].ToString()).Replace("{BusName}", dr["fee_bus_name"].ToString())
                                            .Replace("{Post}", dr["fee_office"].ToString()) + "、");
                    }                    
                }                
                
                result.Add("Feedback", partTimeJobStr.ToString());
                result["Feedback"] = result["Feedback"].Substring(0, result["Feedback"].Length - 1) + "。";
            }



            //计算投资企业情况
            Dictionary<int, List<double>> busValues = new Dictionary<int, List<double>>();
            Dictionary<int, StringBuilder> busStrs = new Dictionary<int, StringBuilder>();            
            for(int i=appType.Self;i<=appType.Son_in_law;i++)
            {
                busValues[i] = new List<double>();
                busStrs[i] = new StringBuilder();
            }
            rows = dtFeedback.Select("fee_subscribe>0");
            foreach (DataRow dr in rows)
            {
                double value = 0;
                BLL.query_detail bll = new BLL.query_detail();
                Model.query_detail model = bll.GetModel(int.Parse(dr["fee_query_id"].ToString()));
                int appTypeIndex = 0;
                switch (model.appellation)
                {
                    case "301"://本人
                        appTypeIndex = appType.Self;
                        break;
                    case "302"://配偶
                        appTypeIndex = appType.Spouse;
                        break;
                    case "303"://儿子
                        appTypeIndex = appType.Son;
                        break;
                    case "304"://女儿  
                        appTypeIndex = appType.Daughter;
                        break;
                    case "305"://媳妇
                        appTypeIndex = appType.Daughter_in_law;
                        break;
                    case "306"://女婿 
                        appTypeIndex = appType.Son_in_law;
                        break;
                    default:
                        break;
                }
                busStrs[appTypeIndex].Append(templateBus["TempStr"].Replace("{BusName}", dr["fee_bus_name"].ToString())
                            .Replace("{Value}", dr["fee_subscribe"].ToString())
                            .Replace("{Proportion}", dr["fee_proportion"].ToString()) + "；");
                double.TryParse(dr["fee_subscribe"].ToString(), out value);
                busValues[appTypeIndex].Add(value);
            }
            double values=0;
            foreach (int key in busValues.Keys)
            {
                values += busValues[key].Sum();
                if (busValues[key].Count > 0)
                {
                    busStrs[key].Insert(0, templateBus["SubTitle"].Replace("{Appellation}", strApps[key])
                    .Replace("{Total}", busValues[key].Count.ToString()).Replace("{TotalValue}", busValues[key].Sum().ToString()));
                }
            }
            if (rows.Length > 0)
            {
                if(result.ContainsKey("Feedback"))
                {
                    result["Feedback"] +="\r\n"+ templateBus["Title"].Replace("{Total}", rows.Length.ToString()).Replace("{TotalValue}",
                        values.ToString())+ "\r\n";
                }
                else
                {
                    result.Add("Feedback", templateBus["Title"].Replace("{Total}", rows.Length.ToString()).Replace("{TotalValue}", 
                        values.ToString())+"\r\n");
                }
                foreach (int key in busStrs.Keys)
                {
                    if (busStrs[key].Length > 0)
                    {
                        result["Feedback"] += busStrs[key];
                    }
                }
                result["Feedback"] = result["Feedback"].Substring(0, result["Feedback"].Length - 1) + "。";
            }
            if (rows.Length == 0&&!result.ContainsKey("Feedback"))
            {
                result.Add("Feedback", templateBus["NoSuchStr"]);
            }

            ////计算个人报告数据

            //计算本人兼职情况
            rows = dtReport.Select(string.Format("rep_subscribe=0", query_id));
            partTimeJobStr = new StringBuilder();
                        
            if (rows.Length > 0)
            {
                partTimeJobStr.Append(templatePart["Title"].Replace("{Total}", rows.Length.ToString()));
                foreach (DataRow dr in rows)
                {
                    BLL.query_detail bll = new BLL.query_detail();
                    Model.query_detail model = bll.GetModel(int.Parse(dr["rep_query_id"].ToString()));
                    int appTypeIndex = 0;
                    switch (model.appellation)
                    {
                        case "301"://本人
                            appTypeIndex = appType.Self;
                            break;
                        case "302"://配偶
                            appTypeIndex = appType.Spouse;
                            break;
                        case "303"://儿子
                            appTypeIndex = appType.Son;
                            break;
                        case "304"://女儿  
                            appTypeIndex = appType.Daughter;
                            break;
                        case "305"://媳妇
                            appTypeIndex = appType.Daughter_in_law;
                            break;
                        case "306"://女婿 
                            appTypeIndex = appType.Son_in_law;
                            break;
                        default:
                            break;
                    }
                    if (appTypeIndex == appType.Self)
                    {
                        partTimeJobStr.Append(templatePart["TempStr"].Replace("{Appellation}", strApps[appTypeIndex]).Replace("{BusName}", dr["rep_bus_name"].ToString())
                                            .Replace("{Post}", dr["rep_office"].ToString()) + "、");
                    }
                    else
                    {
                        partTimeJobStr.Append(templatePart["TempStr"].Replace("{Appellation}", strApps[appTypeIndex] + dr["rep_full_name"].ToString()).Replace("{BusName}", dr["rep_bus_name"].ToString())
                                            .Replace("{Post}", dr["rep_office"].ToString()) + "、");
                    }
                }

                result.Add("Report", partTimeJobStr.ToString());
                result["Report"] = result["Report"].Substring(0, result["Report"].Length - 1) + "。";                
            }

            //计算投资企业情况
            for (int i = appType.Self; i <= appType.Son_in_law; i++)
            {
                busValues[i] = new List<double>();
                busStrs[i] = new StringBuilder();
            }
            rows = dtReport.Select("rep_subscribe>0");
            foreach (DataRow dr in rows)
            {
                double value = 0;
                BLL.query_detail bll = new BLL.query_detail();
                Model.query_detail model = bll.GetModel(int.Parse(dr["rep_query_id"].ToString()));
                int appTypeIndex = 0;
                switch (model.appellation)
                {
                    case "301"://本人
                        appTypeIndex = appType.Self;
                        break;
                    case "302"://配偶
                        appTypeIndex = appType.Spouse;
                        break;
                    case "303"://儿子
                        appTypeIndex = appType.Son;
                        break;
                    case "304"://女儿  
                        appTypeIndex = appType.Daughter;
                        break;
                    case "305"://媳妇
                        appTypeIndex = appType.Daughter_in_law;
                        break;
                    case "306"://女婿 
                        appTypeIndex = appType.Son_in_law;
                        break;
                    default:
                        break;
                }
                busStrs[appTypeIndex].Append(templateBus["TempStr"].Replace("{BusName}", dr["rep_bus_name"].ToString())
                            .Replace("{Value}", dr["rep_subscribe"].ToString())
                            .Replace("{Proportion}", dr["rep_proportion"].ToString()) + "；");
                double.TryParse(dr["rep_subscribe"].ToString(), out value);
                busValues[appTypeIndex].Add(value);
            }
            values = 0;
            foreach (int key in busValues.Keys)
            {
                values += busValues[key].Sum();
                if (busValues[key].Count > 0)
                {
                    busStrs[key].Insert(0, templateBus["SubTitle"].Replace("{Appellation}", strApps[key])
                    .Replace("{Total}", busValues[key].Count.ToString()).Replace("{TotalValue}", busValues[key].Sum().ToString()));
                }
            }
            if (rows.Length > 0)
            {
                if (result.ContainsKey("Report"))
                {
                    result["Report"] += "\r\n" + templateBus["Title"].Replace("{Total}", rows.Length.ToString()).Replace("{TotalValue}",
                        values.ToString()) + "\r\n";
                }
                else
                {
                    result.Add("Report", templateBus["Title"].Replace("{Total}", rows.Length.ToString()).Replace("{TotalValue}",
                        values.ToString()) + "\r\n");
                }
                foreach (int key in busStrs.Keys)
                {
                    if (busStrs[key].Length > 0)
                    {
                        result["Report"] += busStrs[key];
                    }
                }
                result["Report"] = result["Report"].Substring(0, result["Report"].Length - 1) + "。";
            }
            if (rows.Length == 0 && !result.ContainsKey("Report"))
            {
                result.Add("Report", templateBus["NoSuchStr"]);
            }

            //计算比对结果数据

            //计算兼职情况
            rows = dtFeedback.Select(string.Format("fee_subscribe=0 and fee_is_match=False", query_id));
            partTimeJobStr = new StringBuilder();

            if (rows.Length > 0)
            {
                foreach (DataRow dr in rows)
                {
                    BLL.query_detail bll = new BLL.query_detail();
                    Model.query_detail model = bll.GetModel(int.Parse(dr["fee_query_id"].ToString()));
                    int appTypeIndex = 0;
                    switch (model.appellation)
                    {
                        case "301"://本人
                            appTypeIndex = appType.Self;
                            break;
                        case "302"://配偶
                            appTypeIndex = appType.Spouse;
                            break;
                        case "303"://儿子
                            appTypeIndex = appType.Son;
                            break;
                        case "304"://女儿  
                            appTypeIndex = appType.Daughter;
                            break;
                        case "305"://媳妇
                            appTypeIndex = appType.Daughter_in_law;
                            break;
                        case "306"://女婿 
                            appTypeIndex = appType.Son_in_law;
                            break;
                        default:
                            break;
                    }
                    if (appTypeIndex == appType.Self)
                    {
                        partTimeJobStr.Append(templatePart["TempStr"].Replace("{Appellation}", strApps[appTypeIndex]).Replace("{BusName}", dr["fee_bus_name"].ToString())
                                            .Replace("{Post}", dr["fee_office"].ToString()) + "、");
                    }
                    else
                    {
                        partTimeJobStr.Append(templatePart["TempStr"].Replace("{Appellation}", strApps[appTypeIndex] + dr["fee_full_name"].ToString()).Replace("{BusName}", dr["fee_bus_name"].ToString())
                                            .Replace("{Post}", dr["fee_office"].ToString()) + "、");
                    }                   
                }
                partTimeJobStr.Append(templatePart["Title"].Replace("{Total}", rows.Length.ToString()));               
                result.Add("Compare", templatePart["UnreportStr"] + partTimeJobStr.ToString());
                result["Compare"] = result["Compare"].Substring(0, result["Compare"].Length - 1) + "。";
            }

            //计算未报投资企业情况
            for (int i = appType.Self; i <= appType.Son_in_law; i++)
            {
                busValues[i] = new List<double>();
                busStrs[i] = new StringBuilder();
            }
            rows = dtFeedback.Select("fee_subscribe>0 and fee_is_match=False");
            foreach (DataRow dr in rows)
            {
                double value = 0;
                BLL.query_detail bll = new BLL.query_detail();
                Model.query_detail model = bll.GetModel(int.Parse(dr["fee_query_id"].ToString()));
                int appTypeIndex = 0;
                switch (model.appellation)
                {
                    case "301"://本人
                        appTypeIndex = appType.Self;
                        break;
                    case "302"://配偶
                        appTypeIndex = appType.Spouse;
                        break;
                    case "303"://儿子
                        appTypeIndex = appType.Son;
                        break;
                    case "304"://女儿  
                        appTypeIndex = appType.Daughter;
                        break;
                    case "305"://媳妇
                        appTypeIndex = appType.Daughter_in_law;
                        break;
                    case "306"://女婿 
                        appTypeIndex = appType.Son_in_law;
                        break;
                    default:
                        break;
                }
                busStrs[appTypeIndex].Append(templateBus["TempStr"].Replace("{BusName}", dr["fee_bus_name"].ToString())
                            .Replace("{Value}", dr["fee_subscribe"].ToString())
                            .Replace("{Proportion}", dr["fee_proportion"].ToString()) + "；");
                double.TryParse(dr["fee_subscribe"].ToString(), out value);
                busValues[appTypeIndex].Add(value);
            }
            values = 0;
            foreach (int key in busValues.Keys)
            {
                values += busValues[key].Sum();
                if (busValues[key].Count > 0)
                {
                    busStrs[key].Insert(0, templateBus["SubTitle"].Replace("{Appellation}", strApps[key])
                    .Replace("{Total}", busValues[key].Count.ToString()).Replace("{TotalValue}", busValues[key].Sum().ToString()));
                }
            }
            if (rows.Length > 0)
            {
                if (result.ContainsKey("Compare"))
                {
                    result["Compare"] += "\r\n" + templateBus["UnreportStr"];
                }
                else
                {
                    result.Add("Compare", templateBus["UnreportStr"]);
                }
                foreach (int key in busStrs.Keys)
                {
                    if (busStrs[key].Length > 0)
                    {
                        result["Compare"] += busStrs[key];
                    }
                }
                result["Compare"] = result["Compare"].Substring(0, result["Compare"].Length - 1) + "。";
            }

            //计算少报投资企业情况
            for (int i = appType.Self; i <= appType.Son_in_law; i++)
            {
                busValues[i] = new List<double>();
                busStrs[i] = new StringBuilder();
            }
            rows = dtCompare.Select("com_less_value>0 and com_compare_type='不一致'");
            foreach (DataRow dr in rows)
            {
                double value = 0;
                BLL.query_detail bll = new BLL.query_detail();
                Model.query_detail model = bll.GetModel(int.Parse(dr["com_query_id"].ToString()));
                int appTypeIndex = 0;
                switch (model.appellation)
                {
                    case "301"://本人
                        appTypeIndex = appType.Self;
                        break;
                    case "302"://配偶
                        appTypeIndex = appType.Spouse;
                        break;
                    case "303"://儿子
                        appTypeIndex = appType.Son;
                        break;
                    case "304"://女儿  
                        appTypeIndex = appType.Daughter;
                        break;
                    case "305"://媳妇
                        appTypeIndex = appType.Daughter_in_law;
                        break;
                    case "306"://女婿 
                        appTypeIndex = appType.Son_in_law;
                        break;
                    default:
                        break;
                }
                busStrs[appTypeIndex].Append(templateBus["TempStr"].Replace("{BusName}", dr["comf_bus_name"].ToString())
                            .Replace("{Value}", dr["com_less_value"].ToString())
                            .Replace("{Proportion}", dr["comf_proportion"].ToString()) + "；");
                double.TryParse(dr["com_less_value"].ToString(), out value);
                busValues[appTypeIndex].Add(value);
            }
            values = 0;
            foreach (int key in busValues.Keys)
            {
                values += busValues[key].Sum();
                if (busValues[key].Count > 0)
                {
                    busStrs[key].Insert(0, templateBus["SubTitle"].Replace("{Appellation}", strApps[key])
                    .Replace("{Total}", busValues[key].Count.ToString()).Replace("{TotalValue}", busValues[key].Sum().ToString()));
                }
            }
            if (rows.Length > 0)
            {
                if (result.ContainsKey("Compare"))
                {
                    result["Compare"] += "\r\n" + templateBus["UnderreportStr"];
                }
                else
                {
                    result.Add("Compare", templateBus["UnderreportStr"]);
                }
                foreach (int key in busStrs.Keys)
                {
                    if (busStrs[key].Length > 0)
                    {
                        result["Compare"] += busStrs[key];
                    }
                }
                result["Compare"] = result["Compare"].Substring(0, result["Compare"].Length - 1) + "。";
            }

            if (rows.Length == 0 && !result.ContainsKey("Compare"))
            {
                result.Add("Compare", templateBus["EqualStr"]);
            }
            
            return result;
        }

        public override DataTable LoadCompare(int query_id)
        {
            BLL.business_compare bll = new BLL.business_compare();
            string strWhere = String.Format(" (query_id={0} or query_id in (select id from query_detail where parent_id={0}))", query_id);
            return bll.GetList(strWhere).Tables[0];
        }

        public override DataTable LoadCompareResult(int query_id)
        {
            BLL.compare_result bll = new BLL.compare_result();
            string strWhere = String.Format("query_id = {0} and result_type ='{1}' order by add_time", query_id, CBusiness);
            return bll.GetList(strWhere).Tables[0];
        }

        public override DataTable LoadFeedback(int query_id)
        {
            BLL.business_feedback bll = new BLL.business_feedback();
            string strWhere = String.Format(" (query_id={0} or query_id in " +
                "(select id from query_detail where parent_id={0} and is_together=1))", query_id);
            return bll.GetList(strWhere).Tables[0];
        }

        public override DataTable LoadReport(int query_id)
        {
            BLL.business_report bll = new BLL.business_report();
            string strWhere = String.Format(" (query_id={0} or query_id in (select id from query_detail where parent_id={0}))", query_id);
            return bll.GetList(strWhere).Tables[0];
        }

        public override string SaveCompareResult(Dictionary<string, DataTable> dictionary, int query_id)
        {
            DataTable dtReport = dictionary["Report"];
            DataTable dtFeedback = dictionary["Feedback"];
            DataTable dtCompare = dictionary["Compare"];
            DataTable dtResult = dictionary["Result"];

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                SQLiteTransaction tx;
                List<int> repIds = new List<int>();
                object obj;

                //保存个人报告数据
                tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    foreach (DataRow row in dtReport.Rows)
                    {
                        Model.business_report model = new Model.business_report();
                        model.id = Convert.ToInt32(row["rep_id"]);
                        model.query_id = Convert.ToInt32(row["rep_query_id"]);
                        model.bus_name = row["rep_bus_name"].ToString();
                        model.bus_type= row["rep_bus_type"].ToString();
                        model.subscribe = Convert.ToDecimal(row["rep_subscribe"]);
                        model.proportion = Convert.ToDecimal(row["rep_proportion"].ToString());
                        model.office = row["rep_office"].ToString();
                        model.status = row["rep_status"].ToString();
                        model.is_match = Convert.ToBoolean(row["rep_is_match"]);
                        model.is_import = Convert.ToBoolean(row["rep_is_import"]);
                        model.add_user = "admin";
                        model.add_time = DateTime.Now;

                        StringBuilder strSql = new StringBuilder();
                        SQLiteParameter[] parameters = { };
                        if (model.id == 0)//ID为0 则数据是新添加的
                        {
                            strSql = new StringBuilder();
                            strSql.Append("insert into business_report(");
                            strSql.Append("query_id,bus_name,scope,reg_no,bus_type,reg_capital,subscribe,proportion,status,paid_in," +
                                "found_date,lost_date,office,remark,is_match,is_import,add_user,add_time)");
                            strSql.Append(" values (");
                            strSql.Append("@query_id,@bus_name,@scope,@reg_no,@bus_type,@reg_capital,@subscribe,@proportion," +
                                "@status,@paid_in,@found_date,@lost_date,@office,@remark,@is_match,@is_import,@add_user,@add_time)");
                            strSql.Append(";select LAST_INSERT_ROWID()");
                            parameters =new SQLiteParameter[] {
                                new SQLiteParameter("@query_id", DbType.Int32,8),
                                new SQLiteParameter("@bus_name", DbType.String,255),
                                new SQLiteParameter("@scope", DbType.String),
                                new SQLiteParameter("@reg_no", DbType.String,50),
                                new SQLiteParameter("@bus_type", DbType.String,50),
                                new SQLiteParameter("@reg_capital", DbType.Decimal,4),
                                new SQLiteParameter("@subscribe", DbType.Decimal,4),
                                new SQLiteParameter("@proportion", DbType.Decimal,4),
                                new SQLiteParameter("@status", DbType.String,10),
                                new SQLiteParameter("@paid_in", DbType.Decimal,4),
                                new SQLiteParameter("@found_date", DbType.DateTime),
                                new SQLiteParameter("@lost_date", DbType.DateTime),
                                new SQLiteParameter("@office", DbType.String,50),
                                new SQLiteParameter("@remark", DbType.String,255),
                                new SQLiteParameter("@is_match", DbType.Boolean),
                                new SQLiteParameter("@is_import", DbType.Boolean),
                                new SQLiteParameter("@add_user", DbType.String,50),
                                new SQLiteParameter("@add_time", DbType.DateTime)};
                            parameters[0].Value = model.query_id;
                            parameters[1].Value = model.bus_name;
                            parameters[2].Value = model.scope;
                            parameters[3].Value = model.reg_no;
                            parameters[4].Value = model.bus_type;
                            parameters[5].Value = model.reg_capital;
                            parameters[6].Value = model.subscribe;
                            parameters[7].Value = model.proportion;
                            parameters[8].Value = model.status;
                            parameters[9].Value = model.paid_in;
                            parameters[10].Value = model.found_date;
                            parameters[11].Value = model.lost_date;
                            parameters[12].Value = model.office;
                            parameters[13].Value = model.remark;
                            parameters[14].Value = model.is_match;
                            parameters[15].Value = model.is_import;
                            parameters[16].Value = model.add_user;
                            parameters[17].Value = model.add_time;
                        }
                        else//更新数据（未在表中显示的数据不用更新）
                        {
                            strSql = new StringBuilder();
                            strSql.Append("update business_report set ");
                            strSql.Append("query_id=@query_id,");
                            strSql.Append("bus_name=@bus_name,");
                            strSql.Append("scope=@scope,");
                            strSql.Append("reg_no=@reg_no,");
                            strSql.Append("bus_type=@bus_type,");
                            strSql.Append("reg_capital=@reg_capital,");
                            strSql.Append("subscribe=@subscribe,");
                            strSql.Append("proportion=@proportion,");
                            strSql.Append("status=@status,");
                            strSql.Append("paid_in=@paid_in,");
                            strSql.Append("found_date=@found_date,");
                            strSql.Append("lost_date=@lost_date,");
                            strSql.Append("office=@office,");
                            strSql.Append("remark=@remark,");
                            strSql.Append("is_match=@is_match,");
                            strSql.Append("is_import=@is_import,");
                            strSql.Append("add_user=@add_user,");
                            strSql.Append("add_time=@add_time");
                            strSql.Append(" where id=@id");
                            parameters = new SQLiteParameter[]{
                                new SQLiteParameter("@query_id", DbType.Int32,8),
                                new SQLiteParameter("@bus_name", DbType.String,255),
                                new SQLiteParameter("@scope", DbType.String),
                                new SQLiteParameter("@reg_no", DbType.String,50),
                                new SQLiteParameter("@bus_type", DbType.String,50),
                                new SQLiteParameter("@reg_capital", DbType.Decimal,4),
                                new SQLiteParameter("@subscribe", DbType.Decimal,4),
                                new SQLiteParameter("@proportion", DbType.Decimal,4),
                                new SQLiteParameter("@status", DbType.String,10),
                                new SQLiteParameter("@paid_in", DbType.Decimal,4),
                                new SQLiteParameter("@found_date", DbType.DateTime),
                                new SQLiteParameter("@lost_date", DbType.DateTime),
                                new SQLiteParameter("@office", DbType.String,50),
                                new SQLiteParameter("@remark", DbType.String,255),
                                new SQLiteParameter("@is_match", DbType.Boolean),
                                new SQLiteParameter("@is_import", DbType.Boolean),
                                new SQLiteParameter("@add_user", DbType.String,50),
                                new SQLiteParameter("@add_time", DbType.DateTime),
                                new SQLiteParameter("@id", DbType.Int32,8)};
                            parameters[0].Value = model.query_id;
                            parameters[1].Value = model.bus_name;
                            parameters[2].Value = model.scope;
                            parameters[3].Value = model.reg_no;
                            parameters[4].Value = model.bus_type;
                            parameters[5].Value = model.reg_capital;
                            parameters[6].Value = model.subscribe;
                            parameters[7].Value = model.proportion;
                            parameters[8].Value = model.status;
                            parameters[9].Value = model.paid_in;
                            parameters[10].Value = model.found_date;
                            parameters[11].Value = model.lost_date;
                            parameters[12].Value = model.office;
                            parameters[13].Value = model.remark;
                            parameters[14].Value = model.is_match;
                            parameters[15].Value = model.is_import;
                            parameters[16].Value = model.add_user;
                            parameters[17].Value = model.add_time;
                            parameters[18].Value = model.id;
                        }
                        cmd.CommandText = strSql.ToString();
                        cmd.CommandType = CommandType.Text;//cmdType;
                        foreach (SQLiteParameter parm in parameters)
                            cmd.Parameters.Add(parm);
                        obj = cmd.ExecuteScalar();
                        //如果是新添加的记录，则先保存ID号，如果在后面的数据库操作中操作不成功，则批量删除这些新添加记录
                        if (model.id == 0)
                        {
                            repIds.Add(Convert.ToInt32(obj));
                        }
                        cmd.Parameters.Clear();
                    }
                    tx.Commit();
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    tx.Rollback();
                    return E.Message;
                }

                tx = conn.BeginTransaction();
                try
                {
                    //保存反馈数据
                    foreach (DataRow row in dtFeedback.Rows)
                    {
                        Model.business_feedback model = new Model.business_feedback();
                        model.id = Convert.ToInt32(row["fee_id"]);
                        if (row["fee_is_match"].ToString() != "")
                        {
                            model.is_match = Convert.ToBoolean(row["fee_is_match"]);
                        }                       

                        //对于反馈数据，只能修改is_match,add_user,add_time三个字段
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update business_feedback set ");
                        strSql.Append("is_match=@is_match where id=@id");
                        SQLiteParameter[] parameters = {
                            new SQLiteParameter("@is_match", DbType.Boolean),
                            new SQLiteParameter("@id", DbType.Int32,8)};
                        parameters[0].Value = model.is_match;
                        parameters[1].Value = model.id;
                        cmd.CommandText = strSql.ToString();
                        cmd.CommandType = CommandType.Text;//cmdType;
                        foreach (SQLiteParameter parm in parameters)
                            cmd.Parameters.Add(parm);
                        obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                    }

                    //保存比对匹配数据
                    List<int> comIds = new List<int>();
                    foreach (DataRow row in dtCompare.Rows)
                    {
                        Model.business_compare model = new Model.business_compare();
                        model.id = Convert.ToInt32(row["com_id"]);
                        model.query_id = Convert.ToInt32(row["com_query_id"]);
                        model.feedback_id = Convert.ToInt32(row["com_feedback_id"]);
                        model.report_id = Convert.ToInt32(row["com_report_id"]);
                        model.less_value = Convert.ToDecimal(row["com_less_value"]);
                        StringBuilder strSql = new StringBuilder();
                        SQLiteParameter[] parameters = { };
                        //如果是新增的个人报告数据，因为不知道数据的ID，所以需重新查询获取ID
                        if (model.report_id == 0)
                        {
                            strSql.Append("select id from business_report where query_id =@query_id ");
                            strSql.Append("and bus_name=@bus_name ");
                            strSql.Append("and subscribe=@subscribe ");
                            parameters = new SQLiteParameter[] {
                                new SQLiteParameter("@query_id", DbType.Int32,8),
                                new SQLiteParameter("@bus_name", DbType.String,255),
                                new SQLiteParameter("@subscribe", DbType.Decimal)
                            };
                            parameters[0].Value = model.query_id;
                            parameters[1].Value = row["comr_bus_name"].ToString();
                            parameters[2].Value = row["comr_subscribe"].ToString();
                            cmd.CommandText = strSql.ToString();
                            cmd.CommandType = CommandType.Text;//cmdType;
                            foreach (SQLiteParameter parm in parameters)
                                cmd.Parameters.Add(parm);
                            obj = cmd.ExecuteScalar();
                            model.report_id = Convert.ToInt32(obj);
                            cmd.Parameters.Clear();
                        }
                        model.compare_type = row["com_compare_type"].ToString();
                        model.add_user = "admin";
                        model.add_time = DateTime.Now;
                        strSql = new StringBuilder();
                        if (model.id == 0)//ID为0 则数据是新添加的
                        {
                            strSql = new StringBuilder();
                            strSql.Append("insert into business_compare(");
                            strSql.Append("query_id,feedback_id,report_id,compare_type,less_value,add_user,add_time)");
                            strSql.Append(" values (");
                            strSql.Append("@query_id,@feedback_id,@report_id,@compare_type,@less_value,@add_user,@add_time)");
                            strSql.Append(";select LAST_INSERT_ROWID()");
                            parameters = new SQLiteParameter[] {
                                new SQLiteParameter("@query_id", DbType.Int32,8),
                                new SQLiteParameter("@feedback_id", DbType.Int32,8),
                                new SQLiteParameter("@report_id", DbType.Int32,8),
                                new SQLiteParameter("@compare_type", DbType.String,6),
                                new SQLiteParameter("@less_value", DbType.Decimal,4),
                                new SQLiteParameter("@add_user", DbType.String,50),
                                new SQLiteParameter("@add_time", DbType.DateTime)};
                            parameters[0].Value = model.query_id;
                            parameters[1].Value = model.feedback_id;
                            parameters[2].Value = model.report_id;
                            parameters[3].Value = model.compare_type;
                            parameters[4].Value = model.less_value;
                            parameters[5].Value = model.add_user;
                            parameters[6].Value = model.add_time;
                        }
                        else//更新数据
                        {
                            strSql = new StringBuilder();
                            strSql.Append("update business_compare set ");
                            strSql.Append("query_id=@query_id,");
                            strSql.Append("feedback_id=@feedback_id,");
                            strSql.Append("report_id=@report_id,");
                            strSql.Append("compare_type=@compare_type,");
                            strSql.Append("less_value=@less_value,");
                            strSql.Append("add_user=@add_user,");
                            strSql.Append("add_time=@add_time");
                            strSql.Append(" where id=@id");
                            parameters = new SQLiteParameter[] {
                                new SQLiteParameter("@query_id", DbType.Int32,8),
                                new SQLiteParameter("@feedback_id", DbType.Int32,8),
                                new SQLiteParameter("@report_id", DbType.Int32,8),
                                new SQLiteParameter("@compare_type", DbType.String,6),
                                new SQLiteParameter("@less_value", DbType.Decimal,4),
                                new SQLiteParameter("@add_user", DbType.String,50),
                                new SQLiteParameter("@add_time", DbType.DateTime),
                                new SQLiteParameter("@id", DbType.Int32,8)};
                            parameters[0].Value = model.query_id;
                            parameters[1].Value = model.feedback_id;
                            parameters[2].Value = model.report_id;
                            parameters[3].Value = model.compare_type;
                            parameters[4].Value = model.less_value;
                            parameters[5].Value = model.add_user;
                            parameters[6].Value = model.add_time;
                            parameters[7].Value = model.id;
                        }
                        cmd.CommandText = strSql.ToString();
                        cmd.CommandType = CommandType.Text;//cmdType;
                        foreach (SQLiteParameter parm in parameters)
                            cmd.Parameters.Add(parm);
                        obj = cmd.ExecuteScalar();
                        if (model.id == 0)
                        {
                            comIds.Add(Convert.ToInt32(obj));
                        }
                        else
                        {
                            comIds.Add(model.id);
                        }
                        cmd.Parameters.Clear();
                    }

                    //删除本次操作以外的匹配数据，因为除本次操作的匹配数据，其他的已经在Datagridview操作中删除。
                    StringBuilder strdelSql = new StringBuilder();
                    string comidlist = string.Join(",", comIds.ToArray());
                    strdelSql.Append("delete from business_compare ");
                    strdelSql.Append(string.Format(" where id not in ({0}) and (query_id={1} or "
                        + " query_id in (select id from query_detail where parent_id={1}))", comidlist, query_id));
                    cmd.CommandText = strdelSql.ToString();
                    cmd.CommandType = CommandType.Text;//cmdType;
                    obj = cmd.ExecuteScalar();


                    ////保存比对结果数据

                    foreach (DataRow row in dtResult.Rows)
                    {
                        Model.compare_result model = new Model.compare_result();
                        model.query_id = query_id;
                        string strQuery = String.Format("select id from compare_result where query_id={0} and result_type='{1}'", model.query_id, row["Type"].ToString());
                        cmd.CommandText = strQuery;
                        cmd.CommandType = CommandType.Text;//cmdType;
                        obj = cmd.ExecuteScalar();
                        model.id = Convert.ToInt32(obj);
                        model.report_str = row["Report"].ToString();
                        model.feedback_str = row["Feedback"].ToString();
                        model.compare_str = row["Compare"].ToString();
                        model.result_type = row["Type"].ToString();
                        model.rep_lock = Boolean.Parse(row["RepLock"].ToString());
                        model.add_user = "admin";
                        model.add_time = DateTime.Now;
                        StringBuilder strSql = new StringBuilder();
                        SQLiteParameter[] parameters = { };
                        if (model.id == 0)//ID为0 则数据是新添加的
                        {
                            strSql.Append("insert into compare_result(");
                            strSql.Append("query_id,result_type,report_str,feedback_str,compare_str,rep_lock,add_user,add_time)");
                            strSql.Append(" values (");
                            strSql.Append("@query_id,@result_type,@report_str,@feedback_str,@compare_str,@rep_lock,@add_user,@add_time)");
                            strSql.Append(";select LAST_INSERT_ROWID()");
                            parameters = new SQLiteParameter[]{
                                new SQLiteParameter("@query_id", DbType.Int32,8),
                                new SQLiteParameter("@result_type", DbType.String,16),
                                new SQLiteParameter("@report_str", DbType.String),
                                new SQLiteParameter("@feedback_str", DbType.String),
                                new SQLiteParameter("@compare_str", DbType.String),
                                new SQLiteParameter("@rep_lock", DbType.Boolean),
                                new SQLiteParameter("@add_user", DbType.String,50),
                                new SQLiteParameter("@add_time", DbType.DateTime)};
                            parameters[0].Value = model.query_id;
                            parameters[1].Value = model.result_type;
                            parameters[2].Value = model.report_str;
                            parameters[3].Value = model.feedback_str;
                            parameters[4].Value = model.compare_str;
                            parameters[5].Value = model.rep_lock;
                            parameters[6].Value = model.add_user;
                            parameters[7].Value = model.add_time;
                        }
                        else//更新数据
                        {
                            strSql.Append("update compare_result set ");
                            strSql.Append("query_id=@query_id,");
                            strSql.Append("result_type=@result_type,");
                            strSql.Append("report_str=@report_str,");
                            strSql.Append("feedback_str=@feedback_str,");
                            strSql.Append("compare_str=@compare_str,");
                            strSql.Append("rep_lock=@rep_lock,");
                            strSql.Append("add_user=@add_user,");
                            strSql.Append("add_time=@add_time");
                            strSql.Append(" where id=@id");
                            parameters = new SQLiteParameter[]{
                                new SQLiteParameter("@query_id", DbType.Int32,8),
                                new SQLiteParameter("@result_type", DbType.String,16),
                                new SQLiteParameter("@report_str", DbType.String),
                                new SQLiteParameter("@feedback_str", DbType.String),
                                new SQLiteParameter("@compare_str", DbType.String),
                                new SQLiteParameter("@rep_lock", DbType.Boolean),
                                new SQLiteParameter("@add_user", DbType.String,50),
                                new SQLiteParameter("@add_time", DbType.DateTime),
                                new SQLiteParameter("@id", DbType.Int32,8)};
                            parameters[0].Value = model.query_id;
                            parameters[1].Value = model.result_type;
                            parameters[2].Value = model.report_str;
                            parameters[3].Value = model.feedback_str;
                            parameters[4].Value = model.compare_str;
                            parameters[5].Value = model.rep_lock;
                            parameters[6].Value = model.add_user;
                            parameters[7].Value = model.add_time;
                            parameters[8].Value = model.id;
                        }
                        cmd.CommandText = strSql.ToString();
                        cmd.CommandType = CommandType.Text;//cmdType;
                        foreach (SQLiteParameter parm in parameters)
                            cmd.Parameters.Add(parm);
                        obj = cmd.ExecuteScalar();

                        cmd.Parameters.Clear();
                    }
                    tx.Commit();
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    tx.Rollback();
                    //如果写入失败，则删除之前添加的Report数据
                    StringBuilder strSql = new StringBuilder();
                    string idlist = string.Join(",", repIds.ToArray());
                    strSql.Append("delete from business_report ");
                    strSql.Append(" where id in (" + idlist + ")  ");
                    using (cmd = new SQLiteCommand())
                    {
                        cmd.CommandText = strSql.ToString();
                        cmd.CommandType = CommandType.Text;//cmdType;
                        cmd.ExecuteScalar();
                    }
                    return E.Message;
                }

                //更新比对对象是否一致、是否匹配所有项目状态
                BLL.compare_result compare_result = new BLL.compare_result();
                List<string> compare_items = compare_result.GetCompareItems(query_id);
                string[] uncompare_items = Model.query_detail.compare_items;
                uncompare_items = uncompare_items.Except(compare_items).ToArray();
                BLL.query_detail query_Detail = new BLL.query_detail();
                Model.query_detail query_detail_model = query_Detail.GetModel(query_id);
                query_detail_model.uncompare_items = String.Join(",", uncompare_items);
                if (uncompare_items.Length == 0)
                {
                    query_detail_model.is_compare = true;
                }
                else
                {
                    query_detail_model.is_compare = false;
                }

                cmd.CommandText = String.Format("select count(id) from compare_result where query_id={0} and compare_str not like ('%基本一致%')", query_id);
                cmd.CommandType = CommandType.Text;//cmdType;
                obj = cmd.ExecuteScalar();
                if (Convert.ToInt32(obj) > 0)
                {
                    query_detail_model.is_match = false;
                }
                else
                {
                    query_detail_model.is_match = true;
                }
                cmd.CommandText = String.Format("update query_detail set is_compare={1},is_match={2}," +
                    "uncompare_items='{3}' where id={0}", query_id, query_detail_model.is_compare == true ? 1 : 0,
                    query_detail_model.is_match == true ? 1 : 0, query_detail_model.uncompare_items);
                cmd.CommandType = CommandType.Text;//cmdType;
                obj = cmd.ExecuteScalar();
            }
            return "写入成功！";
        }
    }
}
