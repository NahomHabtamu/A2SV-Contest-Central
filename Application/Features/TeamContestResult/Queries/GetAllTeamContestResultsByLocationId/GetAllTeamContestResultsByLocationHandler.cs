using Application.Contracts.Persistence;
using Application.DTOs.TeamContestResult;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.TeamContestResult.Queries.GetAllTeamContestResultsByLocationId;

public class GetAllTeamContestResultsByLocationHandler : IRequestHandler<GetAllTeamContestResultsByLocationQuery, List<TeamContestResultResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTeamContestResultsByLocationHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TeamContestResultResponseDto>> Handle(GetAllTeamContestResultsByLocationQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetAllTeamContestResultsByLocationValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var teamContestResults = await _unitOfWork.TeamContestResultRepository.GetTeamContestResultsByLocationIdAsync(request.LocationId);
        
        return _mapper.Map<List<TeamContestResultResponseDto>>(teamContestResults);
    }
}