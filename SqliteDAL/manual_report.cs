using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using DXD.IDAL;
using DXD.DBUtility;//Please add references
using DXD.Model;
using System.Data;

namespace DXD.SQLiteDAL
{
    public partial class manual_report : Imanual_report
    {
        public int Add(Model.manual_report model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into manual_report(");
            strSql.Append("query_id,rep_type,appellation,rep_str,add_user,add_time)");
            strSql.Append(" values (");
            strSql.Append("@query_id,@rep_type,@appellation,@rep_str,@add_user,@add_time)");
            strSql.Append(";select LAST_INSERT_ROWID()");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@query_id", DbType.Int32,8),
                    new SQLiteParameter("@rep_type", DbType.String,8),
                    new SQLiteParameter("@appellation", DbType.String,8),
                    new SQLiteParameter("@rep_str", DbType.String,255),
                    new SQLiteParameter("@add_user", DbType.String,50),
                    new SQLiteParameter("@add_time", DbType.DateTime)};
            parameters[0].Value = model.query_id;
            parameters[1].Value = model.rep_type;
            parameters[2].Value = model.appellation;
            parameters[3].Value = model.rep_str;
            parameters[4].Value = model.add_user;
            parameters[5].Value = model.add_time;

            object obj = DbHelperSQLite.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public Model.manual_report DataRowToModel(DataRow row)
        {
            DXD.Model.manual_report model = new DXD.Model.manual_report();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["query_id"] != null && row["query_id"].ToString() != "")
                {
                    model.query_id = int.Parse(row["query_id"].ToString());
                }
                if (row["rep_type"] != null)
                {
                    model.rep_type = row["rep_type"].ToString();
                }
                if (row["appellation"] != null)
                {
                    model.appellation = row["appellation"].ToString();
                }
                if (row["rep_str"] != null)
                {
                    model.rep_str = row["rep_str"].ToString();
                }                
                if (row["add_user"] != null)
                {
                    model.add_user = row["add_user"].ToString();
                }
                if (row["add_time"] != null && row["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(row["add_time"].ToString());
                }
            }
            return model;
        }

        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from manual_report ");
            strSql.Append(" where id=@id");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@id", DbType.Int32,4)
            };
            parameters[0].Value = id;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from manual_report ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from manual_report");
            strSql.Append(" where id=@id");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@id", DbType.Int32,4)
            };
            parameters[0].Value = id;

            return DbHelperSQLite.Exists(strSql.ToString(), parameters);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,query_id,rep_type,appellation,rep_str,add_user,add_time  ");
            strSql.Append(" from manual_report");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from manual_report T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperSQLite.GetMaxID("id", "manual_report");
        }

        public Model.manual_report GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,query_id,rep_type,appellation,rep_str,add_user,add_time from manual_report ");
            strSql.Append(" where id=@id");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@id", DbType.Int32,4)
            };
            parameters[0].Value = id;

            //DXD.Model.house_report model = new DXD.Model.house_report();
            DataSet ds = DbHelperSQLite.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM manual_report ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public bool Update(Model.manual_report model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update manual_report set ");
            strSql.Append("query_id=@query_id,");
            strSql.Append("rep_type=@rep_type,");
            strSql.Append("appellation=@appellation,");
            strSql.Append("rep_str=@rep_str,");
            strSql.Append("add_user=@add_user,");
            strSql.Append("add_time=@add_time");
            strSql.Append(" where id=@id");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@query_id", DbType.Int32,8),
                    new SQLiteParameter("@rep_type", DbType.String,8),
                    new SQLiteParameter("@appellation", DbType.String,8),
                    new SQLiteParameter("@rep_str", DbType.String,255),
                    new SQLiteParameter("@add_user", DbType.String,50),
                    new SQLiteParameter("@add_time", DbType.DateTime),
                    new SQLiteParameter("@id", DbType.Int32,8)};
            parameters[0].Value = model.query_id;
            parameters[1].Value = model.rep_type;
            parameters[2].Value = model.appellation;
            parameters[3].Value = model.rep_str;
            parameters[4].Value = model.add_user;
            parameters[5].Value = model.add_time;
            parameters[6].Value = model.id;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
