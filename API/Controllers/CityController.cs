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

public class CityController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CityController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CityDto>>> Get()
    {
        var users = await _unitOfWork.Cities.GetAllAsync();
        return _mapper.Map<List<CityDto>>(users);
    }   

    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CityDto>> Post([FromBody] CityDto dto)
    {
        var result = _mapper.Map<City>(dto);
        this._unitOfWork.Cities.Add(result);
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

    public async Task<ActionResult<CityDto>> put(CityDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<City>(dto);
        this._unitOfWork.Cities.Update(result);
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
        var result = await _unitOfWork.Cities.GetByIdAsync(id);
        if(result == null){return NotFound();}
        this._unitOfWork.Cities.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }
    
    
    
}