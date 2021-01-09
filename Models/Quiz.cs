using QuizApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class Quiz
    {        
        public int QuizId { get; set; }
        //public string QuizName { get; set; }
        public List<Question> Questions { get; set; } 
    }
}
