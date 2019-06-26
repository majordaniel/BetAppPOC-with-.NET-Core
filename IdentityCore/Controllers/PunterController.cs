using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityCore.Data;
using IdentityCore.Models;
using IdentityCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCore.Controllers
{
    [Authorize(Roles = "OddHandler,Punter")]
    public class PunterController : Controller
    {

        private readonly ApplicationDbContext _context;
        
        public PunterController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetOddsList()
        {
          
            List<OddViewModel> OddsLIst = _context.TbOdds.Select(x => new OddViewModel
            {
                AwayValue = x.AwayValue,
                DrawValue = x.DrawValue,
                EndTime = x.EndTime,
                GameDate = x.GameDate,
                GameName = x.GameName,
                HomeValue = x.HomeValue,
                OddCreator = x.OddCreator,
                OddId = x.OddId,
                StakeAmount = x.StakeAmount,
                StartTime = x.StartTime,
                Status = x.Status
            }).ToList();
            //ViewBag.OddLists = OddsLIst;
            return new JsonResult(OddsLIst);

        }

        [HttpPost]
        public JsonResult SaveNewStakeAsync(StakesViewModel IncStakeData)
        {
          
            bool Resp = false;

                TbStakes sT = new TbStakes
                {
                   UserID = User.Identity.Name,
                    TotalStakeAmount = IncStakeData.Stakes.TotalStakeAmount
                };
                _context.TbStakes.Add(sT);
            _context.SaveChanges();
                foreach (var item in IncStakeData.StakesDetails)
                {
                    item.StakeID = sT.StakeID;
                _context.TbStakeDetails.Add(item);
                };
            _context.SaveChanges();
                Resp = true;
          


            return Json(new { Result = Resp });
        }
    }
}