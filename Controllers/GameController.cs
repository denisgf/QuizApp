using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizApp.Models;
using QuizApp.Utils;
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
        private readonly ICategoryRepository _categoryRepository;

        public GameController(IDifficultyRepository difficultyRepository, ITypeRepository typeRepository, ICategoryRepository categoryRepository)
        {
            _difficultyRepository = difficultyRepository;
            _typeRepository = typeRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult NewGame()
        {
            GameOptionsViewModel gameOptions = new GameOptionsViewModel();            
            gameOptions.Difficulties = _difficultyRepository.AllDifficulties;
            gameOptions.Types = _typeRepository.AllTypes;
            gameOptions.Categories = WebService.GetCategories();            
            
            return View(gameOptions);
        }

        private Quiz CreateQuizModel(JsonQuiz jsonQuiz)
        {
            List<Question> questions = new List<Question>();
            foreach(JsonQuestion jsonQuestion in jsonQuiz.Questions)
            {
                Question question = CreateQuestionModel(jsonQuestion);
                questions.Add(question);
            }
            return new Quiz() { Questions = questions };
        }

        private Question CreateQuestionModel(JsonQuestion jsonQuestion)
        {
            List<Answer> incorrectAnswers = new List<Answer>();
            foreach(string incorrectAnswer in jsonQuestion.IncorrectAnswers)
            {
                incorrectAnswers.Add(new Answer() { AnswerStatement = incorrectAnswer });
            }

            return new Question()
            {
                QuestionStatement = jsonQuestion.Question,
                CorrectAnswer = new Answer() { AnswerStatement = jsonQuestion.CorrectAnswer },
                IncorrectAnswers = incorrectAnswers,
                Category = _categoryRepository.GetCategoryByName(jsonQuestion.Category),
                Type = _typeRepository.GetTypeByName(jsonQuestion.Type),
                Difficulty = _difficultyRepository.GetDifficultyByName(jsonQuestion.Difficulty)
            };
        }

        public IActionResult PlayGame(GameOptionsViewModel gameOptions, bool newGame, string json)
        {
            if (newGame)
            {
                // Creating the Quiz from the options entered (gameOptions)
                Difficulty d = _difficultyRepository.GetDifficultyById(System.Int32.Parse(gameOptions.SelectedDifficulty));
                Models.Type t = _typeRepository.GetTypeById(System.Int32.Parse(gameOptions.SelectedType));

                // Generate API URL
                string apiUrl = WebService.CreateApiUrl(gameOptions.Count, d, t, System.Int32.Parse(gameOptions.SelectedCategory));

                // Getting the Quiz from URL
                JsonQuiz jsonQuiz = WebService.GetQuizFromUrl(apiUrl);

                // Validation PENDING
                if (jsonQuiz == null)
                {
                    //return ErrorPageView();
                    return NotFound();
                }

                Quiz quiz = CreateQuizModel(jsonQuiz);

                QuizViewModel quizViewModel = new QuizViewModel()
                {
                    QuizId = quiz.QuizId,
                    CurrentQuestion = 0,
                    QuestionStatement = quiz.Questions[0].QuestionStatement,
                    Answers = SortAllAnswers(quiz.Questions[0].IncorrectAnswers, quiz.Questions[0].CorrectAnswer),
                    Responses= new List<string>(quiz.Questions.Count()) 
                };
                               
                return View(quizViewModel);
            }
            else
            {
                //QuizViewModel quiz = QuizViewModel.fromJson(json);
                return View();
            }
        }

        private List<string> SortAllAnswers(List<Answer> incorrectAnswers, Answer correctAnswer)
        {
            List<string> answers = new List<string>();
            foreach(Answer answer in incorrectAnswers)
            {
                answers.Add(answer.AnswerStatement);
            }
            answers.Add(correctAnswer.AnswerStatement);

            answers.Sort();
            return answers;
        }
    }
}
