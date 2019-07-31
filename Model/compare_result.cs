using System;
namespace DXD.Model
{
	/// <summary>
	/// compare_result:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class compare_result
	{
		public compare_result()
		{
            id = 0;
            query_id = 0;
            result_type = "";
            report_str = "";
            feedback_str = "";
            compare_str = "";
            rep_lock = false;
            add_user = "";
            add_time = DateTime.Now;
        }
		#region Model
		private int _id;
		private int? _query_id;
		private string _result_type;
		private string _report_str;
		private string _feedback_str;
		private string _compare_str;
        private Boolean _rep_lock;
		private string _add_user;
		private DateTime? _add_time= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? query_id
		{
			set{ _query_id=value;}
			get{return _query_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string result_type
		{
			set{ _result_type=value;}
			get{return _result_type; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string report_str
		{
			set{ _report_str=value;}
			get{return _report_str;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string feedback_str
		{
			set{ _feedback_str=value;}
			get{return _feedback_str;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string compare_str
		{
			set{ _compare_str=value;}
			get{return _compare_str;}
		}
        public Boolean rep_lock
        {
            set { _rep_lock = value; }
            get { return _rep_lock; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string add_user
		{
			set{ _add_user=value;}
			get{return _add_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

