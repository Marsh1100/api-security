using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class PersonRepository : GenericRepository<Person>, IPerson
{
    private readonly SecurityContext _context;

    public PersonRepository(SecurityContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetEmployees()
    {
        return await _context.People.Include(i=> i.IdTypePersonNavigation)
                              .Where(a=> a.IdTypePersonNavigation.Description == "Empleado")
                              .ToListAsync();
    }
    public async Task<IEnumerable<Person>> GetEmployeesVigilant()
    {
        return await _context.People.Include(i=> i.IdTypePersonNavigation).Include(e=> e.IdCategoryPersonNavigation)
                              .Where(a=> a.IdTypePersonNavigation.Description == "Empleado" && a.IdCategoryPersonNavigation.Name == "Vigilante")
                              .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetPhonesVigilant()
    {
        var people = await _context.People.ToListAsync();
        var categorypeople = await _context.Categorypeople.ToListAsync();
        var typePeople = await _context.Typepeople.ToListAsync();
        var contactPeople = await _context.Contactpeople.ToListAsync();
        var typeContacts = await _context.Typecontacts.ToListAsync();

        return (from person in people 
                join typePerson in typePeople on person.IdTypePerson equals typePerson.Id
                join categoryperson in categorypeople on person.IdCategoryPerson equals categoryperson.Id
                join contactPerson in contactPeople on person.Id equals contactPerson.IdPerson
                join typecontact in typeContacts on contactPerson.IdTypeContact equals typecontact.Id
                where typePerson.Description == "Empleado" && categoryperson.Name == "Vigilante" &&typecontact.Description == "Celular"
                select new {
                    Empleado =  person.Name,
                    Numero = contactPerson.Description
                }).ToList();
    }

    public async Task<IEnumerable<Person>> GetClientsBga()
    {
        return await _context.People.Include(i=> i.IdTypePersonNavigation).Include(e=>e.IdCityNavigation)
                              .Where(a=> a.IdTypePersonNavigation.Description == "Cliente" && a.IdCityNavigation.Name == "Bucaramanga")
                              .ToListAsync();
    }

    public async Task<IEnumerable<Person>> GetEmployeesGironPiedecuesta()
    {
        return await _context.People.Include(i=> i.IdTypePersonNavigation).Include(e=>e.IdCityNavigation)
                              .Where(a=> a.IdTypePersonNavigation.Description == "Empleado" && (a.IdCityNavigation.Name == "Giron" || a.IdCityNavigation.Name == "Piedecuesta"))
                              .ToListAsync();
    }

    public async Task<IEnumerable<Person>> GetClientsFiveYears()
    {
        return await _context.People.Include(i=> i.IdTypePersonNavigation).Include(e=>e.IdCityNavigation)
                              .Where(a=> a.IdTypePersonNavigation.Description == "Cliente" && a.DateRegister.AddYears(5)<=  DateOnly.FromDateTime(DateTime.Now))
                              .ToListAsync();
    }
    public async Task<IEnumerable<object>> GetActiveContracts()
    {
        var people = await _context.People.ToListAsync();
        var contracts = await _context.Contracts.ToListAsync();
        var statuses = await _context.Statuses.ToListAsync();
        

        return (from client in people 
                join contract in contracts on client.Id equals contract.IdClient
                join employee in people on contract.IdEmployee equals employee.Id
                join status in statuses on contract.IdStatus equals status.Id
                where status.Description == "Activo"
                select new {
                    nro_contrato = contract.Id,
                    client = client.Name,
                    employee = employee.Name
                }).ToList();

    }
}
