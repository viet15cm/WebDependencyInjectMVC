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

        private readonly ICollection<Product> _products;
        
        public ProductService(IOptions<List<Product>> options)
        {
            _products = options.Value;
            var c = 0;

        }
         
        public Product FindProduct(string productId)
        {
            var qr = from p in _products where p.Id == productId select p;
            return qr.FirstOrDefault();
        }
        
    }
}
