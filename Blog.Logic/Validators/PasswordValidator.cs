using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Blog.Logic.Validators
{
    /// <summary>
    ///     Used to validate some basic password policy like length and number of non alphanumerics
    /// </summary>
    public class PasswordValidator : IPasswordValidator
    {
        /// <summary>
        ///     Shows gets list of validation errors.
        /// </summary>
        public List<string> errors { get; private set; }

        /// <summary>
        ///     Minimum required length
        /// </summary>
        public int RequiredLength { get; set; }

        /// <summary>
        ///     Require a non letter or digit character
        /// </summary>
        public bool RequireNonLetterOrDigit { get; set; }

        /// <summary>
        ///     Require a lower case letter ('a' - 'z')
        /// </summary>
        public bool RequireLowercase { get; set; }

        /// <summary>
        ///     Require an upper case letter ('A' - 'Z')
        /// </summary>
        public bool RequireUppercase { get; set; }

        /// <summary>
        ///     Require a digit ('0' - '9')
        /// </summary>
        public bool RequireDigit { get; set; }

        /// <summary>
        ///     Ensures that the string is of the required length and meets the configured requirements
        /// </summary>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        public virtual bool Validate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Password not found");
            }

            errors = new List<string>();
            errors.Add(String.Format(CultureInfo.CurrentCulture, "Password should have at least"));

            if (string.IsNullOrWhiteSpace(password) || password.Length < RequiredLength)
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, $"{RequiredLength} characters."));
            }
            if (RequireNonLetterOrDigit && password.All(IsLetterOrDigit))
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, $"one symbol."));
            }
            if (RequireDigit && password.All(c => !IsDigit(c)))
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, $"one number."));
            }
            if (RequireLowercase && password.All(c => !IsLower(c)))
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, $"one lower case character."));
            }
            if (RequireUppercase && password.All(c => !IsUpper(c)))
            {
                errors.Add(String.Format(CultureInfo.CurrentCulture, $"one upper case character."));
            }

            if (errors.Any()) return false;
            else return true;
        }

        /// <summary>
        ///     Returns true if the character is a digit between '0' and '9'
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        /// <summary>
        ///     Returns true if the character is between 'a' and 'z'
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool IsLower(char c)
        {
            return c >= 'a' && c <= 'z';
        }

        /// <summary>
        ///     Returns true if the character is between 'A' and 'Z'
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool IsUpper(char c)
        {
            return c >= 'A' && c <= 'Z';
        }

        /// <summary>
        ///     Returns true if the character is upper, lower, or a digit
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool IsLetterOrDigit(char c)
        {
            return IsUpper(c) || IsLower(c) || IsDigit(c);
        }
    }
}