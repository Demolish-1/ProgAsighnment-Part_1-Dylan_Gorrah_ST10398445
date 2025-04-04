// ST10398445 Dylan Gorrah
// Handals Animations Trewout project


using System;
using System.Threading;

public static class Utilities
{
    // Method to apply glitch effects by randomly modifying characters
    public static string ApplyGlitchEffect(string message, Random rand)
    {
        char[] messageArray = message.ToCharArray();

        for (int i = 0; i < messageArray.Length; i++)
        {
            if (rand.Next(100) < 10) // 10% chance to apply glitch
            {
                messageArray[i] = (char)rand.Next(33, 127); // Replace with a random ASCII character
            }
        }

        return new string(messageArray);
    }

    // Function to create a typing effect for the response only
    public static void TypeEffect(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(50); // Adjust speed: Lower means faster typing
        }
        Console.WriteLine();
    }
}



