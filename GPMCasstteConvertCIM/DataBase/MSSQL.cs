using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GPMCasstteConvertCIM.DataBase
{
    public class MSSQL
    {
        private SqlConnection _conn;

        public void Close()
        {
            try
            {
                _conn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public bool Connect(string dbName, out string errMsg, string server = "127.0.0.1", string uid = "sa", string pw = "12345678",int port = 1433)
        {
            errMsg = string.Empty;
            try
            {
                _conn = new SqlConnection($"Server={server},{port};Database={dbName};uid={uid};pwd={pw}");
                _conn.Open();
                return _conn.State == ConnectionState.Open;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        public bool TryQuery(string QueryCmdStr, out DataSet dataset, out string errMsg)
        {
            errMsg = string.Empty;
            dataset = new DataSet();
            try
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(QueryCmdStr, _conn))
                {
                    dataAdapter.Fill(dataset);
                }

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }

        }
    }
}
