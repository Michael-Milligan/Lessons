using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        //For testing
        public IDataSource dataSource = new ProductSource(new List<Product>() { new Product() { Name="Ha", Price=15 }, new Product() { Name="Ho", Price=25 } });
        public ViewResult Index()
        {
            return View(
                dataSource.Products
            );
        }
    }
}
