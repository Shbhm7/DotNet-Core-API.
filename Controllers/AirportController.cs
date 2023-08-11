using AIRPORTAPI.Helpers;
using AIRPORTAPI.Models;
using Microsoft.AspNetCore.Mvc;

 

namespace AIRPORTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportDistanceController : ControllerBase
    {
        [HttpGet]
        public ActionResult<double> GetDistance([FromQuery] string airport1Code, [FromQuery] string airport2Code)
        {
            AirportResponse response = null ;
            var airports = new List<Airport>
        {
            new Airport { Code = "DEL", Latitude = 28.7041, Longitude = 77.1025 },
            new Airport { Code = "BLR", Latitude = 12.9716, Longitude = 77.5946 },          
        };

            var airport1 = airports.FirstOrDefault(a => a.Code == airport1Code.ToUpper());
            var airport2 = airports.FirstOrDefault(a => a.Code == airport2Code.ToUpper());

            if (airport1 == null || airport2 == null)
            {
                return NotFound("Airports Not Found.");
            }
            double airportDistance = AirportDistanceCalculator.CalculateDistance(airport1, airport2);
 
             if(airportDistance > 0)
        {
             response = new AirportResponse
            {              
                     Message = "Distance found Successfully",
                     ResponseCode = 200,
                     Distance = airportDistance                
            };
        }
          return Ok(response);
        }
        
    }
}