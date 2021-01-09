using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QuizApp.Utils
{
    public class QuizWrap
    {
        public QuizWrap(JsonQuiz jsonQuiz)
        {
            List<QuestionWrap> questions = new List<QuestionWrap>();

            foreach(JsonQuestion jsonQuestion in jsonQuiz.Questions)
            {
                questions.Add(new QuestionWrap(jsonQuestion));
            }

            Questions = questions;
        }
        public IEnumerable<QuestionWrap> Questions { get; set; }
        public int QuizId { get; set; }
    }

    public class QuestionWrap
    {
        public QuestionWrap(JsonQuestion jsonQuestion)
        {
            Category = jsonQuestion.Category;
            Type = jsonQuestion.Type;
            Difficulty = jsonQuestion.Difficulty;
            Question = jsonQuestion.Question;
            Answers = setAnswers(jsonQuestion.IncorrectAnswers, jsonQuestion.CorrectAnswer);

        }

        private IEnumerable<string> setAnswers(IEnumerable<string> incorrectAnswers, string correctAnswer)
        {
            List<string> list = new List<string>();
            foreach(string str in incorrectAnswers)
            {
                list.Add(HttpUtility.HtmlDecode(str));
            }
            list.Add(HttpUtility.HtmlDecode(correctAnswer));

            list.Sort();
            return list;

        }

        private string _question;
        private IEnumerable<string> _answers;

        public string Category { get; set; }   
        
        public string Type { get; set; }       

        public string Difficulty { get; set; }  
        
        public string Question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = HttpUtility.HtmlDecode(value);
            }
        }
               
        public IEnumerable<string> Answers { get; set; }
    }
}
