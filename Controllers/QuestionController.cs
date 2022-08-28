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
    public class QuestionController : ControllerBase
    {
        private readonly PerfectPoliciesContext _context;

        public QuestionController (PerfectPoliciesContext context)
        {
            _context = context;
        }

        // GET: api/<QuestionController>
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return Ok(_context.Questions.AsEnumerable());
        }

        // GET: api/<QuestionController>/GetForQuizId
        [HttpGet]
        [Route("GetForQuizId/{id}")]
        public ActionResult<IEnumerable<Question>> GetForQuizId(int id)
        {
            return Ok(_context.Questions.Where(c => c.QuizId == id).AsEnumerable());
        }

        // GET api/<QuestionController>/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            var question = _context.Questions.Find(id);
            return question == null ? NotFound() : question;
        }

        // POST api/<QuestionController>
        [HttpPost]
        public void Post([FromBody] QuestionCreate question)
        {
            Question newQuestion = new Question
            {
                QuestionTopic = question.QuestionTopic,
                QuestionText = question.QuestionText,
                QuestionImageUrl = question.QuestionImageUrl,
                QuizId = question.QuizId
            };

            _context.Questions.Add(newQuestion);

            //List<int> numberList = new List<int>();

            _context.SaveChanges();
        }

        // PUT api/<QuestionController>/5
        [Authorize(Roles = "Admin")]
        // if (Roles = "Admin") is applied, in the tokenController has to difine
        //new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin")
        // Otherwise. remove  new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin") and (Roles = "Admin") 
        [HttpPut("{id}")]
        public ActionResult Put(int id, Question question)
        {
            _context.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<QuestionController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }
    }
}
