using System.Threading.Tasks;

using Blog.Logic.CrossCuttingConcerns.Behaviours;
using Blog.Logic.CrossCuttingConcerns.Interfaces;
using Blog.Logic.EntryAggregate.Commands.CreateEntry;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

namespace Blog.Logic.Tests.CrossCuttingConcerns.Behaviours
{
	public class RequestLoggerTests
	{
		private readonly Mock<ILogger<CreateEntryCommand>> _logger;
		private readonly Mock<ICurrentUserService> _currentUserService;


		public RequestLoggerTests()
		{
			_logger = new Mock<ILogger<CreateEntryCommand>>();

			_currentUserService = new Mock<ICurrentUserService>();
		}

		[Test]
		public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
		{
			_currentUserService.Setup(x => x.UserId).Returns("Administrator");

			var requestLogger = new LoggingBehaviour<CreateEntryCommand>(_logger.Object, _currentUserService.Object);

			Assert.Fail();
		}

		[Test]
		public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
		{
			var requestLogger = new LoggingBehaviour<CreateEntryCommand>(_logger.Object, _currentUserService.Object);

			Assert.Fail();
		}
	}
}
