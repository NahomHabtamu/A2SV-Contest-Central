using Application.Contracts.Persistence;
using Application.DTOs.UserContestResult;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.UserContestResult.Queries.GetUserContestResultByGroup;

public class GetUserContestResultByGroupHandler : IRequestHandler<GetUserContestResultByGroupQuery, List<UserContestResultResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetUserContestResultByGroupHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserContestResultResponseDto>> Handle(GetUserContestResultByGroupQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetUserContestResultByGroupValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult.Errors);
        
        var userContestResult = _mapper.Map<List<UserContestResultResponseDto>>(_unitOfWork.UserContestResultRepository.GetUserContestResultByGroupIdAsync(request.GroupId));
        
        return _mapper.Map<List<UserContestResultResponseDto>>(userContestResult);
    }
}