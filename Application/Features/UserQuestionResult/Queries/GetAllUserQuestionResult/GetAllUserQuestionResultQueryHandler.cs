using Application.Contracts.Persistence;
using Application.DTOs.UserQuestionResult;
using AutoMapper;
using MediatR;

namespace Application.Features.UserQuestionResult.Queries.GetAllUserQuestionResult;

public class GetAllUserQuestionResultQueryHandler : IRequestHandler<GetAllUserQuestionResultQuery, List<UserQuestionsResultResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUserQuestionResultQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<UserQuestionsResultResponseDto>> Handle(GetAllUserQuestionResultQuery request, CancellationToken cancellationToken)
    {
        var questionResults = await _unitOfWork.UserQuestionResultRepository.GetAllAsync();
        return _mapper.Map<List<UserQuestionsResultResponseDto>>(questionResults);
    }
}