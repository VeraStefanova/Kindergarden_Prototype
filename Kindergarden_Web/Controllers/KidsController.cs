using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kindergarden_Data;
using Kindergarden_Models;

namespace Kindergarden_Web.Controllers
{
    public class KidsController : Controller
    {
        private readonly KindergardenDbContext _context;

        public KidsController(KindergardenDbContext context)
        {
            _context = context;
        }

        // GET: Kids
        public async Task<IActionResult> Index()
        {
            var kindergardenDbContext = _context.Kids.Include(k => k.Group).Include(k => k.Parent);
            return View(await kindergardenDbContext.ToListAsync());
        }

        // GET: Kids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kid = await _context.Kids
                .Include(k => k.Group)
                .Include(k => k.Parent)
                .FirstOrDefaultAsync(m => m.KidId == id);
            if (kid == null)
            {
                return NotFound();
            }

            return View(kid);
        }

        // GET: Kids/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName");
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "Address");
            return View();
        }

        // POST: Kids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KidId,FirstName,LastName,Age,ParentId,GroupId")] Kid kid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName", kid.GroupId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "Address", kid.ParentId);
            return View(kid);
        }

        // GET: Kids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kid = await _context.Kids.FindAsync(id);
            if (kid == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName", kid.GroupId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "Address", kid.ParentId);
            return View(kid);
        }

        // POST: Kids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KidId,FirstName,LastName,Age,ParentId,GroupId")] Kid kid)
        {
            if (id != kid.KidId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KidExists(kid.KidId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupName", kid.GroupId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "Address", kid.ParentId);
            return View(kid);
        }

        // GET: Kids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kid = await _context.Kids
                .Include(k => k.Group)
                .Include(k => k.Parent)
                .FirstOrDefaultAsync(m => m.KidId == id);
            if (kid == null)
            {
                return NotFound();
            }

            return View(kid);
        }

        // POST: Kids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kid = await _context.Kids.FindAsync(id);
            if (kid != null)
            {
                _context.Kids.Remove(kid);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KidExists(int id)
        {
            return _context.Kids.Any(e => e.KidId == id);
        }
    }
}
