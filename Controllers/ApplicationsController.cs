using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PO_projekt_implementacja_Puz.Data;
using PO_projekt_implementacja_Puz.Models;

namespace PO_projekt_implementacja_Puz.Controllers
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
            var applicationContext = _context.Applications.
                Include(a => a.Document)
                .Include(a => a.Candidate)
                .Include(a => a.Candidate.LoggedUserFkNavigation)
                .Include(a => a.Recruitment)
                .Include(a => a.Recruitment.FieldOfStudyFkNavigation)
                .Include(a => a.Recruitment.FieldOfStudyFkNavigation.FacultyFkNavigation)
                .Include(a => a.ApplicationStatus)
                .ToListAsync();
            return View(await applicationContext);

        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .Include(a => a.Document)
                .Include(a => a.Candidate)
                .Include(a => a.Candidate.LoggedUserFkNavigation)
                .Include(a => a.Recruitment)
                .Include(a => a.Recruitment.FieldOfStudyFkNavigation)
                .Include(a => a.Recruitment.FieldOfStudyFkNavigation.FacultyFkNavigation)
                .Include(a => a.ApplicationStatus)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (application == null)
            {
                return NotFound();
            }

            return View(application);

        }

    }
}
