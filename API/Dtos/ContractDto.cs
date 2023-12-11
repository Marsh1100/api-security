using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ContractDto
{
    public int Id {get; set;}
    public int IdClient { get; set; }

    public int IdEmployee { get; set; }

    public DateOnly DateContract { get; set; }

    public DateOnly DateEnd { get; set; }

    public int IdStatus { get; set; }
  
    
}
