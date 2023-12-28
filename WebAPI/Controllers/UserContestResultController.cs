using Application.DTOs.UserContestResult;
using Application.Features.UserContestResult.Queries.GetAllUserContestResultByLocation;
using Application.Features.UserContestResult.Queries.GetUserContestResultByGroup;
using Application.Features.UserContestResult.Queries.GetUserContestResultByUserId;
using Application.Features.UserContestResult.Queries.GetUserContestResultsByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserContestResultController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserContestResultController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // get all user contest results
    [HttpGet("getAllUserContestResults")]
    public async Task<ActionResult<List<UserContestResultResponseDto>>> GetAllUserContestResults()
    {
        var response = await _mediator.Send(new GetAllUserContestResultByLocationQuery());

        return response;
    }
    
    // get all user's contest results
    [HttpGet("getUserContestResultsByUserId/{userId}")]
    public async Task<ActionResult<List<UserContestResultResponseDto>>> GetUserContestResultByUserId(Guid userId)
    {
        var response = await _mediator.Send(new GetUserContestResultsByUserId
        {
            UserId = userId
        });

        return response;
    }
    
    // get user's specific contest result
    [HttpGet("getUserContestResultByUserIdAndContestId")]
    public async Task<ActionResult<UserContestResultResponseDto>> GetUserContestResultByUserIdAndContestId(UserContestResultRequestDto userContestResultRequestDto)
    {
        var response = await _mediator.Send(new GetUserContestResultByUserIdAndContestId
        {
            UserId = userContestResultRequestDto.UserId,
            ContestId = userContestResultRequestDto.ContestId
        });

        return response;
    }
    
    // get user contest results of a group
    [HttpGet("getUserContestResultsByGroupId/{groupId}")]
    public async Task<ActionResult<List<UserContestResultResponseDto>>> GetUserContestResultsByGroupId(Guid groupId)
    {
        var response = await _mediator.Send(new GetUserContestResultByGroupQuery
        {
            GroupId = groupId
        });

        return response;
    }
    
    // get user contest results of a location
    [HttpGet("getUserContestResultsByLocationId/{locationId}")]
    public async Task<ActionResult<List<UserContestResultResponseDto>>> GetUserContestResultsByLocationId(
        Guid locationId)
    {
        var response = await _mediator.Send(new GetAllUserContestResultByLocationQuery()
        {
            LocationId = locationId
        });

        return response;
    }
}