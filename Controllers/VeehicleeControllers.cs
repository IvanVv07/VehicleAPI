using Microsoft.AspNetCore.Mvc;
using VeehicleeAPI.Models;
using System.Linq;

namespace VeehicleeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VeehicleeController : ControllerBase
{
    private static readonly List<Vehicle> Data = new();

    // GET: api/Veehiclee?make=Ford&year=2025  (parámetros OPCIONALES)
    [HttpGet]
    public ActionResult<IEnumerable<Vehicle>> Get([FromQuery] string? make, [FromQuery] int? year)
    {
        IEnumerable<Vehicle> result = Data;

        // Solo filtro por 'make' si viene con valor (evita ArgumentNullException)
        if (!string.IsNullOrWhiteSpace(make))
            result = result.Where(v => (v.Make ?? string.Empty)
                .Contains(make, StringComparison.InvariantCultureIgnoreCase));

        // Solo filtro por 'year' si viene con valor
        if (year.HasValue)
            result = result.Where(v => v.Year == year.Value);

        return Ok(result.ToArray());
    }

    // GET api/Veehiclee/{id}
    [HttpGet("{id:guid}")]
    public ActionResult<Vehicle> GetById(Guid id)
    {
        var vehicle = Data.FirstOrDefault(v => v.Id == id);
        return vehicle is null ? NotFound() : Ok(vehicle);
    }

    // POST api/Veehiclee
    [HttpPost]
    public ActionResult<Vehicle> Create([FromBody] Vehicle vehicle)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        if (vehicle.Id == Guid.Empty)
            vehicle.Id = Guid.NewGuid();

        Data.Add(vehicle);
        // Apunta al GET by id
        return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
    }

    // PUT api/Veehiclee/{id}
    [HttpPut("{id:guid}")]
    public IActionResult Replace(Guid id, [FromBody] Vehicle vehicle)
    {
        var existing = Data.FirstOrDefault(v => v.Id == id);
        if (existing is null) return NotFound();

        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        existing.Make  = vehicle.Make;
        existing.Model = vehicle.Model;
        existing.Year  = vehicle.Year;
        return NoContent();
    }

    // DELETE api/Veehiclee/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var existing = Data.FirstOrDefault(v => v.Id == id);
        if (existing is null) return NotFound();

        Data.Remove(existing);
        return NoContent();
    }
}