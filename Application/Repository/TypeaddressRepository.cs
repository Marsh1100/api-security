using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class TypeaddressRepository : GenericRepository<Typeaddress>, ITypeaddress
{
    private readonly SecurityContext _context;

    public TypeaddressRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
