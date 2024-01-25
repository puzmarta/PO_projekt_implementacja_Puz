using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PO_projekt_implementacja_Puz.Data;
using PO_projekt_implementacja_Puz.Models;
using PO_projekt_implementacja_Puz.Services;
using PO_projekt_implementacja_Puz.ViewModels;

namespace PO_projekt_implementacja_Puz.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly RecruitmentSystemContext _context;
        private readonly IDBUtilsService _dbUtils;
        private readonly ISelectListService _selectListService;

        public ApplicationsController(RecruitmentSystemContext context, IDBUtilsService dbUtils, ISelectListService selectListService)
        {
            _context = context;
            _dbUtils = dbUtils;
            _selectListService = selectListService;
        }

        private List<Application> GetAllApplications()
        {
            return _context.Applications.
				Include(a => a.Document)
				.Include(a => a.Candidate)
				.Include(a => a.Candidate.LoggedUser)
				.Include(a => a.Recruitment)
				.Include(a => a.Recruitment.FieldOfStudy)
				.Include(a => a.Recruitment.FieldOfStudy.Faculty)
				.Include(a => a.ApplicationStatus)
				.ToList();

		}



     


        // GET: Applications
        [HttpGet]
        public ActionResult Index()
        {

            var applications = GetAllApplications();
            var facultySelectList = _selectListService.GetFacultiesSelectList(ISelectListService.NOT_SELECTED, _context.Faculties.ToList());
            var fieldSelectList = _selectListService.GetFieldsOfStudySelectList(ISelectListService.NOT_SELECTED, _context.FieldOfStudies.ToList());
            var yearsSelectList = _selectListService.GetYearsSelectList(null, _dbUtils.GetUniqueApplicationYears());

            var viewModel = new ApplicationsIndexViewModel
            {
                
                Applications = applications,
                Faculties = facultySelectList,
                FieldsOfStudy = fieldSelectList,
                Years = yearsSelectList,
                SelectedFacultyId = ISelectListService.NOT_SELECTED,
                SelectedFieldOfStudy = ISelectListService.NOT_SELECTED


            };

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Index(int? year, int facultyId, int fieldId)
        {
            var applications = _dbUtils.GetFilteredApplications(year, facultyId, fieldId);
            var facultySelectList = _selectListService.GetFacultiesSelectList(facultyId, _context.Faculties.ToList());
            var fieldSelectList = _selectListService.GetFieldsOfStudySelectList(fieldId, _context.FieldOfStudies.ToList());
            var yearsSelectList = _selectListService.GetYearsSelectList(year, _dbUtils.GetUniqueApplicationYears());


            var viewModel = new ApplicationsIndexViewModel
            {
                Applications = applications,
                Faculties = facultySelectList,
                FieldsOfStudy = fieldSelectList,
                Years = yearsSelectList,
                SelectedFacultyId = facultyId,
                SelectedFieldOfStudy = fieldId
     

            };

            return View(viewModel);

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
                .Include(a => a.Candidate.Gender)
                .Include(a => a.Candidate.LoggedUser)
                .Include(a => a.Recruitment)
                .Include(a => a.Recruitment.FieldOfStudy)
                .Include(a => a.Recruitment.FieldOfStudy.Faculty)
                .Include(a => a.ApplicationStatus)
                .Include(a => a.Recruitment.FieldOfStudy.DegreeLevel)
                .Include(a => a.Documents)
                .Include(a => a.HighSchoolDiploma.Document)
                
                .FirstOrDefaultAsync(a => a.Id == id);

            if (application == null)
            {
                return NotFound();
            }

            ViewBag.IconFilename = _dbUtils.MapIconToStatus(application.ApplicationStatus);

            return View(application);

        }

    }
}
