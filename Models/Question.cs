using QuizApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class Question
    {        
        public int QuestionId { get; set; }
        public string QuestionStatement { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> IncorrectAnswers { get; set; }
        public string Category { get; set; }
        public Type Type { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
