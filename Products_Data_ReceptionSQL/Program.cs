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


            VPrpductRepository myProduct = new VPrpductRepository();
            var product = myProduct.Get(2);
            product.Name = "Vegetables_sticks";
            product.Price = 12.2m;
            myProduct.Update(product);

            Console.ReadLine();

        }
    }
}
