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
    public class releaseController : ControllerBase
    {
        private readonly ILogger<releaseController> _logger;

        private readonly SrrdbContext _context;

        public releaseController(ILogger<releaseController> logger, SrrdbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(typeof(List<ReleaseDetails>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ReleaseDetails))]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(string? releaseName, string? imdbId)
        {
            Srr srr = this._context.Srr.Include(x => x.Release).FirstOrDefault(x => x.Release.Title == releaseName);

            if (srr != null)
            {
                SrrDetails srrDetails = new SrrDetails
                {
                    Exist = true,
                    ReleaseName = srr.Release.Title,
                    UploadedAt = srr.UploadedAt
                };

                return Ok(srrDetails);
            }

            return this.NotFound();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "", Description = "Longer description")]
        public async Task<IActionResult> Add(string releaseName, DateTime? preTime)
        {
            throw new NotImplementedException();

            return Ok();
        }
    }
}
