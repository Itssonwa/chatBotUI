using System;

public class User
{
    public string Name { get; private set; }

    public void GetName()
    {
        Console.Write("Buck: What is your name? ");
        Name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(Name))
        {
            Name = "friend";
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Buck: Howdy, {Name} its a pleaser to met ya!");
        Console.ResetColor();
    }
}
