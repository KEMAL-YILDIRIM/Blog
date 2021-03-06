﻿
using Blog.Domain.AuditableEntities;

using MediatR;

namespace Blog.Logic.EntryAggregate.Commands.CreateEntry
{
	public class CreateEntryRequest : IRequest
	{
		public string Title { get; set; }

		public Content Content { get; set; }
	}
}
