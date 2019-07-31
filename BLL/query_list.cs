﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using DXD.Model;
using DXD.DALFactory;
using DXD.IDAL;
using System.Reflection;
namespace DXD.BLL
{
	/// <summary>
	/// query_list
	/// </summary>
	public partial class query_list
	{
        private readonly Iquery_list dal=DataAccess.Createquery_list();
        //private readonly Iquery_list dal =Createquery_list();
        static Iquery_list Createquery_list()
        { 
            string AssemblyPath = System.Configuration.ConfigurationManager.AppSettings["DAL"];
            Assembly obj = Assembly.Load(AssemblyPath);
            object obj2 = obj.CreateInstance("DXD.SQLiteDAL.query_list");
            return (Iquery_list)obj2;
        }
        public query_list()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DXD.Model.query_list model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DXD.Model.query_list model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(idlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DXD.Model.query_list GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public DXD.Model.query_list GetModelByCache(int id)
		{
			
			string CacheKey = "query_listModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DXD.Model.query_list)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DXD.Model.query_list> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DXD.Model.query_list> DataTableToList(DataTable dt)
		{
			List<DXD.Model.query_list> modelList = new List<DXD.Model.query_list>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DXD.Model.query_list model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

