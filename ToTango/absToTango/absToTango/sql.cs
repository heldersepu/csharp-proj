using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace absToTango
{
    class sql
    {

        private string _sqlConn = "";

        /// <summary>
        /// Initializes a new instance of the sql class
        /// </summary>
        /// <param name="sqlConString">SQL connection string</param>
        public sql(string sqlConString)
        {
            this._sqlConn = sqlConString;
        }

        public Int64 addCall()
        {
            return 0;
        }

        public void addAttrib(Int64 id, string key, string value)
        {
            
        }
    }
}
