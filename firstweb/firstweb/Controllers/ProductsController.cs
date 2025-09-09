//using Microsoft.AspNetCore.Mvc;
//using firstweb.Models; // We MUST include this to use our Product class
//using System.Collections.Generic;

//namespace firstweb.Controllers
//{
//    public class ProductsController : Controller
//    {
//        public IActionResult Index()
//        {
//            List<Product> products = new List<Product>
//            {
//                new Product{ Id = 1, Name = "Laptop", Price = 12000.0m
//                },
//                new Product{Id = 2,Name = "Mouse",Price = 120.0m }
//                };

//                return View(products);
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Data;   
using firstweb.Models; 
using System.Collections.Generic;
using System.Linq; 

namespace MyFirstWebApp.Controllers 
{
    public class ProductsController : Controller
    {
       
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context; 
        }

        
        public IActionResult Index()
        {
           
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    }
}