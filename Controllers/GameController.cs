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
        private readonly IQuizRepository _quizRepository;


        public GameController(
            IDifficultyRepository difficultyRepository, 
            ITypeRepository typeRepository, 
            ICategoryRepository categoryRepository,
            IQuizRepository quizRepository)
        {
            _difficultyRepository = difficultyRepository;
            _typeRepository = typeRepository;
            _categoryRepository = categoryRepository;
            _quizRepository = quizRepository;
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
            //List<Answer> incorrectAnswers = new List<Answer>();
            //foreach(string incorrectAnswer in jsonQuestion.IncorrectAnswers)
            //{
            //    incorrectAnswers.Add(new Answer() { AnswerStatement = incorrectAnswer });
            //}

            Question question = new Question()
            {
                QuestionStatement = jsonQuestion.Question,
                CorrectAnswer = jsonQuestion.CorrectAnswer,
                //IncorrectAnswers = incorrectAnswers,
                IncorrectAnswers = jsonQuestion.IncorrectAnswers.ToList(),
                Category = jsonQuestion.Category,
                Type = _typeRepository.GetTypeByName(jsonQuestion.Type),
                Difficulty = _difficultyRepository.GetDifficultyByName(jsonQuestion.Difficulty)
            };

            return question;
        }

        public IActionResult ShowStatistics(int quizId, string responses, int currentQuestion, string response)
        {
            int goodAnswers = 0;
            Quiz quiz = _quizRepository.GetQuizById(quizId);
            List<string> tmpResponses = QuizViewModel.ResponsesFromJson(responses);
            tmpResponses[currentQuestion] = response;

            for (int i = 0; i<quiz.Questions.Count(); i ++)
            {
                if (quiz.Questions[i].CorrectAnswer.Equals(tmpResponses[i]))
                {
                    goodAnswers++;
                }
            }

            ViewBag.GoodAnswers = goodAnswers;
            ViewBag.Total = quiz.Questions.Count();

            return View();
        }

        public IActionResult PlayGame(GameOptionsViewModel gameOptions, bool newGame, int currentQuestion, int quizId, string response, string move, string responses)
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
                if(jsonQuiz.ResponseCode != 0)
                {
                    return RedirectToAction("NewGame");
                }

                Quiz quiz = CreateQuizModel(jsonQuiz);
                _quizRepository.InsertQuiz(quiz);


                // TEST CODE
                //Quiz quiz = _quizRepository.GetQuizById(6);

                Question question = quiz.Questions[0];

                QuizViewModel quizViewModel = new QuizViewModel()
                {
                    QuizId = quiz.QuizId,
                    CurrentQuestion = 0,
                    QuestionStatement = question.QuestionStatement,
                    Answers = SortAllAnswers(question.IncorrectAnswers, question.CorrectAnswer),
                    Responses = CreateEmptyList(quiz.Questions.Count()),
                    Category = question.Category,
                    Difficulty = question.Difficulty.DifficultyName
                };
                
                               
                return View(quizViewModel);
            }
            else
            {
                Quiz quiz = _quizRepository.GetQuizById(quizId);

                List<string> tmpResponses = QuizViewModel.ResponsesFromJson(responses);
                tmpResponses[currentQuestion] = response;
                   
                // Update Database

                // Validation Control
                if (move == "next")
                {
                    if(currentQuestion < quiz.Questions.Count() - 1)
                    {
                        currentQuestion++;
                    }
                }
                if(move == "previous")
                {
                    if(currentQuestion > 0)
                    {
                        currentQuestion--;
                    }

                }

                Question question = quiz.Questions[currentQuestion];
                QuizViewModel quizViewModel = new QuizViewModel()
                {
                    QuizId = quiz.QuizId,
                    CurrentQuestion = currentQuestion,
                    QuestionStatement = question.QuestionStatement,
                    Answers = SortAllAnswers(question.IncorrectAnswers, question.CorrectAnswer),
                    Responses = tmpResponses,
                    Category = question.Category,
                    Difficulty = question.Difficulty.DifficultyName
                };

                return View(quizViewModel);
            }
        }

        private List<string> CreateEmptyList(int capacity)
        {
            List<string> list = new List<string>(capacity);
            for (int i = 0; i<capacity; i++)
            {
                list.Add(null);
            }

            return list;
        }

        private List<string> SortAllAnswers(List<string> incorrectAnswers, string correctAnswer)
        {
            List<string> answers = new List<string>();
            foreach(string answer in incorrectAnswers)
            {
                answers.Add(answer);
            }
            answers.Add(correctAnswer);

            answers.Sort();
            return answers;
        }
    }
}
