using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPIDFromTo.DataAccess
{
    public class OracleDataAccess
    {
        #region MyRegion

        public string Host { get; set; } = string.Empty;
        public string Port { get; set; } = "1521";
        public string DatabaseSID { get; set; } = string.Empty;
        public string UserID { get; set; } = "system";
        public string Password { get; set; } = string.Empty;
               
        //string connectionString = "Data Source=HOST:PORT/DB_SID;User Id=system;Password=password;"; //;Integrated Security=no;";

        public OracleConnection Connection { get; set; } = null;


        #endregion

        #region Contructors

        public OracleDataAccess()
        { }

        public OracleDataAccess(string Host, string Port, string SID, string UID, string PWD)
        {
            this.Host = Host;
            this.Port = Port;
            this.DatabaseSID = SID;
            this.UserID = UID;
            this.Password = PWD;
        } 

        #endregion

        #region Methods


        public string CreateConnectionString()
        {
            return $"Data Source={Host}:{Port}/{DatabaseSID};User Id={UserID};Password={Password};";
        }

        public OracleDataReader ExecuteQuery(string query)
        {
            using (OracleCommand cmd = Connection.CreateCommand())
            {
                try
                {
                    cmd.CommandText = query;

                    /* Add Prameters to Oracle COmmand
                    cmd.CommandText = "select * from sppidplantpid.t_piperun pr where pr.sp_id= :ID";
                    OracleParameter parameter1 = new OracleParameter("ID", "AABBED9AEA5E40AAA7E29B1040B7DB50");
                    cmd.Parameters.Add(parameter1); */


                    //this.Connection.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    return reader;

                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message + ex.StackTrace);
                    return null;
                }
            }
        }

        public bool ConnectToDatabase()
        {
            OracleConnection conn = new OracleConnection(CreateConnectionString());

            using (OracleCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    this.Connection = conn;
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message + ex.StackTrace);
                    return false;
                }

            }
        }

        

        #endregion

    }
}
