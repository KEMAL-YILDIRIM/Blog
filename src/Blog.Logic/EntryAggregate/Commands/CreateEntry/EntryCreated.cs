using MediatR;

namespace Blog.Logic.EntryAggregate.Commands.CreateEntry
{
	internal class EntryCreated : INotification
	{
		public string EntryId { get; set; }
	}
}