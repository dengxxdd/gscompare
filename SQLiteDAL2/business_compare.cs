using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using DXD.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace DXD.SQLiteDAL
{
	/// <summary>
	/// 数据访问类:business_compare
	/// </summary>
	public partial class business_compare:Ibusiness_compare
	{
		public business_compare()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("id", "business_compare"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from business_compare");
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
		public int Add(DXD.Model.business_compare model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into business_compare(");
			strSql.Append("query_id,feedback_id,report_id,compare_type,less_capital,add_user,add_time)");
			strSql.Append(" values (");
			strSql.Append("@query_id,@feedback_id,@report_id,@compare_type,@less_capital,@add_user,@add_time)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@query_id", DbType.Int32,8),
					new SQLiteParameter("@feedback_id", DbType.Int32,8),
					new SQLiteParameter("@report_id", DbType.Int32,8),
					new SQLiteParameter("@compare_type", DbType.Int32,4),
					new SQLiteParameter("@less_capital", DbType.Decimal,4),
					new SQLiteParameter("@add_user", DbType.String,50),
					new SQLiteParameter("@add_time", DbType.DateTime)};
			parameters[0].Value = model.query_id;
			parameters[1].Value = model.feedback_id;
			parameters[2].Value = model.report_id;
			parameters[3].Value = model.compare_type;
			parameters[4].Value = model.less_capital;
			parameters[5].Value = model.add_user;
			parameters[6].Value = model.add_time;

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
		public bool Update(DXD.Model.business_compare model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update business_compare set ");
			strSql.Append("query_id=@query_id,");
			strSql.Append("feedback_id=@feedback_id,");
			strSql.Append("report_id=@report_id,");
			strSql.Append("compare_type=@compare_type,");
			strSql.Append("less_capital=@less_capital,");
			strSql.Append("add_user=@add_user,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@query_id", DbType.Int32,8),
					new SQLiteParameter("@feedback_id", DbType.Int32,8),
					new SQLiteParameter("@report_id", DbType.Int32,8),
					new SQLiteParameter("@compare_type", DbType.Int32,4),
					new SQLiteParameter("@less_capital", DbType.Decimal,4),
					new SQLiteParameter("@add_user", DbType.String,50),
					new SQLiteParameter("@add_time", DbType.DateTime),
					new SQLiteParameter("@id", DbType.Int32,8)};
			parameters[0].Value = model.query_id;
			parameters[1].Value = model.feedback_id;
			parameters[2].Value = model.report_id;
			parameters[3].Value = model.compare_type;
			parameters[4].Value = model.less_capital;
			parameters[5].Value = model.add_user;
			parameters[6].Value = model.add_time;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from business_compare ");
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
			strSql.Append("delete from business_compare ");
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
		public DXD.Model.business_compare GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,query_id,feedback_id,report_id,compare_type,less_capital,add_user,add_time from business_compare ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			DXD.Model.business_compare model=new DXD.Model.business_compare();
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
		public DXD.Model.business_compare DataRowToModel(DataRow row)
		{
			DXD.Model.business_compare model=new DXD.Model.business_compare();
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
				if(row["feedback_id"]!=null && row["feedback_id"].ToString()!="")
				{
					model.feedback_id=int.Parse(row["feedback_id"].ToString());
				}
				if(row["report_id"]!=null && row["report_id"].ToString()!="")
				{
					model.report_id=int.Parse(row["report_id"].ToString());
				}
				if(row["compare_type"]!=null && row["compare_type"].ToString()!="")
				{
					model.compare_type=int.Parse(row["compare_type"].ToString());
				}
				if(row["less_capital"]!=null && row["less_capital"].ToString()!="")
				{
					model.less_capital=decimal.Parse(row["less_capital"].ToString());
				}
				if(row["add_user"]!=null)
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
			strSql.Append("select id,query_id,feedback_id,report_id,compare_type,less_capital,add_user,add_time ");
			strSql.Append(" FROM business_compare ");
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
			strSql.Append("select count(1) FROM business_compare ");
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
			strSql.Append(")AS Row, T.*  from business_compare T ");
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
			parameters[0].Value = "business_compare";
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

