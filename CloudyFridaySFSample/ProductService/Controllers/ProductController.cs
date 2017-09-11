using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{

    class Product
    {

        public String Name { get; set; }
        public int ID { get; set; }

    }


    [Route("api/[Controller]")]
    public class ProductController : Controller
    {

        List<Product> products = new List<Product>();

    

        public IActionResult Index()
        {

            products.Add(new Product() { ID = 1, Name = "Product1" });
            products.Add(new Product() { ID = 2, Name = "Product2" });
            return new JsonResult(products);
        }
    }
}