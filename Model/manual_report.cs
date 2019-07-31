using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXD.Model
{
    [Serializable]
    public partial class manual_report
    {
        //    id INTEGER       PRIMARY KEY AUTOINCREMENT,
        //query_id INTEGER,
        //rep_type    CHAR(8),
        //appellation CHAR(8),
        //rep_str VARCHAR(255),
        //add_user VARCHAR(50),
        //add_time DATETIME
        public manual_report()
        {
            this.id = 0;
            this.query_id = 0;
            this.rep_type = "";
            this.appellation = "";
            this.rep_str = "";
            this.add_user = "";
            this.add_time = DateTime.Now;
        }
        #region Model
        private int _id;
        private int? _query_id;
        private string _rep_type;
        private string _appellation;
        private string _rep_str;
        private string _add_user;
        private DateTime? _add_time = DateTime.Now;

        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public int? query_id
        {
            set { _query_id = value; }
            get { return _query_id; }
        }
        public string rep_type
        {
            set { _rep_type = value; }
            get { return _rep_type; }
        }
        public string appellation
        {
            set { _appellation = value; }
            get { return _appellation; }
        }
        public string rep_str
        {
            set { _rep_str = value; }
            get { return _rep_str; }
        }
        public string add_user
        {
            set { _add_user = value; }
            get { return _add_user; }
        }
        public DateTime? add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }

        #endregion

    }
}
