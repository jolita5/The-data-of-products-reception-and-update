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

            // Console.WriteLine("Customer LIST");
            VPrpductRepository myProduct = new VPrpductRepository();

            //var product = myProduct.Get(1);
            //myProduct.PrintProduct(2);


            //var allProducts = myProduct.GetAll();
            //var sorting = allProducts.OrderBy(i => i.Price);

            //foreach(var item in sorting)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //var product = myProduct.Get(2);
            //product.Name = "Vegetables_sticks";
            //product.Price = 12.2m;
            //myProduct.Update(product);


            //myProduct.Add(new VeganProduct() { Name = "Almond desert", Price = 6.6m });
            //myProduct.Delete(8);


            //Console.WriteLine("Customer LIST");

            CustomerRepository myCustomer = new CustomerRepository();
            //var n = myCustomer.Get(9);
            //n.Name = "ffff";
            //n.City = "eeee";
            //myCustomer.Update(n);


           var cus = myCustomer.Get(1);

            Console.WriteLine(cus.ToString());


            

            //var allCustomers = myCustomer.GetAll();
            //var sorting = allCustomers.OrderBy(i => i.Name);

            //foreach (var item in sorting)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            // myCustomer.Add(new Customer() { Name = "gfsdfgs", Surname = "dffrft", City = "Kaunas" });
            // myCustomer.Delete(7);
            Console.WriteLine("Order LIST");
            OrderRepository myOrder = new OrderRepository();

         //  var n = myOrder.Get(1);

            // myOrder.PrintProduct(1);

          //  Console.WriteLine(n.ToString());
            //var list = myOrder.GetAll();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //  myOrder.Add(new Order() { CustomerID = 3, ProductID = 3, Amount = 1, Order_date = DateTime.Now });


            //  myOrder.Delete(16);


            //var product2 = myProduct.Get(2);

            //product.Name = "Vegetables_sticks";
            //product.Price = 12.2m;
            //myProduct.Update(product);

            Console.ReadLine();

        }
    }
}
