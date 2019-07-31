using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace DXD.DTD
{
    public class Business:XlsTDbBase
    {
        public override string DbToFile(DTDParameter parameter)
        {
            throw new NotImplementedException();
        }
        public override string FileToDb(DTDParameter parameter)
        {
            DataTable dt = ConvertToDataTable(parameter.filename);

            //读取比对任务表，判断是否已经导入过数据
            BLL.query_list bll_list = new BLL.query_list();
            Model.query_list model_list = new Model.query_list();
            model_list = bll_list.GetModel(parameter.list_id);
            //model_list.feedback_security = true;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                SQLiteTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    object obj;
                    //如果原来已经导入过数据，则先把原来导入的数据删除。
                    if (model_list.feedback_business)
                    {
                        cmd.CommandText = "delete from business_feedback where query_id in (select id from query_detail where list_id=@list_id)";
                        SQLiteParameter para = new SQLiteParameter("@list_id", DbType.Int32, 4);
                        para.Value = parameter.list_id;
                        cmd.Parameters.Add(para);
                        cmd.CommandType = CommandType.Text;//cmdType;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    Hashtable hashtable = new Hashtable();
                    for (int i = 2; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        Model.business_feedback model = new Model.business_feedback();
                        string card_no = dr[1].ToString();
                        if (card_no == "")
                        {
                            break;  //身份证列为空则说明已导入了所有有效数据，退出循环
                        }
                        if (hashtable.Contains(card_no))
                        {
                            model.query_id = Convert.ToInt32(hashtable[card_no]);
                        }
                        else
                        {
                            //以身份证号为关键字查找同一批比对任务中的人员ID号，存储于hash表中
                            cmd.CommandText = "select id from query_detail where card_no='" + card_no + "' and list_id=" + parameter.list_id;
                            cmd.CommandType = CommandType.Text;//cmdType;
                            obj = cmd.ExecuteScalar();
                            if (obj == null)//如果没有在人员表中找到身份证号，说明人员不在任务列表中，继续循环
                            {
                                continue;
                            }
                            hashtable.Add(card_no, Convert.ToInt32(obj));
                            model.query_id = Convert.ToInt32(hashtable[card_no]);
                        }
                        model.bus_name = dr[4].ToString();
                        model.scope = dr[5].ToString();
                        model.reg_no = dr[6].ToString();
                        model.bus_type = dr[7].ToString();
                        model.reg_capital = Convert.ToDecimal(dr[8]);
                        model.subscribe = Convert.ToDecimal(dr[10]);
                        model.proportion = Convert.ToDecimal(dr[12]);
                        model.status = dr[13].ToString();
                        model.paid_in = Convert.ToDecimal(dr[14]);
                        model.found_date = DateTime.ParseExact(dr[15].ToString(), "yyyy-MM-dd", null);
                        if(dr[16].ToString()!="")
                        {
                            model.lost_date= DateTime.ParseExact(dr[16].ToString(), "yyyy-MM-dd", null);
                        }
                        model.office = dr[17].ToString();
                        model.remark = dr[18].ToString();
                        model.add_user = "admin";
                        model.add_time = DateTime.Now;
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into business_feedback(");
                        strSql.Append("query_id,bus_name,scope,reg_no,bus_type,reg_capital,subscribe,proportion,status,paid_in," +
                            "found_date,lost_date,office,remark,is_hidden,is_match,add_user,add_time)");
                        strSql.Append(" values (");
                        strSql.Append("@query_id,@bus_name,@scope,@reg_no,@bus_type,@reg_capital,@subscribe,@proportion,@status," +
                            "@paid_in,@found_date,@lost_date,@office,@remark,@is_hidden,@is_match,@add_user,@add_time)");
                        strSql.Append(";select LAST_INSERT_ROWID()");
                        SQLiteParameter[] parameters = {
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
                            new SQLiteParameter("@is_hidden", DbType.Boolean),
                            new SQLiteParameter("@is_match", DbType.Boolean),
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
                        parameters[14].Value = model.is_hidden;
                        parameters[15].Value = model.is_match;
                        parameters[16].Value = model.add_user;
                        parameters[17].Value = model.add_time;

                        try
                        {
                            cmd.CommandText = strSql.ToString();
                            cmd.CommandType = CommandType.Text;//cmdType;
                            foreach (SQLiteParameter parm in parameters)
                                cmd.Parameters.Add(parm);
                            obj = cmd.ExecuteScalar();
                            cmd.Parameters.Clear();
                        }
                        catch (System.Data.SQLite.SQLiteException e)
                        {
                            throw new Exception(e.Message);
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    tx.Rollback();
                    return E.Message;
                }
            }
            model_list.feedback_business = true;
            bll_list.Update(model_list);
            return "导入成功！";
        }
    }
}
