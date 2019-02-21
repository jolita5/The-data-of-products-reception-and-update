using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Data_ReceptionSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=VegianProducts");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM VeganProducts", con);

            SqlDataReader reader = cmd.ExecuteReader();
             while(reader.Read())
            {
                Console.WriteLine($"{reader.GetSqlInt32(0)}, {reader.GetString(1)}, {reader.GetSqlSingle(2)}");
            }
            reader.Close();
            con.Close();

            if(Debugger.IsAttached)
            {
                Console.ReadLine();
            }
        }
    }
}
