using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDependencyInjectMVC.Services
{

    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

    }
    public class ProductService
    {

        List<Product> products = new List<Product>();

        public ProductService()
        {
            Console.WriteLine("Da dang ky dich vu /n");
            products.AddRange(new Product[] {

                new Product(){ Id ="1" , Name ="Dien Thoai IP" , Price = 50000 },
                new Product(){ Id ="2" , Name ="Dien Thoai ss" , Price = 60000 },
                new Product(){ Id ="3" , Name ="Dien Thoai tt" , Price = 70000 },
                new Product(){ Id ="4" , Name ="Dien Thoai ll" , Price = 80000 },
            });
        }
         
        public Product FindProduct(string productId)
        {
            var qr = from p in products where p.Id == productId select p;
            return qr.FirstOrDefault();
        }
    }
}
