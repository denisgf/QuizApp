using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizApp.Models;
using QuizApp.ViewModel;
using System;
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
            
            return View(gameOptions);
        }
    }
}
