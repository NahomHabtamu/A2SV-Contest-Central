using Application.Contracts.Infrastructure.ExternalServices;
using Application.Contracts.Persistence;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Application.Features.CodeforcesApi.Commands
{
    public class FetchContestDataFromApiCommandHandler
        : IRequestHandler<FetchContestDataFromApiCommand, bool>
    {
        private readonly ICodeforcesApiService _codeforcesApiService;
        private readonly IUnitOfWork _unitOfWork;

        public FetchContestDataFromApiCommandHandler(
            IUnitOfWork unitOfWork,
            ICodeforcesApiService codeforcesApiService
        )
        {
            _unitOfWork = unitOfWork;
            _codeforcesApiService = codeforcesApiService;
        }

        public async Task<bool> Handle(
            FetchContestDataFromApiCommand command,
            CancellationToken cancellationToken
        )
        {
            var validator = new FetchContestDataFromApiCommandValidator(
                _unitOfWork,
                _codeforcesApiService
            );
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                Guid contest_id_guid = command.ContestId;
                string contest_id = await _unitOfWork.ContestRepository.GetGlobalIdByContestGuid(contest_id_guid);
                // string contest_id = "abcd";

                //fetch data from codeforces using codeforces api
                dynamic data = await _codeforcesApiService.GetContestData(contest_id);

                //status and phase
                if (data.status == "FAILED")
                    return false;
                
                // JObject? contestObject = data.result.contest as JObject;
                //
                // var updated_contest = contestObject?.ToObject<ContestEntity>();
                JObject contestObject = data.result.contest;
                Console.WriteLine("here: ");
                Console.WriteLine(data.GetType());
                Console.WriteLine(data.result.contest);

                var updated_contest = new ContestEntity
                {
                    Type = contestObject["type"]?.ToString() ?? "",
                    DurationSeconds = contestObject["durationSeconds"]?.ToObject<int>() ?? default(int),
                    StartTimeSeconds = contestObject["startTimeSeconds"]?.ToObject<int>() ?? default(int),
                    RelativeTimeSeconds = contestObject["relativeTimeSeconds"]?.ToObject<int>() ?? default(int),
                    PreparedBy = contestObject["preparedBy"]?.ToString() ?? "",
                    WebsiteUrl = contestObject["websiteUrl"]?.ToString() ?? "",
                    Description = contestObject["description"]?.ToString() ?? "",
                    Difficulty = contestObject["difficulty"]?.ToObject<string>() ?? "",
                    Kind = contestObject["kind"]?.ToString() ?? "",
                    Status = contestObject["phase"]?.ToString() ?? "",
                    Season = contestObject["season"]?.ToString() ?? ""
                };
                
                Console.WriteLine("new UPDATED!!!!");
                Console.WriteLine(updated_contest);
                // update contest
                await _unitOfWork.ContestRepository.UpdateContestByGlobalIdAsync(contest_id_guid, updated_contest);
                
                // if contest hasn't completed yet
                if (data.result.contest.phase != "FINISHED")
                {
                    return false;
                }

                
                // fetch list of question_id from database using contest_id and index
                // JArray problems = data.result.problems;
                Console.WriteLine(contest_id_guid);
                IReadOnlyList<QuestionEntity> contestQuestions =
                    await _unitOfWork.QuestionRepository.GetQuestionsFromContestAsync(contest_id_guid);
                Console.WriteLine("before contestQuestions");
                Console.WriteLine(contestQuestions[0].Name);
                
                // update question names from the contest api
                for (int i = 0; i < contestQuestions.Count; i++)
                {
                    var questionFromDb = _unitOfWork.QuestionRepository.GetByIdAsync(contestQuestions[i].Id).Result;
                    questionFromDb.Name = data.result.problems[i].name;
                    await _unitOfWork.QuestionRepository.UpdateAsync(contestQuestions[i].Id, questionFromDb);
                }
                
                // todo: check if the contest is team or individual
                // iterate through "rows" of the api response to get all the information regarding user performance in the contest
                var rows = data.result.rows;

                foreach (var singleUser in rows)
                {
                    string userCodeforcesHandle = singleUser.party.members[0].handle.ToString();
                    Guid userId =
                        await _unitOfWork.UserRepository.GetUserIdByCodeforcesHandle(userCodeforcesHandle);
                    
                    // create new UserContestResultEntity and add it to database
                    var userContestResult = new UserContestResultEntity
                    {
                        ContestId = contest_id_guid,
                        UserId = userId,
                        Rank = (int)singleUser.rank,
                        Penalty = (int)singleUser.penalty,
                        SuccessfulHackCount = (int)singleUser.successfulHackCount,
                        UnsuccessfulHackCount = (int)singleUser.unsuccessfulHackCount,
                    };
                    
                    // create userContestResult
                    await _unitOfWork.UserContestResultRepository.CreateAsync(userContestResult);
                    
                    var userQuestions = singleUser.problemResults;
                    for (int i=0; i<userQuestions.Count; i++)
                    {
                        
                        // update question info into database
                        var userQuestion = userQuestions[i];
                        Guid questionId = contestQuestions[i].Id;
                        
                        // create new UserQuestionResultEntity and add it to database
                        var userQuestionResult = new UserQuestionResultEntity
                        {
                            QuestionId = questionId,
                            UserId = userId,
                            Points = (double)userQuestion.points,
                            RejectedAttemptCount = (int)userQuestion.rejectedAttemptCount,
                            BestSubmissionTimeSeconds = userQuestion.bestSubmissionTimeSeconds.ToString()
                        };
                        
                        // create userQuestionResult
                        await _unitOfWork.UserQuestionResultRepository.CreateAsync(userQuestionResult);
                    }
                }
                
                // questions info
                // contest result
                // standing
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching data from Codeforces", ex);
                throw new Exception("An error occurred while fetching data from Codeforces");
            }
        }
    }
}
