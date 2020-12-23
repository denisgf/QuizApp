using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _appDbContext;
        public QuestionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Question> AllQuestions => _appDbContext.Questions;

        public Question GetQuestionById(int questionId)
        {
            return _appDbContext.Questions.FirstOrDefault(q => q.QuestionId == questionId);
        }
    }
}
