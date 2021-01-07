using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizApp.Models;
using QuizApp.Utils;
using QuizApp.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IDifficultyRepository _difficultyRepository;
        private readonly ITypeRepository _typeRepository;

        public GameController(IDifficultyRepository difficultyRepository, ITypeRepository typeRepository)
        {
            _difficultyRepository = difficultyRepository;
            _typeRepository = typeRepository;
        }

        public IActionResult NewGame()
        {
            GameOptionsViewModel gameOptions = new GameOptionsViewModel();            
            gameOptions.Difficulties = _difficultyRepository.AllDifficulties;
            gameOptions.Types = _typeRepository.AllTypes;
            gameOptions.Categories = WebService.GetCategories();            
            
            return View(gameOptions);
        }

        public IActionResult PlayGame(GameOptionsViewModel gameOptions)
        {
            // Creating the Quiz from the options entered (gameOptions)
            Difficulty d = _difficultyRepository.GetDifficultyById(System.Int32.Parse(gameOptions.SelectedDifficulty));
            Type t = _typeRepository.GetTypeById(System.Int32.Parse(gameOptions.SelectedType));

            // Generate API URL
            string apiUrl = WebService.CreateApiUrl(gameOptions.Count, d, t, System.Int32.Parse(gameOptions.SelectedCategory));

            // Getting the Quiz from URL
            JsonQuiz quiz = WebService.GetQuizFromUrl(apiUrl);

            // Validation PENDING
            if (quiz == null)
            {
                //return ErrorPageView();
                return NotFound();
            }

            QuizViewModel quizViewModel = new QuizViewModel() { Quiz = quiz };

            return View(quizViewModel);
        }
    }
}
