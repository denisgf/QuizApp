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
        public Answer CorrectAnswer { get; set; }
        public List<Answer> IncorrectAnswers { get; set; }
        public Category Category { get; set; }
        public Type Type { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
