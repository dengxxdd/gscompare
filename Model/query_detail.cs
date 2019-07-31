using System;
using System.Collections.Generic;
namespace DXD.Model
{
    /// <summary>
    /// query_detail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class query_detail {
        public static string[] compare_items = { "护照","港澳台通行证","出国","出境","国外生活","房产","股票","基金","保险","工商" };
		public query_detail()
		{
            this.id = 0;
            this.list_id = 0;
            this.full_name = "";
            this.sex = "";
            this.card_no = "";
            this.work_unit = "";
            this.post = "";
            this.pol_status = "";
            this.parent_id = 0;
            this.appellation = "";
            this.is_together = false;
            this.is_compare = false;
            this.is_match = true;
            this.uncompare_items =string.Join(uncompare_items,',');
            this.add_user = "admin";
            this.add_time = DateTime.Now;
        }
		#region Model
		private int _id;
		private int? _list_id;
		private string _full_name;
		private string _sex;
		private string _card_no;
        private string _work_unit;
        private string _post;
        private string _pol_status;
		private int? _parent_id=0;
		private string _appellation;
		private bool _is_together;
        private bool _is_compare;
        private bool _is_match;
        private string _uncompare_items;
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
		/// 任务表ID
		/// </summary>
		public int? list_id
		{
			set{ _list_id=value;}
			get{return _list_id;}
		}
		/// <summary>
		/// 全名
		/// </summary>
		public string full_name
		{
			set{ _full_name=value;}
			get{return _full_name;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 身份证号
		/// </summary>
		public string card_no
		{
			set{ _card_no=value;}
			get{return _card_no;}
		}
        /// <summary>
        /// 工作单位
        /// </summary>
        public string work_unit
        {
            set { _work_unit = value; }
            get { return _work_unit; }
        }
        /// <summary>
        /// 职务
        /// </summary>
        public string post
        {
            set { _post = value; }
            get { return _post; }
        }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string pol_status
        {
            set { _pol_status=value; }
            get { return _pol_status; }
        }
		/// <summary>
		/// 家庭成员所属领导ID
		/// </summary>
		public int? parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 称谓
		/// </summary>
		public string appellation
		{
			set{ _appellation=value;}
			get{return _appellation;}
		}
		/// <summary>
		/// 是否共同生活
		/// </summary>
		public bool is_together
		{
			set{ _is_together=value;}
			get{return _is_together;}
		}
        /// <summary>
        /// 是否已比对
        /// </summary>
        public bool is_compare
        {
            set { _is_compare = value; }
            get { return _is_compare; }
        }
        /// <summary>
        /// 比对结果是否一致（默认一致）
        /// </summary>
        public bool is_match
        {
            set { _is_match = value; }
            get { return _is_match; }
        }
        public string uncompare_items
        {
            set { _uncompare_items = value; }
            get { return _uncompare_items; }
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

