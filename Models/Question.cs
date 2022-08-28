using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicies.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionTopic { get; set; }
        public string QuestionText { get; set; }
        public string QuestionImageUrl { get; set; }

        //nevagation property
        public ICollection<Option> Options { get; set; }

        public Quiz Quiz { get; set; }

        //FK
        public int QuizId { get; set; }
    }
}
