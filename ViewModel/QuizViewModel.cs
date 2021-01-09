using Newtonsoft.Json;
using QuizApp.Models;
using QuizApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.ViewModel
{
    public class QuizViewModel
    {
        public int QuizId { get; set; }
        public int CurrentQuestion { get; set; }
        public string QuestionStatement { get; set; }
        public List<string> Answers { get; set; }
        public List<string> Responses { get; set; }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static QuizViewModel fromJson(string json)
        {
            return JsonConvert.DeserializeObject<QuizViewModel>(json);
        }
    }
}
