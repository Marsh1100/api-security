using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserDto>()
            .ReverseMap();
        CreateMap<Rol, RolDto>()
            .ForMember(dest=>dest.Rol, origen=> origen.MapFrom(origen=> origen.Name.ToString()))
            .ReverseMap();
        CreateMap<User,UserAllDto>()
            .ForMember(dest=>dest.Roles, origen=> origen.MapFrom(origen=> origen.Roles))
            .ReverseMap();

        CreateMap<Addressperson, AddresspersonDto>()
            .ReverseMap();
        CreateMap<Categoryperson, CategorypersonDto>()
            .ReverseMap();
        CreateMap<City, City>()
            .ReverseMap();
        CreateMap<Contactperson, ContactpersonDto>()
            .ReverseMap();
        CreateMap<Contract, ContractDto>()
            .ReverseMap();
        CreateMap<Country, CountryDto>()
            .ReverseMap();
        CreateMap<Person, PersonDto>()
            .ReverseMap();
        CreateMap<Programming, ProgrammingDto>()
            .ReverseMap();
        CreateMap<Region, RegionDto>()
            .ReverseMap();
        CreateMap<Shift, ShiftDto>()
            .ReverseMap();
        CreateMap<Status, StatusDto>()
            .ReverseMap();
        CreateMap<Typeaddress, TypeaddressDto>()
            .ReverseMap();
        CreateMap<Typecontact, TypecontactDto>()
            .ReverseMap();
        CreateMap<Typeperson, TypepersonDto>()
            .ReverseMap();

    }
}
