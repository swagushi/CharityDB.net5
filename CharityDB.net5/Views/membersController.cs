using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CharityDB;
using CharityDB.net5.Models;

namespace CharityDB.net5.Views
{
    public class membersController : Controller
    {
        private readonly net5Context _context;

        public membersController(net5Context context)
        {
            _context = context;
        }

        // GET: members
        public async Task<IActionResult> Index()
        {
            return View(await _context.members.ToListAsync());
        }

        // GET: members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.members
                .FirstOrDefaultAsync(m => m.membersId == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // GET: members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("membersId,membersName,FirstName,LastName,Email,Password")] members members)
        {
            if (ModelState.IsValid)
            {
                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(members);
        }

        // GET: members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.members.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }
            return View(members);
        }

        // POST: members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("membersId,membersName,FirstName,LastName,Email,Password")] members members)
        {
            if (id != members.membersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!membersExists(members.membersId))
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
            return View(members);
        }

        // GET: members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.members
                .FirstOrDefaultAsync(m => m.membersId == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // POST: members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var members = await _context.members.FindAsync(id);
            _context.members.Remove(members);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool membersExists(int id)
        {
            return _context.members.Any(e => e.membersId == id);
        }
    }
}
