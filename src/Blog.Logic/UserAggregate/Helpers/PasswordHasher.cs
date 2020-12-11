using System;
using System.Text;

using Blog.Logic.CrossCuttingConcerns.Constants;

namespace Blog.Logic.UserAggregate.Helpers
{
	public class PasswordHasher : IPasswordHasher
	{
		public virtual string Create(string password)
		{
			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentNullException(nameof(password));

			using (var hmac = new System.Security.Cryptography.HMACSHA512(ApplicationSettings.Salt))
			{
				var hash = hmac
					.ComputeHash(Encoding.UTF8.GetBytes(password));

				return Convert.ToBase64String(hash);
			}
		}

		public virtual bool Verify(string password, string storedPassword)
		{
			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentNullException(nameof(password));

			using (var hmac = new System.Security.Cryptography.HMACSHA512(ApplicationSettings.Salt))
			{
				var hashedPassword = hmac
					.ComputeHash(Encoding.UTF8.GetBytes(password));

				return storedPassword.Equals(
					Convert.ToBase64String(hashedPassword),
					StringComparison.InvariantCultureIgnoreCase);
			}
		}
	}
}
