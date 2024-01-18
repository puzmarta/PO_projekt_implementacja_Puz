using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PO_projekt_implementacja_Puz.Data;

namespace PO_projekt_implementacja_Puz.Controllers
{
    public class QuestionaryController : Controller
    {

        private readonly RecruitmentSystemContext _context;


        public QuestionaryController(RecruitmentSystemContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Start()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Question(int id)
        {
         

            var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }


        [HttpPost]

        public void SaveAnswer(int questionId, char answer)
        {
            //TODO (save answer for session)

            RedirectToAction("Quesionary", "Question", new {id = questionId});
        }

    }
}
