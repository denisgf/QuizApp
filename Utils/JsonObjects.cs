using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Utils
{
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
