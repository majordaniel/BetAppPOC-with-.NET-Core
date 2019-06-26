using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCore.Controllers
{
    [Authorize(Roles = "OddHandler,Punter")]
    public class PunterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}