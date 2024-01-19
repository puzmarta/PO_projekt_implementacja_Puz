using Microsoft.EntityFrameworkCore;
using PO_projekt_implementacja_Puz.Data;
using PO_projekt_implementacja_Puz.Models;

namespace PO_projekt_implementacja_Puz.Services
{

    public interface IDBUtilsService
    {
        public List<Application> GetFilteredApplications(int? year, int facultyId, int fieldId);
        public List<int> GetUniqueApplicationYears();


    }



    public class DBUtilsService: IDBUtilsService
    {
        private readonly RecruitmentSystemContext _context;


        public DBUtilsService(RecruitmentSystemContext context) {  _context = context; }


        public List<Application> GetFilteredApplications(int? year, int facultyId, int fieldId)
        {
            var applications = _context.Applications
                .Include(a => a.Document)
                .Include(a => a.Candidate)
                .Include(a => a.Candidate.LoggedUser)
                .Include(a => a.Recruitment)
                .Include(a => a.Recruitment.FieldOfStudy)
                .Include(a => a.Recruitment.FieldOfStudy.Faculty)
                .Include(a => a.ApplicationStatus)
                .Include(a => a.Recruitment.FieldOfStudy.DegreeLevel)
                .Include(a => a.Documents)
                .ToList();

            if (year != null)
            {
                applications = applications.Where(app => app.Document.CreationDate.Value.Year == year).ToList();
            }

            if (facultyId != -1)
            {
                applications = applications.Where(app => app.Recruitment.FieldOfStudy.FacultyFk == facultyId).ToList();
            }

            if (fieldId != -1)
            {
                applications = applications.Where(app => app.Recruitment.FieldOfStudyFk == fieldId).ToList();
            }

            return applications;



        }


        public List<int> GetUniqueApplicationYears()
        {
            return _context.Applications
                .Include(a => a.Document)
                .ToList()
                .Select(app => app.Document)
                .ToList()
                .Select(doc => doc.CreationDate!.Value.Year)
                .Distinct()
                .ToList();

        }


    }
}
