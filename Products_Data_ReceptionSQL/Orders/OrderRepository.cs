﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Data_ReceptionSQL
{
    public class OrderRepository:IRepository<Order>
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=VegianProducts";
        Customer customer = new Customer();
        VeganProduct product = new VeganProduct();


        public Order Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM OrdersVegan WHERE Id=@Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new Order
                            {
                                Id = reader.GetInt32(0),
                                CustomerID = customer.Id = reader.GetInt32(1),
                                ProductID = product.Id = reader.GetInt32(2),
                                Amount = reader.GetDecimal(3),
                                Date = reader.GetDateTime(4)
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM OrdersVegan WHERE Id = @Id", connection))
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


        public List<Order> GetAll()
        {
            var result = new List<Order>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM OrdersVegan", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(new Order
                            {
                                Id = reader.GetInt32(0),
                                CustomerID = reader.GetInt32(1),
                                ProductID = reader.GetInt32(2),
                                Amount = reader.GetDecimal(3),
                                Date = reader.GetDateTime(4)
                            });
                        }
                    }

                    return result;
                }

            }
        }

        public void PrintAll()
        {
            var result = new List<Order>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT c.Name, c.Surname, c.City, p.Name, p.Price, o.* +" +
                    " FROM OrdersVegan o +" +
                    "JOIN Customer c on CustomerID = c.Id +" +
                    "JOIN VeganProducts p on ProductID = p.Id", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader.GetValue(i));
                            }
                        }
                    }
                }

            }
        }



        public void Update(Order item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE OrdersVegan SET " +
                    "CustomerID = @CustomerID, ProductID = @ProductID, Amount = @Amount, Date = @Order_Date WHERE Id=@Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("CustomerID", customer.Id));
                    command.Parameters.Add(new SqlParameter("ProductID", product.Id));
                    command.Parameters.Add(new SqlParameter("Amount", item.Amount));
                    command.Parameters.Add(new SqlParameter("Date", item.Date));

                    command.ExecuteNonQuery();
                }

            }
        }


        public void Add(Order item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO OrdersVegan (CustomerID, ProductID, Amount, Date) " +
                    "VALUES(@CustomerID, @ProductID, @Amount, @Order_date)", connection))
                {
                    command.Parameters.Add(new SqlParameter("CustomerID", item.CustomerID));
                    command.Parameters.Add(new SqlParameter("ProductID", item.ProductID));
                    command.Parameters.Add(new SqlParameter("Amount", item.Amount));
                    command.Parameters.Add(new SqlParameter("Date", item.Date));
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
                    "DELETE FROM OrdersVegan WHERE Id = @Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));
                    command.ExecuteNonQuery();
                }
            }


        }
    }
}
