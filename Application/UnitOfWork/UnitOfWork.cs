using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SecurityContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;

    private IAddressperson _addresspeople;
   
    private ICategoryperson _categorypeople; 
    private ICity _cities;
   
    private IContactperson _Contactpeople; 
    private IContract _Contracts;
   
    private ICountry _Countries; 
    private IPerson _People;
   
    private IProgramming _Programmings; 
    private IRegion _Regions;
   
    private IShift _Shifts; 
    private IStatus _Statuses;
   
    private ITypeaddress _Typeaddresses; 
    private ITypecontact _Typecontacts;
   
    private ITypeperson _Typepeople; 
  
    public UnitOfWork(SecurityContext context)
    {
        _context = context;
    }
    public IRolRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }
    public IAddressperson Addresspeople
    {
        get
        {
            if (_addresspeople == null)
            {
                _addresspeople = new AddresspersonRepository(_context);
            }
            return _addresspeople;
        }
    }
    public ICategoryperson Categorypeople
    {
        get
        {
            if (_categorypeople == null)
            {
                _categorypeople = new CategorypersonRepository(_context);
            }
            return _categorypeople;
        }
    }
    public ICity Cities
    {
        get
        {
            if (_cities == null)
            {
                _cities = new CityRepository(_context);
            }
            return _cities;
        }
    }
    public IContactperson Contactpeople
    {
        get
        {
            if (_Contactpeople == null)
            {
                _Contactpeople = new ContactpersonRepository(_context);
            }
            return _Contactpeople;
        }
    }
    public IContract Contracts
    {
        get
        {
            if (_Contracts == null)
            {
                _Contracts = new ContractRepository(_context);
            }
            return _Contracts;
        }
    }
    public ICountry Countries
    {
        get
        {
            if (_Countries == null)
            {
                _Countries = new CountryRepository(_context);
            }
            return _Countries;
        }
    }
    public IPerson People
    {
        get
        {
            if (_People == null)
            {
                _People = new PersonRepository(_context);
            }
            return _People;
        }
    }
    public IProgramming Programmings
    {
        get
        {
            if (_Programmings == null)
            {
                _Programmings = new ProgrammingRepository(_context);
            }
            return _Programmings;
        }
    }
    public IRegion Regions
    {
        get
        {
            if (_Regions == null)
            {
                _Regions = new RegionRepository(_context);
            }
            return _Regions;
        }
    }
    public IShift Shifts
    {
        get
        {
            if (_Shifts == null)
            {
                _Shifts = new ShiftRepository(_context);
            }
            return _Shifts;
        }
    }

    public IStatus Statuses
    {
        get
        {
            if (_Statuses == null)
            {
                _Statuses = new StatusRepository(_context);
            }
            return _Statuses;
        }
    }
    public ITypeaddress Typeaddresses
    {
        get
        {
            if (_Typeaddresses == null)
            {
                _Typeaddresses = new TypeaddressRepository(_context);
            }
            return _Typeaddresses;
        }
    }


    public ITypecontact Typecontacts
    {
        get
        {
            if (_Typecontacts == null)
            {
                _Typecontacts = new TypecontactRepository(_context);
            }
            return _Typecontacts;
        }
    }


    public ITypeperson Typepeople
    {
        get
        {
            if (_Typepeople == null)
            {
                _Typepeople = new TypepersonRepository(_context);
            }
            return _Typepeople;
        }
    }



    
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}