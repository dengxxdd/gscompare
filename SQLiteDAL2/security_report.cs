using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using DXD.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace DXD.SQLiteDAL
{
	/// <summary>
	/// 数据访问类:security_report
	/// </summary>
	public partial class security_report:Isecurity_report
	{
		public security_report()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("id", "security_report"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from security_report");
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
		public int Add(DXD.Model.security_report model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into security_report(");
			strSql.Append("query_id,query_date,sec_type,sec_account,sec_code,sec_name,sec_number,sec_value,add_user,add_time)");
			strSql.Append(" values (");
			strSql.Append("@query_id,@query_date,@sec_type,@sec_account,@sec_code,@sec_name,@sec_number,@sec_value,@add_user,@add_time)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@query_id", DbType.Int32,8),
					new SQLiteParameter("@query_date", DbType.DateTime),
					new SQLiteParameter("@sec_type", DbType.char,2),
					new SQLiteParameter("@sec_account", DbType.String,50),
					new SQLiteParameter("@sec_code", DbType.char,10),
					new SQLiteParameter("@sec_name", DbType.String,50),
					new SQLiteParameter("@sec_number", DbType.Decimal,4),
					new SQLiteParameter("@sec_value", DbType.Decimal,4),
					new SQLiteParameter("@add_user", DbType.String,50),
					new SQLiteParameter("@add_time", DbType.DateTime)};
			parameters[0].Value = model.query_id;
			parameters[1].Value = model.query_date;
			parameters[2].Value = model.sec_type;
			parameters[3].Value = model.sec_account;
			parameters[4].Value = model.sec_code;
			parameters[5].Value = model.sec_name;
			parameters[6].Value = model.sec_number;
			parameters[7].Value = model.sec_value;
			parameters[8].Value = model.add_user;
			parameters[9].Value = model.add_time;

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
		public bool Update(DXD.Model.security_report model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update security_report set ");
			strSql.Append("query_id=@query_id,");
			strSql.Append("query_date=@query_date,");
			strSql.Append("sec_type=@sec_type,");
			strSql.Append("sec_account=@sec_account,");
			strSql.Append("sec_code=@sec_code,");
			strSql.Append("sec_name=@sec_name,");
			strSql.Append("sec_number=@sec_number,");
			strSql.Append("sec_value=@sec_value,");
			strSql.Append("add_user=@add_user,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@query_id", DbType.Int32,8),
					new SQLiteParameter("@query_date", DbType.DateTime),
					new SQLiteParameter("@sec_type", DbType.char,2),
					new SQLiteParameter("@sec_account", DbType.String,50),
					new SQLiteParameter("@sec_code", DbType.char,10),
					new SQLiteParameter("@sec_name", DbType.String,50),
					new SQLiteParameter("@sec_number", DbType.Decimal,4),
					new SQLiteParameter("@sec_value", DbType.Decimal,4),
					new SQLiteParameter("@add_user", DbType.String,50),
					new SQLiteParameter("@add_time", DbType.DateTime),
					new SQLiteParameter("@id", DbType.Int32,8)};
			parameters[0].Value = model.query_id;
			parameters[1].Value = model.query_date;
			parameters[2].Value = model.sec_type;
			parameters[3].Value = model.sec_account;
			parameters[4].Value = model.sec_code;
			parameters[5].Value = model.sec_name;
			parameters[6].Value = model.sec_number;
			parameters[7].Value = model.sec_value;
			parameters[8].Value = model.add_user;
			parameters[9].Value = model.add_time;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from security_report ");
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
			strSql.Append("delete from security_report ");
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
		public DXD.Model.security_report GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,query_id,query_date,sec_type,sec_account,sec_code,sec_name,sec_number,sec_value,add_user,add_time from security_report ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			DXD.Model.security_report model=new DXD.Model.security_report();
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
		public DXD.Model.security_report DataRowToModel(DataRow row)
		{
			DXD.Model.security_report model=new DXD.Model.security_report();
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
				if(row["query_date"]!=null && row["query_date"].ToString()!="")
				{
					model.query_date=DateTime.Parse(row["query_date"].ToString());
				}
				if(row["sec_type"]!=null)
				{
					model.sec_type=row["sec_type"].ToString();
				}
				if(row["sec_account"]!=null)
				{
					model.sec_account=row["sec_account"].ToString();
				}
				if(row["sec_code"]!=null)
				{
					model.sec_code=row["sec_code"].ToString();
				}
				if(row["sec_name"]!=null)
				{
					model.sec_name=row["sec_name"].ToString();
				}
				if(row["sec_number"]!=null && row["sec_number"].ToString()!="")
				{
					model.sec_number=decimal.Parse(row["sec_number"].ToString());
				}
				if(row["sec_value"]!=null && row["sec_value"].ToString()!="")
				{
					model.sec_value=decimal.Parse(row["sec_value"].ToString());
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
			strSql.Append("select id,query_id,query_date,sec_type,sec_account,sec_code,sec_name,sec_number,sec_value,add_user,add_time ");
			strSql.Append(" FROM security_report ");
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
			strSql.Append("select count(1) FROM security_report ");
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
			strSql.Append(")AS Row, T.*  from security_report T ");
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
			parameters[0].Value = "security_report";
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

