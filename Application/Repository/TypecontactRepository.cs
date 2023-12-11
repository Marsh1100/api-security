using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class TypecontactRepository : GenericRepository<Typecontact>, ITypecontact
{
    private readonly SecurityContext _context;

    public TypecontactRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
