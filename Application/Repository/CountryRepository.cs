using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class CountryRepository : GenericRepository<Country>, ICountry
{
    private readonly SecurityContext _context;

    public CountryRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
