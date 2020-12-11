using System.Threading.Tasks;

using Blog.Logic.EntryAggregate.Commands.CreateEntry;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Authorize]
	public class EntryController : BaseController
	{
		/// <summary>
		/// Create a blog entry.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///		POST /Create
		///		{
		///			"Title": "Blog title or subject",
		///			"Content": {
		///				"Html": "Some html content"
		///			}
		///		}
		///
		/// </remarks>
		/// <param name="createEntryModel"></param>
		/// <returns><see cref="OkResult"/></returns>
		/// <response code="200">Returns ok result</response>
		/// <response code="400">If the information is not valid</response>
		public async Task<IActionResult> Create([FromBody] CreateEntryRequest createEntryModel)
		{
			if (!ModelState.IsValid) return ValidationProblem();

			await Mediator.Send(createEntryModel).ConfigureAwait(false);
			return Ok();
		}

		/// <summary>
		/// Update a blog entry.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///		POST /Create
		///		{
		///			"Title": "Blog title or subject",
		///			"Content": {
		///				"Html": "Some html content"
		///			}
		///		}
		///
		/// </remarks>
		/// <param name="updateEntryModel"></param>
		/// <returns><see cref="OkResult"/></returns>
		/// <response code="200">Returns ok result</response>
		/// <response code="400">If the information is not valid</response>
		public async Task<IActionResult> Update([FromBody] UpdateEntryRequest updateEntryModel)
		{
			if (!ModelState.IsValid) return ValidationProblem();

			await Mediator.Send(updateEntryModel).ConfigureAwait(false);
			return Ok();
		}
	}
}
