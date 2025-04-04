// St10398445
//Defines the structure for chatbot responses.using System;


using System.Threading;

public class ChatResponse
{
    public string Question { get; set; }
    public string Answer { get; set; }

    public string GenerateResponse(string userInput) {
        //Generates a response using the user's input
        return $"Nice to meet you, {userInput}! How can I assist you today?";
    }

    public void DisplayResponse(string response)
    {
        Console.ForegroundColor = ConsoleColor.Cyan; // Set color to cyan
        foreach (char c in response)
        {
            Console.Write(c);
            Thread.Sleep(100); // Adjust the typing speed here (milliseconds)
        }
        Console.ResetColor(); // Reset color after displaying the response
        Console.WriteLine(); // Move to the next line after the response
    }
}
