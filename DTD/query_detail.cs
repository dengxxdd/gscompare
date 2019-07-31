using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using DXD.Model;
using DXD.BLL;
using System.Data;
using System.Data.SQLite;

namespace DXD.DTD
{
    public class query_detail:XlsTDbBase
    {
        private readonly string tablename = "query_detail";
        public override string FileToDb(DTDParameter parameter)
        {
            DataTable dt = ConvertToDataTable(parameter.filename);
            int parentId =0;

            BLL.query_list bll_list = new BLL.query_list();
            Model.query_list model_list = new Model.query_list();
            model_list = bll_list.GetModel(parameter.list_id);
            if(model_list.is_import)
            {
                return "不能重复导入对象表！";
            }
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
                    //如果原来已经导入过数据，则先把原来导入的数据删除。人员对象表与反馈数据有一对多关联，删除会导致数据关联出错。
                    //if (model_list.feedback_security)
                    //{
                    //    cmd.CommandText = "delete from query_detail where list_id=@list_id";
                    //    SQLiteParameter para = new SQLiteParameter("@list_id", DbType.Int32, 4);
                    //    para.Value = parameter.list_id;
                    //    cmd.Parameters.Add(para);
                    //    cmd.CommandType = CommandType.Text;//cmdType;
                    //    cmd.ExecuteNonQuery();
                    //    cmd.Parameters.Clear();
                    //}

                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        Model.query_detail model = new Model.query_detail();
                        model.full_name = dr[0].ToString();
                        model.sex = dr[1].ToString();
                        model.card_no = dr[2].ToString();
                        cmd.CommandText = "select code_id from vGetCodeList where code_name='" + dr[3].ToString() + "'";
                        cmd.CommandType = CommandType.Text;//cmdType;
                        obj = cmd.ExecuteScalar();
                        if(obj!=null)
                        {
                            model.appellation = obj.ToString();
                        }
                        else
                        {
                            return model.full_name + "称谓信息不完整";
                        }                        
                        if (dr.IsNull(4) || dr[4].ToString() == "否")
                        {
                            model.is_together = false;
                        }
                        else
                        {
                            model.is_together = true;
                        }
                        if(model.appellation=="301" || model.appellation=="302")
                        {
                            model.is_together = true;
                        }

                        model.parent_id = parentId;
                        model.list_id = parameter.list_id;
                        model.add_user = "admin";
                        model.add_time = DateTime.Now;

                        //查找对应任务表中是否已经有记录，如果有则更新，没有则添加
                        cmd.CommandText = "select id from query_detail where card_no=@card_no and list_id=@list_id";
                        SQLiteParameter[] paras ={
                            new SQLiteParameter("@card_no", DbType.String,18),
                            new SQLiteParameter("@list_id", DbType.Int32,8)
                        };
                        paras[0].Value = model.card_no;
                        paras[1].Value = model.list_id;
                        foreach (SQLiteParameter parm in paras)
                            cmd.Parameters.Add(parm);
                        cmd.CommandType = CommandType.Text;//cmdType;
                        obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if (obj != null)
                        {
                            StringBuilder strSql = new StringBuilder();
                            strSql.Append("update query_detail set ");
                            strSql.Append("list_id=@list_id,");
                            strSql.Append("full_name=@full_name,");
                            strSql.Append("sex=@sex,");
                            strSql.Append("card_no=@card_no,");
                            strSql.Append("parent_id=@parent_id,");                            
                            strSql.Append("appellation=@appellation,");
                            strSql.Append("is_together=@is_together,");
                            strSql.Append("add_user=@add_user,");
                            strSql.Append("add_time=@add_time");
                            strSql.Append(" where id=@id");
                            SQLiteParameter[] parameters = {
                                new SQLiteParameter("@list_id", DbType.Int32,8),
                                new SQLiteParameter("@full_name", DbType.String,50),
                                new SQLiteParameter("@sex", DbType.String,2),
                                new SQLiteParameter("@card_no", DbType.String,18),
                                new SQLiteParameter("@parent_id", DbType.Int32,8),
                                new SQLiteParameter("@appellation", DbType.String,4),
                                new SQLiteParameter("@is_together", DbType.Boolean),
                                new SQLiteParameter("@add_user", DbType.String,50),
                                new SQLiteParameter("@add_time", DbType.DateTime),
                                new SQLiteParameter("@id", DbType.Int32,8)};
                            parameters[0].Value = model.list_id;
                            parameters[1].Value = model.full_name;
                            parameters[2].Value = model.sex;
                            parameters[3].Value = model.card_no;
                            parameters[4].Value = model.parent_id;
                            parameters[5].Value = model.appellation;
                            parameters[6].Value = model.is_together;
                            parameters[7].Value = model.add_user;
                            parameters[8].Value = model.add_time;
                            parameters[9].Value = model.id;

                            try
                            {
                                cmd.CommandText = strSql.ToString();
                                cmd.CommandType = CommandType.Text;//cmdType;
                                foreach (SQLiteParameter parm in parameters)
                                    cmd.Parameters.Add(parm);
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                            catch (System.Data.SQLite.SQLiteException e)
                            {
                                throw new Exception(e.Message);
                            }
                        }
                        else
                        {
                            StringBuilder strSql = new StringBuilder();
                            strSql.Append("insert into query_detail(");
                            strSql.Append("list_id,full_name,sex,card_no,work_unit,post,pol_status,parent_id,appellation,is_together,is_compare,is_match," +
                                "uncompare_items,add_user,add_time)");
                            strSql.Append(" values (");
                            strSql.Append("@list_id,@full_name,@sex,@card_no,@work_unit,@post,@pol_status,@parent_id,@appellation,@is_together,@is_compare,@is_match,@uncompare_items," +
                                "@add_user,@add_time)");
                            strSql.Append(";select LAST_INSERT_ROWID()");
                            SQLiteParameter[] parameters = {
                                new SQLiteParameter("@list_id", DbType.Int32,8),
                                new SQLiteParameter("@full_name", DbType.String,50),
                                new SQLiteParameter("@sex", DbType.String,2),
                                new SQLiteParameter("@card_no", DbType.String,18),
                                new SQLiteParameter("@work_unit", DbType.String,255),
                                new SQLiteParameter("@post", DbType.String,50),
                                new SQLiteParameter("@pol_status", DbType.String,50),
                                new SQLiteParameter("@parent_id", DbType.Int32,8),
                                new SQLiteParameter("@appellation", DbType.String,4),
                                new SQLiteParameter("@is_together", DbType.Boolean),
                                new SQLiteParameter("@is_compare", DbType.Boolean),
                                new SQLiteParameter("@is_match", DbType.Boolean),
                                new SQLiteParameter("@uncompare_items", DbType.String,100),
                                new SQLiteParameter("@add_user", DbType.String,50),
                                new SQLiteParameter("@add_time", DbType.DateTime)};
                            parameters[0].Value = model.list_id;
                            parameters[1].Value = model.full_name;
                            parameters[2].Value = model.sex;
                            parameters[3].Value = model.card_no;
                            parameters[4].Value = model.work_unit;
                            parameters[5].Value = model.post;
                            parameters[6].Value = model.pol_status;
                            parameters[7].Value = model.parent_id;
                            parameters[8].Value = model.appellation;
                            parameters[9].Value = model.is_together;
                            parameters[10].Value = model.is_compare;
                            parameters[11].Value = model.is_match;
                            parameters[12].Value = model.uncompare_items;
                            parameters[13].Value = model.add_user;
                            parameters[14].Value = model.add_time;
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
                            //如果是本人，则在插入数据后立即将parentId设置为当前插入数据库的信息的id，后面记录只要不出现
                            //称谓为本人的情况，则其他称谓的记录的parentId都会是该parentId。
                            if (parentId == 0)
                            {
                                parentId = Convert.ToInt32(obj);
                            }
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

            //导入成功后，任务表里的是否导入选项更新为true            
            model_list.is_import = true;
            bll_list.Update(model_list);
            return "导入成功！";
        }
        
        public override string DbToFile(DTDParameter parameter)
        {
            return "";
        }
    }
}
