using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using DXD.IDAL;
using DXD.DBUtility;//Please add references
namespace DXD.SQLiteDAL
{
	/// <summary>
	/// 数据访问类:query_list
	/// </summary>
	public partial class query_list : Iquery_list
	{
		public query_list()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		    return DbHelperSQLite.GetMaxID("id", "query_list"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from query_list");
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
		public int Add(DXD.Model.query_list model)
		{
            //feedback_passport,feedback_leave,feedback_house1,feedback_house2,feedback_security,feedback_insurance,feedback_business;
            StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into query_list(");
            strSql.Append("query_title,batch,client,query_type,entrust_date,is_import,feedback_passport,");
            strSql.Append("feedback_leave,feedback_house1,feedback_house2,feedback_security,feedback_insurance,feedback_business,add_user,add_time)");
			strSql.Append(" values (");
            strSql.Append("@query_title,@batch,@client,@query_type,@entrust_date,@is_import,@feedback_passport,@feedback_leave,");
            strSql.Append("@feedback_house1,@feedback_house2,@feedback_security,@feedback_insurance,@feedback_business,@add_user,@add_time)");
			strSql.Append(";select LAST_INSERT_ROWID()");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@query_title", DbType.String,255),
					new SQLiteParameter("@batch", DbType.String,50),
					new SQLiteParameter("@client", DbType.String,200),
                    new SQLiteParameter("@query_type", DbType.String,4),
                    new SQLiteParameter("@entrust_date", DbType.DateTime),
                    new SQLiteParameter("@is_import", DbType.Boolean),
                    new SQLiteParameter("@feedback_passport", DbType.Boolean),
                    new SQLiteParameter("@feedback_leave", DbType.Boolean),
                    new SQLiteParameter("@feedback_house1", DbType.Boolean),
                    new SQLiteParameter("@feedback_house2", DbType.Boolean),
                    new SQLiteParameter("@feedback_security", DbType.Boolean),
                    new SQLiteParameter("@feedback_insurance", DbType.Boolean),
                    new SQLiteParameter("@feedback_business", DbType.Boolean),
                    new SQLiteParameter("@add_user", DbType.String,50),
					new SQLiteParameter("@add_time", DbType.DateTime)};
			parameters[0].Value = model.query_title;
			parameters[1].Value = model.batch;
			parameters[2].Value = model.client;
            parameters[3].Value = model.query_type;
			parameters[4].Value = model.entrust_date;
            parameters[5].Value = model.is_import;
            parameters[6].Value = model.feedback_passport;
            parameters[7].Value = model.feedback_leave;
            parameters[8].Value = model.feedback_house1;
            parameters[9].Value = model.feedback_house2;
            parameters[10].Value = model.feedback_security;
            parameters[11].Value = model.feedback_insurance;
            parameters[12].Value = model.feedback_business;
			parameters[13].Value = model.add_user;
			parameters[14].Value = model.add_time;

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
		public bool Update(DXD.Model.query_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update query_list set ");
			strSql.Append("query_title=@query_title,");
			strSql.Append("batch=@batch,");
			strSql.Append("client=@client,");
            strSql.Append("query_type=@query_type,");
            strSql.Append("entrust_date=@entrust_date,");
            strSql.Append("is_import=@is_import,");
            strSql.Append("feedback_passport=@feedback_passport,");
            strSql.Append("feedback_leave=@feedback_leave,");
            strSql.Append("feedback_house1=@feedback_house1,");
            strSql.Append("feedback_house2=@feedback_house2,");
            strSql.Append("feedback_security=@feedback_security,");
            strSql.Append("feedback_insurance=@feedback_insurance,");
            strSql.Append("feedback_business=@feedback_business,"); 
			strSql.Append("add_user=@add_user,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@query_title", DbType.String,255),
					new SQLiteParameter("@batch", DbType.String,50),
					new SQLiteParameter("@client", DbType.String,200),
                    new SQLiteParameter("@query_type", DbType.String,4),
                    new SQLiteParameter("@entrust_date", DbType.DateTime),
                    new SQLiteParameter("@is_import", DbType.Boolean),
                    new SQLiteParameter("@feedback_passport", DbType.Boolean),
                    new SQLiteParameter("@feedback_leave", DbType.Boolean),
                    new SQLiteParameter("@feedback_house1", DbType.Boolean),
                    new SQLiteParameter("@feedback_house2", DbType.Boolean),
                    new SQLiteParameter("@feedback_security", DbType.Boolean),
                    new SQLiteParameter("@feedback_insurance", DbType.Boolean),
                    new SQLiteParameter("@feedback_business", DbType.Boolean),
                    new SQLiteParameter("@add_user", DbType.String,50),
					new SQLiteParameter("@add_time", DbType.DateTime),
					new SQLiteParameter("@id", DbType.Int32,8)};
			parameters[0].Value = model.query_title;
			parameters[1].Value = model.batch;
			parameters[2].Value = model.client;
            parameters[3].Value = model.query_type;            
            parameters[4].Value = model.entrust_date;
            parameters[5].Value = model.is_import;
            parameters[6].Value = model.feedback_passport;
            parameters[7].Value = model.feedback_leave;
            parameters[8].Value = model.feedback_house1;
            parameters[9].Value = model.feedback_house2;
            parameters[10].Value = model.feedback_security;
            parameters[11].Value = model.feedback_insurance;
            parameters[12].Value = model.feedback_business;
            parameters[13].Value = model.add_user;
			parameters[14].Value = model.add_time;
			parameters[15].Value = model.id;

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
			strSql.Append("delete from query_list ");
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
			strSql.Append("delete from query_list ");
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
		public DXD.Model.query_list GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,query_title,batch,client,query_type,entrust_date,is_import,feedback_passport,");
            strSql.Append("feedback_leave,feedback_house1,feedback_house2,feedback_security,feedback_insurance,feedback_business,add_user,add_time from query_list ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			DXD.Model.query_list model=new DXD.Model.query_list();
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
		public DXD.Model.query_list DataRowToModel(DataRow row)
		{
			DXD.Model.query_list model=new DXD.Model.query_list();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["query_title"]!=null)
				{
					model.query_title=row["query_title"].ToString();
				}
				if(row["batch"]!=null)
				{
					model.batch=row["batch"].ToString();
				}
				if(row["client"]!=null)
				{
					model.client=row["client"].ToString();
				}
                if(row["query_type"]!=null)
                {
                    model.query_type = row["query_type"].ToString();
                }
				if(row["entrust_date"]!=null && row["entrust_date"].ToString()!="")
				{
					model.entrust_date=DateTime.Parse(row["entrust_date"].ToString());
				}
                if (row["is_import"] != null && row["is_import"].ToString() != "")
                {
                    model.is_import = Boolean.Parse(row["is_import"].ToString());
                }                
                if (row["feedback_passport"] != null && row["feedback_passport"].ToString() != "")
                {
                    model.feedback_passport = Boolean.Parse(row["feedback_passport"].ToString());
                }
                if (row["feedback_leave"] != null && row["feedback_leave"].ToString() != "")
                {
                    model.feedback_leave = Boolean.Parse(row["feedback_leave"].ToString());
                }
                if (row["feedback_house1"] != null && row["feedback_house1"].ToString() != "")
                {
                    model.feedback_house1 = Boolean.Parse(row["feedback_house1"].ToString());
                }
                if (row["feedback_house2"] != null && row["feedback_house2"].ToString() != "")
                {
                    model.feedback_house2 = Boolean.Parse(row["feedback_house2"].ToString());
                }
                if (row["feedback_security"] != null && row["feedback_security"].ToString() != "")
                {
                    model.feedback_security = Boolean.Parse(row["feedback_security"].ToString());
                }
                if (row["feedback_insurance"] != null && row["feedback_insurance"].ToString() != "")
                {
                    model.feedback_insurance = Boolean.Parse(row["feedback_insurance"].ToString());
                }
                if (row["feedback_business"] != null && row["feedback_business"].ToString() != "")
                {
                    model.feedback_business = Boolean.Parse(row["feedback_business"].ToString());
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
            strSql.Append("select id,query_title,batch,client,query_type,entrust_date,is_import,feedback_passport,");
            strSql.Append("feedback_leave,feedback_house1,feedback_house2,feedback_security,feedback_insurance,feedback_business,add_user,add_time,count"); 
			strSql.Append(" FROM vGetQueryList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM query_list ");
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
			strSql.Append(")AS Row, T.*  from query_list T ");
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
			parameters[0].Value = "query_list";
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

