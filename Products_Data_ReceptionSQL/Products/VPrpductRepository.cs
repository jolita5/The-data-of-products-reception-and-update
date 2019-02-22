using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Data_ReceptionSQL
{
    public class VPrpductRepository : IRepository<VeganProduct>
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=VegianProducts";



        public VeganProduct Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM VeganProducts WHERE Id =@Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new VeganProduct
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2)
                            };

                        }
                    }
                    return null;
                }
            }

        }

        public void PrintProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM VeganProducts WHERE Id = @Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                              Console.WriteLine(reader.GetValue(i));
                            }

                            Console.WriteLine();

                        }
                    }
                }
            }

        }


        public List<VeganProduct> GetAll()
        {
            var result = new List<VeganProduct>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM VeganProducts", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(new VeganProduct
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2)
                            });
                        }
                    }

                    return result;
                }

            }
        }



        public void Update(VeganProduct item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE VeganProducts SET " +
                    "Name = @Name, Price = @Price WHERE Id=@Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("Name", item.Name));
                    command.Parameters.Add(new SqlParameter("Price", item.Price));
                    command.Parameters.Add(new SqlParameter("Id", item.Id));
                    command.ExecuteNonQuery();
                }

            }
        }


        public void Add(VeganProduct item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO VeganProducts (Name, Price) " +
                    "VALUES(@Name, @Price)", connection))
                {
                    command.Parameters.Add(new SqlParameter("Name", item.Name));
                    command.Parameters.Add(new SqlParameter("Price", item.Price));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "DELETE FROM VeganProducts WHERE Id = @Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));
                    command.ExecuteNonQuery();
                }
            }


        }


    }
}
