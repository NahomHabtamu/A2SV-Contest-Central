using MediatR;

namespace Application.Features.CodeforcesApi.Queries.CheckContestUrl
{
    public class ContestUrlCheckerRequest : IRequest<bool>
    {
        public string ContestUrl { get; set; } = null!;
    }
}
