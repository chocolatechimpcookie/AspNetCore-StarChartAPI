using Microsoft.AspNetCore.Mvc;
using System;
using StarChart.Data;
using StarChart.Models;
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

    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
      var celestialObjects = _context.CelestialObjects.Where(e => e.Name == name).ToList();


      if(!celestialObjects.Any())
        return NotFound();

      foreach(var celestialObject in celestialObjects)
      {
        celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == celestialObject.Id).ToList();
      }

      return Ok(celestialObjects);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var celestialObjects = _context.CelestialObjects.ToList();

      foreach(var celestialObject in celestialObjects)
      {

        celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == celestialObject.Id).ToList();
      }


      return Ok(celestialObjects);
    }

    [HttpPost]
    public IActionResult Create([FromBody]CelestialObject celestialObject)
    {
      _context.CelestialObjects.Add(celestialObject);
      _context.SaveChanges();
      return CreatedAtRoute("GetById", new {id = celestialObject.Id}, celestialObject);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CelestialObject celestialObject)
    {

      //This method should locate the CelestialObject with an Id that matches the provided int parameter.
      var existingObject = _context.CelestialObjects.Find(id);

      if (existingObject == null)
        return NotFound();

      //If a match is found set it's Name, OrbitalPeriod, and OrbitedObject properties
      //based on the provided CelestialObject parameter. Call Update on the CelestialObjects
      //DbSet with an argument of the updated CelestialObject, and then call SaveChanges.
      existingObject.Name = celestialObject.Name;
      existingObject.OrbitalPeriod = celestialObject.OrbitalPeriod;
      existingObject.OrbitalObjectId = celestialObject.OrbitalObjectId;

      _context.CelestialObjects.Update();
      _context.SaveChanges();

      return NoContent();

    }

  }
}
