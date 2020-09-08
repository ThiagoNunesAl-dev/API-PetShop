using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Context
{
    public class PetShopContext
    {
        SqlConnection con = new SqlConnection();

        public PetShopContext ()
        {
            con.ConnectionString = @"Data Source=THIAGO-PC\SQLEXPRESS;Initial Catalog=PetShop;Persist Security Info=True;User ID=sa;Password=sa123";

        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }
        
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
