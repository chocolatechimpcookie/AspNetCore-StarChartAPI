using Microsoft.AspNetCore.Mvc;
using System;
using StarChart.Data;

namespace StarChart.Controllers
{
  [Route("")]
  [ApiController]
  public class CelestialObjectController : ControllerBase
  {
    private readonly ApplicationDbContext _context;


  }
}
