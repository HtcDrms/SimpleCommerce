using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCommerce.Data;

namespace SimpleCommerce.Controllers
{
    public class ProductsController : ControllerBase
    {
        public ProductsController(ApplicationDbContext context):base(context)
        {

        }
        public IActionResult Index(int categoryId, string order = "date-asc")
        {
            ViewBag.ProductCategories = _context.Categories.Include(c=>c.Products).ToList();

            ViewBag.SelectedCategory = _context.Categories.Where(c=>c.Id == categoryId).FirstOrDefault();

            ViewBag.LatestProducts = _context.Products.Where(p=>p.IsPublished==true).OrderByDescending(o => o.CreateDate).Take(3).ToList();
       
            var products = _context.Products.Where(p =>(categoryId != 0 ? p.CategoryId == categoryId : true) && p.IsPublished == true);
            switch (order)
            {
                case "date-asc":
                    products = products.OrderBy(o => o.CreateDate);
                    break;
                case "date-desc":
                    products = products.OrderByDescending(o => o.CreateDate);
                    break;
                case "price-asc":
                    products = products.OrderBy(o => o.Price);
                    break;
                case "price-desc":
                    products = products.OrderByDescending(o => o.Price);
                    break;
            }
            return View(products.ToList());
       
        }
    }
}