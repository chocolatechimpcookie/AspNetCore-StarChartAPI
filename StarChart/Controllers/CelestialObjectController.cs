using Microsoft.AspNetCore.Mvc;
using System;
using StarChart.Data;
using System.Linq;

namespace StarChart.Controllers
{
  [Route("")]
  [ApiController]
  public class CelestialObjectController : ControllerBase
  {

    private readonly ApplicationDbContext _context;
    public CelestialObjectController(ApplicationDbContext thecontext)
    {
      _context = thecontext;
    }

    [HttpGet("{id:int}", Name = "GetById")]
    public IActionResult GetById(int id)
    {
      var celestialObject = _context.CelestialObjects.Find(id);

      if(celestialObject == null)
        return NotFound();

      celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == id).ToList();

      return Ok(celestialObject);
    }

  }
}
