
// St10398445
//Manages the chat history during a session.

using System;
using System.Collections.Generic;

public class ChatSession
{
    public List<string> ChatHistory { get; set; } = new List<string>();

    public void DisplayResponse(string response) {
        // Ensure the response is displayed with the correct formatting
        Console.WriteLine(response); // This should now include the formatted response from ChatResponse
    }
}
