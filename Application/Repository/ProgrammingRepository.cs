using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class ProgrammingRepository : GenericRepository<Programming>, IProgramming
{
    private readonly SecurityContext _context;

    public ProgrammingRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
