using Microsoft.AspNetCore.Mvc;

namespace VeehicleeAPI.Controllers  // 👈 usa tu namespace exacto
{
    [ApiController]
    [Route("api/[controller]")]   // quedará: api/vehicles
    public class VehiclesController : ControllerBase
    {
        // GET api/vehicles
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/vehicles/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}