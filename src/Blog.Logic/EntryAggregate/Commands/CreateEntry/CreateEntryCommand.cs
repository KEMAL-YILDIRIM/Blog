using System;
using System.Threading;
using System.Threading.Tasks;

using Blog.Domain.AuditableEntities;
using Blog.Logic.CrossCuttingConcerns.Interfaces;

using MediatR;

namespace Blog.Logic.EntryAggregate.Commands.CreateEntry
{
	public class CreateEntryCommand : IRequestHandler<CreateEntryRequest>
	{
		private readonly IDbContext _context;
		private readonly IMediator _mediator;

		public CreateEntryCommand(IDbContext context,
			IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
		}


		public async Task<Unit> Handle(CreateEntryRequest request, CancellationToken cancellationToken)
		{
			var entity = new Entry
			(
				request.Title,
				TimeSpan.MinValue,
				request.Content,
				null
			);

			await _context.Entries.AddAsync(entity).ConfigureAwait(false);
			await _context.SaveChangesAsync().ConfigureAwait(false);

			await _mediator.Publish(
				new EntryCreated
				{
					EntryId = entity.EntryId,
					UserId = entity.CreatedBy
				}, cancellationToken)
				.ConfigureAwait(false);

			return Unit.Value;
		}
	}
}
