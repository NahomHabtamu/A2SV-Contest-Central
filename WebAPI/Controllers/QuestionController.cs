using Application.DTOs.Question;
using Application.Features.Question.Queries.CheckDuplicate;
using Application.Features.Question.Queries.GetAll;
using Application.Features.Question.Queries.GetQuestionsFromContest;
using Application.Features.Question.Queries.GetSingle;
using Microsoft.AspNetCore.Mvc;
using MediatR;
namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public QuestionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<QuestionResponseDto>> GetAll()
    {
        var questions = await _mediator.Send(new GetAllQuestionRequest());
        return Ok(questions);
    }

    [HttpGet]
    [Route("GetSingle")]
    public async Task<ActionResult< QuestionResponseDto>> GetSingle(Guid questionId)
    {
        var question = await _mediator.Send(new GetSingleQuestionRequest { QuestionId = questionId });
        
        return Ok(question);
    }
    
    [HttpGet]
    [Route("CheckDuplicate")]
    public async Task<ActionResult<bool>> CheckDuplicate(string questionText)
    {
        var question = await _mediator.Send(new CheckDuplicateQuestionRequest { GlobalQuestionUrl = questionText });
        
        return Ok(question);
    }

    [HttpGet]
    [Route("GetQuestionsFromContest")]
    public async Task<ActionResult<IReadOnlyList<QuestionResponseDto>>> GetQuestionsFromContest(Guid contestId)
    {
        var questions = await _mediator.Send(new GetQuestionsFromContestRequest { ContestId = contestId });

        return Ok(questions);

    }
}