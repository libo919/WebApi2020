using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi2020.Controllers
{
    public class ToolController : Controller
    {
        public ActionResult Json()
        {
            return View();
        }
    }
}
