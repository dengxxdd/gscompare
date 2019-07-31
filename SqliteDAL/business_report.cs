using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using DXD.IDAL;
using DXD.DBUtility;//Please add references
namespace DXD.SQLiteDAL
{
	/// <summary>
	/// 数据访问类:business_report
	/// </summary>
	public partial class business_report:Ibusiness_report
	{
		public business_report()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("id", "business_report"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from business_report");
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
		public int Add(DXD.Model.business_report model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into business_report(");
			strSql.Append("query_id,bus_name,scope,reg_no,bus_type,reg_capital,subscribe,proportion,status,paid_in," +
                "found_date,lost_date,office,remark,is_match,is_import,add_user,add_time)");
			strSql.Append(" values (");
			strSql.Append("@query_id,@bus_name,@scope,@reg_no,@bus_type,@reg_capital,@subscribe,@proportion," +
                "@status,@paid_in,@found_date,@lost_date,@office,@remark,@is_match,@is_import,@add_user,@add_time)");
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
		public bool Update(DXD.Model.business_report model)
		{
			StringBuilder strSql=new StringBuilder();
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
			strSql.Append("delete from business_report ");
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
			strSql.Append("delete from business_report ");
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
		public DXD.Model.business_report GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,query_id,bus_name,scope,reg_no,bus_type,reg_capital,subscribe,proportion," +
                "status,paid_in,found_date,lost_date,office,remark,is_match,is_import,add_user,add_time " +
                "from business_report ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			DXD.Model.business_report model=new DXD.Model.business_report();
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
		public DXD.Model.business_report DataRowToModel(DataRow row)
		{
			DXD.Model.business_report model=new DXD.Model.business_report();
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
				if(row["bus_name"]!=null)
				{
					model.bus_name=row["bus_name"].ToString();
				}
				if(row["scope"]!=null)
				{
					model.scope=row["scope"].ToString();
				}
				if(row["reg_no"]!=null)
				{
					model.reg_no=row["reg_no"].ToString();
				}
				if(row["bus_type"]!=null)
				{
					model.bus_type=row["bus_type"].ToString();
				}
				if(row["reg_capital"]!=null && row["reg_capital"].ToString()!="")
				{
					model.reg_capital=decimal.Parse(row["reg_capital"].ToString());
				}
				if(row["subscribe"]!=null && row["subscribe"].ToString()!="")
				{
					model.subscribe=decimal.Parse(row["subscribe"].ToString());
				}
				if(row["proportion"]!=null && row["proportion"].ToString()!="")
				{
					model.proportion=decimal.Parse(row["proportion"].ToString());
				}
				if(row["status"]!=null)
				{
					model.status=row["status"].ToString();
				}
				if(row["paid_in"]!=null && row["paid_in"].ToString()!="")
				{
					model.paid_in=decimal.Parse(row["paid_in"].ToString());
				}
				if(row["found_date"]!=null && row["found_date"].ToString()!="")
				{
					model.found_date=DateTime.Parse(row["found_date"].ToString());
				}
				if(row["lost_date"]!=null && row["lost_date"].ToString()!="")
				{
					model.lost_date=DateTime.Parse(row["lost_date"].ToString());
				}
				if(row["office"]!=null)
				{
					model.office=row["office"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
                if (row["is_match"] != null && row["is_match"].ToString() != "")
                {
                    model.is_match = Boolean.Parse(row["is_match"].ToString());
                }
                if (row["is_import"] != null && row["is_import"].ToString() != "")
                {
                    model.is_import = Boolean.Parse(row["is_import"].ToString());
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
			strSql.Append("select id,query_id,full_name,bus_name,bus_type,subscribe,proportion," +
                "office,status,is_match,is_import,feedback_id ");
			strSql.Append(" FROM vGetBusinessReport ");
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
			strSql.Append("select count(1) FROM business_report ");
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
			strSql.Append(")AS Row, T.*  from business_report T ");
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
			parameters[0].Value = "business_report";
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

