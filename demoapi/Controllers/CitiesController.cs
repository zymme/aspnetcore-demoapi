using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demoapi.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
       

        [HttpGet()]
        public IActionResult GetCities()
        {

            return Ok(CitiesDataStore.Current.Cities);

            //return new JsonResult(CitiesDataStore.Current.Cities);

            //return new JsonResult(new List<object>()
            //{
            //    new { id=1, Name="Leander" },
            //    new { id=2, Name="Sacramento" }
            //});
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {

            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if(cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);

            //return new JsonResult(
            //    CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id)
            //);
        }
    }
}
