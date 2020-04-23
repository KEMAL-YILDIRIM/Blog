using Blog.Entities.Seed;
using Blog.Exceptions;

using System;
using System.Collections.Generic;

namespace Blog.Entities.AuditableEntities
{
	public class Note : AuditableEntity, IEntity
	{

		#region Constructor


		public Note(
			string subject,
			string description,
			PropertyEntities.DomainType type,
			string createdBy,
			string updatedBy,
			DateTime createdAt,
			DateTime? updatedAt)
			: base(createdBy, updatedBy, createdAt, updatedAt)
		{
			if (string.IsNullOrEmpty(subject)) throw new PropertyNotFoundException("Note -> Subject");
			Subject = subject;
			if (string.IsNullOrEmpty(description)) throw new PropertyNotFoundException("Note -> Description");
			Description = description;

			Type = type ?? new Type("Note");
		}

		public Note(
			int id,
			string subject,
			string description,
			PropertyEntities.DomainType type,
			string createdBy,
			string updatedBy,
			DateTime createdAt,
			DateTime? updatedAt)
			: base(createdBy, updatedBy, createdAt, updatedAt)
		{
			if (id <= 0) throw new PropertyNotFoundException("Note -> Id");
			Id = id;
			if (string.IsNullOrEmpty(subject)) throw new PropertyNotFoundException("Note -> Subject");
			Subject = subject;
			if (string.IsNullOrEmpty(description)) throw new PropertyNotFoundException("Note -> Description");
			Description = description;

			Type = type ?? new Type("Note");
		}


		#endregion

		public int Id { get; private set; }
		public string From { get; private set; }
		public string Subject { get; private set; }
		public string Description { get; private set; }

		public Type Type { get; private set; }

		public ICollection<string> To { get; private set; }

		#region Behavior

		public ICollection<string> AddMailTo_To(string mail)
		{
			if (To.Contains(mail)) return To;

			To.Add(mail);
			return To;
		}

		public ICollection<string> RemoveMailFrom_To(string mail)
		{
			if (To.Count > 1)
				To.Remove(mail);

			return To;
		}

		public Type UpsertType(Type type)
		{
			if (type == null)
				return this.Type;


			Type = type;
			return Type;
		}

		public bool UpsertFrom(string mail)
		{
			if (string.IsNullOrEmpty(mail)) throw new PropertyNotFoundException("Note -> From");

			From = mail;
			return true;
		}

		public bool UpdateDescription(string description)
		{
			if (string.IsNullOrEmpty(description)) throw new PropertyNotFoundException("Note -> Description");

			Description = description;
			return true;
		}
		#endregion
	}
}