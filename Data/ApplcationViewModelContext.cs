using Microsoft.EntityFrameworkCore;
using PO_projekt_implementacja_Puz.ViewModels;

namespace PO_projekt_implementacja_Puz.Data
{
    public class ApplicationViewModelContext
    {

        private readonly RecruitmentSystemContext _dbContext;


        public ApplicationViewModelContext( RecruitmentSystemContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<ApplicationViewModel>> GetApplicationViewModels() {

            return await  _dbContext.Applications
                .Include(a => a.Document)
                .Include(a => a.ApplicationStatus)
                .Include(a => a.Candidate)
                .Include(a => a.Candidate.LoggedUserFkNavigation)
                .Include(a => a.Recruitment)
                .Include(a => a.Recruitment.FieldOfStudyFkNavigation)
                .Include(a => a.Recruitment.FieldOfStudyFkNavigation.FacultyFkNavigation)
                .Include(a => a.Documents)
                .Select(a => new ApplicationViewModel
                {
                    Id = a.Id,
                    Identfier = a.ApplicationIdentifier.ToString(),
                    SubmissionDate = a.Document.CreationDate,
                    Status = a.ApplicationStatus,
                    Recruitment = a.Recruitment,
                    Candidate = a.Candidate,
                    Documents = a.Documents.Select( d => d.Name).ToList(),
                    RecruitmentIndex = a.RecruitmentIndex,



                }).ToListAsync();
        
        }



    }
}
