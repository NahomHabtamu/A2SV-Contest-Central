using Application.Contracts.Persistence;
using MediatR;
using AutoMapper;

namespace Application.Features.Question.Queries.CheckDuplicate;

public class CheckDuplicateQuestionHandler : IRequestHandler<CheckDuplicateQuestionRequest, bool>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    
    public CheckDuplicateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(CheckDuplicateQuestionRequest request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.ExistsByGlobalQuestionUrl(request.GlobalQuestionUrl);
        
        return question;
    }
    
    
}