using Application.DTOs.Location;
using Application.Features.Location.Commands.CreateLocation;
using Application.Features.Location.Commands.DeleteLocation;
using Application.Features.Location.Commands.UpdateLocation;
using Application.Features.Location.Queries.GetAllLocations;
using Application.Features.Location.Queries.GetLocationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("GetAllLocations")]
    public async Task<ActionResult<List<LocationResponseDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllLocationsQuery());
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetLocationById/{id:guid}")]
    public async Task<ActionResult<LocationResponseDto>> LocationById(Guid id)
    {
        var result = await _mediator.Send(new GetLocationByIdQuery()
        {
            LocationId = id
        });
        return Ok(result);
    }
    
    [HttpPost]
    [Route("CreateLocation")]
    public async Task<ActionResult<LocationResponseDto>> Location(LocationDto groupDto)
    {
        var result = await _mediator.Send(new CreateLocationCommand()
        {
            LocationDto = groupDto
        });
        return Ok(result);
    }
    
    [HttpPut]
    [Route("Location/{id:guid}")]
    public async Task<ActionResult<LocationResponseDto>> Location(Guid id, LocationDto groupDto)
    {
        var result = await _mediator.Send(new UpdateLocationCommand
        {
            Id = id,
            LocationDto = groupDto
        });
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("Location/{id:guid}")]
    public async Task<ActionResult<LocationResponseDto>> Location(Guid id)
    {
        var result = await _mediator.Send(new DeleteLocationCommand
        {
            LocationId = id
        });
        return Ok(result);
    }
}
