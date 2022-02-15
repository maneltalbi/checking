using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace CheckingSystem1.database_access_layer
{
    public class db
    {

        SqlConnection con = new SqlConnection("Server=.;Database=CheckingSystem;Trusted_Connection=True;MultipleActiveResultSets=true");
        //Get Country List
        public DataSet GetCategories()
        {
            SqlCommand com = new SqlCommand("Sp_Categories", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        public DataSet GetSubCategories(int catid)
        {
            SqlCommand com = new SqlCommand("Sp_SubCategories", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IdCat", catid);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
    }
}
