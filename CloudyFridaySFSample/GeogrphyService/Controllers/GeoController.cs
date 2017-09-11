using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeogrphyService.Controllers
{
    class Geography
    {
        public String Name { get; set; }

        public int ID { get; set; }
    }

    [Route("api/[Controller]")]
    public class GeoController : Controller
    {

        List<Geography> geographies = new List<Geography>();
        public IActionResult Index()
        {
            geographies.Add(new Geography() { ID = 1, Name = "GEO1" });
            geographies.Add(new Geography() { ID = 2, Name = "GEO2" });
            return new JsonResult(geographies);
        }
    }
}