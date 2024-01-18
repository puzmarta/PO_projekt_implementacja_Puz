using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PO_projekt_implementacja_Puz.Data;
using PO_projekt_implementacja_Puz.Models;

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

            List<Question> questions = _context.Questions.ToList();
            HttpContext.Session.SetString("questions", JsonConvert.SerializeObject(questions));
            HttpContext.Session.SetInt32("currentQuestionIndex", -1);


            return View();
        }


        [HttpGet]
        public IActionResult NextQuestion()
        {
            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(HttpContext.Session.GetString("questions"));
            int currentQuestionIndex = HttpContext.Session.GetInt32("currentQuestionIndex") ?? -1;

            try
            {
                if (currentQuestionIndex == questions.Count() - 1)
                    return RedirectToAction( "Result", "Questionary");

                Question question = questions[currentQuestionIndex + 1];
                HttpContext.Session.SetInt32("currentQuestionIndex", currentQuestionIndex + 1);
                return View("Question", question);

            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult PreviousQuestion()
        {
            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(HttpContext.Session.GetString("questions"));
            int currentQuestionIndex = HttpContext.Session.GetInt32("currentQuestionIndex") ?? -1;

            try
            {
                if (currentQuestionIndex  == 0)
                    return RedirectToAction("Start", "Questionary");

                Question question = questions[currentQuestionIndex - 1];
                HttpContext.Session.SetInt32("currentQuestionIndex", currentQuestionIndex - 1);
                return View("Question", question);

            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound();
            }
        }



        [HttpPost]
        public IActionResult SaveAnswer(int questionId, char answer)
        {
            //TODO (save answer for session)

            return RedirectToAction("NextQuestion", "Questionary");
        }


        [HttpGet]
        public IActionResult Result()
        {

           

            return View(null);

        }

    }
}
