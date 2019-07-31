using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXD.DTD
{
    public class DTDParameter
    {
        private string _filename;
        private int _list_id;
        private int _query_id;
        public string filename
        {
            set { _filename = value; }
            get { return _filename; }
        }
        public int list_id
        {
            set { _list_id = value; }
            get { return _list_id; }
        }

        public int query_id
        {
            set { _query_id = value; }
            get { return _query_id; }
        }
    }
    
}
