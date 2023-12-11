using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class CityRepository : GenericRepository<City>, ICity
{
    private readonly SecurityContext _context;

    public CityRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
