using Microsoft.AspNetCore.Authorization;
using WebApi2020.Models.AuthModels;

namespace WebApi2020.Authorization
{
    public class MyRequirement : IAuthorizationRequirement
    {
        public ApiUser ApiUser { get; set; }
    }
}
