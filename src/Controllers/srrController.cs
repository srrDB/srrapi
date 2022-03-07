using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using srrdb;
using srrapi.ViewModels;
using Microsoft.EntityFrameworkCore;
using srrdb.dbo;
using Swashbuckle.AspNetCore.Annotations;

namespace srrapi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class srrController : ControllerBase
    {
        private readonly ILogger<srrController> _logger;

        private readonly SrrdbContext _context;

        public srrController(ILogger<srrController> logger, SrrdbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();

            return NotFound();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "", Description = "This will also add a release in case there is no information about the release.")]
        public async Task<IActionResult> Add(string releaseName, IFormFile file)
        {
            throw new NotImplementedException();

            return Ok();
        }
    }
}
