using BootstrapWebseite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapWebseite.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Test()
        {
            TestModel model = new TestModel()
            {
                QuestionCount = 5
            };

            return View(model);
        }
    }
}