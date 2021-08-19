using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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

        private readonly List<Product> _products;
        public ProductService(List<Product> products)
        {
            Console.WriteLine("Da dang ky dich vu /n");

            _products = products;

            /*products.AddRange(new Product[] {

                new Product(){ Id ="1" , Name ="Dien Thoai IP" , Price = 50000 },
                new Product(){ Id ="2" , Name ="Dien Thoai ss" , Price = 60000 },
                new Product(){ Id ="3" , Name ="Dien Thoai tt" , Price = 70000 },
                new Product(){ Id ="4" , Name ="Dien Thoai ll" , Price = 80000 },
            });
            */
        }
         
        public Product FindProduct(string productId)
        {
            var qr = from p in _products where p.Id == productId select p;
            return qr.FirstOrDefault();
        }

        public static List<Product> GetListFile()
        {
            ConfigurationRoot configurationRoot = RedFile("FileJson/Data.json");
            var products = configurationRoot.GetSection("Product").Get<List<Product>>();
            return products;
        }

        public static ConfigurationRoot RedFile(string path)
        {
            ConfigurationRoot configurationRoot;
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile(path);
            configurationRoot = (ConfigurationRoot)configurationBuilder.Build();

            return configurationRoot;
        }
    }
}
