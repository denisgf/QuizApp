using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public interface IQuizRepository
    {
        IEnumerable<Quiz> AllQuizzes { get; }
        Quiz GetQuizById(int quizId);

        public void InsertQuiz(Quiz quiz);
    }
}
