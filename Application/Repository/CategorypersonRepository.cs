using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class CategorypersonRepository : GenericRepository<Categoryperson>, ICategoryperson
{
    private readonly SecurityContext _context;

    public CategorypersonRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
