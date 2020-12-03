using System.Threading;
using System.Threading.Tasks;

using Blog.Logic.CrossCuttingConcerns.Constants;
using Blog.Logic.CrossCuttingConcerns.Interfaces;

using MediatR.Pipeline;

using Microsoft.Extensions.Logging;

namespace Blog.Logic.CrossCuttingConcerns.Behaviours
{
	public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
	{
		private readonly ILogger _logger;
		private readonly ICurrentUserService _currentUserService;

		public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
		{
			_logger = logger;
			_currentUserService = currentUserService;
		}

		public async Task Process(TRequest request, CancellationToken cancellationToken)
		{
			var requestName = typeof(TRequest).Name;
			var userId = _currentUserService.UserId ?? string.Empty;

			_logger.LogInformation("{AppName} Request: {Name} {@UserId} {@Request}",
				ApplicationSettings.ApplicationName, requestName, userId, request);
		}
	}
}
