using System;
namespace DXD.Model
{
	/// <summary>
	/// business_compare:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class business_compare
	{
		public business_compare()
		{
            this.id = 0;
            this.query_id = 0;
            this.feedback_id = 0;
            this.report_id = 0;
            this.compare_type = "";
            this.less_value = 0;
            this.add_user = "";
            this.add_time = DateTime.Now;
        }
		#region Model
		private int _id;
		private int? _query_id;
		private int? _feedback_id;
		private int? _report_id;
		private string _compare_type;
		private decimal? _less_value=0M;
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
		public int? feedback_id
		{
			set{ _feedback_id=value;}
			get{return _feedback_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? report_id
		{
			set{ _report_id=value;}
			get{return _report_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string compare_type
		{
			set{ _compare_type=value;}
			get{return _compare_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? less_value
		{
			set{ _less_value=value;}
			get{return _less_value;}
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

