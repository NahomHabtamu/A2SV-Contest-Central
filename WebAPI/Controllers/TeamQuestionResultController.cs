using Application.DTOs.TeamQuestionResult;
using Application.Features.TeamQuestionResult.Queries.GetAllTeamQuestionResult;
using Application.Features.TeamQuestionResult.Queries.GetTeamQuestionResultByQuestionIdTeamId;
using Application.Features.TeamQuestionResult.Queries.GetTeamQuestionResultByTeamId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamQuestionResultController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeamQuestionResultController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<TeamQuestionResultResponseDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllTeamQuestionResultQuery());
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetByTeamId/{teamId:guid}")]
    public async Task<ActionResult<List<TeamQuestionResultResponseDto>>> GetByTeamId(Guid teamId)
    {
        var result = await _mediator.Send(new GetTeamQuestionResultByTeamIdQuery
        {
            TeamId = teamId
        });
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetByQuestionAndTeamId")]
    public async Task<ActionResult<TeamQuestionResultResponseDto>> GetByQuestionAndTeamId(Guid questionId, Guid teamId)
    {
        var result = await _mediator.Send(new GetTeamQuestionResultByQuestionIdTeamIdQuery
        {
            TeamId = teamId, QuestionId = questionId
        });
        return Ok(result);
    }
    
}