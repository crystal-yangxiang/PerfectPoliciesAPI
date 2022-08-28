using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectPolicies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectPolicies.DTO;

namespace PerfectPolicies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly PerfectPoliciesContext _context;

        public ReportController(PerfectPoliciesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// return quiz title and how many question is under each quiz from database
        /// </summary>
        /// <returns></returns>

        [HttpGet("QuestionPerQuizReport")]
        public IActionResult QuestionPerQuizReport()
        {
            var quizzesWithQuestions = _context.Quizzes.Include(c => c.Questions).ToList();

            List<QuestionsPerQuizViewModel> reportData = quizzesWithQuestions.Select(c => new QuestionsPerQuizViewModel
            {
                QuizTitle = c.QuizTitle,
                QuestionCount = c.Questions.Count
            }).ToList();

            return Ok(reportData);
        }
    }
}
