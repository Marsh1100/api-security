# api-security
Proyecto webapi de cuatro capas.

1. Lista todos los empleados de la empresa de seguridad
```
localhost:5000/api/Person/empleados
```
```c#
public async Task<List<Person>> GetEmployees()
    {
        return await _context.People.Include(i=> i.IdTypePersonNavigation)
                              .Where(a=> a.IdTypePersonNavigation.Description == "Empleado")
                              .ToListAsync();
    }
```
2. Lista todos los empleados que son vigilantes
```
localhost:5000/api/Person/empleadosVigilantes
```
```c#
public async Task<List<Person>> GetEmployeesVigilant()
    {
        return await _context.People.Include(i=> i.IdTypePersonNavigation).Include(e=> e.IdCategoryPersonNavigation)
                              .Where(a=> a.IdTypePersonNavigation.Description == "Empleado" && a.IdCategoryPersonNavigation.Name == "Vigilante")
                              .ToListAsync();
    }
```
3. Lista los numeros de contacto de un empleado que sea vigilante.
```
localhost:5000/api/Person/telefonosVigilates
```
```c#
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
```
4. Lista todos los clientes que vivan en la ciudad de Bucaramanga.
```
localhost:5000/api/Person/clientesBga
```
```c#
public async Task<IEnumerable<Person>> GetClientsBga()
    {
        return await _context.People.Include(i=> i.IdTypePersonNavigation).Include(e=>e.IdCityNavigation)
                              .Where(a=> a.IdTypePersonNavigation.Description == "Cliente" && a.IdCityNavigation.Name == "Bucaramanga")
                              .ToListAsync();
    }
```
5. Lista todos los empleados que vivan en Giron y Piedecuesta.
```
localhost:5000/api/Person/empleadosGironPiedecusta
```
```c#
public async Task<IEnumerable<Person>> GetEmployeesGironPiedecuesta()
    {
        return await _context.People.Include(i=> i.IdTypePersonNavigation).Include(e=>e.IdCityNavigation)
                              .Where(a=> a.IdTypePersonNavigation.Description == "Empleado" && (a.IdCityNavigation.Name == "Giron" || a.IdCityNavigation.Name == "Piedecuesta"))
                              .ToListAsync();
    }
```
6. Lista todos los clientes que tengan mas de 5 años de antiguedad.
```
localhost:5000/api/Person/clientesAntiguos5
```
```c#
 public async Task<IEnumerable<Person>> GetClientsFiveYears()
    {
        return await _context.People.Include(i=> i.IdTypePersonNavigation).Include(e=>e.IdCityNavigation)
                              .Where(a=> a.IdTypePersonNavigation.Description == "Cliente" && a.DateRegister.AddYears(5)<=  DateOnly.FromDateTime(DateTime.Now))
                              .ToListAsync();
    }
```
7. Lista todos los contratos cuyo estado es activo. Se debe mostrar el nro de contrato el nombre del cliente y el empleado que registro el contrato.
```
localhost:5000/api/Person/contratosActivos
```
```c#
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
```
