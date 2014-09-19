using System;
using System.Data;
using System.Data.SqlClient;


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

        public string addCall()
        {
            string id = "0";
            if (!string.IsNullOrEmpty(_sqlConn))
            {
                using (SqlConnection conn = new SqlConnection(_sqlConn))
                {
                    SqlCommand command = new SqlCommand("sp", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.Add("@WebServerName", SqlDbType.Text);
                    //command.Parameters["@WebServerName"].Value = args[i];
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader["id"].ToString();
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            return id;
        }

        public void addAttrib(string id, string key, string value)
        {
            if (!string.IsNullOrEmpty(_sqlConn))
            {
                using (SqlConnection conn = new SqlConnection(_sqlConn))
                {
                    SqlCommand command = new SqlCommand("sp", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@id", SqlDbType.Text);
                    command.Parameters["@id"].Value = id;
                    command.Parameters.Add("@key", SqlDbType.Text);
                    command.Parameters["@key"].Value = key;
                    command.Parameters.Add("@value", SqlDbType.Text);
                    command.Parameters["@value"].Value = value;
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
