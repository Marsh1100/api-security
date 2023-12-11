using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class ShiftRepository : GenericRepository<Shift>, IShift
{
    private readonly SecurityContext _context;

    public ShiftRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
