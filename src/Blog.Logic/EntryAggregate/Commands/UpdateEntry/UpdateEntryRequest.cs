
using Blog.Domain.AuditableEntities;
using Blog.Domain.PropertyEntities;

using MediatR;

using System;
using System.Collections.Generic;

namespace Blog.Logic.EntryAggregate.Commands.CreateEntry
{
	public class UpdateEntryRequest : IRequest
	{
		public int EntryId { get; set; }
		public string Title { get; set; }

		public TimeSpan ReadingTime { get; set; }
		public Content Content { get; set; }

		public IEnumerable<Category> Categories { get; set; }
	}
}
