using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2020.Models;

namespace WebApi2020.Authorization
{
    public class MyRequirement : IAuthorizationRequirement
    {
        public ApiUser ApiUser { get; set; }
    }
}
