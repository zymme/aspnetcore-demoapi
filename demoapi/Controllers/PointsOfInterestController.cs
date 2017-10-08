using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demoapi.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null) 
            {
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{cityId}/pointsofinterest/{id}")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
			if (city == null)
			{
				return NotFound();
			}

            var pointofinterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointofinterest == null)
            {
                return NotFound();
            }

            return Ok(pointofinterest);
        }
    }
}
