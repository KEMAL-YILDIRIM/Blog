using Blog.Domain.CrossCuttingConcerns;
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
		}

		public User(
			string fullName,
			string email,
			string password,

			ICollection<Phone> phones,
			ICollection<Entry> entries)
		{
			FullName = fullName;
			Email = email;
			Password = password;

			Phones = phones ?? new HashSet<Phone>();
			Entries = entries ?? new HashSet<Entry>();
		}

		public User(string fullName,
			string email,
			string password,
			string id,

			ICollection<Phone> phones,
			ICollection<Entry> entries)
		{
			FullName = fullName;
			Email = email;
			Password = password;
			Id = id;

			Phones = phones ?? new HashSet<Phone>();
			Entries = entries ?? new HashSet<Entry>();
		}
		#endregion

		public string FullName { get; private set; }
		public string Email { get; private set; }
		public string Id { get; private set; }
		public string Password { get; private set; }


		public ICollection<Phone> Phones { get; private set; }
		public ICollection<Entry> Entries { get; private set; }

		#region Behaviour

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

		public bool UpsertEntry(Entry entry)
		{
			if (entry is null) throw new EntityNotFoundException("User -> Entry");

			var current = Entries.FirstOrDefault(r => r.Title == entry.Title);
			if (current != null)
				current = entry;
			else
				Entries.Add(entry);

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
