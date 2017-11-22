using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrintingWebService
{
    public class SearchDataTable
    {
        private static string ConnectionString = "Data Source=(local)\\FREEDOM;Database=db_Thunder;User ID=sa;Pwd=Abcd123456;";
        public SqlConnection scn;
        public DataSet ds;
        public SqlDataAdapter sda;
        public SqlCommand cmd;
        public void Init()
        {
            scn = new SqlConnection(ConnectionString);
            scn.Open();
            cmd = scn.CreateCommand();
            ds = new DataSet();
            sda = new SqlDataAdapter();
           
        }
    }
}