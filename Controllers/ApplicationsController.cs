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
using PO_projekt_implementacja_Puz.ViewModels;

namespace PO_projekt_implementacja_Puz.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly RecruitmentSystemContext _context;

        public ApplicationsController(RecruitmentSystemContext context)
        {
            _context = context;
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


        private List<int> GetApplicationYears()
        {
            return  _context.Applications
                .Include(a => a.Document)
                .ToList()
                .Select(app => app.Document)
                .ToList()
                .Select(doc => doc.CreationDate!.Value.Year)
                .Distinct()
                .ToList();

        }

        private SelectList GetYearsSelectList( int? selectedYear)
        {

            var yearsList = GetApplicationYears();

            var selectListYears = yearsList.Select(value => new SelectListItem
            {
                Value = value.ToString(),
                Text = value.ToString(),
                Selected = value == selectedYear
            })
            .ToList();

            selectListYears.Insert(0, new SelectListItem { Value = "", Text = "---", Selected = !yearsList.Any() });

            return new SelectList(selectListYears, "Value", "Text", selectedYear);

        }

        private SelectList GetFacultiesSelectList(int selectedFacultyId)
        {
            var facultiesList = _context.Faculties.ToList();

            facultiesList.Insert(0, new Faculty { Id = -1, FacultyName = "---" });

            var selectListFaculties = facultiesList
                .Select(faculty => new SelectListItem
                {
                    Value = faculty.Id.ToString(),
                    Text = faculty.FacultyName,
                    Selected = faculty.Id == selectedFacultyId
                })
                .ToList();

            return new SelectList(selectListFaculties, "Value", "Text", selectedFacultyId);
        }

        private SelectList GetFieldsOfStudySelectList(int selectedFieldId)
        {
            var fieldsList = _context.FieldOfStudies.ToList();

            fieldsList.Insert(0, new FieldOfStudy { Id = -1, FieldName = "---" });

            var selectListFields = fieldsList
                .Select(field => new SelectListItem
                {
                    Value = field.Id.ToString(),
                    Text = field.FieldName,
                    Selected = field.Id == selectedFieldId
                })
                .ToList();

            return new SelectList(selectListFields, "Value", "Text", selectedFieldId);

        }

        private List<Application> GetFilteredApplications(int? year, int facultyId, int fieldId)
        {
            var applications = GetAllApplications();

            if( year != null)
            {
                applications = applications.Where(app => app.Document.CreationDate.Value.Year == year).ToList();
            }

            if(  facultyId != -1)
            {
                applications = applications.Where( app => app.Recruitment.FieldOfStudy.FacultyFk ==  facultyId ).ToList();
            }

            if( fieldId != -1)
            {
                applications = applications.Where( app => app.Recruitment.FieldOfStudyFk == fieldId ).ToList(); 
            }

            return applications;



        }


        // GET: Applications
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new ApplicationsIndexViewModel
            {
                Applications = GetAllApplications(),
                Faculties = GetFacultiesSelectList(-1),
                FieldsOfStudy = GetFieldsOfStudySelectList(-1),
                Years = GetYearsSelectList(null),
                SelectedFacultyId = -1,
                SelectedFieldOfStudy = -1,
                SelectedYear = null,

            };

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Index(int? year, int facultyId, int fieldId)
        {
            var viewModel = new ApplicationsIndexViewModel
            {
                Applications = GetFilteredApplications(year, facultyId, fieldId),
                Faculties = GetFacultiesSelectList(facultyId),
                FieldsOfStudy = GetFieldsOfStudySelectList(fieldId),
                Years = GetYearsSelectList(year),
                SelectedFacultyId = -1,
                SelectedFieldOfStudy = -1,
                SelectedYear = null,

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
                .Include(a => a.Candidate.LoggedUser)
                .Include(a => a.Recruitment)
                .Include(a => a.Recruitment.FieldOfStudy)
                .Include(a => a.Recruitment.FieldOfStudy.Faculty)
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
