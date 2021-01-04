using QuizApp.Models;
using QuizApp.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.ViewModel
{
    public class GameOptionsViewModel
    {
        public int Count { get; set; }
        public string SelectedDifficulty { get; set; }
        public IEnumerable<Difficulty> Difficulties { get; set; }
        public string SelectedType { get; set; }
        public IEnumerable<Type> Types { get; set; }
        public string SelectedCategory { get; set; }
        public IEnumerable<JsonCategory> Categories { get; set; }
    }
}
