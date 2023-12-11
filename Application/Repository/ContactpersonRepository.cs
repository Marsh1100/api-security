using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class ContactpersonRepository : GenericRepository<Contactperson>, IContactperson
{
    private readonly SecurityContext _context;

    public ContactpersonRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
