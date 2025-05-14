using System.Collections.Generic;
using System.IO;
using System;

namespace PoeChatBotPart1
{

    public class memory_Recall
    {
        private string filepath;

        public memory_Recall()
        {
            // Get full path of project directory and adjust the path
            string full_path = AppDomain.CurrentDomain.BaseDirectory;
            string newpath = full_path.Replace("bin\\Debug\\", "");
            filepath = Path.Combine(newpath, "MemoryResponse.txt");

            List<string> memory_stored = LoadMemory(filepath);


        }

        // Method to load stored memory from file
        private List<string> LoadMemory(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Close(); // Ensure file is created properly
                }

                return new List<string>(File.ReadAllLines(path));
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error loading memory: " + ex.Message);
                return new List<string>();
            }
        }

        // Method to store user input and bot response
        public void StoreUserInput(string username, string userInterest, string botResponse)
        {
            try
            {
                List<string> memory_stored = LoadMemory(filepath);
                // This line is important; it adds the [Interest] tag
                memory_stored.Add(username + ": [Interest] " + userInterest);
                // Store the bot response
                memory_stored.Add("Bot: " + botResponse + "\n");
                File.WriteAllLines(filepath, memory_stored); // Update memory file
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error storing memory: " + ex.Message);
            }
        }


        // Method to retrieve stored user interest
        public string GetUserInterest(string username)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string[] memory_stored = File.ReadAllLines(filepath);

                    foreach (var entry in memory_stored)
                    {
                        // Check if the line contains the Interest tag and the username
                        if (entry.StartsWith(username + ": [Interest]"))
                        {
                            // Spliting with "] " and take the second part which is the interest itself
                            return entry.Split(new string[] { "] " }, StringSplitOptions.None)[1].Trim();
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error retrieving memory: " + ex.Message);
            }

            return "I don't have any stored interests for you yet.";
        }

        // Method to display stored memory
        public void DisplayMemory()
        {
            try
            {
                if (File.Exists(filepath))
                {
                    List<string> memory_stored = new List<string>(File.ReadAllLines(filepath));

                    Console.WriteLine("========== Previous Interactions ==========");
                    Console.WriteLine("\n--- Interests ---");
                    foreach (var entry in memory_stored)
                    {
                        if (entry.Contains("[Interest]"))
                        {
                            Console.WriteLine(entry.Replace("[Interest]", "").Trim());
                        }
                    }
                    //displaying the stored memory

                    Console.WriteLine("\n--- Conversations ---");
                    foreach (var entry in memory_stored)
                    {
                        if (!entry.Contains("[Interest]"))
                        {
                            Console.WriteLine(entry.Trim());
                        }
                    }
                    Console.WriteLine("===========================================\n");
                }
                else
                {
                    Console.WriteLine("No memory file found.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error displaying memory: " + ex.Message);
            }
        }




    }
}