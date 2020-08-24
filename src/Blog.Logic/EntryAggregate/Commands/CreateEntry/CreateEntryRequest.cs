
using System.Collections.Generic;

using Blog.Domain.AuditableEntities;
using Blog.Domain.PropertyEntities;

using MediatR;

namespace Blog.Logic.EntryAggregate.Commands.CreateEntry
{
	public class CreateEntryRequest : IRequest
	{
		public CreateEntryRequest()
		{
			Categories = new HashSet<Category>();
		}

		public string Title { get; set; }

		public Content Content { get; set; }

		public IEnumerable<Category> Categories { get; set; }
	}
}
