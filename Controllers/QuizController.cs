using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfectPolicies.DTO;
using PerfectPolicies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectPolicies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly PerfectPoliciesContext _context;

        public QuizController (PerfectPoliciesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Return all quizzes from database
        /// </summary>
        /// <returns>action result</returns>

        // GET: api/<QuizController>
        [HttpGet]
        public ActionResult<IEnumerable<Quiz>> Get()
        {
            return Ok(_context.Quizzes.AsEnumerable());
        }

        /// <summary>
        /// Return a single quiz from database (based on quidId
        /// </summary>
        /// <param name="id">quiz id</param>
        /// <returns>action result</returns>

        // GET api/<QuizController>/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Quiz> Get(int id)
        {
            var quiz = _context.Quizzes.Find(id);
            return quiz == null ? NotFound() : quiz;
        }

        /// <summary>
        /// Create a new quiz to store in the database
        /// </summary>
        /// <param name="quiz"></param>
        // POST api/<QuizController>
        [HttpPost]
        public void Post([FromBody] QuizCreate quiz)
        {
            Quiz newQuiz = new Quiz
            {
                QuizTitle = quiz.QuizTitle,
                QuizTopic = quiz.QuizTopic,
                QuizCreatorName = quiz.QuizCreatorName,
                QuizCreatedDate = quiz.QuizCreatedDate,
                PassPercentage = quiz.PassPercentage
            };
            _context.Quizzes.Add(newQuiz);

            List<int> numberList = new List<int>();

            _context.SaveChanges();
        }

        /// <summary>
        /// Edit a single quiz details (based on QuizId)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quiz"></param>
        /// <returns></returns>
        // PUT api/<QuizController>/5
        [Authorize(Roles = "Admin")]
        // if (Roles = "Admin") is applied, in the tokenController has to difine
        //new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin")
        // Otherwise. remove  new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin") and (Roles = "Admin")       
        [HttpPut("{id}")]
        public ActionResult Put(int id, Quiz quiz)
        {
            _context.Entry(quiz).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Delete a single Quiz (based on QuizId)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<QuizController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var quiz = _context.Quizzes.Find(id);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
