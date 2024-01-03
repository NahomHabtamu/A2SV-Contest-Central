﻿using Application.Contracts.Persistence;
using Application.DTOs.GlobalQuestion;
using Application.DTOs.Question;
using MediatR;
using AutoMapper;

namespace Application.Features.Question.Queries.CheckDuplicate;

public class CheckDuplicateQuestionHandler : IRequestHandler<CheckDuplicateQuestionRequest, QuestionDuplicateCheckResponseDto>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    
    public CheckDuplicateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }
    
    public async Task<QuestionDuplicateCheckResponseDto> Handle(CheckDuplicateQuestionRequest request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.GetQuestionsByGlobalQuestionUrl(request.GlobalQuestionUrl);

        var groups = new HashSet<string>();
        foreach (var question in questions)
        {
            groups.UnionWith(question.Contest.ContestGroups.Select(cg => cg.Group.Name).ToList());
        }
        Console.WriteLine("count: " + groups.Count);
        var response = new QuestionDuplicateCheckResponseDto
        {
            Status = questions.Count != 0,
            Group = groups.ToList(),
            NumberOfTimesUsed = questions.Count
        };
        
        return response;
    }
    
    
}