using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicies.DTO
{
    public class QuizCreate
    {
        public string QuizTitle { get; set; }
        public string QuizTopic { get; set; }
        public string QuizCreatorName { get; set; }
        public DateTime? QuizCreatedDate { get; set; }
        public int PassPercentage { get; set; }
    }
}
