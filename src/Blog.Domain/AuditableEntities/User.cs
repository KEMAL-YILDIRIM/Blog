using Blog.Domain.Common;
using Blog.Domain.Exceptions;
using Blog.Domain.ValueObjects;

using System.Collections.Generic;
using System.Linq;

namespace Blog.Domain.AuditableEntities
{
	public class User : IEntity
	{

		#region Constructor

		public User()
		{
			Phones = new HashSet<Phone>();
			Entries = new HashSet<Entry>();
			RefreshTokens = new HashSet<RefreshToken>();
		}

		public User(
			string firstname,
			string lastname,
			string username,
			string email,
			string password,

			ICollection<Phone> phones,
			ICollection<RefreshToken> refreshTokens,
			ICollection<Entry> entries)
		{
			if (string.IsNullOrEmpty(email)) throw new PropertyNotFoundException("User -> Email");
			if (string.IsNullOrEmpty(password)) throw new PropertyNotFoundException("User -> Password");

			FirstName = firstname;
			LastName = lastname;
			Username = username;
			Email = email;
			Password = password;

			Phones = phones ?? new HashSet<Phone>();
			RefreshTokens = refreshTokens ?? new HashSet<RefreshToken>();
			Entries = entries ?? new HashSet<Entry>();
		}

		public User(string firstname,
			string lastname,
			string username,
			string email,
			string password,
			string id,

			ICollection<Phone> phones,
			ICollection<RefreshToken> refreshTokens,
			ICollection<Entry> entries)
		{
			if (string.IsNullOrEmpty(email)) throw new PropertyNotFoundException("User -> Email");
			if (string.IsNullOrEmpty(password)) throw new PropertyNotFoundException("User -> Password");
			if (string.IsNullOrEmpty(id)) throw new PropertyNotFoundException("User -> Id");


			FirstName = firstname;
			LastName = lastname;
			Username = username;
			Email = email;
			Password = password;
			UserId = id;

			Phones = phones ?? new HashSet<Phone>();
			RefreshTokens = refreshTokens ?? new HashSet<RefreshToken>();
			Entries = entries ?? new HashSet<Entry>();
		}

		#endregion





		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string Username { get; private set; }
		public string Email { get; private set; }
		public string UserId { get; private set; }
		public string Password { get; private set; }


		public ICollection<Phone> Phones { get; private set; }
		public ICollection<Entry> Entries { get; private set; }
		public ICollection<RefreshToken> RefreshTokens { get; private set; }





		#region Behaviour

		public bool UpsertPhone(Phone phone)
		{
			if (phone is null) throw new EntityNotFoundException("User -> Phone");

			var current = Phones.FirstOrDefault(r => r.Type == phone.Type);
			if (current is null)
				Phones.Add(phone);
			else
				current = phone;

			return true;
		}

		public bool RemovePhone(Phone phone)
		{
			if (phone is null) throw new EntityNotFoundException("User -> Phone");

			if (!Phones.Contains(phone)) return false;

			Phones.Remove(phone);
			return true;
		}

		public bool UpsertRefreshToken(RefreshToken refreshToken)
		{
			if (refreshToken is null) throw new EntityNotFoundException("User -> RefreshToken");

			var current = RefreshTokens
				.FirstOrDefault(r
				=> r.Token == refreshToken.Token
				&& r.OwnerIp == refreshToken.OwnerIp
				&& r.IsActive);
			if (current is null)
				RefreshTokens.Add(refreshToken);
			else
			{
				RefreshTokens.Remove(current);
				RefreshTokens.Add(refreshToken);
			}

			return true;
		}

		public bool RemoveRefreshToken(RefreshToken refreshToken)
		{
			if (refreshToken is null) throw new EntityNotFoundException("User -> RefreshToken");

			if (!RefreshTokens.Contains(refreshToken)) return false;

			RefreshTokens.Remove(refreshToken);
			return true;
		}

		public bool UpsertEntry(Entry entry)
		{
			if (entry is null) throw new EntityNotFoundException("User -> Entry");

			var current = Entries.FirstOrDefault(r => r.Title == entry.Title);
			if (current is null)
				Entries.Add(entry);
			else
				current = entry;

			return true;
		}

		public bool RemoveEntry(Entry entry)
		{
			if (entry is null) throw new EntityNotFoundException("User -> Entry");

			if (!Entries.Contains(entry)) return false;

			Entries.Remove(entry);
			return true;
		}

		#endregion
	}
}
