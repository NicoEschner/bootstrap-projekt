using BootstrapWebseite.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootstrapWebseite.Data.Classes
{
    public class Question
    {
        public string QuestionStr { get; set; }
        public List<string> Selections { get; set; }
        public string Answere { get; set; }
        public QuestionType Type { get; set; }
    }
}