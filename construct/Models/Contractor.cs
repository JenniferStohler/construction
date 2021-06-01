using System;
using System.ComponentModel.DataAnnotations;

namespace construct.Models
{

  public class Contractor
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Location { get; set; }
  }
}
