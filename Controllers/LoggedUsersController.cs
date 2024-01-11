using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PO_projekt_implementacja_Puz.Models;

namespace PO_projekt_implementacja_Puz.Controllers
{
    public class LoggedUsersController : Controller
    {
        private readonly TestContext _context;

        public LoggedUsersController(TestContext context)
        {
            _context = context;
        }

        // GET: LoggedUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoggedUsers.ToListAsync());
        }

        // GET: LoggedUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loggedUser = await _context.LoggedUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loggedUser == null)
            {
                return NotFound();
            }

            return View(loggedUser);
        }

        // GET: LoggedUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoggedUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsActive,AccountCreationDate,Email,Password,FirstName,LastName")] LoggedUser loggedUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loggedUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loggedUser);
        }

        // GET: LoggedUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loggedUser = await _context.LoggedUsers.FindAsync(id);
            if (loggedUser == null)
            {
                return NotFound();
            }
            return View(loggedUser);
        }

        // POST: LoggedUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsActive,AccountCreationDate,Email,Password,FirstName,LastName")] LoggedUser loggedUser)
        {
            if (id != loggedUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loggedUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoggedUserExists(loggedUser.Id))
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
            return View(loggedUser);
        }

        // GET: LoggedUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loggedUser = await _context.LoggedUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loggedUser == null)
            {
                return NotFound();
            }

            return View(loggedUser);
        }

        // POST: LoggedUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loggedUser = await _context.LoggedUsers.FindAsync(id);
            if (loggedUser != null)
            {
                _context.LoggedUsers.Remove(loggedUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoggedUserExists(int id)
        {
            return _context.LoggedUsers.Any(e => e.Id == id);
        }
    }
}
