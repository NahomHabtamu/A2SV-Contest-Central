using Application.Contracts.Persistence;
using Application.DTOs.UserContestResult;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.UserContestResult.Queries.GetAllUserContestResultByLocation;

public class GetAllUserContestResultByLocationHandler : IRequestHandler<GetAllUserContestResultByLocationQuery, List<UserContestResultResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public GetAllUserContestResultByLocationHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<UserContestResultResponseDto>> Handle(GetAllUserContestResultByLocationQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetAllUserContestResultsByLocationValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var userContestResult = _mapper.Map<UserContestResultResponseDto>(_unitOfWork.UserContestResultRepository.GetUserContestResultByLocationIdAsync(request.LocationId));
        
        return _mapper.Map<List<UserContestResultResponseDto>>(userContestResult);
    }
}