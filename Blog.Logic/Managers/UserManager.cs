using System;
using System.Globalization;
using System.Threading.Tasks;
using Blog.Entities;
using Blog.Logic.Repositories;
using Blog.Logic.Validators;

namespace Blog.Logic.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IEmailValidator _emailValidator;

        public UserManager(
            IPasswordValidator passwordValidator,
            IEmailValidator emailValidator,
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
        }

        public virtual async Task<(string error, bool isValid)> RegisterAsync(User user)
        {
            // validation
            if (user is null)
                return ("User is null!", false);

            if (!_emailValidator.IsValid(user.Email))
                return ("Email not valid!", false);

            if (!_passwordValidator.Validate(user.Password))
            {
                var errors = string.Join(Environment.NewLine, _passwordValidator.errors);
                return (errors, false);
            }

            var existingUser = await _userRepository.GetByEmailAsync(user.Email).ConfigureAwait(true);
            if (existingUser != null)
                return ("User already exists.", false);

            // register
            await _userRepository.Add(user).ConfigureAwait(true);

            return (string.Format(CultureInfo.CurrentCulture, "{0}registered successfuly", user.FullName), true);
        }
    }
}
