using System.Collections.Generic;

namespace Blog.Logic.Validators
{
    public interface IPasswordValidator
    {
        List<string> errors { get; }
        bool RequireDigit { get; set; }
        int RequiredLength { get; set; }
        bool RequireLowercase { get; set; }
        bool RequireNonLetterOrDigit { get; set; }
        bool RequireUppercase { get; set; }

        bool IsDigit(char c);
        bool IsLetterOrDigit(char c);
        bool IsLower(char c);
        bool IsUpper(char c);
        bool Validate(string item);
    }
}