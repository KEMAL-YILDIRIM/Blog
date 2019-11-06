using System;

using Blog.Entities;
using Blog.Logic.Validators;

namespace Blog.Logic.Managers
{
    public class UserManager : IUserManager
    {
        //private readonly UserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IEmailValidator _emailValidator;

        public UserManager(
            IPasswordValidator passwordValidator,
            IEmailValidator emailValidator)
        {
            //_userRepository = userRepository;
            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
        }

        public (string error, bool isValid) Register(User user)
        {
            if (!_emailValidator.IsValid(user.Email))
                return ("Email not valid!", false);

            if (!_passwordValidator.Validate(user.Password))
            {
                var errors = string.Join(Environment.NewLine, _passwordValidator.errors);
                return (errors, false);
            }

            return (string.Format("{0}registered successfuly", user.FullName), true);
        }
    }
}
