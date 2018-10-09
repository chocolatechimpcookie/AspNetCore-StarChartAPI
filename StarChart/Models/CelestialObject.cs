using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarChart
{
  public class CelestialObject
  {
    public int Id {get; set;}
    [Required]
    public string Name {get; set;}
    public int? OrbitedObjectId {get; set;}
    // public List<CelestialObject> Satellites;

  }
}
