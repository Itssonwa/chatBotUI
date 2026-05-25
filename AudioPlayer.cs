using System;
using System.Media;

public class AudioPlayer
{
    public void PlayGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("Greeting.wav");
            player.Load();
            player.PlaySync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Buck: Sorry partner, theres an Audio error" + ex.Message);
        }
    }
}