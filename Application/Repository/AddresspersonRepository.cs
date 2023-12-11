using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class AddresspersonRepository : GenericRepository<Addressperson>, IAddressperson
{
    private readonly SecurityContext _context;

    public AddresspersonRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

  

    
}
