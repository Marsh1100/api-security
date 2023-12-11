using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRolRepository Roles { get; }
    IUserRepository Users { get; }

    IAddressperson Addresspeople {get;}
    ICategoryperson Categorypeople {get;}
    ICity Cities  {get;}
    IContactperson Contactpeople {get;}
    IContract Contracts {get;}
    ICountry Countries {get;}
    IPerson People {get;}
    IProgramming Programmings {get;}
    IRegion Regions {get;}
    IShift Shifts {get;}

    IStatus Statuses {get;}
    ITypeaddress Typeaddresses {get;}
    ITypecontact Typecontacts {get;}
    ITypeperson Typepeople {get;}
    Task<int> SaveAsync();
}
