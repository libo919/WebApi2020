using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi2020.Authorization
{
    public class MyHandler:AuthorizationHandler<MyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MyRequirement requirement)
        {
            var code = context.User.Claims.FirstOrDefault(m => m.Type.Equals(ClaimTypes.NameIdentifier));
            string uid = requirement.ApiUser.UID;
            context.Fail();
            return Task.CompletedTask;
        }
    }
}
