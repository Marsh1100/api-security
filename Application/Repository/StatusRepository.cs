using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class StatusRepository : GenericRepository<Status>, IStatus
{
    private readonly SecurityContext _context;

    public StatusRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
