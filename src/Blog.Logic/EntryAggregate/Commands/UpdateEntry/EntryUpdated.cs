using MediatR;

namespace Blog.Logic.EntryAggregate.Commands.CreateEntry
{
	internal class EntryUpdated : INotification
	{
		public string EntryId { get; set; }
		public string UserId { get; set; }
	}
}