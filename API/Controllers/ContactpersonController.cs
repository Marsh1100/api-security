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

public class ContactpersonController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContactpersonController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ContactpersonDto>>> Get()
    {
        var users = await _unitOfWork.Contactpeople.GetAllAsync();
        return _mapper.Map<List<ContactpersonDto>>(users);
    }   

    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactpersonDto>> Post([FromBody] ContactpersonDto dto)
    {
        var result = _mapper.Map<Contactperson>(dto);
        this._unitOfWork.Contactpeople.Add(result);
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

    public async Task<ActionResult<ContactpersonDto>> put(ContactpersonDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Contactperson>(dto);
        this._unitOfWork.Contactpeople.Update(result);
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
        var result = await _unitOfWork.Contactpeople.GetByIdAsync(id);
        if(result == null){return NotFound();}
        this._unitOfWork.Contactpeople.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }
    
    
    
}