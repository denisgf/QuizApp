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
            //return _appDbContext.Quizzes.Include(q => q.Questions).FirstOrDefault(q => q.QuizId == quizId);
            //return _appDbContext.Quizzes
            //    .Include(e => e.Questions)
            //        .ThenInclude(e => e.Difficulty)
            //    .Include(e => e.Questions)
            //        .ThenInclude(e => e.Type)
            //    .FirstOrDefault(q => q.QuizId == quizId);
            return _appDbContext.Quizzes.Where(q => q.QuizId == quizId)
                .Include(q => q.Questions)
                    .ThenInclude(e => e.Difficulty)
                .FirstOrDefault(); 
        }

        public void InsertQuiz(Quiz quiz)
        {
            _appDbContext.Quizzes.Add(quiz);


            _appDbContext.SaveChanges();
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
