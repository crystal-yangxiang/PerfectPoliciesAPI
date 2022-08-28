using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicies.DTO
{
    public class OptionCreate
    {

        public string OptionText { get; set; }
        public string OptionLetter { get; set; }
        public bool OptionIsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
