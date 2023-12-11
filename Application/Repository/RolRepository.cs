using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    private readonly SecurityContext _context;

    public RolRepository(SecurityContext context) : base(context)
    {
       _context = context;
    }
}
