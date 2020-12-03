using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Blog.Logic.CrossCuttingConcerns.Constants;
using Blog.Logic.CrossCuttingConcerns.Interfaces;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Blog.Logic.CrossCuttingConcerns.Behaviours
{
	public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly Stopwatch _timer;
		private readonly ILogger<TRequest> _logger;
		private readonly ICurrentUserService _currentUserService;

		public PerformanceBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
		{
			_timer = new Stopwatch();

			_logger = logger;
			_currentUserService = currentUserService;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			_timer.Start();

			var response = await next().ConfigureAwait(false);

			_timer.Stop();

			if (_timer.ElapsedMilliseconds > 500)
			{
				var name = typeof(TRequest).Name;
				var userId = _currentUserService.UserId ?? string.Empty;

				_logger.LogWarning("{AppName} Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
					ApplicationSettings.ApplicationName, name, _timer.ElapsedMilliseconds, userId, request);
			}

			return response;
		}
	}
}
