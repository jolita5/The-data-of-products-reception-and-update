using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Data_ReceptionSQL
{
    public class Customer:Order
    {
        public override int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }


        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Surname = {Surname}, City = {City}";
        }

    }
}
