using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PO_projekt_implementacja_Puz.Data;
using PO_projekt_implementacja_Puz.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;

namespace PO_projekt_implementacja_Puz.Controllers
{
    public class QuestionaryController : Controller
    {

        private readonly RecruitmentSystemContext _context;
        public const int NO_CURRENT_QUESTION = -1;


        public QuestionaryController(RecruitmentSystemContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Start()
        {
            int questionPoolId = 1;
            List<Question> questions = _context.Questions.Where(q => q.QuestionPoolFk == questionPoolId).ToList();
            HttpContext.Session.SetString("questions", JsonConvert.SerializeObject(questions));
            HttpContext.Session.SetInt32("currentQuestionIndex", NO_CURRENT_QUESTION);


            return View();
        }


        [HttpGet]
        public IActionResult NextQuestion()
        {
            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(HttpContext.Session.GetString("questions"));
            int currentQuestionIndex = HttpContext.Session.GetInt32("currentQuestionIndex") ?? NO_CURRENT_QUESTION;

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
            int currentQuestionIndex = HttpContext.Session.GetInt32("currentQuestionIndex") ?? NO_CURRENT_QUESTION;

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
        public IActionResult SaveAnswer(string answer)
        {

            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(HttpContext.Session.GetString("questions"));
            int currentQuestionIndex = HttpContext.Session.GetInt32("currentQuestionIndex") ?? NO_CURRENT_QUESTION;
            string serializedSavedAnswers = HttpContext.Session.GetString("savedAnswers");

            if (currentQuestionIndex == -1)
            {
                return BadRequest();
            }

            try
            {
                int currentQuestionId = questions[currentQuestionIndex].Id;
                Dictionary<int, string>? savedAnswers = (serializedSavedAnswers != null) ?
                    JsonConvert.DeserializeObject<Dictionary<int, string>>(serializedSavedAnswers) :
             
                    new Dictionary<int, string>();

   
                savedAnswers[currentQuestionId] = answer;
                HttpContext.Session.SetString("savedAnswers", JsonConvert.SerializeObject(savedAnswers));

            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound();
            }


            return RedirectToAction("NextQuestion", "Questionary");
        }


        [HttpGet]
        public IActionResult Result()
        {
            int currentQuestionIndex = HttpContext.Session.GetInt32("currentQuestionIndex") ?? NO_CURRENT_QUESTION;
            if(currentQuestionIndex == NO_CURRENT_QUESTION)
            {
                return NotFound();
            }

            Dictionary<int, string> savedAnswers = JsonConvert.DeserializeObject<Dictionary<int, string>>(HttpContext.Session.GetString("savedAnswers")) ?? new Dictionary<int, string>();

            Dictionary<int,int>? pointsMapping = SumPointForFieldsBasedOnAnswers(savedAnswers);

            if (pointsMapping == null)
                return View(null);

            else
                return View(GetFieldOfStudyRecommendation(pointsMapping));

        }

        private List<AnswerMapping> GetQuestionMappings(int questionId, string answer)
        {
            return  _context.AnswerMappings.Where(
                    map => map.Answer == answer && map.QuestionFk == questionId).ToList();

        }


        private Dictionary<int, int>? SumPointForFieldsBasedOnAnswers(Dictionary<int, string> answers)
        {

            Dictionary<int, int> fieldPoints = new Dictionary<int, int>();
        

            foreach( var answer in answers)
            {
                List<AnswerMapping> temp = GetQuestionMappings(answer.Key, answer.Value);

                foreach (var answerMapping in temp)
                {
                    fieldPoints[answerMapping.FieldOfStudyFk] =+ answerMapping.Points;

                }
            }

            if (fieldPoints.Count == 0)
                return null;

            else return fieldPoints;
        }


        private FieldOfStudy? GetFieldOfStudyRecommendation(Dictionary<int, int> points)
        {

            int? keyWithMaxValue = null;
            int max = int.MinValue;
            bool isMaxValueUnique = true;

            foreach (var kvp in points)
            {
                if (kvp.Value > max)
                {
                    max = kvp.Value;
                    keyWithMaxValue = kvp.Key;
                    isMaxValueUnique = true;
                }
                else if (kvp.Value == max)
                {
                    isMaxValueUnique = false;
                }
            }

            if (!isMaxValueUnique)
                return null;

            FieldOfStudy? recommendation = _context.FieldOfStudies.Where(f => f.Id == keyWithMaxValue).FirstOrDefault();

            return recommendation;
        }


    }


   


}
