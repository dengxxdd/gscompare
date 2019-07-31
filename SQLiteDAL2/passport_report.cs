using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using DXD.IDAL;
using Maticsoft.DBUtility;//Please add references
namespace DXD.SQLiteDAL
{
	/// <summary>
	/// 数据访问类:passport_report
	/// </summary>
	public partial class passport_report:Ipassport_report
	{
		public passport_report()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("id", "passport_report"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from passport_report");
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
		public int Add(DXD.Model.passport_report model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into passport_report(");
			strSql.Append("query_id,passpport_no,passport_type,approva_auth,issuing_date,valid_date,add_user,add_time)");
			strSql.Append(" values (");
			strSql.Append("@query_id,@passpport_no,@passport_type,@approva_auth,@issuing_date,@valid_date,@add_user,@add_time)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@query_id", DbType.Int32,8),
					new SQLiteParameter("@passpport_no", DbType.char,20),
					new SQLiteParameter("@passport_type", DbType.String,200),
					new SQLiteParameter("@approva_auth", DbType.String,255),
					new SQLiteParameter("@issuing_date", DbType.DateTime),
					new SQLiteParameter("@valid_date", DbType.DateTime),
					new SQLiteParameter("@add_user", DbType.String,50),
					new SQLiteParameter("@add_time", DbType.DateTime)};
			parameters[0].Value = model.query_id;
			parameters[1].Value = model.passpport_no;
			parameters[2].Value = model.passport_type;
			parameters[3].Value = model.approva_auth;
			parameters[4].Value = model.issuing_date;
			parameters[5].Value = model.valid_date;
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
		public bool Update(DXD.Model.passport_report model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update passport_report set ");
			strSql.Append("query_id=@query_id,");
			strSql.Append("passpport_no=@passpport_no,");
			strSql.Append("passport_type=@passport_type,");
			strSql.Append("approva_auth=@approva_auth,");
			strSql.Append("issuing_date=@issuing_date,");
			strSql.Append("valid_date=@valid_date,");
			strSql.Append("add_user=@add_user,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@query_id", DbType.Int32,8),
					new SQLiteParameter("@passpport_no", DbType.char,20),
					new SQLiteParameter("@passport_type", DbType.String,200),
					new SQLiteParameter("@approva_auth", DbType.String,255),
					new SQLiteParameter("@issuing_date", DbType.DateTime),
					new SQLiteParameter("@valid_date", DbType.DateTime),
					new SQLiteParameter("@add_user", DbType.String,50),
					new SQLiteParameter("@add_time", DbType.DateTime),
					new SQLiteParameter("@id", DbType.Int32,8)};
			parameters[0].Value = model.query_id;
			parameters[1].Value = model.passpport_no;
			parameters[2].Value = model.passport_type;
			parameters[3].Value = model.approva_auth;
			parameters[4].Value = model.issuing_date;
			parameters[5].Value = model.valid_date;
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
			strSql.Append("delete from passport_report ");
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
			strSql.Append("delete from passport_report ");
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
		public DXD.Model.passport_report GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,query_id,passpport_no,passport_type,approva_auth,issuing_date,valid_date,add_user,add_time from passport_report ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			DXD.Model.passport_report model=new DXD.Model.passport_report();
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
		public DXD.Model.passport_report DataRowToModel(DataRow row)
		{
			DXD.Model.passport_report model=new DXD.Model.passport_report();
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
				if(row["passpport_no"]!=null)
				{
					model.passpport_no=row["passpport_no"].ToString();
				}
				if(row["passport_type"]!=null)
				{
					model.passport_type=row["passport_type"].ToString();
				}
				if(row["approva_auth"]!=null)
				{
					model.approva_auth=row["approva_auth"].ToString();
				}
				if(row["issuing_date"]!=null && row["issuing_date"].ToString()!="")
				{
					model.issuing_date=DateTime.Parse(row["issuing_date"].ToString());
				}
				if(row["valid_date"]!=null && row["valid_date"].ToString()!="")
				{
					model.valid_date=DateTime.Parse(row["valid_date"].ToString());
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
			strSql.Append("select id,query_id,passpport_no,passport_type,approva_auth,issuing_date,valid_date,add_user,add_time ");
			strSql.Append(" FROM passport_report ");
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
			strSql.Append("select count(1) FROM passport_report ");
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
			strSql.Append(")AS Row, T.*  from passport_report T ");
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
			parameters[0].Value = "passport_report";
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

