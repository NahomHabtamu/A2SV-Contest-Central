using Application.DTOs.UserQuestionResult;
using Application.Features.UserQuestionResult.Queries.GetAllUserQuestionResult;
using Application.Features.UserQuestionResult.Queries.GetUserQuestionResultByQuestionIdUserId;
using Application.Features.UserQuestionResult.Queries.GetUserQuestionResultByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserQuestionResultController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserQuestionResultController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<UserQuestionsResultResponseDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllUserQuestionResultQuery());
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetByUserId/{userId:guid}")]
    public async Task<ActionResult<List<UserQuestionsResultResponseDto>>> GetByUserId(Guid userId)
    {
        var result = await _mediator.Send(new GetUserQuestionResultByUserIdQuery
        {
            UserId = userId
        });
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetByQuestionAndUserIdId")]
    public async Task<ActionResult<UserQuestionsResultResponseDto>> GetByQuestionAndUserIdId(Guid questionId, Guid userId)
    {
        var result = await _mediator.Send(new GetUserQuestionResultByQuestionIdUserIdQuery
        {
            UserId = userId, QuestionId = questionId
        });
        return Ok(result);
    }
    
    
    
    
}