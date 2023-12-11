using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class ContractRepository : GenericRepository<Contract>, IContract
{
    private readonly SecurityContext _context;

    public ContractRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

   

    
}
