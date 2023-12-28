namespace Application.Contracts.Infrastructure.ExternalServices
{
    public interface ICodeforcesApiService
    {
        public Task<dynamic> GetContestData(string contestId);
    }
}
