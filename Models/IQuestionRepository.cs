using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> AllQuestions { get; }

        public Question GetQuestionById(int questionId);
    }
}
