using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class RegionRepository : GenericRepository<Region>, IRegion
{
    private readonly SecurityContext _context;

    public RegionRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
