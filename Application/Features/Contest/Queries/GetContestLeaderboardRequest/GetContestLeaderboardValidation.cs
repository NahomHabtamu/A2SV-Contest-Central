﻿using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Contest.Queries;

public class GetContestLeaderboardValidation : AbstractValidator<GetContestLeaderboardRequest>
{
    public GetContestLeaderboardValidation(IUnitOfWork unitOfWork)
    {
        RuleFor(req => req.ContestId)
            .NotEmpty()
            .WithMessage("Contest URL cannot be empty.")
            .MustAsync(async (contestId, token) => await unitOfWork.ContestRepository.Exists(contestId))
            .WithMessage("Invalid Codeforces contest URL.");
    }
}