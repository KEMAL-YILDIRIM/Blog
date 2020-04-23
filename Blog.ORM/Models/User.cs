using Blog.ORM.Context;

using System;
using System.Collections.Generic;

namespace Blog.ORM.Models
{
	public class User : IPersistance
	{
		public User()
		{

		}

		public Guid UserId { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public Phone Phone { get; set; }
		public string Password { get; set; }

		public IEnumerable<Entry> Entries { get; set; }


		#region Constructor
		public User()
		{
			Phones = new HashSet<Phone>();
			Roles = new HashSet<Role>();
		}

		public User(string fullName,
			string email,
			string id,

			ICollection<Role> roles,
			ICollection<Phone> phones)
		{
			if (string.IsNullOrEmpty(id)) throw new IdNotFoundException();
			Id = id;
			FullName = fullName;
			Email = email;

			Roles = roles ?? new HashSet<Role>();
			Phones = phones ?? new HashSet<Phone>();
		}

		public User(string fullName,
			string email,
			string id,
			string password,

			ICollection<Role> roles,
			ICollection<Phone> phones)
		{
			Id = id;
			Password = password;
			FullName = fullName;
			Email = email;

			Roles = roles ?? new HashSet<Role>();
			Phones = phones ?? new HashSet<Phone>();
		}
		#endregion

		public string FullName { get; private set; }
		public string Email { get; private set; }
		public string Id { get; private set; }
		public string Password { get; private set; }

		public ICollection<Role> Roles { get; private set; }
		public ICollection<Phone> Phones { get; private set; }

		#region Behaviour
		public bool AddRole(Role role)
		{
			if (role is null) throw new EntityNotFoundException("User -> Role");

			if (Roles.Contains(role)) return false;

			Roles.Add(role);
			return true;
		}

		public bool RemoveRole(Role role)
		{
			if (role is null) throw new EntityNotFoundException("User -> Role");

			if (!Roles.Contains(role)) return false;

			Roles.Remove(role);
			return true;
		}

		public bool UpsertPhone(Phone phone)
		{
			if (phone is null) throw new EntityNotFoundException("User -> Phone");

			var current = Phones.FirstOrDefault(r => r.Type == phone.Type);
			if (current != null)
				current = phone;
			else
				Phones.Add(phone);

			return true;
		}

		public bool RemovePhone(Phone phone)
		{
			if (phone is null) throw new EntityNotFoundException("User -> Phone");

			if (!Phones.Contains(phone)) return false;

			Phones.Remove(phone);
			return true;
		}
		#endregion
	}
}
