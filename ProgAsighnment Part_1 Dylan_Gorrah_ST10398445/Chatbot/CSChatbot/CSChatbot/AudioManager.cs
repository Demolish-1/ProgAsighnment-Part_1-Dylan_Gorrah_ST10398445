using System;
using System.IO;
using System.Media;
using System.Threading.Tasks;

public static class AudioManager
{
    public static void PlayWelcomeSoundAsync()
    {
        Task.Run(() => {
            try
            {
                // useing 2 paths 
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                Console.WriteLine($"DEBUG: Base directory is {baseDirectory}");

                // Try different  paths
                string[] possiblePaths = new string[]
                {
                    Path.Combine(baseDirectory, "Audio", "BOT Voice.wav"),
                    Path.Combine(baseDirectory, "BOT Voice.wav"),
                    @"Audio\BOT Voice.wav",
                    @".\Audio\BOT Voice.wav",
                    // Add the full path as a fallback for testing
                    @"C:\Users\Dylan\Desktop\ProgAsighnment Part_1 Dylan_Gorrah_ST10398445\Chatbot\CSChatbot\CSChatbot\Audio\BOT Voice.wav"
                };

                bool fileFound = false;

                foreach (string path in possiblePaths)
                {
                    Console.WriteLine($"DEBUG: Checking path: {path}");

                    if (File.Exists(path))
                    {
                        Console.WriteLine($"DEBUG: Found audio file at: {path}");
                        fileFound = true;

                        using (SoundPlayer player = new SoundPlayer(path))
                        {
                            try
                            {
                                Console.WriteLine("DEBUG: Loading audio file...");
                                player.LoadAsync();

                                Console.WriteLine("DEBUG: Playing audio file...");
                                player.Play();

                                Console.WriteLine("DEBUG: Finished playing audio");
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"DEBUG: Error playing file: {ex.Message}");
                            }
                        }
                    }
                }

                if (!fileFound)
                {
                    Console.WriteLine("DEBUG: Audio file not found in any of the checked locations");
                    Console.WriteLine("Please ensure 'BOT Voice.wav' is in an 'Audio' folder and set to 'Copy to Output Directory'");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DEBUG: Error in audio playback: {ex.Message}");
                Console.WriteLine($"DEBUG: Stack trace: {ex.StackTrace}");
            }
        });
    }
}