using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class PersonRepository : GenericRepository<Person>, IPerson
{
    private readonly SecurityContext _context;

    public PersonRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
