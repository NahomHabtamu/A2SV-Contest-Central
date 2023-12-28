using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.DTOs.Contest;
using Application.Exceptions;
using Application.Features.Contest.Command.Create;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Contest.Commands.CreateContest;

public class CreateContestCommandHandler : IRequestHandler<CreateContestCommand,ContestResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IContestRepository _contestRepository;
    private readonly IUserRepository _userRepository;
    
    public CreateContestCommandHandler(IContestRepository contestRepository, IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _contestRepository = contestRepository;
        _userRepository = userRepository;
    }

    public async Task<ContestResponseDto> Handle(CreateContestCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateContestCommandValidator(_userRepository);
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // extract questions
        // user transaction to make sure all questions and the contest are created
        // we need another handler for fetching contest standing using the api  
        var new_contest = _mapper.Map<ContestEntity>(command.NewContest);
        // contest.UserId = ;

        var createdContest = await _contestRepository.CreateAsync(new_contest);

        return _mapper.Map<ContestResponseDto>(createdContest);
    }
}