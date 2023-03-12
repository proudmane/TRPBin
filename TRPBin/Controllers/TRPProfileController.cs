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
        public ActionResult<TRPProfile> CreateProfile(CreateTRPProfilePayload payload)
        {
            var result = _trpProfileService.CreateProfile(payload.ExportString);

            return Ok(result);
        }
    }
}