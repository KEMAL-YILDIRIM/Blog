using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Blog.Domain.AuditableEntities;
using Blog.Domain.Exceptions;
using Blog.Domain.LinkEntities;
using Blog.Logic.CrossCuttingConcerns.Interfaces;

using MediatR;

namespace Blog.Logic.EntryAggregate.Commands.CreateEntry
{
	public class UpdateEntryCommand : IRequestHandler<UpdateEntryRequest>
	{
		private readonly IDbContext _context;
		private readonly IMediator _mediator;

		public UpdateEntryCommand(IDbContext context,
			IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
		}


		public async Task<Unit> Handle(UpdateEntryRequest request, CancellationToken cancellationToken)
		{
			var currentEntry = await _context.Entries
				.FindAsync(request.EntryId)
				.ConfigureAwait(false);

			if (currentEntry is null) throw new EntityNotFoundException("User");

			var readingTime = currentEntry.ReadingTime;
			if (request.ReadingTime == TimeSpan.MinValue)
				readingTime = currentEntry.ReadingTime;

			var entryCategories = currentEntry.EntryCategories;
			if (request.Categories.Any())
			{
				entryCategories.Clear();
				foreach (var item in request.Categories)
				{
					var entryCategory = new EntryCategory
					{
						EntryId = currentEntry.EntryId,
						CategoryId = item.Id
					};
					entryCategories.Add(entryCategory);
				}
			}

			var entity = new Entry
			(
				currentEntry.EntryId,
				request.Title ?? currentEntry.Title,

				readingTime,
				request.Content,

				entryCategories
			);

			_context.Entries.Update(entity);
			await _context.SaveChangesAsync().ConfigureAwait(false);

			await _mediator.Publish(
				new EntryUpdated
				{
					EntryId = entity.EntryId,
					UserId = entity.UpdatedBy
				}, cancellationToken)
				.ConfigureAwait(false);

			return Unit.Value;
		}
	}
}
