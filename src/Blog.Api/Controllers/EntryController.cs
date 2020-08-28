﻿using System.Threading.Tasks;

using Blog.Logic.EntryAggregate.Commands.CreateEntry;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Authorize]
	public class EntryController : BaseController
	{
		public async Task<IActionResult> Create([FromBody] CreateEntryRequest createEntryModel)
		{
			return Ok();
		}
	}
}