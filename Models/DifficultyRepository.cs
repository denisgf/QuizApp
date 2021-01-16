using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly AppDbContext _appDbContext;
        public DifficultyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Difficulty> AllDifficulties => _appDbContext.Difficulties;

        public Difficulty GetDifficultyById(int id)
        {
            return _appDbContext.Difficulties.FirstOrDefault(d => d.DifficultyId == id);
        }

        public Difficulty GetDifficultyByName(string difficultyDescription)
        {
            return _appDbContext.Difficulties.FirstOrDefault(d => d.Description.Equals(difficultyDescription));
        }
    }
}
