using Blog.Logic.EntryAggregate.Commands.CreateEntry;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
	[Authorize]
	public class EntryController : BaseController
	{
		/// <summary>
		/// Create an blog entry.
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
		/// <returns></returns>
		public async Task<IActionResult> Create([FromBody] CreateEntryRequest createEntryModel)
		{
			if (!ModelState.IsValid) return ValidationProblem();

			await Mediator.Send(createEntryModel).ConfigureAwait(false);
			return Ok();
		}
	}
}
