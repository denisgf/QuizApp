using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly AppDbContext _appDbContext;
        public AnswerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Answer> GetAnswersByQuestioId(int questionId)
        {
            throw new NotImplementedException();
        }
    }
}
