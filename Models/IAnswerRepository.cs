using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public interface IAnswerRepository
    {
        public IEnumerable<Answer> GetAnswersByQuestioId(int questionId);
    }
}
