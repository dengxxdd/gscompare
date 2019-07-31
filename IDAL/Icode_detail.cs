using System;
using System.Data;
using System.Collections.Generic;
namespace DXD.IDAL
{
	/// <summary>
	/// 接口层code_detail
	/// </summary>
	public interface Icode_detail
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(DXD.Model.code_detail model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DXD.Model.code_detail model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int id);
		bool DeleteList(string idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DXD.Model.code_detail GetModel(int id);
        DXD.Model.code_detail GetModel(string codestr,bool flag);
		DXD.Model.code_detail DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        #endregion  成员方法
        #region  MethodEx
        DataSet GetCodeList(string listName);
        DataTable CodeConvert(DataTable dt, string field);
        DataTable NameToCode(DataTable dt, string field);
        #endregion  MethodEx
    } 
}
