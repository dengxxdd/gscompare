﻿using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using DXD.IDAL;
using DXD.DBUtility;//Please add references
using DXD.Model;

namespace DXD.SQLiteDAL {
    public class country_list:Icountry_list {
        public country_list() { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            return DbHelperSQLite.GetMaxID("id", "country_list");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from country_list");
            strSql.Append(" where id=@id");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@id", DbType.Int32,4)
            };
            parameters[0].Value = id;

            return DbHelperSQLite.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DXD.Model.country_list model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into country_list(");
            strSql.Append("country_name,order_no,add_user,add_time)");
            strSql.Append(" values (");
            strSql.Append("@country_name,@order_no,@add_user,@add_time)");
            strSql.Append(";select LAST_INSERT_ROWID()");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@country_name", DbType.String,50),
                    new SQLiteParameter("@order_no",DbType.Int32,8),
                    new SQLiteParameter("@add_user", DbType.String,50),
                    new SQLiteParameter("@add_time", DbType.DateTime)};
            parameters[0].Value = model.country_name;
            parameters[1].Value = model.order_no;
            parameters[2].Value = model.add_user;
            parameters[3].Value = model.add_time;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DXD.Model.country_list model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update country_list set ");
            strSql.Append("country_name=@country_name,");
            strSql.Append("order_no=@order_no,");
            strSql.Append("add_user=@add_user,");
            strSql.Append("add_time=@add_time");
            strSql.Append(" where id=@id");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@country_name", DbType.String,50),
                    new SQLiteParameter("@order_no",DbType.Int32,8),
                    new SQLiteParameter("@add_user", DbType.String,50),
                    new SQLiteParameter("@add_time", DbType.DateTime),
                    new SQLiteParameter("@id", DbType.Int32,8)};
            parameters[0].Value = model.country_name;
            parameters[1].Value = model.order_no;
            parameters[2].Value = model.add_user;
            parameters[3].Value = model.add_time;
            parameters[4].Value = model.id;

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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from country_list ");
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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from country_list ");
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DXD.Model.country_list GetModel(int id) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,country_name,order_no,add_user,add_time from country_list ");
            strSql.Append(" where id=@id");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@id", DbType.Int32,4)
            };
            parameters[0].Value = id;

            DXD.Model.country_list model = new DXD.Model.country_list();
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DXD.Model.country_list DataRowToModel(DataRow row) {
            DXD.Model.country_list model = new DXD.Model.country_list();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["country_name"] != null)
                {
                    model.country_name = row["country_name"].ToString();
                }
                if (row["order_no"] != null && row["order_no"].ToString() != "")
                {
                    model.order_no = int.Parse(row["order_no"].ToString());
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,country_name,order_no,add_user,add_time ");
            strSql.Append(" FROM country_list ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by order_no desc");
            return DbHelperSQLite.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM country_list ");
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
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex) {
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
            strSql.Append(")AS Row, T.*  from country_list T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public Model.country_list GetModel(string country_name) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,country_name,order_no,add_user,add_time from country_list ");
            strSql.Append(" where country_name=@country_name");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@country_name", DbType.String,50)
            };
            parameters[0].Value = country_name;

            DXD.Model.country_list model = new DXD.Model.country_list();
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

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "country_list";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
