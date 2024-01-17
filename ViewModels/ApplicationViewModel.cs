using Microsoft.Identity.Client;
using PO_projekt_implementacja_Puz.Models;

namespace PO_projekt_implementacja_Puz.ViewModels
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }

        public string? Identfier { get; set; }

        public DateOnly? SubmissionDate { get; set; }

        public ApplicationStatus? Status { get; set; }

        public Recruitment? Recruitment { get; set; }

        public Candidate? Candidate { get; set; }

        public List<String>? Documents { get; set; }

        public double RecruitmentIndex { get; set; }

    }
}
