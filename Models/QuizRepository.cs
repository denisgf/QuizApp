using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class QuizRepository : IQuizRepository
    {
        private readonly AppDbContext _appDbContext;
        public QuizRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public Quiz GetQuizById(int quizId)
        {
            return _appDbContext.Quizzes.FirstOrDefault(q => q.QuizId == quizId);
        }

        public IEnumerable<Quiz> AllQuizzes
        {
            get
            {
                return _appDbContext.Quizzes.Include(q => q.Questions);
            }
        }
    }
}
