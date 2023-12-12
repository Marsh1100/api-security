using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ContactpersonDto
{
    public int Id {get; set;}
    public string Description { get; set; }

    public int IdPerson { get; set; }

    public int IdTypeContact { get; set; }
  
}
