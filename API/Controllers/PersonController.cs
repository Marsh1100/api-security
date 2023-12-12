using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class PersonController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
    {
        var users = await _unitOfWork.People.GetAllAsync();
        return _mapper.Map<List<PersonDto>>(users);
    }   

    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonDto>> Post([FromBody] PersonDto dto)
    {
        var result = _mapper.Map<Person>(dto);
        this._unitOfWork.People.Add(result);
        await _unitOfWork.SaveAsync();


        if(result == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new{id=result.Id}, result);
    }


    [HttpPut()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PersonDto>> put(PersonDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Person>(dto);
        this._unitOfWork.People.Update(result);
        Console.WriteLine(await this._unitOfWork.SaveAsync());
        return Ok(result);
    }


    [HttpDelete("{id}")]
    [Authorize(Roles ="Administrator")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.People.GetByIdAsync(id);
        if(result == null){return NotFound();}
        this._unitOfWork.People.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }

    //1

    [HttpGet("empleados")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PersonDto>>> GetEmployees()
    {
        var users = await _unitOfWork.People.GetEmployees();
        return _mapper.Map<List<PersonDto>>(users);
    } 
    //2
    [HttpGet("empleadosVigilantes")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PersonDto>>> GetEmployeesVigilant()
    {
        var users = await _unitOfWork.People.GetEmployeesVigilant();
        return _mapper.Map<List<PersonDto>>(users);
    } 

    //3
    [HttpGet("telefonosVigilates")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> GetPhonesVigilant()
    {
        var users = await _unitOfWork.People.GetPhonesVigilant();
        return Ok(users);
    } 

     //4
    [HttpGet("clientesBga")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async  Task<ActionResult<IEnumerable<PersonDto>>> GetClientsBga()
    {
        var users = await _unitOfWork.People.GetClientsBga();
        return _mapper.Map<List<PersonDto>>(users);
    } 

    //5
    [HttpGet("empleadosGironPiedecusta")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PersonDto>>> GetEmployeesGironPiedecuesta()
    {
        var users = await _unitOfWork.People.GetEmployeesGironPiedecuesta();
        return _mapper.Map<List<PersonDto>>(users);
    } 
     //6
    [HttpGet("clientesAntiguos5")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async  Task<ActionResult<IEnumerable<PersonDto>>> GetClientsFiveYears()
    {
        var users = await _unitOfWork.People.GetClientsFiveYears();
        return _mapper.Map<List<PersonDto>>(users);
    } 

     //7
    [HttpGet("contratosActivos")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async  Task<ActionResult> GetActiveContracts()
    {
        var users = await _unitOfWork.People.GetActiveContracts();
         return Ok(users);
    } 
    
}