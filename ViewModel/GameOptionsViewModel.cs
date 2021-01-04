using QuizApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.ViewModel
{
    public class GameOptionsViewModel
    {
        public string SelectedDifficulty { get; set; }
        public IEnumerable<Difficulty> Difficulties { get; set; }
        public string SelectedType { get; set; }
        public IEnumerable<Type> Types { get; set; }
    }
}
