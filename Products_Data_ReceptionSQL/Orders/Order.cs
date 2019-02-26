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
        public virtual int CustomerID { get; set; }
        public virtual int ProductID { get; set; }
        public DateTime Order_date { get; set; }
        public decimal Amount { get; set; }
 

        public override string ToString()
        {
            return $"Id = {Id}, Customer Id = {CustomerID}, Product Id = {ProductID}, amount {Amount} Order Date = {Order_date}";
        }
    }
}
