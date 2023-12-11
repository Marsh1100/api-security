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

public class AddresspersonController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddresspersonController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<AddresspersonDto>>> Get()
    {
        var users = await _unitOfWork.Addresspeople.GetAllAsync();
        return _mapper.Map<List<AddresspersonDto>>(users);
    }   

    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddresspersonDto>> Post([FromBody] AddresspersonDto dto)
    {
        var result = _mapper.Map<Addressperson>(dto);
        this._unitOfWork.Addresspeople.Add(result);
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

    public async Task<ActionResult<AddresspersonDto>> put(AddresspersonDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Addressperson>(dto);
        this._unitOfWork.Addresspeople.Update(result);
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
        var result = await _unitOfWork.Addresspeople.GetByIdAsync(id);
        if(result == null){return NotFound();}
        this._unitOfWork.Addresspeople.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }
    
    
    
}