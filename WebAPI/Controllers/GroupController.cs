using Application.DTOs.Group;
using Application.Features.Group.Commands.CreateGroup;
using Application.Features.Group.Commands.DeleteGroup;
using Application.Features.Group.Commands.UpdateGroup;
using Application.Features.Group.Queries.GetAllGroups;
using Application.Features.Group.Queries.GetOneGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroupController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("GetAllGroups")]
    public async Task<ActionResult<List<GroupResponseDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllGroupsQuery());
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetGroupById/{id:guid}")]
    public async Task<ActionResult<GroupResponseDto>> GetGroupById(Guid id)
    {
        var result = await _mediator.Send(new GetOneGroupQuery
        {
            Id = id
        });
        return Ok(result);
    }
    
    [HttpPost]
    [Route("CreateGroup")]
    public async Task<ActionResult<GroupResponseDto>> CreateGroup(GroupDto groupDto)
    {
        var result = await _mediator.Send(new CreateGroupCommand
        {
            GroupDto = groupDto
        });
        return Ok(result);
    }
    
    [HttpPut]
    [Route("UpdateGroup/{id:guid}")]
    public async Task<ActionResult<GroupResponseDto>> UpdateGroup(Guid id, GroupDto groupDto)
    {
        var result = await _mediator.Send(new UpdateGroupCommand
        {
            Id = id,
            GroupDto = groupDto
        });
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("DeleteGroup/{id:guid}")]
    public async Task<ActionResult<GroupResponseDto>> DeleteGroup(Guid id)
    {
        var result = await _mediator.Send(new DeleteGroupCommand
        {
            GroupId = id
        });
        return Ok(result);
    }
}
