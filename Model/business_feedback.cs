using System;
namespace DXD.Model
{
	/// <summary>
	/// business_feedback:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class business_feedback
	{
		public business_feedback()
		{
            this.id = 0;
            this.query_id = 0;
            this.bus_name = "";
            this.scope = "";
            this.reg_no = "";
            this.bus_type = "";
            this.reg_capital = 0;
            this.subscribe = 0;
            this.proportion = 0;
            this.status = "";
            this.paid_in = 0;
            this.found_date = DateTime.MinValue;
            this.lost_date = DateTime.MinValue;
            this.office = "";
            this.remark = "";
            this.is_hidden = false;
            this.is_match = false;
            this.add_user = "admin";
            this.add_time = DateTime.Now;
        }
		#region Model
		private int _id;
		private int? _query_id;
		private string _bus_name;
		private string _scope;
		private string _reg_no;
		private string _bus_type;
		private decimal? _reg_capital=0M;
		private decimal? _subscribe=0M;
		private decimal? _proportion=0M;
		private string _status;
		private decimal? _paid_in=0M;
		private DateTime? _found_date;
		private DateTime? _lost_date;
		private string _office;
		private string _remark;
        private Boolean _is_hidden;
        private Boolean _is_match;
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
		/// 对应的人员ID
		/// </summary>
		public int? query_id
		{
			set{ _query_id=value;}
			get{return _query_id;}
		}
		/// <summary>
		/// 公司名称
		/// </summary>
		public string bus_name
		{
			set{ _bus_name=value;}
			get{return _bus_name;}
		}
		/// <summary>
		/// 经营范围
		/// </summary>
		public string scope
		{
			set{ _scope=value;}
			get{return _scope;}
		}
		/// <summary>
		/// 注册号
		/// </summary>
		public string reg_no
		{
			set{ _reg_no=value;}
			get{return _reg_no;}
		}
		/// <summary>
		/// 企业类型
		/// </summary>
		public string bus_type
		{
			set{ _bus_type=value;}
			get{return _bus_type;}
		}
		/// <summary>
		/// 注册资本
		/// </summary>
		public decimal? reg_capital
		{
			set{ _reg_capital=value;}
			get{return _reg_capital;}
		}
		/// <summary>
		/// 认缴出资额
		/// </summary>
		public decimal? subscribe
		{
			set{ _subscribe=value;}
			get{return _subscribe;}
		}
		/// <summary>
		/// 出资比例
		/// </summary>
		public decimal? proportion
		{
			set{ _proportion=value;}
			get{return _proportion;}
		}
		/// <summary>
		/// 企业状态
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 实缴资本
		/// </summary>
		public decimal? paid_in
		{
			set{ _paid_in=value;}
			get{return _paid_in;}
		}
		/// <summary>
		/// 成立日期
		/// </summary>
		public DateTime? found_date
		{
			set{ _found_date=value;}
			get{return _found_date;}
		}
		/// <summary>
		/// 吊销日期
		/// </summary>
		public DateTime? lost_date
		{
			set{ _lost_date=value;}
			get{return _lost_date;}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string office
		{
			set{ _office=value;}
			get{return _office;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
        /// <summary>
        /// 是否匹配
        /// </summary>
        public Boolean is_match
        {
            set { _is_match = value; }
            get { return _is_match; }
        }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public Boolean is_hidden
        {
            set { _is_hidden = value; }
            get { return _is_hidden; }
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

