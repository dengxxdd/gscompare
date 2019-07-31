using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXD.Model {
    public partial class city_list {
        public city_list() {
            this.id = 0;
            this.country_id = 0;
            this.city_name = "";
            this.order_no = 0;
            this.add_user = "";
            this._add_time = DateTime.MinValue;
        }
        #region Model
        private int _id;
        private int _country_id;
        private string _city_name;
        private int _order_no;
        private string _add_user;
        private DateTime? _add_time = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public int country_id
        {
            set { _country_id = value; }
            get { return _country_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string city_name
        {
            set { _city_name = value; }
            get { return _city_name; }
        }
        public int order_no
        {
            set { _order_no = value; }
            get { return _order_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string add_user
        {
            set { _add_user = value; }
            get { return _add_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model
    }
}
