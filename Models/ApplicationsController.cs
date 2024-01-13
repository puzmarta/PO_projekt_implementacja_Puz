using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PO_projekt_implementacja_Puz.Data;

namespace PO_projekt_implementacja_Puz.Models
{
    public class ApplicationsController : Controller
    {
        private readonly RecruitmentSystemContext _context;

        public ApplicationsController(RecruitmentSystemContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            var recruitmentSystemContext = _context.Applications.Include(a => a.ApplicationStatus).Include(a => a.Candidate).Include(a => a.Document).Include(a => a.HighSchoolDiploma).Include(a => a.Recruitment);
            return View(await recruitmentSystemContext.ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .Include(a => a.ApplicationStatus)
                .Include(a => a.Candidate)
                .Include(a => a.Document)
                .Include(a => a.HighSchoolDiploma)
                .Include(a => a.Recruitment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            ViewData["ApplicationStatusFk"] = new SelectList(_context.ApplicationStatuses, "Id", "Id");
            ViewData["CandidateFk"] = new SelectList(_context.Candidates, "Id", "Id");
            ViewData["DocumentFk"] = new SelectList(_context.Documents, "Id", "Id");
            ViewData["HighSchoolDiplomaFk"] = new SelectList(_context.HighSchoolDiplomas, "Id", "Id");
            ViewData["RecruitmentFk"] = new SelectList(_context.Recruitments, "Id", "Id");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationIdentifier,RecruitmentIndex,CandidateFk,RecruitmentFk,ApplicationStatusFk,HighSchoolDiplomaFk,DocumentFk")] Application application)
        {
            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationStatusFk"] = new SelectList(_context.ApplicationStatuses, "Id", "Id", application.ApplicationStatusFk);
            ViewData["CandidateFk"] = new SelectList(_context.Candidates, "Id", "Id", application.CandidateFk);
            ViewData["DocumentFk"] = new SelectList(_context.Documents, "Id", "Id", application.DocumentFk);
            ViewData["HighSchoolDiplomaFk"] = new SelectList(_context.HighSchoolDiplomas, "Id", "Id", application.HighSchoolDiplomaFk);
            ViewData["RecruitmentFk"] = new SelectList(_context.Recruitments, "Id", "Id", application.RecruitmentFk);
            return View(application);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            ViewData["ApplicationStatusFk"] = new SelectList(_context.ApplicationStatuses, "Id", "Id", application.ApplicationStatusFk);
            ViewData["CandidateFk"] = new SelectList(_context.Candidates, "Id", "Id", application.CandidateFk);
            ViewData["DocumentFk"] = new SelectList(_context.Documents, "Id", "Id", application.DocumentFk);
            ViewData["HighSchoolDiplomaFk"] = new SelectList(_context.HighSchoolDiplomas, "Id", "Id", application.HighSchoolDiplomaFk);
            ViewData["RecruitmentFk"] = new SelectList(_context.Recruitments, "Id", "Id", application.RecruitmentFk);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationIdentifier,RecruitmentIndex,CandidateFk,RecruitmentFk,ApplicationStatusFk,HighSchoolDiplomaFk,DocumentFk")] Application application)
        {
            if (id != application.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.Id))
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
            ViewData["ApplicationStatusFk"] = new SelectList(_context.ApplicationStatuses, "Id", "Id", application.ApplicationStatusFk);
            ViewData["CandidateFk"] = new SelectList(_context.Candidates, "Id", "Id", application.CandidateFk);
            ViewData["DocumentFk"] = new SelectList(_context.Documents, "Id", "Id", application.DocumentFk);
            ViewData["HighSchoolDiplomaFk"] = new SelectList(_context.HighSchoolDiplomas, "Id", "Id", application.HighSchoolDiplomaFk);
            ViewData["RecruitmentFk"] = new SelectList(_context.Recruitments, "Id", "Id", application.RecruitmentFk);
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .Include(a => a.ApplicationStatus)
                .Include(a => a.Candidate)
                .Include(a => a.Document)
                .Include(a => a.HighSchoolDiploma)
                .Include(a => a.Recruitment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application != null)
            {
                _context.Applications.Remove(application);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}
