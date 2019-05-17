using BootstrapWebseite.Data.Classes;
using BootstrapWebseite.Data.Enums;
using BootstrapWebseite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace BootstrapWebseite.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Test()
        {
            TestModel model = new TestModel()
            {
                QuestionCount = LoadJson().Count
            };

            return View(model);
        }

        public ActionResult LoadQuestion(int number)
        {
            number--;
            List<Object> questions = LoadJson();

            switch (((JObject)questions[number]).ToObject<Question>().Type)
            {
                case QuestionType.Normal:
                    return PartialView("Questions/Question", ((JObject)questions[number]).ToObject<Question>());
                case QuestionType.Image:
                    return PartialView("Questions/ImageQuestion", ((JObject)questions[number]).ToObject<ImageQuestion>());
                case QuestionType.Video:
                    return PartialView("Questions/VideoQuestion", ((JObject)questions[number]).ToObject<VideoQuestion>());
                default:
                    break;
            }
            return PartialView();
        }

        private List<Object> LoadJson()
        {
            using (StreamReader r = new StreamReader(Server.MapPath(@"../Data/TestData/QuestionsAnsweres.json")))
            {
                string json = r.ReadToEnd();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Object>>(json);
            }
        }
    }
}