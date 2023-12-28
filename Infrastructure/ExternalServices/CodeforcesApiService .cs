using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure.ExternalServices;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.ExternalServices
{
    public class CodeforcesApiService : ICodeforcesApiService
    {
        private readonly CodeforcesAPISettings _codeforcesAPISettings;
        private readonly HttpClient _httpClient;

        public CodeforcesApiService(IOptions<CodeforcesAPISettings> codeforcesAPISettings, HttpClient httpClient)
        {
            _codeforcesAPISettings = codeforcesAPISettings.Value;
            _httpClient = httpClient;
        }

        public async Task<dynamic> GetContestData(string contestId)
        {
            string apiKey = _codeforcesAPISettings.ApiKey;
            string apiSecret = _codeforcesAPISettings.ApiSecret;
            string randStr = GenerateRandomString();
            long currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            string apiSig = $"{randStr}/contest.standings?apiKey={apiKey}&contestId={contestId}&time={currentTime}#{apiSecret}";
            string hash = CalculateSHA512(apiSig);

            string url = $"https://codeforces.com/api/contest.standings?contestId={contestId}&apiKey={apiKey}&time={currentTime}&apiSig={randStr}{hash}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            string responseData = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(responseData)!;
            return data; 
        }

        private static string GenerateRandomString()
        {
            Random random = new Random();
            int rand = random.Next(100000);
            return rand.ToString("D6");
        }

        public static string CalculateSHA512(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder stringBuilder = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

    }
}
