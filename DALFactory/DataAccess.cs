using System;
using System.Reflection;
using System.Configuration;
namespace DXD.DALFactory
{
	/// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
	/// </summary>
	public sealed class DataAccess 
	{
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];        
		public DataAccess()
		{ }

        #region CreateObject 

		//不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath,string classNamespace)
		{		
			try
			{
				object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);                
                return objType;
			}
			catch//(System.Exception ex)
			{
				//string str=ex.Message;// 记录错误日志
				return null;
			}			
			
        }
		//使用缓存
		private static object CreateObject(string AssemblyPath,string classNamespace)
		{			
			object objType = DataCache.GetCache(classNamespace);
			if (objType == null)
			{
				try
				{                    
					objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
				}
				catch(System.Exception ex)
				{
					string str=ex.Message;// 记录错误日志
				}
			}
			return objType;
		}
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

        #region CreateSysManage
        public static DXD.IDAL.ISysManage CreateSysManage()
		{
			//方式1			
			//return (DXD.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

			//方式2 			
			string classNamespace = AssemblyPath+".SysManage";	
			object objType=CreateObject(AssemblyPath,classNamespace);
            return (DXD.IDAL.ISysManage)objType;		
		}
		#endregion
             
        
   
		/// <summary>
		/// 创建business_compare数据层接口。
		/// </summary>
		public static DXD.IDAL.Ibusiness_compare Createbusiness_compare()
		{

			string ClassNamespace = AssemblyPath +".business_compare";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (DXD.IDAL.Ibusiness_compare)objType;
		}


		/// <summary>
		/// 创建business_feedback数据层接口。
		/// </summary>
		public static DXD.IDAL.Ibusiness_feedback Createbusiness_feedback()
		{

			string ClassNamespace = AssemblyPath +".business_feedback";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (DXD.IDAL.Ibusiness_feedback)objType;
		}


		/// <summary>
		/// 创建business_report数据层接口。
		/// </summary>
		public static DXD.IDAL.Ibusiness_report Createbusiness_report()
		{

			string ClassNamespace = AssemblyPath +".business_report";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (DXD.IDAL.Ibusiness_report)objType;
		}


		/// <summary>
		/// 创建code_detail数据层接口。
		/// </summary>
		public static DXD.IDAL.Icode_detail Createcode_detail()
		{

			string ClassNamespace = AssemblyPath +".code_detail";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (DXD.IDAL.Icode_detail)objType;
		}


		/// <summary>
		/// 创建code_list数据层接口。
		/// </summary>
		public static DXD.IDAL.Icode_list Createcode_list()
		{

			string ClassNamespace = AssemblyPath +".code_list";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (DXD.IDAL.Icode_list)objType;
		}


		/// <summary>
		/// 创建compare_result数据层接口。
		/// </summary>
		public static DXD.IDAL.Icompare_result Createcompare_result()
		{

			string ClassNamespace = AssemblyPath +".compare_result";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (DXD.IDAL.Icompare_result)objType;
		}


		
		/// <summary>
		/// 创建query_detail数据层接口。
		/// </summary>
		public static DXD.IDAL.Iquery_detail Createquery_detail()
		{
			string ClassNamespace = AssemblyPath +".query_detail";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (DXD.IDAL.Iquery_detail)objType;
		}


		/// <summary>
		/// 创建query_list数据层接口。
		/// </summary>
		public static DXD.IDAL.Iquery_list Createquery_list()
		{
			string ClassNamespace = AssemblyPath +".query_list";
			object objType= CreateObject(AssemblyPath,ClassNamespace);
			return (DXD.IDAL.Iquery_list)objType;
		}
		
        /// <summary>
		/// 创建security_report数据层接口。
		/// </summary>
		public static DXD.IDAL.Imanual_report Createmanual_report()
        {
            string ClassNamespace = AssemblyPath + ".manual_report";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DXD.IDAL.Imanual_report)objType;
        }
        
        public static DXD.IDAL.Icountry_list Createcountry_list() {
            string ClassNamespace = AssemblyPath + ".country_list";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DXD.IDAL.Icountry_list)objType;
        }
        public static DXD.IDAL.Icity_list Createcity_list() {
            string ClassNamespace = AssemblyPath + ".city_list";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (DXD.IDAL.Icity_list)objType;
        }
    }
}