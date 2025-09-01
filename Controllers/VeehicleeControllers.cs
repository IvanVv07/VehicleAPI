using Microsoft.AspNetCore.Mvc;

namespace VeehicleeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VeehicleeController : ControllerBase
{
    //GET:api/<VeehicleesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] {"Value 1", "Value 2"};
    }
    //GET api/<VeehicleesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }
    //POST api/<VeehicleesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
        
    }
    //PUT api/<VeehicleesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
        
    }
    //DELETE api/<VeehicleesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        
    }
}