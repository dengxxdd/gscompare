using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using DXD.IDAL;
using DXD.DBUtility;//Please add references
using DXD.Model;

namespace DXD.SQLiteDAL
{
	/// <summary>
	/// 数据访问类:query_detail
	/// </summary>
	public partial class query_detail:Iquery_detail
	{
		public query_detail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("id", "query_detail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from query_detail");
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
		public int Add(DXD.Model.query_detail model)
		{
			StringBuilder strSql=new StringBuilder();
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
		public bool Update(DXD.Model.query_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update query_detail set ");
			strSql.Append("list_id=@list_id,");
			strSql.Append("full_name=@full_name,");
			strSql.Append("sex=@sex,");
			strSql.Append("card_no=@card_no,");
            strSql.Append("work_unit=@work_unit,");
            strSql.Append("post=@post,");
            strSql.Append("pol_status=@pol_status,");
            strSql.Append("parent_id=@parent_id,");
			strSql.Append("appellation=@appellation,");
			strSql.Append("is_together=@is_together,");
            strSql.Append("is_compare=@is_compare,");
            strSql.Append("is_match=@is_match,");
            strSql.Append("uncompare_items=@uncompare_items,");
            strSql.Append("add_user=@add_user,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
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
					new SQLiteParameter("@add_time", DbType.DateTime),
					new SQLiteParameter("@id", DbType.Int32,8)};
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
			strSql.Append("delete from query_detail ");
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
			strSql.Append("delete from query_detail ");
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
		public DXD.Model.query_detail GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,list_id,full_name,sex,card_no,work_unit,post,pol_status,parent_id,appellation,is_together,is_compare,is_match,add_user,add_time from query_detail ");
			strSql.Append(" where id=@id");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@id", DbType.Int32,4)
			};
			parameters[0].Value = id;

			DXD.Model.query_detail model=new DXD.Model.query_detail();
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
		public DXD.Model.query_detail DataRowToModel(DataRow row)
		{
			DXD.Model.query_detail model=new DXD.Model.query_detail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["list_id"]!=null && row["list_id"].ToString()!="")
				{
					model.list_id=int.Parse(row["list_id"].ToString());
				}
				if(row["full_name"]!=null)
				{
					model.full_name=row["full_name"].ToString();
				}
				if(row["sex"]!=null)
				{
					model.sex=row["sex"].ToString();
				}
				if(row["card_no"]!=null)
				{
					model.card_no=row["card_no"].ToString();
				}
                if (row["work_unit"] != null)
                {
                    model.work_unit = row["work_unit"].ToString();
                }
                if (row["post"] != null)
                {
                    model.post = row["post"].ToString();
                }
                if (row["pol_status"] != null)
                {
                    model.pol_status = row["pol_status"].ToString();
                }
                if (row["parent_id"]!=null && row["parent_id"].ToString()!="")
				{
					model.parent_id=int.Parse(row["parent_id"].ToString());
				}
				if(row["appellation"]!=null)
				{
					model.appellation=row["appellation"].ToString();
				}
				if(row["is_together"]!=null && row["is_together"].ToString()!="")
				{
					if((row["is_together"].ToString()=="1")||(row["is_together"].ToString().ToLower()=="true"))
					{
						model.is_together=true;
					}
					else
					{
						model.is_together=false;
					}
				}
                if (row["is_compare"] != null && row["is_compare"].ToString() != "")
                {
                    if ((row["is_compare"].ToString() == "1") || (row["is_compare"].ToString().ToLower() == "true"))
                    {
                        model.is_compare = true;
                    }
                    else
                    {
                        model.is_compare = false;
                    }
                }
                if (row["is_match"] != null && row["is_match"].ToString() != "")
                {
                    if ((row["is_match"].ToString() == "1") || (row["is_match"].ToString().ToLower() == "true"))
                    {
                        model.is_match = true;
                    }
                    else
                    {
                        model.is_match = false;
                    }
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
			strSql.Append("select id,list_id,full_name,sex,card_no,work_unit,post,pol_status," +
                "parent_id,appellation,is_together,is_compare,is_match,add_user,add_time");
			strSql.Append(" FROM query_detail ");
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
			strSql.Append("select count(1) FROM query_detail ");
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
			strSql.Append(")AS Row, T.*  from query_detail T ");
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
			parameters[0].Value = "query_detail";
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

