using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Authorize]
	public class EntryController : BaseController
	{
		public async Task<IActionResult> Create()
		{
			return Ok();
		}
	}
}
