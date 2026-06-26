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
 new Question("Which of these is most likely a phishing email?",
             "A", "A. Bank email asking you to verify your account with a link", "B. Company newsletter from a known address", "C. Receipt for something you bought"),

new Question("What is the main goal of a phishing attack?",
             "B", "A. To speed up your internet", "B. To steal personal or login information", "C. To give you free software"),

new Question("True or False: You should reuse the same strong password for all accounts.",
             "False"),

new Question("True or False: Password managers help you use unique passwords safely.",
             "True"),

new Question("What should you look for before entering card details on a site?",
             "A", "A. HTTPS and a padlock icon", "B. Lots of ads", "C. A .com ending"),

new Question("Is public Wi-Fi safe for online banking without a VPN?",
             "B", "A. Yes, always safe", "B. No, it can be intercepted by others", "C. Only at night"),

new Question("True or False: Social engineering tricks people instead of hacking computers directly.",
             "True"),

new Question("True or False: Someone pretending to be IT support on the phone is never a social engineering attack.",
             "False"),

new Question("What does 2FA add to your account security?",
             "C", "A. A faster login", "B. A new password", "C. A second verification step"),

new Question("Which is an example of 2FA?",
             "A", "A. Password + code sent to your phone", "B. Password only", "C. Username only"),

new Question("True or False: Ransomware locks your files and demands payment.",
             "True"),

new Question("True or False: Clicking random email attachments cannot install malware.",
             "False"),

new Question("True or False: Ransomware locks your files and demands payment.",
             "True"),

new Question("True or False: Clicking random email attachments cannot install malware.",
             "False"),

new Question("Why should you review app privacy settings?",
             "B", "A. To make your phone faster", "B. To control what data apps can access", "C. To get more storage"),

new Question("What does turning off location tracking help with?",
             "A", "A. Protecting your physical privacy", "B. Making photos brighter", "C. Increasing battery drain"),

new Question("What is the main benefit of regular data backups?",
             "C", "A. More free cloud storage", "B. Faster internet", "C. You can recover files after ransomware or device failure"),

new Question("Which is a good backup practice?",
             "A", "A. 3-2-1 rule: 3 copies, 2 media types, 1 offsite", "B. Keep only one copy on your desktop", "C. Never test your backups")
            };
        }
    }
}