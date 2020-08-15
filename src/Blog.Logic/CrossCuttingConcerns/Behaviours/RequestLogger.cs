using System.Threading;
using System.Threading.Tasks;

using Blog.Logic.CrossCuttingConcerns.Constants;
using Blog.Logic.CrossCuttingConcerns.Interfaces;

using MediatR.Pipeline;

using Microsoft.Extensions.Logging;

namespace Blog.Logic.CrossCuttingConcerns.Behaviours
{
	public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
	{
		private readonly ILogger _logger;
		private readonly ICurrentUserService _currentUserService;

		public RequestLogger(ILogger<TRequest> logger, ICurrentUserService currentUserService)
		{
			_logger = logger;
			_currentUserService = currentUserService;
		}

		public Task Process(TRequest request, CancellationToken cancellationToken)
		{
			var name = typeof(TRequest).Name;

			_logger.LogInformation("{AppName} Request: {Name} {@UserId} {@Request}",
				BlogSettings.ApplicationName,
				name,
				_currentUserService.UserId,
				request);

			return Task.CompletedTask;
		}
	}
}
