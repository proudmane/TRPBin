using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TRPBin.Models;
using TRPBin.Services;

namespace TRPBin.Controllers
{
    [ApiController]
    [Route("api/v1/trpProfiles")]
    public class TRPProfileController : ControllerBase
    {
        private readonly ITRPProfileService _trpProfileService;

        public TRPProfileController(
            ITRPProfileService tRPProfileService
        )
        {
            _trpProfileService = tRPProfileService;
        }

        [HttpPost]
        public async Task<ActionResult<TRPProfile>> CreateProfile(CreateTRPProfilePayload payload)
        {
            var result = await _trpProfileService.CreateProfileAsync(payload.ExportString);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<TRPProfile>>> FetchProfiles()
        {
            var result = await _trpProfileService.FetchProfilesAsync();

            return Ok(result);
        }
    }
}