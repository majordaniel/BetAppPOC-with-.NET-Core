using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityCore.Data;
using IdentityCore.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdentityCore.Controllers
{

    [Authorize(Roles = "OddHandler")]
    public class OddsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OddsController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: Odds
        public async Task<IActionResult> Index()
        {
            return View(await _db.TbOdds.ToListAsync());
        }

        // GET: Odds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbOdds = await _db.TbOdds
                .FirstOrDefaultAsync(m => m.OddId == id);
            if (tbOdds == null)
            {
                return NotFound();
            }

            return View(tbOdds);
        }

        // GET: Odds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Odds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OddId,GameName,HomeValue,DrawValue,AwayValue,GameDate,StakeAmount,StartTime,EndTime,Status,OddCreator")] TbOdds tbOdds)
        {
            if (ModelState.IsValid)
            {
                _db.Add(tbOdds);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbOdds);
        }

        // GET: Odds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbOdds = await _db.TbOdds.FindAsync(id);
            if (tbOdds == null)
            {
                return NotFound();
            }
            return View(tbOdds);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OddId,GameName,HomeValue,DrawValue,AwayValue,GameDate,StakeAmount,StartTime,EndTime,Status,OddCreator")] TbOdds tbOdds)
        {
            if (id != tbOdds.OddId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(tbOdds);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbOddsExists(tbOdds.OddId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbOdds);
        }

        // GET: Odds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbOdds = await _db.TbOdds
                .FirstOrDefaultAsync(m => m.OddId == id);
            if (tbOdds == null)
            {
                return NotFound();
            }

            return View(tbOdds);
        }

        // POST: Odds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbOdds = await _db.TbOdds.FindAsync(id);
            _db.TbOdds.Remove(tbOdds);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbOddsExists(int id)
        {
            return _db.TbOdds.Any(e => e.OddId == id);
        }
    }
}
