using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork

{

    public IUserRepository UserRepository { get; }
    
    public IQuestionRepository QuestionRepository { get; }
    public IUserTypeRepository UserTypeRepository { get; }
    public ITeamRepository TeamRepository { get; }
    public IContestRepository ContestRepository { get; }
    public ILocationRepository LocationRepository { get; }
    public IA2SVGroupRepository A2SVGroupRepository { get; }
    public IUserContestResultRepository UserContestResultRepository { get; }
    public ITeamContestResultRepository TeamContestResultRepository { get; }
    public IUserQuestionResultRepository UserQuestionResultRepository { get; }
    public ITeamQuestionResultRepository TeamQuestionResultRepository { get; }

    private readonly AppDBContext _dbContext;
    
    public UnitOfWork(IQuestionRepository questionRepository, IUserRepository userRepository, IUserTypeRepository userTypeRepository, ITeamRepository teamRepository, IContestRepository contestRepository, ILocationRepository locationRepository, IA2SVGroupRepository a2SvGroupRepository, AppDBContext dbContext, IUserQuestionResultRepository userQuestionResultRepository, ITeamQuestionResultRepository teamQuestionResultRepository, IUserContestResultRepository userContestResultRepository, ITeamContestResultRepository teamContestResultRepository)
    {
        _dbContext = dbContext;
        UserRepository = userRepository;
        UserTypeRepository = userTypeRepository;
        TeamRepository = teamRepository;
        ContestRepository = contestRepository;
        LocationRepository = locationRepository;
        A2SVGroupRepository = a2SvGroupRepository;
        QuestionRepository = questionRepository;
        UserQuestionResultRepository = userQuestionResultRepository;
        TeamQuestionResultRepository = teamQuestionResultRepository;
        UserContestResultRepository = userContestResultRepository;
        TeamContestResultRepository = teamContestResultRepository;
    }
}
