using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace chatBotUI
{
    public class Quiz
    {
        public List<Question> Questions { get; set; }

        public int CurrentQuestion = 0;

        public int Score = 0;

        public Quiz()
        {
            Questions = new List<Question>()
            {
    new Question("What is malware?",
             "Malicious software designed to harm or exploit devices"),

new Question("What does MFA stand for?",
             "Multi-Factor Authentication"),

new Question("True or False: Backing up data protects you from ransomware.",
             "True"),

new Question("What should you check before entering card details on a website?",
             "Look for HTTPS and a padlock in the address bar"),

new Question("What is a strong password?",
             "Long, random, and unique to each account"),

new Question("True or False: Shutting down your PC removes all viruses.",
             "False"),

new Question("What is social engineering?",
             "Manipulating people to give up confidential info"),

new Question("What does 2FA add to your account?",
             "An extra verification step besides your password"),

new Question("What should you do with old devices before selling them?",
             "Factory reset and wipe the data"),

new Question("True or False: Antivirus alone makes you 100% safe.",
             "False"),

new Question("What is a phishing link?",
             "A fake link designed to steal login details or data"),

new Question("What is encryption?",
             "Scrambling data so only authorized people can read it")
            };
        }
    }
}