using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ProgrammingDto
{
    public int Id {get; set;}
    public int IdContract { get; set; }

    public int IdShift { get; set; }

    public int IdEmployee { get; set; }
    
}
