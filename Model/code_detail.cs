using System;
namespace DXD.Model
{
	/// <summary>
	/// code_detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class code_detail
	{
		public code_detail()
		{}
        #region Model
        private int? _id;
		private string _code_id;
		private int? _list_id;
		private string _code_name;
		private string _add_user;
		private DateTime? _add_time= DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int? id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string code_id
		{
			set{ _code_id = value;}
			get{return _code_id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? list_id
		{
			set{ _list_id=value;}
			get{return _list_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code_name
		{
			set{ _code_name=value;}
			get{return _code_name;}
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

