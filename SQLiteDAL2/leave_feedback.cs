using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using DXD.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace DXD.SQLiteDAL
{
	/// <summary>
	/// 数据访问类:leave_feedback
	/// </summary>
	public partial class leave_feedback:Ileave_feedback
	{
		public leave_feedback()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("id", "leave_feedback"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from leave_feedback");
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
		public int Add(DXD.Model.leave_feedback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into leave_feedback(");
			strSql.Append("query_id,passport_id,passport_type,inout_type,visa_type,inout_date,port_name,destination,leave_reason,add_user,add_time)");
			strSql.Append(" values (");
			strSql.Append("@query_id,@passport_id,@passport_type,@inout_type,@visa_type,@inout_date,@port_name,@destination,@leave_reason,@add_user,@add_time)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@query_id", DbType.Int32,8),
					new SQLiteParameter("@passport_id", DbType.Int32,8),
					new SQLiteParameter("@passport_type", DbType.Int32,4),
					new SQLiteParameter("@inout_type", DbType.Int32,4),
					new SQLiteParameter("@visa_type", DbType.Int32,4),
					new SQLiteParameter("@inout_date", DbType.DateTime),
					new SQLiteParameter("@port_name", DbType.String,200),
					new SQLiteParameter("@destination", DbType.String,200),
					new SQLiteParameter("@leave_reason", DbType.String,200),
					new SQLiteParameter("@add_user", DbType.String,50),
					new SQLiteParameter("@add_time", DbType.DateTime)};
			parameters[0].Value = model.query_id;
			parameters[1].Value = model.passport_id;
			parameters[2].Value = model.passport_type;
			parameters[3].Value = model.inout_type;
			parameters[4].Value = model.visa_type;
			parameters[5].Value = model.inout_date;
			parameters[6].Value = model.port_name;
			parameters[7].Value = model.destination;
			parameters[8].Value = model.leave_reason;
			parameters[9].Value = model.add_user;
			parameters[10].Value = model.add_time;

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
		public bool Update(DXD.Model.leave_feedback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update leave_feedback set ");
			strSql.Append("query_id=@query_id,");
			strSql.Append("passport_id=@passport_id,");
			strSql.Append("passport_type=@passport_type,");
			strSql.Append("inout_type=@inout_type,");
			strSql.Append("visa_type=@visa_type,");
			strSql.Append("inout_date=@inout_date,");
			strSql.Append("port_name=@port_name,");
			strSql.Append("destination=@destination,");
			strSql.Append("leave_reason=@leave_reason,");
			strSql.Append("add_user=@add_user,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@query_id", DbType.Int32,8),
					new SQLiteParameter("@passport_id", DbType.Int32,8),
					new SQLiteParameter("@passport_type", DbType.Int32,4),
					new SQLiteParameter("@inout_type", DbType.Int32,4),
					new SQLiteParameter("@visa_type", DbType.Int32,4),
					new SQLiteParameter("@inout_date", DbType.DateTime),
					new SQLiteParameter("@port_name", DbType.String,200),
					new SQLiteParameter("@destination", DbType.String,200),
					new SQLiteParameter("@leave_reason", DbType.String,200),
					new SQLiteParameter("@add_user", DbType.String,50),
					new SQLiteParameter("@add_time", DbType.DateTime),
					new SQLiteParameter("@id", DbType.Int32,8)};
			parameters[0].Value = model.query_id;
			parameters[1].Value = model.passport_id;
			parameters[2].Value = model.passport_type;
			parameters[3].Value = model.inout_type;
			parameters[4].Value = model.visa_type;
			parameters[5].Value = model.inout_date;
			parameters[6].Value = model.port_name;
			parameters[7].Value = model.destination;
			parameters[8].Value = model.leave_reason;
			parameters[9].Value = model.add_user;
			parameters[10].Value = model.add_time;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from leave_feedback ");
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
			strSql.Append("delete from leave_feedback ");
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
		public DXD.Model.leave_feedback GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,query_id,passport_id,passport_type,inout_type,visa_type,inout_date,port_name,destination,leave_reason,add_user,add_time from leave_feedback ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			DXD.Model.leave_feedback model=new DXD.Model.leave_feedback();
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
		public DXD.Model.leave_feedback DataRowToModel(DataRow row)
		{
			DXD.Model.leave_feedback model=new DXD.Model.leave_feedback();
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
				if(row["passport_id"]!=null && row["passport_id"].ToString()!="")
				{
					model.passport_id=int.Parse(row["passport_id"].ToString());
				}
				if(row["passport_type"]!=null && row["passport_type"].ToString()!="")
				{
					model.passport_type=int.Parse(row["passport_type"].ToString());
				}
				if(row["inout_type"]!=null && row["inout_type"].ToString()!="")
				{
					model.inout_type=int.Parse(row["inout_type"].ToString());
				}
				if(row["visa_type"]!=null && row["visa_type"].ToString()!="")
				{
					model.visa_type=int.Parse(row["visa_type"].ToString());
				}
				if(row["inout_date"]!=null && row["inout_date"].ToString()!="")
				{
					model.inout_date=DateTime.Parse(row["inout_date"].ToString());
				}
				if(row["port_name"]!=null)
				{
					model.port_name=row["port_name"].ToString();
				}
				if(row["destination"]!=null)
				{
					model.destination=row["destination"].ToString();
				}
				if(row["leave_reason"]!=null)
				{
					model.leave_reason=row["leave_reason"].ToString();
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
			strSql.Append("select id,query_id,passport_id,passport_type,inout_type,visa_type,inout_date,port_name,destination,leave_reason,add_user,add_time ");
			strSql.Append(" FROM leave_feedback ");
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
			strSql.Append("select count(1) FROM leave_feedback ");
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
			strSql.Append(")AS Row, T.*  from leave_feedback T ");
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
			parameters[0].Value = "leave_feedback";
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

