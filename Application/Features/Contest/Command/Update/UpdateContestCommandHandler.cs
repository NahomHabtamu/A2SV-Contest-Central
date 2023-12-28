using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Contest.Commands.UpdateContest;

public class UpdateContestCommandHandler : IRequestHandler<UpdateContestCommand,Unit>
{
    private readonly IMapper _mapper;
    private readonly IContestRepository _contestRepository;
    private readonly IUserRepository _userRepository;

    public UpdateContestCommandHandler(IContestRepository contestRepository, IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _contestRepository = contestRepository;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(UpdateContestCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateContestCommandValidator(_userRepository);
        var validationResult = await validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    
        var old_contest = await _contestRepository.GetByIdAsync(command.ContestId);
        if (old_contest == null)
        {
            throw new NotFoundException($"Contest with id {command.ContestId} does't exist!", command);
        }
        
        // extract questions and replace the previous questions with the new ones
        // use transaction to make sure that all questions and the contest are updated

        var update_contest = _mapper.Map<ContestEntity>(command.UpdateContest);
        
        await _contestRepository.UpdateAsync(command.ContestId, update_contest);
        return Unit.Value;
    }
}


