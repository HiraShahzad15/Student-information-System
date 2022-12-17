using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_information.Data;
using Student_information.Models;

namespace Student_information.Controllers
{
    public class FeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fees.ToListAsync());
        }

        // GET: Fee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fees = await _context.Fees
                .FirstOrDefaultAsync(m => m.FeeId == id);
            if (fees == null)
            {
                return NotFound();
            }

            return View(fees);
        }

        // GET: Fee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeeId,Amount")] Fees fees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fees);
        }

        // GET: Fee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fees = await _context.Fees.FindAsync(id);
            if (fees == null)
            {
                return NotFound();
            }
            return View(fees);
        }

        // POST: Fee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeeId,Amount")] Fees fees)
        {
            if (id != fees.FeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeesExists(fees.FeeId))
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
            return View(fees);
        }

        // GET: Fee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fees = await _context.Fees
                .FirstOrDefaultAsync(m => m.FeeId == id);
            if (fees == null)
            {
                return NotFound();
            }

            return View(fees);
        }

        // POST: Fee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fees = await _context.Fees.FindAsync(id);
            _context.Fees.Remove(fees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeesExists(int id)
        {
            return _context.Fees.Any(e => e.FeeId == id);
        }
    }
}
