using Application.Contracts.Persistence;
using Application.DTOs.UserContestResult;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.UserContestResult.Queries.GetUserContestResultByUserId;

public class GetUserContestResultByUserIdAndContestIdHandler : IRequestHandler<GetUserContestResultByUserIdAndContestId, UserContestResultResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetUserContestResultByUserIdAndContestIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserContestResultResponseDto> Handle(GetUserContestResultByUserIdAndContestId request, CancellationToken cancellationToken)
    {
        var validator = new GetUserContestResultByUserIdAndContestIdValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var userContestResult = await _unitOfWork.UserContestResultRepository.GetUserContestResultByUserIdAndContestIdAsync(request.UserId, request.ContestId);
        return _mapper.Map<UserContestResultResponseDto>(userContestResult);
    }
}