using System;
// Threading is used for delays and effects
// Reference: https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread.sleep
using System.Threading;
// For using List<T>
// Reference: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1
using System.Collections.Generic;
// For using LINQ methods like FirstOrDefault
// Reference: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault
using System.Linq;

using System.IO; // For file path handling
using System.Media; // For audio playback

/// <summary>
/// This is a simple Cyber Security Chatbot console app.
/// It starts with a delay and typing animation, shows an ASCII title,
/// asks for the user’s name, and responds to predefined cybersecurity questions
/// with a typing effect. It also stores conversation history.
/// </summary>
class Program
{
    static void Main()
    {
        // Pause for 1.2 seconds before starting
        // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread.sleep
        Thread.Sleep(1200);
        ShowStartMessage();
    }

    static void ShowStartMessage()
    {
        // Clear the console screen
        // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.console.clear
        Console.Clear();

        // Set console text color to magenta
        // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.console.foregroundcolor
        Console.ForegroundColor = ConsoleColor.Magenta;

        // Show a message one character at a time
        // Reference: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in
        string message = "Press 1 to start...";
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(100); // typing delay
        }

        // Reset console color
        // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.console.resetcolor
        Console.ResetColor();

        // Read user input
        // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.console.readline
        string input = Console.ReadLine().Trim();

        if (input == "1")
        {
            Welcome(); // Proceed
        }
        else
        {
            Console.WriteLine("Invalid input. Please press 1 to start.");
            ShowStartMessage(); // Retry
        }
    }

    static void Welcome()
    {
        // PLayes audio file BotVoice.wav / welcome voice
        AudioManager.PlayWelcomeSoundAsync();
        string asciiMessage = @"
   ___      _                 __        __             _           _     _              _   
  / __\   _| |__   ___ _ __  / _\ __ _ / _| ___       /_\  ___ ___(_)___| |_ __ _ _ __ | |_ 
 / / | | | | '_ \ / _ \ '__| \ \ / _` | |_ / _ \     //_\\/ __/ __| / __| __/ _` | '_ \| __|
/ /__| |_| | |_) |  __/ |    _\ \ (_| |  _|  __/    /  _  \__ \__ \ \__ \ || (_| | | | | |_ 
\____/\__, |_.__/ \___|_|    \__/\__,_|_|  \___|    \_/ \_/___/___/_|___/\__\__,_|_| |_|\__|
      |___/                                                                                 
";

        // Random flickering effect
        // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.random
        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            if (rand.Next(2) == 0)
            {
                Console.Clear();
            }

            string glitchedMessage = Utilities.ApplyGlitchEffect(asciiMessage, rand);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(glitchedMessage);
            Console.ResetColor();

            Thread.Sleep(rand.Next(50, 200));

            if (i == 9)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(asciiMessage);
                Console.ResetColor();


            }
        }

        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("    Welcome to the Cyber Security Chatbot!");
        Console.WriteLine("------------------------------------------------\n");

        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine().Trim();

        // Fallback for empty names
        // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorempty
        if (string.IsNullOrEmpty(userName))
        {
            userName = "User";
        }

        Console.WriteLine($"\nChatBot: Nice to meet you, {userName}! How can I assist you today?\n");

        DisplayAvailableQuestions();

        ChatSession session = new ChatSession(); // Conversation history

        while (true)
        {
            ChatInteraction(session);
        }
    }

    static void DisplayAvailableQuestions()
    {
        string[] questions = new string[]
        {
            "How are you?",
            "What is phishing?",
            "What is a strong password?",
            "What is public Wi-Fi?",
            "How to avoid malware?"
        };

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine("    Here are some questions you can ask:");
        Console.WriteLine("--------------------------------------------------");

        foreach (string question in questions)
        {
            Console.WriteLine($"    {question}");
        }

        Console.WriteLine("--------------------------------------------------");
        Console.ResetColor();
    }

    static void ChatInteraction(ChatSession session)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("You: ");
        Console.ResetColor();

        string input = Console.ReadLine().Trim();

        if (input == "1")
        {
            Console.Clear();
            Welcome();
            return;
        }

        if (string.IsNullOrEmpty(input))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ChatBot: Please type something!");
            Console.ResetColor();
            return;
        }

        string response = GetResponse(input);
        session.ChatHistory.Add($"You: {input}");
        session.ChatHistory.Add($"ChatBot: {response}");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("ChatBot: ");
        Utilities.TypeEffect(response); // Typing effect (custom)
        Console.ResetColor();
    }

    static string GetResponse(string question)
    {
        // Convert user input to lowercase
        // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.string.tolower
        question = question.ToLower();

        // Predefined chatbot responses
        List<ChatResponse> responses = new List<ChatResponse>
        {
            new ChatResponse { Question = "how are you", Answer = "I'm good! Remember to never share your personal details online." },
            new ChatResponse { Question = "what is phishing", Answer = "Phishing is a scam where attackers trick you into giving personal info. Don't click on suspicious links!" },
            new ChatResponse { Question = "strong password", Answer = "Use a mix of uppercase, lowercase, numbers, and symbols. At least 12 characters long!" },
            new ChatResponse { Question = "public wifi", Answer = "Public Wi-Fi is risky! Use a VPN and avoid logging into sensitive accounts." },
            new ChatResponse { Question = "avoid malware", Answer = "Don't download files from unknown sources. Keep your software updated!" }
        };

        // Match the user input with a known question
        // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault
        var response = responses.FirstOrDefault(r => question.Contains(r.Question));

        if (response != null)
            return response.Answer;

        return "I don't know how to respond to that.";
    }
}
