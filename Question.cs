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
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }

        public Question(string question,
                        string answer,
                        string optionA,
                        string optionB,
                        string optionC)
        {
            QuestionText = question;
            Answer = answer;
            OptionA = optionA;
            OptionB = optionB;
            OptionC = optionC;
        }

        public Question(string question, string answer)
        {
            QuestionText = question;
            Answer = answer;

            OptionA = "True";
            OptionB = "False";
            OptionC = "";
        }
    }
}