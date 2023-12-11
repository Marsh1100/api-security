using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class CityDto
{
    public int Id {get; set;}
  
    public string Name { get; set; }

    public int IdRegion { get; set; }
}
