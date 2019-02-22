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
            //VPrpductRepository myProduct = new VPrpductRepository();

            //var product = myProduct.Get(1);
            //myProduct.PrintProduct(2);


            //var allProducts = myProduct.GetAll();
            //var sorting = allProducts.OrderBy(i => i.Price);

            //foreach(var item in sorting)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //var product2 = myProduct.Get(2);
            //product.Name = "Vegetables_sticks";
            //product.Price = 12.2m;
            //myProduct.Update(product);


            //myProduct.Add(new VeganProduct() { Name = "Almond desert", Price = 6.6m });
            //myProduct.Delete(8);


            Console.WriteLine("Customer LIST");

            CustomerRepository myCustomer = new CustomerRepository();

            var allProducts = myCustomer.GetAll();
            var sorting = allProducts.OrderBy(i => i.Name);

            foreach (var item in sorting)
            {
                Console.WriteLine(item.ToString());
            }

           // myCustomer.Add(new Customer() { Name = "gfsdfgs", Surname = "dffrft", City = "Kaunas" });
             myCustomer.Delete(7);

            Console.ReadLine();

        }
    }
}
