using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Data_ReceptionSQL
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime Order_date { get; set; }
        public decimal Amount { get; set; }
        Customer customer = new Customer();
        VeganProduct product = new VeganProduct();

        public override string ToString()
        {
            return $"Id = {Id}, Customer Id = {CustomerID}, Product Id = {ProductID}, amount {Amount} Order Date = {Order_date}";
        }
    }
}
