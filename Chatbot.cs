using System;

public class Chatbot
{
    private AudioPlayer audio;

    public Chatbot()
    {
        audio = new AudioPlayer();
        audio.PlayGreeting();
    }
    public string Respond(string input)
    {
        input = input.ToLower();

        string sentiment = DetectSentiment(input);

        string empathyMessage = ShowEmpathy(sentiment);

        if (input.Contains("phishing"))
        {
         return empathyMessage +
         "\nBuck: Phishing's like a snake oil salesman tryin' to steal your secrets.";
        }
        else if (input.Contains("malware"))
        {
         return empathyMessage +
         "\nBuck: Malware's like a rustler causin' trouble in your digital ranch.";
        }
        else if (input.Contains("stay safe"))
        {
         return empathyMessage +
         "\nBuck: Use strong passwords and avoid shady links, partner.";
        }
        else if (input.Contains("vpn"))
        {
         return empathyMessage +
         "\nBuck: A VPN keeps your online trail hidden from cyber varmints.";
        }
        else if (input.Contains("firewall"))
        {
         return empathyMessage +
         "\nBuck: A firewall guards your network like a sheriff guards a town.";
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