using Newtonsoft.Json;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace QuizApp.Utils
{
    public class WebService
    {
        public static IEnumerable<JsonCategory> GetCategories()
        {
            try
            {
                string json = string.Empty;
                string url = @"https://opentdb.com/api_category.php";

                ServicePointManager.Expect100Continue = true;
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                    var JsonObj = JsonConvert.DeserializeObject<JsonTriviaCategories>(json);
                    if (JsonObj != null)
                    {
                        return JsonObj.Categories;
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }

            return Enumerable.Empty<JsonCategory>();
        }

        public static string CreateApiUrl(int count, Difficulty d, Models.Type t, int categoryId)
        {
            string apiUrl = @"https://opentdb.com/api.php?amount=" + count;

            if (categoryId != -1)
            {
                apiUrl += @"&category=" + categoryId;
            }

            if (d != null)
            {
                apiUrl += @"&difficulty=" + d.Description;
            }

            if (t != null)
            {
                apiUrl += @"&type=" + t.Description;
            }

            return apiUrl;
        }

        public static JsonQuiz GetQuizFromUrl(string apiUrl)
        {
            try
            {
                string json = string.Empty;
                
                ServicePointManager.Expect100Continue = true;
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                    
                    var JsonObj = JsonConvert.DeserializeObject<JsonQuiz>(json);
                    if (JsonObj != null)
                    {
                        return JsonObj;
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            return null;
        }


    }
}
