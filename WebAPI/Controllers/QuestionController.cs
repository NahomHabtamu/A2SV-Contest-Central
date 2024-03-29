﻿using Application.DTOs.Question;
using Application.Features.Question.Queries.CheckDuplicate;
using Application.Features.Question.Queries.GetAll;
using Application.Features.Question.Queries.GetQuestionsFromContest;
using Application.Features.Question.Queries.GetSingle;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Question.Commands.CreateOrUpdate;
using Microsoft.AspNetCore.Cors;
using Application.Features.Question.Commands.CreateFromExt;

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
    public async Task<ActionResult<QuestionDuplicateCheckResponseDto>> CheckDuplicate(string questionUrl)
    {
        var question = await _mediator.Send(new CheckDuplicateQuestionRequest { GlobalQuestionUrl = questionUrl });
        
        return Ok(question);
    }

    [HttpGet]
    [Route("GetQuestionsFromContest")]
    public async Task<ActionResult<IReadOnlyList<QuestionResponseDto>>> GetQuestionsFromContest(Guid contestId)
    {
        var questions = await _mediator.Send(new GetQuestionsFromContestRequest { ContestId = contestId });

        return Ok(questions);

    }

    [HttpPost]
    [Route("CreateOrUpdateQuestions")]
    public async Task<ActionResult<bool>> CreateOrUpdateQuestions(QuestionRequestDto questions)
    {
       bool res = await _mediator.Send(new CreateFromExtQuestionCommand {  NewQuestions = questions });

        return Ok(new { status = res });
    }
}