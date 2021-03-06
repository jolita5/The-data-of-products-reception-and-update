﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Data_ReceptionSQL
{
    public class CustomerRepository : IRepository<Customer>
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=VegianProducts";



        public Customer Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE Id =@CustomerID", connection))
                {
                    command.Parameters.Add(new SqlParameter("@CustomerID", id));
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        
                        while (reader.Read())
                        {
                            if (String.IsNullOrEmpty(reader["Id"].ToString())) // todo: doesn't work
                            {
                                return null;
                            }

                            return new Customer
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Surname = reader.GetString(2),
                                City = reader.GetString(3),

                            };

                        }

                    }
                    return null;
                }
            }

        }

        public List<Customer> GetAll()
        {
            var result = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Customer", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            result.Add(new Customer
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Surname = reader.GetString(2),
                                City = reader.GetString(3),

                            });
                        }


                    }

                    return result;
                }

            }
        }



        public void Update(Customer item)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE VeganProducts SET " +
                    "Name = @Name, Surname = @Surname, City = @City WHERE Id=@CustomerID", connection))
                {
                    command.Parameters.Add(new SqlParameter("Name", item.Name));
                    command.Parameters.Add(new SqlParameter("Surname", item.Surname));
                    command.Parameters.Add(new SqlParameter("City", item.City));
                    command.ExecuteNonQuery();
                       
                }

            }
        }


        public void Add(Customer item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO Customer (Name, Surname, City) " +
                    "VALUES(@Name, @Surname, @City)", connection))
                {
                    command.Parameters.Add(new SqlParameter("Name", item.Name));
                    command.Parameters.Add(new SqlParameter("Surname", item.Surname));
                    command.Parameters.Add(new SqlParameter("City", item.City));
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
                    "DELETE FROM Customer WHERE Id = @CustomerID", connection))
                {
                    command.Parameters.Add(new SqlParameter("@CustomerID", id));
                    command.ExecuteNonQuery();
                }
            }


        }
    }
}
