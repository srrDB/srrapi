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
    public class mediaController : ControllerBase
    {
        private readonly ILogger<mediaController> _logger;

        private readonly SrrdbContext _context;

        public mediaController(ILogger<mediaController> logger, SrrdbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(typeof(List<ReleaseDetails>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<ReleaseDetails>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(string? imdb, string? tvdb, string? igdb, string? allMusic)
        {
            List<Release> releases = this._context.Release.Include(x => x.Srr).Where(x => x.ImdbId == imdb).ToList();

            if (releases != null)
            {
                List<ReleaseDetails> releaseDetails = releases.Select(x => new ReleaseDetails
                {
                    ReleaseName = x.Title,
                    HasSrr = x.Srr.Id > 0
                }).ToList();

                return Ok(releaseDetails);
            }

            return NotFound();
        }
    }
}
