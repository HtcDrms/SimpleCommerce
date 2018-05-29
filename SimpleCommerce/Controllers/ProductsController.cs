using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}