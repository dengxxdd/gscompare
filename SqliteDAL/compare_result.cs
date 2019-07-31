using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SQLite;
using DXD.IDAL;
using DXD.DBUtility;//Please add references
namespace DXD.SQLiteDAL
{
	/// <summary>
	/// 数据访问类:compare_result
	/// </summary>
	public partial class compare_result:Icompare_result
	{
		public compare_result()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("id", "compare_result"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from compare_result");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DXD.Model.compare_result model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into compare_result(");
			strSql.Append("query_id,result_type,report_str,feedback_str,compare_str,rep_lock,add_user,add_time)");
			strSql.Append(" values (");
			strSql.Append("@query_id,@result_type,@report_str,@feedback_str,@compare_str,@rep_lock,@add_user,@add_time)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
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

			object obj = DbHelperSQLite.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(DXD.Model.compare_result model)
		{
			StringBuilder strSql=new StringBuilder();
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
			SQLiteParameter[] parameters = {
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

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from compare_result ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from compare_result ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
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
		public DXD.Model.compare_result GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,query_id,result_type,report_str,feedback_str,compare_str,rep_lock,add_user,add_time from compare_result ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			DXD.Model.compare_result model=new DXD.Model.compare_result();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public DXD.Model.compare_result DataRowToModel(DataRow row)
		{
			DXD.Model.compare_result model=new DXD.Model.compare_result();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["query_id"]!=null && row["query_id"].ToString()!="")
				{
					model.query_id=int.Parse(row["query_id"].ToString());
				}
				if(row["result_type"] !=null)
				{
					model.result_type = row["result_type"].ToString();
				}
				if(row["report_str"]!=null)
				{
					model.report_str=row["report_str"].ToString();
				}
				if(row["feedback_str"]!=null)
				{
					model.feedback_str=row["feedback_str"].ToString();
				}
				if(row["compare_str"]!=null)
				{
					model.compare_str=row["compare_str"].ToString();
				}
                if (row["rep_lock"] != null && row["rep_lock"].ToString() != "")
                {
                    model.rep_lock = Boolean.Parse(row["rep_lock"].ToString());
                }
                if (row["add_user"]!=null)
				{
					model.add_user=row["add_user"].ToString();
				}
				if(row["add_time"]!=null && row["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(row["add_time"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,query_id,result_type,report_str,feedback_str,compare_str,rep_lock,add_user,add_time ");
			strSql.Append(" FROM compare_result ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM compare_result ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from compare_result T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLite.Query(strSql.ToString());
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
			parameters[0].Value = "compare_result";
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
        public Model.compare_result GetModal(string strWhere)
        {
            DataSet ds = GetList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public List<string> GetCompareItems(int query_id) {
            List<string> compareItems = new List<string>();
            string strSql = string.Format("select result_type from compare_result where query_id={0}", query_id);
            DataSet ds= DbHelperSQLite.Query(strSql.ToString());
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                compareItems.Add(dr[0].ToString());
            }
            return compareItems;
        }



        #endregion  ExtensionMethod
    }
}

