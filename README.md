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

```
```c#

```
