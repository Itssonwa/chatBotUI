using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace chatBotUI
{
    public class Question
    {
        public string QuestionText { get; set; }

        public string Answer { get; set; }

        public Question(string question, string answer)
        {
            QuestionText = question;
            Answer = answer;
        }
    }
}