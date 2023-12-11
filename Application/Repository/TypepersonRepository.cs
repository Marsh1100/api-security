using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class TypepersonRepository : GenericRepository<Typeperson>, ITypeperson
{
    private readonly SecurityContext _context;

    public TypepersonRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
