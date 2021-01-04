using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public interface IDifficultyRepository
    {
        IEnumerable<Difficulty> AllDifficulties { get; }
        Difficulty GetDifficultyById(int id);
    }
}
