using Microsoft.AspNetCore.Mvc;

namespace VeehicleeAPI.Controllers;

[Route(template: "api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    // GET: api/<VehiclesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET: api/<VehiclesController>/5
    [HttpGet(template: "{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST: api/<VehiclesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/<VehiclesController>/5
    [HttpPut(template: "{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/<VehiclesController>/5
    [HttpDelete(template: "{id}")]
    public void Delete(int id)
    {
    }
}