using chatBotUI;
using System;

public class Chatbot
{
    private AudioPlayer audio;

    private string currentTopic = "";

    public Chatbot()
    {
     audio = new AudioPlayer();
     audio.PlayGreeting();
    }
    private int currentLogIndex = 0;

    private string GetActivityLog()
    {
        if (ActivityLog.Log.Count == 0)
            return "Buck: I ain't done anything yet, partner.";

        string output = "Buck: Here's what I've been up to:\n\n";

        int end = Math.Min(currentLogIndex + 5, ActivityLog.Log.Count);

        for (int i = currentLogIndex; i < end; i++)
        {
            output += (i + 1) + ". " + ActivityLog.Log[i] + "\n";
        }

        if (end < ActivityLog.Log.Count)
        {
            output += "\nType 'show more' to see more activities.";
        }

        currentLogIndex = end;

        return output;
    }

    public string Respond(string input)
    {
        if (input.Contains("show activity log") ||
    input.Contains("what have you done for me"))
        {
            currentLogIndex = 0;
            return GetActivityLog();
        }
        input = input.ToLower();

        string sentiment = DetectSentiment(input);

        string empathyMessage = ShowEmpathy(sentiment);

        if (input == "show more")
        {
            return GetActivityLog();
        }

        if (input.Contains("phishing"))
        {
            currentTopic = "phishing";

            string response = empathyMessage +
            "\nBuck: Phishing's like a snake oil salesman tryin' to steal your secrets.";

            if (sentiment == "curious")
            {
             response += "\nBuck: I admire that curiosity partner. Learnin' about scams keeps ya safe.";
            }
            else if (sentiment == "worried")
            {
             response += "\nBuck: Don't fret partner. Most phishing scams can be spotted if ya stay alert.";
            }

            return response;
        }
        else if (input.Contains("password"))
        {
            currentTopic = "password";
         return empathyMessage +
            "\nBuck: Make sure ya use strong, unique passwords for every account partner.\n Avoid birthdays or easy words.";
        }

        else if (input.Contains("scam"))
        {
            currentTopic = "scam";
         return empathyMessage +
            "\nBuck: Online scams often try to trick folks into giving money or personal info.";
        }

        else if (input.Contains("malware"))
        {
            currentTopic = "malware";
         return empathyMessage +
            "\nBuck: Malware's like a rustler causin' trouble in your digital ranch.";
        }

        else if (input.Contains("privacy"))
        {
            currentTopic = "privacy";
         return empathyMessage +
            "\nBuck: Protect your privacy by avoidin' oversharin' personal information online and using secure websites.";
        }

        else if (input.Contains("vpn"))
        {
           currentTopic = "vpn";
         return empathyMessage +
            "\nBuck: A VPN keeps your online trail hidden from cyber varmints.";
        }

        else if (input.Contains("firewall"))
        {
           currentTopic = "firewall";
         return empathyMessage +
            "\nBuck: A firewall guards your network like a sheriff guards a town.";
        }

        else if (input.Contains("stay safe"))
        {
           currentTopic = "safety";
         return empathyMessage +
            "\nBuck: Use strong passwords and avoid shady links, partner.";
        }

        else if (input.Contains("tell me more"))
        {
            if (currentTopic == "phishing")
            {
             return "Buck: Phishing emails often pretend to be banks or trusted companies to fool ya.";
            }

            else if (currentTopic == "password")
            {
                return "Buck: A strong password's like a sturdy ranch fence,partner.\n Mix in numbers, symbols, uppercase, and lowercase letters to keep them cyber bandits out.";
            }

            else if (currentTopic == "scam")
            {
                return "Buck: Them scammers are sneakier than coyotes in the night, partner.\n They often disguise themselves as banks, stores, or even government folk to trick unsuspectin' cowpokes.";
            }

            else if (currentTopic == "privacy")
            {
             return "Buck: Privacy settings on social media can help protect your personal information.";
            }

            else if (currentTopic == "malware")
            {
             return "Buck: Malware can slow down your device or even steal important information.";
            }

            else if (currentTopic == "vpn")
            {
              return "Buck: VPNs are mighty useful when using public Wi-Fi in cafes or airports.";
            }

            else if (currentTopic == "firewall")
            {
              return "Buck: Firewalls monitor incoming and outgoing traffic to block dangerous connections.";
            }

            else
            {
              return "Buck: Tell me which topic ya want to hear more about partner.";
            }
        }


        else if (input.Contains("another tip"))
        {
            return "Buck: Always double-check links before clickin' em partner.";
         }

        else
        {
            return "Buck: I ain't quite sure about that partner.";
         }
      }

    private string DetectSentiment(string input)
    {
        if (input.Contains("worried") ||
            input.Contains("scared") ||
            input.Contains("afraid"))
        {
         return "worried";
        }
        if (input.Contains("curious") ||
            input.Contains("wondering") ||
            input.Contains("interested"))
        {
         return "curious";
        }
        if (input.Contains("frustrated") ||
            input.Contains("confused") ||
            input.Contains("flustered") ||
            input.Contains("annoyed"))
        {
         return "frustrated";
        }

        return "neutral";
    }
    private string ShowEmpathy(string sentiment)
    {
        switch (sentiment)
        {
          case "worried":
             return "Buck: I hear ya partner. Cyber threats can be scary.";

          case "curious":
             return "Buck: I like that curiosity partner!";

          case "frustrated":
             return "Buck: Easy there partner, I got your back.";

          default:
             return "";
        }
    }
}
