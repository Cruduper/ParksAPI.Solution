using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Cors;


namespace Parks.Controllers
{
  [EnableCors("Policy1")]
  [Route("api/1.0/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  public class ParksController : ControllerBase
  {
    private readonly ParksContext _db;

    public ParksController(ParksContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Returns a paged list of Parks that correspond with any search queries in the URL
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="park"></param> 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string city, string state, bool swimming, bool hiking, int size )
    {
      var query = _db.Parks.AsQueryable();

      if (name != null)
      {
        Console.WriteLine("name is not null");
        query = query.Where(entry => entry.Name == name);
      }
      if (city != null)
      {
        Console.WriteLine("name is not null");
        query = query.Where(entry => entry.City == city);
      }
      if (state != null)
      {
        Console.WriteLine("name is not null");
        query = query.Where(entry => entry.State == state);
      }
      if (size > 0)
      {
        query = query.Where(entry => entry.Size > size);
      }

      return await query.ToListAsync();
    }

    // POST api/animals
    /// <summary>
    /// Creates a new Park object
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="park"></param> 
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }


    /// <summary>
    /// Returns a single Park object that has a ParkId value matching the id passed into the URL
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="park"></param> 
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
        var park = await _db.Parks.FindAsync(id);

        if (park == null)
        {
            return NotFound();
        }

        return park;
    }

    /// <summary>
    /// Modifies properties of an already existing Park
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="park"></param> 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Entry(park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
        return NoContent();
      }

      /// <summary>
      /// Deletes a specific Park with a ParkId value matching the id passed into the URL.
      /// </summary>
      /// <param name="id"></param>  
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeletePark(int id)
      {
        var park = await _db.Parks.FindAsync(id);
        if (park == null)
        {
          return NotFound();
        }

        _db.Parks.Remove(park);
        await _db.SaveChangesAsync();

        return NoContent();
      }

      private bool ParkExists(int id)
      {
        return _db.Parks.Any(e => e.ParkId == id);
      }
  }
}
