using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Parks.Controllers
{
  [EnableCors("Policy1")]
  [Route("api/1.0/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  public class ParksController : ControllerBase
  {
    private readonly ParksContext _db;
    private readonly IUriService _uriService;

    public ParksController(ParksContext db, IUriService uriService)
    {
      _db = db;
      this._uriService = uriService;
    }

    /// <summary>
    /// Returns a paged list of Parks that correspond with any search queries in the URL
    /// </summary>
    [HttpGet]
    //  [FromQuery] attribute means PaginationFilter's constructor get non-default values
    // from search query part of request (i.e. ?pageNumber=2 appended to URL changes 
    // value of pageNumber property in PaginationFilters constructor from 1 to 2)
    public async Task<ActionResult<IEnumerable<Park>>> Get([FromQuery] PaginationFilter filter, string name, string city, string state, bool swimming, bool hiking, int size )
    {
      var route = Request.Path.Value;
      var query = _db.Parks.AsQueryable();
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

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

      var pagedData = await query
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToListAsync();

      var totalRecords = await _db.Parks.CountAsync();
      var pagedReponse = PaginationHelper.CreatePagedReponse<Park>(pagedData, validFilter, totalRecords, _uriService, route);
      return Ok(pagedReponse);
    }


    /// <summary>
    /// Creates a new Park object
    /// </summary>
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
    /// <param name="id"></param> 
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
        // var park = await _db.Parks.FindAsync(id);

        // if (park == null)
        // {
        //     return NotFound();
        // }
        var park = await _db.Parks.Where(a => a.ParkId == id).FirstOrDefaultAsync();
        return Ok(new Response<Park>(park));
    }

    /// <summary>
    /// Modifies properties of an already existing Park
    /// </summary>
    /// <param name="id"></param> 
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
