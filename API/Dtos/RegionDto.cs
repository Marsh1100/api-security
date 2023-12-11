using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class RegionDto
{
    public int Id {get; set;}
  
    public string Name { get; set; }

    public int IdCountry { get; set; }
}
