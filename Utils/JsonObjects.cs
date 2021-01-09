using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QuizApp.Utils
{

    public class JsonQuiz
    {
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
        
        [JsonProperty("results")]
        public IEnumerable<JsonQuestion> Questions { get; set; }
    }

    public class JsonQuestion        
    {
        private string _correctAnswer;

        [JsonProperty("category")]
        public string Category { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("correct_answer")]
        public string CorrectAnswer
        {
            get
            {
                return _correctAnswer;
            }
            set
            {
                _correctAnswer = HttpUtility.HtmlDecode(value);
            }
        }

        [JsonProperty("incorrect_answers")]
        public IEnumerable<string> IncorrectAnswers { get; set; }
    }

    public class JsonTriviaCategories
    {
        [JsonProperty("trivia_categories")]
        public IEnumerable<JsonCategory> Categories { get; set; }
    }

    public class JsonCategory
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
