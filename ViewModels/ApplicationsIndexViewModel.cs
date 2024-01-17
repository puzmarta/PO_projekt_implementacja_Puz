using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using PO_projekt_implementacja_Puz.Models;

namespace PO_projekt_implementacja_Puz.ViewModels
{
	public class ApplicationsIndexViewModel
	{

		public List<Application> Applications { get; set; }
		public SelectList  Faculties { get; set; }
		public SelectList FieldsOfStudy { get; set; }
		public SelectList Years { get; set; }

		public int SelectedFacultyId { get; set; }
		public int SelectedFieldOfStudy {  get; set; }	

		public int? SelectedYear { get; set; }

	



	}
}
