using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PO_projekt_implementacja_Puz.Data;
using PO_projekt_implementacja_Puz.Models;

namespace PO_projekt_implementacja_Puz.Controllers
{
    public class FieldOfStudiesController : Controller
    {
        private readonly RecruitmentSystemContext _context;

        public FieldOfStudiesController(RecruitmentSystemContext context)
        {
            _context = context;
        }

        // GET: FieldOfStudies
        public async Task<IActionResult> Index()
        {
            var recruitmentSystemContext = _context.FieldOfStudies.Include(f => f.AcademicTitle).Include(f => f.DegreeLevel).Include(f => f.Faculty).Include(f => f.StudyForm);
            return View(await recruitmentSystemContext.ToListAsync());
        }

        // GET: FieldOfStudies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldOfStudy = await _context.FieldOfStudies
                .Include(f => f.AcademicTitle)
                .Include(f => f.DegreeLevel)
                .Include(f => f.Faculty)
                .Include(f => f.StudyForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fieldOfStudy == null)
            {
                return NotFound();
            }

            return View(fieldOfStudy);
        }

        // GET: FieldOfStudies/Create
        public IActionResult Create()
        {
            ViewData["AcademicTitleFk"] = new SelectList(_context.AcademicTitles, "Id", "Id");
            ViewData["DegreeLevelFk"] = new SelectList(_context.DegreeLevels, "Id", "Id");
            ViewData["FacultyFk"] = new SelectList(_context.Faculties, "Id", "Id");
            ViewData["StudyFormFk"] = new SelectList(_context.StudyForms, "Id", "Id");
            return View();
        }

        // POST: FieldOfStudies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FieldName,FieldAbbreviation,FieldDescription,AdmissionLimit,StudyProgram,StudyPlan,CourseCards,FacultyFk,StudyFormFk,DegreeLevelFk,AcademicTitleFk")] FieldOfStudy fieldOfStudy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldOfStudy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcademicTitleFk"] = new SelectList(_context.AcademicTitles, "Id", "Id", fieldOfStudy.AcademicTitleFk);
            ViewData["DegreeLevelFk"] = new SelectList(_context.DegreeLevels, "Id", "Id", fieldOfStudy.DegreeLevelFk);
            ViewData["FacultyFk"] = new SelectList(_context.Faculties, "Id", "Id", fieldOfStudy.FacultyFk);
            ViewData["StudyFormFk"] = new SelectList(_context.StudyForms, "Id", "Id", fieldOfStudy.StudyFormFk);
            return View(fieldOfStudy);
        }

        // GET: FieldOfStudies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldOfStudy = await _context.FieldOfStudies.FindAsync(id);
            if (fieldOfStudy == null)
            {
                return NotFound();
            }
            ViewData["AcademicTitleFk"] = new SelectList(_context.AcademicTitles, "Id", "Id", fieldOfStudy.AcademicTitleFk);
            ViewData["DegreeLevelFk"] = new SelectList(_context.DegreeLevels, "Id", "Id", fieldOfStudy.DegreeLevelFk);
            ViewData["FacultyFk"] = new SelectList(_context.Faculties, "Id", "Id", fieldOfStudy.FacultyFk);
            ViewData["StudyFormFk"] = new SelectList(_context.StudyForms, "Id", "Id", fieldOfStudy.StudyFormFk);
            return View(fieldOfStudy);
        }

        // POST: FieldOfStudies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FieldName,FieldAbbreviation,FieldDescription,AdmissionLimit,StudyProgram,StudyPlan,CourseCards,FacultyFk,StudyFormFk,DegreeLevelFk,AcademicTitleFk")] FieldOfStudy fieldOfStudy)
        {
            if (id != fieldOfStudy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldOfStudy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldOfStudyExists(fieldOfStudy.Id))
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
            ViewData["AcademicTitleFk"] = new SelectList(_context.AcademicTitles, "Id", "Id", fieldOfStudy.AcademicTitleFk);
            ViewData["DegreeLevelFk"] = new SelectList(_context.DegreeLevels, "Id", "Id", fieldOfStudy.DegreeLevelFk);
            ViewData["FacultyFk"] = new SelectList(_context.Faculties, "Id", "Id", fieldOfStudy.FacultyFk);
            ViewData["StudyFormFk"] = new SelectList(_context.StudyForms, "Id", "Id", fieldOfStudy.StudyFormFk);
            return View(fieldOfStudy);
        }

        // GET: FieldOfStudies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldOfStudy = await _context.FieldOfStudies
                .Include(f => f.AcademicTitle)
                .Include(f => f.DegreeLevel)
                .Include(f => f.Faculty)
                .Include(f => f.StudyForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fieldOfStudy == null)
            {
                return NotFound();
            }

            return View(fieldOfStudy);
        }

        // POST: FieldOfStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fieldOfStudy = await _context.FieldOfStudies.FindAsync(id);
            if (fieldOfStudy != null)
            {
                _context.FieldOfStudies.Remove(fieldOfStudy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldOfStudyExists(int id)
        {
            return _context.FieldOfStudies.Any(e => e.Id == id);
        }
    }
}
