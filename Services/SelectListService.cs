using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PO_projekt_implementacja_Puz.Data;
using PO_projekt_implementacja_Puz.Models;

namespace PO_projekt_implementacja_Puz.Services
{
    public interface ISelectListService
    {
            public SelectList GetYearsSelectList(int? selectedYear, List<int> yearsList);
            public SelectList GetFacultiesSelectList(int selectedFacultyId, List<Faculty> facultiesList);
            public List<FieldSelectListItem> GetFieldsOfStudySelectList(int selectedFieldId, List<FieldOfStudy> fieldsList);

            public const int NOT_SELECTED = -1;

    }

    public class FieldSelectListItem
    {
        public string Text { get; set; }
        public string Id { get; set; }
        public string FacultyId { get; set; }
        public bool Selected { get; set; }
    }

    public class SelectListService: ISelectListService
    {
        
        public SelectList GetYearsSelectList(int? selectedYear, List<int> yearsList)
        {
             yearsList.Sort();

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

   

        public SelectList GetFacultiesSelectList(int selectedFacultyId, List<Faculty> facultiesList)
        {
         
            facultiesList.Insert(0, new Faculty { Id = ISelectListService.NOT_SELECTED, FacultyName = "---" });

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


    
        public List<FieldSelectListItem> GetFieldsOfStudySelectList(int selectedFieldId, List<FieldOfStudy> fieldsList)
        {
          

            fieldsList.Insert(0, new FieldOfStudy { Id = ISelectListService.NOT_SELECTED, FieldName = "---", FacultyFk = ISelectListService.NOT_SELECTED });

            var selectListFields = fieldsList
                .Select(field => new FieldSelectListItem
                {
                    Id = field.Id.ToString(),
                    Text = field.FieldName,
                    Selected = field.Id == selectedFieldId,
                    FacultyId = field.FacultyFk.ToString()
                })
                .ToList();

            return selectListFields;

        }




    }
}
