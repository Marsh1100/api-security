using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ShiftDto
{
    public int Id {get; set;}
  
    public string Name { get; set; }

    public int HourStart { get; set; }

    public int HourEnd { get; set; }
}
