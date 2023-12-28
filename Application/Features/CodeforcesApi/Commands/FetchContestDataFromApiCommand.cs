using MediatR;

namespace Application.Features.CodeforcesApi.Commands
{
    public class FetchContestDataFromApiCommand : IRequest<Unit>
    {
        public string ContestId { get; set; } = null!;
    }
}