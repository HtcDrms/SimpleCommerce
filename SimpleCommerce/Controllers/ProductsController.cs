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
        public IActionResult Index(int categoryId)
        {
            ViewBag.ProductCategories = _context.Categories.Include(c=>c.Products).ToList();

            ViewBag.SelectedCategory = _context.Categories.Where(c=>c.Id == categoryId).FirstOrDefault();

            ViewBag.LatestProducts = _context.Products.OrderByDescending(o => o.CreateDate).Take(3).ToList();
            return View();
        }
    }
}