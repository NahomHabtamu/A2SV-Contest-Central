using Application.Contracts.Infrastructure.ExternalServices;
using MediatR;

namespace Application.Features.CodeforcesApi.Commands
{
    public class FetchContestDataFromApiCommandHandler : IRequestHandler<FetchContestDataFromApiCommand, Unit>
    {
        ICodeforcesApiService _codeforcesApiService;
        public FetchContestDataFromApiCommandHandler(ICodeforcesApiService codeforcesApiService)
        {
            _codeforcesApiService = codeforcesApiService;
        }
        public async Task<Unit> Handle(FetchContestDataFromApiCommand command, CancellationToken cancellationToken)
        {
            var data = await _codeforcesApiService.GetContestData(command.ContestId);
            return Unit.Value;
        }
    }
}