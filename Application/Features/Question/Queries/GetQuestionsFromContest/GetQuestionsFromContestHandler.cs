using Application.Contracts.Persistence;
using Application.DTOs.Question;
using AutoMapper;
using MediatR;

namespace Application.Features.Question.Queries.GetQuestionsFromContest;

public class GetQuestionsFromContestHandler : IRequestHandler<GetQuestionsFromContestRequest, IReadOnlyList<QuestionResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _questionRepository;
    
       public GetQuestionsFromContestHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
       
        public async Task<IReadOnlyList<QuestionResponseDto>> Handle(GetQuestionsFromContestRequest request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetQuestionsFromContestAsync(request.ContestId);
            return _mapper.Map<IReadOnlyList<QuestionResponseDto>>(questions);
        }

}