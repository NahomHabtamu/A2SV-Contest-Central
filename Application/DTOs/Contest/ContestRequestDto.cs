

namespace Application.DTOs.Contest
{
    public class ContestRequestDto
    {
        public string ContestUrl { get; set; } = null!;
        public List<string> Questions { get; set; }
        public List<string> Groups { get; set; }
    }
} 

