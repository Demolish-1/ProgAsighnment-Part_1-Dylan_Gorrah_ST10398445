

-----------------------------------------------------------

This is the main entry point of the application. It contains the logic for initializing the chatbot and managing user interactions. Key components include:

- **Main Method**: The entry point of the program, which starts the chatbot after a brief delay.

- **ShowStartMessage()**: Displays a welcome message and prompts the user to start the chatbot.

- **Welcome()**: Welcomes the user, asks for their name, and displays available questions they can ask the chatbot. It also initializes a `ChatSession` to keep track of the conversation.

- **DisplayAvailableQuestions()**: Lists the questions that the user can ask the chatbot.

- **ChatInteraction(ChatSession session)**: Handles the conversation flow, taking user input and generating responses. It stores the chat history in the `ChatSession`.

- **GetResponse(string question)**: Matches user input with predefined questions and returns the corresponding answer. If no match is found, it returns a default response.

------------------------------------------------------------

# Cyber Security Chatbot Program Summary

- **Purpose**: 
  - The program serves as an interactive chatbot that provides information on cybersecurity topics, helping users understand key concepts and best practices.

- **File Structure**:
  - The program consists of three main files:
    - `Program.cs`: The main entry point of the application.
    - `ChatResponse.cs`: Defines the structure for chatbot responses.
    - `ChatSession.cs`: Manages the chat history during a session.
    - 'Utilities.cs' : Handles animaed ASCI Logo on start
     
- **Key Features**:
  - **User Interaction**:
    - The program starts with a welcome message and prompts the user to enter their name.
    - It displays a list of questions that users can ask the chatbot.

  - **Typing Effect**:
    - Responses from the chatbot are displayed with a typing effect to enhance user experience.

  - **Glitch Effect**:
    - The welcome message includes a glitch effect for visual appeal.

- **Core Components**:
  - **Main Method**:
    - Initializes the program and calls the `ShowStartMessage` method to begin user interaction.

  - **ShowStartMessage()**:
    - Clears the console and displays a message prompting the user to press "1" to start.
    - Handles user input to either proceed to the welcome message or retry on invalid input.

  - **Welcome()**:
    - Displays an ASCII art welcome message with a glitch effect.
    - Prompts the user for their name and greets them.
    - Calls `DisplayAvailableQuestions()` to show the questions the user can ask.

  - **DisplayAvailableQuestions()**:
    - Lists predefined questions related to cybersecurity that the user can inquire about.

  - **ChatInteraction(ChatSession session)**:
    - Manages the conversation flow, taking user input and generating responses.
    - Stores the chat history in the `ChatSession` object.

  - **GetResponse(string question)**:
    - Matches user input with predefined questions and returns the corresponding answer.
    - If no match is found, it returns a default response indicating that the chatbot cannot respond.

- **Data Structures**:
  - **ChatResponse Class**:
    - Contains properties for `Question` and `Answer`, representing the chatbot's knowledge base.

  - **ChatSession Class**:
    - Maintains a list of chat history, storing both user inputs and chatbot responses.

- **User Experience**:
  - The chatbot provides friendly and informative responses, encouraging users to engage in discussions about cybersecurity.
  - It emphasizes the importance of online safety and best practices.

- **Conclusion**:
  - The Cyber Security Chatbot program is designed to educate users on cybersecurity topics in an interactive and engaging manner, making it a valuable tool for learning and awareness.