﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebDependencyInjectMVC.Models;
using WebDependencyInjectMVC.Services;

namespace WebDependencyInjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;
        public HomeController(ILogger<HomeController> logger , ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult ProductInfo(string productId)
        {
            Console.WriteLine(_productService.GetHashCode());
           var product =  _productService.FindProduct(productId);
           
            return View(product);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
