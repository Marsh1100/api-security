using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PersonDto
{
    public int Id {get; set;}
  
    public string Name { get; set; }

    public DateOnly DateRegister { get; set; }

    public int IdTypePerson { get; set; }

    public int IdCategoryPerson { get; set; }

    public int IdCity { get; set; }
}
