using Application.Contracts.Persistence;
using Application.DTOs.UserContestResult;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.UserContestResult.Queries.GetUserContestResultsByUserId;

public class GetUserContestResultsByUserIdHandler : IRequestHandler<GetUserContestResultsByUserId, List<UserContestResultResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetUserContestResultsByUserIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserContestResultResponseDto>> Handle(GetUserContestResultsByUserId request, CancellationToken cancellationToken)
    {
        var validator = new GetUserContestResultsByUserIdValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var userContestResults = await _unitOfWork.UserContestResultRepository.GetUserContestResultByUserIdAsync(request.UserId);
        
        return _mapper.Map<List<UserContestResultResponseDto>>(userContestResults);
    }
}