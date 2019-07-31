﻿using System;
using System.Data;
namespace DXD.IDAL
{
    /// <summary>
    /// 接口层manual_report
    /// </summary>
    public interface Imanual_report
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
        int Add(DXD.Model.manual_report model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(DXD.Model.manual_report model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int id);
        bool DeleteList(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        DXD.Model.manual_report GetModel(int id);
        DXD.Model.manual_report DataRowToModel(DataRow row);
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

        #endregion  MethodEx
    }
}
