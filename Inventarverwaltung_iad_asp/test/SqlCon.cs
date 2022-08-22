using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Inventarverwaltung_iad_asp
{
    internal class SqlCon
    {
        public  static SqlCommand command;
        public static SqlDataReader reader;
        private static string servername = "*****", serverdb = "IAD_Inventar"; 
        public static string serveruser, serverpassword;
        public static string sqlcon="";
        public static SqlConnection sqlConnection= new SqlConnection(SqlCon.sqlcon);
        

        public static void checkLogin(string login, string pass)
        {
            serveruser = login;
            serverpassword = pass;
            sqlcon = $"Data Source={SqlCon.servername};Initial Catalog={SqlCon.serverdb};User Id={SqlCon.serveruser};Password={SqlCon.serverpassword};";
            sqlConnection = new SqlConnection(SqlCon.sqlcon);
        }

       
    
    }
}
