using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicies.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public string OptionLetter { get; set; }
        public bool OptionIsCorrect { get; set; }

        //navigation property
        public Question Question { get; set; }

        //FK
        public int QuestionId { get; set; }

        
    }
}
