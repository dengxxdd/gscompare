using System;
namespace DXD.Model
{
	/// <summary>
	/// query_list:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class query_list
	{
		public query_list()
		{}
		#region Model
		private int _id;
		private string _query_title;
		private string _batch;
		private string _client;
        private string _query_type;
		private DateTime? _entrust_date= DateTime.Now.Date;
        private Boolean _is_import = false;
        private Boolean _feedback_passport = false;
        private Boolean _feedback_leave = false;
        private Boolean _feedback_house1 = false;
        private Boolean _feedback_house2 = false;
        private Boolean _feedback_security = false;
        private Boolean _feedback_insurance = false;
        private Boolean _feedback_business = false;
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
		public string query_title
		{
			set{ _query_title=value;}
			get{return _query_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string batch
		{
			set{ _batch=value;}
			get{return _batch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string client
		{
			set{ _client=value;}
			get{return _client;}
		}
        
        public string query_type
        {
            set { _query_type = value;}
            get { return _query_type; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? entrust_date
		{
			set{ _entrust_date=value;}
			get{return _entrust_date;}
		}
        public Boolean is_import
        {
            set { _is_import = value; }
            get { return _is_import; }
        }
        public Boolean feedback_passport
        {
            set { _feedback_passport = value; }
            get { return _feedback_passport; }
        }

        public Boolean feedback_leave
        {
            set { _feedback_leave = value; }
            get { return _feedback_leave; }
        }
        public Boolean feedback_house1
        {
            set { _feedback_house1 = value; }
            get { return _feedback_house1; }
        }

        public Boolean feedback_house2
        {
            set { _feedback_house2 = value; }
            get { return _feedback_house2; }
        }

        public Boolean feedback_security
        {
            set { _feedback_security = value; }
            get { return _feedback_security; }
        }

        public Boolean feedback_insurance
        {
            set { _feedback_insurance = value; }
            get { return _feedback_insurance; }
        }
        public Boolean feedback_business
        {
            set { _feedback_business = value; }
            get { return _feedback_business; }
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

