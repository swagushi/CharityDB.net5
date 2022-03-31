using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CharityDB.net5.Data;
using CharityDB.net5.Models;

namespace CharityDB.net5.Views
{
    public class donations1Controller : Controller
    {
        private readonly Context _context;

        public donations1Controller(Context context)
        {
            _context = context;
        }

        // GET: donations1
        public async Task<IActionResult> Index()
        {
            return View(await _context.donations.ToListAsync());
        }

        // GET: donations1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donations = await _context.donations
                .FirstOrDefaultAsync(m => m.donationsID == id);
            if (donations == null)
            {
                return NotFound();
            }

            return View(donations);
        }

        // GET: donations1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: donations1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("donationsID,donationName,donationPrice,donationDescription,TransactionID,TransactionName,Banktype,AccountNumber")] donations donations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donations);
        }

        // GET: donations1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donations = await _context.donations.FindAsync(id);
            if (donations == null)
            {
                return NotFound();
            }
            return View(donations);
        }

        // POST: donations1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("donationsID,donationName,donationPrice,donationDescription,TransactionID,TransactionName,Banktype,AccountNumber")] donations donations)
        {
            if (id != donations.donationsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!donationsExists(donations.donationsID))
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
            return View(donations);
        }

        // GET: donations1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donations = await _context.donations
                .FirstOrDefaultAsync(m => m.donationsID == id);
            if (donations == null)
            {
                return NotFound();
            }

            return View(donations);
        }

        // POST: donations1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donations = await _context.donations.FindAsync(id);
            _context.donations.Remove(donations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool donationsExists(int id)
        {
            return _context.donations.Any(e => e.donationsID == id);
        }
    }
}
