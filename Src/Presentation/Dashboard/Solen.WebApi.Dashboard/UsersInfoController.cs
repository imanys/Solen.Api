﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solen.Core.Application.Dashboard.Queries;
using Solen.WebApi.Controllers;
using Swashbuckle.AspNetCore.Annotations;

namespace Solen.WebApi.Dashboard
{
    [Authorize(Policy = AuthorizationPolicies.AdminPolicy)]
    [Route("api/dashboard/users")]
    [SwaggerTag("(Dashboard)")]
    public class UsersInfoController : BaseController
    {
        [HttpGet("count")]
        public async Task<ActionResult<UserCountInfoViewModel>> GetUserCount(CancellationToken token)
        {
            return Ok(await Mediator.Send(new GetUserCountInfoQuery(), token));
        }
    }
}