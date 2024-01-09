using System.Text.RegularExpressions;
using FluentValidation;

namespace Application.Features.Question.Queries.CheckDuplicate;

public class CheckDuplicateQuestionValidator : AbstractValidator<CheckDuplicateQuestionRequest>
{
    public CheckDuplicateQuestionValidator()
    {
        RuleFor(x => x.GlobalQuestionUrl)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .Must(BeValidCodeforcesQuestionUrl).WithMessage("Invalid Question Url");
    }
    
    private bool BeValidCodeforcesQuestionUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return false;
        }
        url = Uri.UnescapeDataString(url);

        // Define the regex pattern for Codeforces contest URLs
        var pattern = @"^https://codeforces.com/problemset/problem/\d+/[A-Z]$";
        
        // Use regex to match the pattern
        return Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase);
    }
}