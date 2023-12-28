using System.Net.Http.Json;
using Application.Contracts.Infrastructure.ExternalServices;
using MediatR;
using Newtonsoft.Json;

namespace Application.Features.CodeforcesApi.Queries.CheckContestUrl
{
    public class ContestUrlCheckerRequestHandler : IRequestHandler<ContestUrlCheckerRequest, bool>
    {
        private ICodeforcesApiService _codeforcesApiService;

        public ContestUrlCheckerRequestHandler(ICodeforcesApiService codeforcesApiService)
        {
            _codeforcesApiService = codeforcesApiService;
        }

        public async Task<bool> Handle(ContestUrlCheckerRequest request, CancellationToken cancellationToken)
        {
            string contest_id = ParseIdFromUrl(request.ContestUrl);
            if(contest_id == "NotFound") return false;

            dynamic data = await _codeforcesApiService.GetContestData(contest_id);

            if(data.status == "FAILED" && data.comment == $"contestId: Contest with id {contest_id} not found"){
                return false;
            }

            return true;
        }

        static string ParseIdFromUrl(string url)
        {
            url = Uri.UnescapeDataString(url);
            int index = url.LastIndexOf('/');

            if (index >= 0 && index < url.Length - 1)
            {
                string id = url.Substring(index + 1);
                return id;
            }

            return "NotFound";
        }
    }
}
