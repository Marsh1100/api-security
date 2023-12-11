using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ShiftDto
{
    public int Id {get; set;}
  
    public string Name { get; set; }

    public TimeOnly HourStart { get; set; }

    public TimeOnly HourEnd { get; set; }
}
