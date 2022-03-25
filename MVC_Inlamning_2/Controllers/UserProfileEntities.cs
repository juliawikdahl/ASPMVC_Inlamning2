#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Inlamning_2.Models.Data;

namespace MVC_Inlamning_2.Controllers
{
    public class UserProfileEntities : Controller
    {
        private readonly AppDbContext _context;

        public UserProfileEntities(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserProfileEntities
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserProfiles.Include(u => u.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserProfileEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfileEntity = await _context.UserProfiles
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProfileEntity == null)
            {
                return NotFound();
            }

            return View(userProfileEntity);
        }

        // GET: UserProfileEntities/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserProfileEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,PostalCode,City,Country,UserId")] UserProfileEntity userProfileEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProfileEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userProfileEntity.UserId);
            return View(userProfileEntity);
        }

        // GET: UserProfileEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfileEntity = await _context.UserProfiles.FindAsync(id);
            if (userProfileEntity == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userProfileEntity.UserId);
            return View(userProfileEntity);
        }

        // POST: UserProfileEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,PostalCode,City,Country,UserId")] UserProfileEntity userProfileEntity)
        {
            if (id != userProfileEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfileEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileEntityExists(userProfileEntity.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userProfileEntity.UserId);
            return View(userProfileEntity);
        }

        // GET: UserProfileEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfileEntity = await _context.UserProfiles
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProfileEntity == null)
            {
                return NotFound();
            }

            return View(userProfileEntity);
        }

        // POST: UserProfileEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProfileEntity = await _context.UserProfiles.FindAsync(id);
            _context.UserProfiles.Remove(userProfileEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProfileEntityExists(int id)
        {
            return _context.UserProfiles.Any(e => e.Id == id);
        }
    }
}
