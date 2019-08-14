using System;
using Microsoft.AspNetCore.Mvc;

namespace Incredibilis.Presentation.Controllers
{
	[ApiController]
	[Route("")]
	public class MonitorController : ControllerBase
	{
		[HttpGet]
		[Route("[action]")]
		public IActionResult Health()
			=> Ok("INCONTINENS\nINCREDIBILIS\nINFIRMUS\nETIAM");
	}
}
