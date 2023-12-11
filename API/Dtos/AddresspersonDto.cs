using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class AddresspersonDto
{
    public int Id {get; set;}
    public string Address { get; set; }

    public int IdPerson { get; set; }

    public int IdTypeAddress { get; set; }
    
}
