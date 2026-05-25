using System;

public class Chatbot
{
    private User user;
    private AudioPlayer audio;

    public Chatbot()
    {
        user = new User();
        audio = new AudioPlayer();
    }
    public void Start()
    {
        ShowAsciiArt();
        audio.PlayGreeting();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Buck: Howdy,welcome to the Cybersecurity Chatbot![tips hat] ");
        Console.WriteLine("Buck:  Ya got any security questions that need answerin ?");
        Console.ResetColor();

        user.GetName();

        while (true)
        {
            Console.Write("You: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                ShowError("Ya gotta type something,friend.");
                continue;
            }

            input = input.ToLower();
            if (input == "exit")
            {
                Console.WriteLine("Buck: Stay safe online Partner. Adios!");
                break;
            }
            Respond(input);
        }
    }
    private void Respond(string input)
    {
        string sentiment = DetectSentiment(input);

        if (sentiment != "neutral")
        {
            ShowEmpathy(sentiment);
        }

        Console.ForegroundColor = ConsoleColor.Blue;

        if (input.Contains("phishing"))
        {
            Console.WriteLine("Buck: Phishing's like a snake oil salesman, tryin' to swindle your secrets outta ya.");
        }
        else if (input.Contains("malware"))
        {
            Console.WriteLine("Buck: Malware's like a rustler sneakin' into your digital ranch, causin' trouble.");
        }
        else if (input.Contains("stay safe"))
        {
            Console.WriteLine("Buck: Lock down them passwords, avoid shady links, and keep your systems updated.");
        }
        else if (input.Contains("vpn"))
        {
            Console.WriteLine("Buck: A VPN's like a secret tunnel through the desert—keeps your data safe and hidden.");
        }
        else if (input.Contains("firewall"))
        {
            Console.WriteLine("Buck: A firewall’s the sheriff of your network, keepin’ bad folks out.");
        }
        else
        {
            Console.WriteLine("Buck: I ain't quite sure about that, partner. Try askin' about cybersecurity.");
        }

        Console.ResetColor();
    }
    private string DetectSentiment(string input)
    {
        if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid"))
            return "worried";

        if (input.Contains("curious") || input.Contains("interested"))
            return "curious";

        if (input.Contains("frustrated") || input.Contains("confused") || input.Contains("annoyed"))
            return "frustrated";

        return "neutral";
    }
    private void ShowEmpathy(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;

        switch (sentiment)
        {
            case "worried":
                Console.WriteLine("Buck: I hear ya, partner. It's normal to feel worried about these things. Let's make sure you're safe.");
                break;

            case "curious":
                Console.WriteLine("Buck: I like that curiosity, partner! Let's explore this together.");
                break;

            case "frustrated":
                Console.WriteLine("Buck: Easy there, partner. This stuff can get mighty confusing, but I got your back.");
                break;
        }

        Console.ResetColor();
    }
    private void ShowAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@" 
====================================================================
______       _____  _   __ ______ _  __  ______  _____  _____ ______
| ___ \ | | /  __ \| | / / |_   _| | | ||  ___| | ___ \|  _  |_   _|
| |_/ / | | | /  \/| |/ /    | | | |_| || |__   | |_/ /| | | | | |  
| ___ \ | | | |    |    \    | | |  _  ||  __|  | ___ \| | | | | |  
| |_/ / |_| | \__/\| |\  \   | | | | | || |___  | |_/ /\ \_/ / | |  
\____/ \___/ \____/\_| \_/   \_/ \_| |_/\____/  \____/  \___/  \_/  

 ===================================================================                                                                   
                                                                    
    ");
        Console.ResetColor();
    }
    private void ShowError(string message)
    {
     Console.ForegroundColor = ConsoleColor.Red;
     Console.WriteLine("Buck: " + message);
     Console.ResetColor();
    }
}