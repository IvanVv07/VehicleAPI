using System.Collections;
using Microsoft.AspNetCore.Mvc;
using VeehicleeAPI.Models;

namespace VeehicleeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VeehicleeController : ControllerBase
{
    private static readonly List<Vehicle> Data = [];
    //GET:api/<Veehiclees?Make=Ford&year=2025
    [HttpGet]
    public ActionResult<IEnumerable<Vehicle>> Get(string? make, int? year)
    {
       var result =Data.AsEnumerable();
       if (string.IsNullOrWhiteSpace(make))
       {
           result = result.Where(v =>
               v.Make.Contains(make, StringComparison.InvariantCultureIgnoreCase));
       }

       if (year > 0)
       {
           result = result.Where(v => v.Year == year);
       }
       return Ok(result.ToArray());
    }
    //GET api/Veehiclees/{id}
    [HttpGet("{id:guid}")]
    public ActionResult<Vehicle> Get(Guid id)
    {
        var vehicle = Data.FirstOrDefault(v => v.Id == id);
        if (vehicle == null) return NotFound();
        return Ok(vehicle);
    }
    //POST api/<Veehiclees
    [HttpPost]
    public ActionResult<Vehicle> Creat(Vehicle vehicle)
    {
        Data.Add(vehicle);
        return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
    }
    //PUT api/<Veehiclees/{id}
    [HttpPut("{id:guid}")]
    public IActionResult Replace(Guid id, Vehicle vehicle)
    {
        var existing = Data.FirstOrDefault(v => v.Id == id);
        if (existing == null) return NotFound();
        existing.Make = vehicle.Make;
        existing.Model = vehicle.Model;
        existing.Year = vehicle.Year;
        return NoContent();
    }
    //DELETE api/<Veehiclees/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var existing = Data.FirstOrDefault(v => v.Id == id);
        if (existing == null) return NotFound();
        Data.Remove(existing);
        return NoContent();
    }
}
