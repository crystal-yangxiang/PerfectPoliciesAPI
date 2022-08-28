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
    public class OptionController : ControllerBase
    {
        private readonly PerfectPoliciesContext _context;
        public OptionController(PerfectPoliciesContext context)
        {
            _context = context;
        }

        // GET: api/<OptionController>
        [HttpGet]
        public ActionResult<IEnumerable<Option>> Get()
        {
            return Ok(_context.Options.AsEnumerable());
        }

        // GET: api/<OptionController>/GetForQuestionId
        [HttpGet]
        [Route("GetForQuestionId/{id}")]
        public ActionResult<IEnumerable<Option>> GetForQuestionId(int id)
        {
            return Ok(_context.Options.Where(c => c.QuestionId == id).AsEnumerable());
        }

        // GET api/<OptionController>/5
        [HttpGet("{id}")]
        public ActionResult<Option> Get(int id)
        {
            var option = _context.Options.Find(id);
            return option == null ? NotFound() : option;
        }

        // POST api/<OptionController>
        [HttpPost]
        public void Post([FromBody] OptionCreate option)
        {
            Option newOption = new Option
            {
                OptionText = option.OptionText,
                OptionLetter = option.OptionLetter,
                OptionIsCorrect = option.OptionIsCorrect,
                QuestionId = option.QuestionId
            };

            _context.Options.Add(newOption);

            //List<int> numberList = new List<int>();

            _context.SaveChanges();
        }

        // PUT api/<OptionController>/5
        [Authorize(Roles = "Admin")]
        // if (Roles = "Admin") is applied, in the tokenController has to difine
        //new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin")
        // Otherwise. remove  new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin") and (Roles = "Admin") 
        [HttpPut("{id}")]
        public ActionResult Put(int id, Option option)
        {
            _context.Entry(option).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<OptionController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var option = _context.Options.Find(id);
            if (option != null)
            {
                _context.Options.Remove(option);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }
    }
}
