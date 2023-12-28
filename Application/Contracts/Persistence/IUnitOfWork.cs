using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    
    IQuestionRepository QuestionRepository { get; }
    IUserTypeRepository UserTypeRepository { get; }
    ITeamRepository TeamRepository { get; }
    IContestRepository ContestRepository { get; }
    ILocationRepository LocationRepository { get; }
    IA2SVGroupRepository A2SVGroupRepository { get; }
    IUserContestResultRepository UserContestResultRepository { get; }
    ITeamContestResultRepository TeamContestResultRepository { get; }
    IUserQuestionResultRepository UserQuestionResultRepository { get; }
    ITeamQuestionResultRepository TeamQuestionResultRepository { get; }
}