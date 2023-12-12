using Domain.Entities;

namespace Domain.Interfaces;

public interface IPerson : IGenericRepository<Person> 
{ 
    
    Task<IEnumerable<Person>> GetEmployees();
    Task<IEnumerable<Person>> GetEmployeesVigilant();
    Task<IEnumerable<object>> GetPhonesVigilant();
    Task<IEnumerable<Person>> GetClientsBga();

    Task<IEnumerable<Person>> GetEmployeesGironPiedecuesta();
    Task<IEnumerable<Person>> GetClientsFiveYears();
    Task<IEnumerable<object>> GetActiveContracts();

}
