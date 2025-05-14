using System;
using System.Collections;
using System.Collections.Generic;

namespace PoeChatBotPart1
{

    public class Store_and_Prompt
    {
        // Declaring a generic collection that will store the bot responses
        public static Dictionary<string, string> Bot_Response = new Dictionary<string, string>();
        public static string userName = string.Empty;
        public static string user_Question = string.Empty;
        public static List<string> Words_to_ignore = new List<string>();

        // Declaring a dictionary to store sentiment-based responses
        public static Dictionary<string, string> Sentiment_Response = new Dictionary<string, string>()
        {
       { "worried", "It's completely understandable to feel that way. Security threats can be concerning, but I’m here to help!" },
       { "frustrated", "I hear you! Security can be complex, but I’ll simplify things for you." },
       { "curious", "Curiosity is great! Learning about security helps you stay safe." },
       { "overwhelmed", "Security can feel overwhelming, but taking small steps makes a big difference." },
       { "confused", "No worries! I’ll break it down for you in a simple way." }
       };

        // Create an instance of the Random_Response class
        private static Random_Response randomResponder = new Random_Response();

        Store_ValidationMethods validate = new Store_ValidationMethods();
        memory_Recall memoryRecall = new memory_Recall();

        public Store_and_Prompt()
        {
            validate.AddBotTypingEffect("Bot: Please Enter your name: ", ConsoleColor.Yellow);

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("User: ");
                userName = Console.ReadLine();
            } while (!validate.CheckUserName(userName));

            // Load previous memory, checking if the user has communicated with the bot before
            string lastInterest = memoryRecall.GetUserInterest(userName);

            // If memory is found, ask if the user wants to continue
            if (!string.IsNullOrEmpty(lastInterest) && lastInterest != "I don't have any stored interests for you yet.")
            {
                validate.AddBotTypingEffect($"Bot: I remember you were interested in '{lastInterest}'. Would you like us to continue from there? (yes/no): ", ConsoleColor.Yellow);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(userName);
                string response = Console.ReadLine().ToLower();

                //checking if the user input is yes or no
                if (response == "yes")
                {
                    validate.AddBotTypingEffect($"Bot: Great! Let's continue exploring {lastInterest}.\n", ConsoleColor.DarkGreen);
                    // Display previous memory (for user reference)
                    memoryRecall.DisplayMemory();
                }
            }



            // Call methods to store bot responses and ignored words
            Store_Bot_Response();
            Store_words_to_ignore();


            validate.AddBotTypingEffect("Bot: Please Enter a Question related to CyberSecurity, you can ask me about about (phishing/security/malware): ", ConsoleColor.Yellow);
            //a do while loop to validate the question, whether it is empty or has exit words, or if the user still wants to continue
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(userName + ": ");
                user_Question = Console.ReadLine().ToLower();

                // checking if the question is not or not
                if (!validate.VerifyUserQuestion(user_Question))
                {


                }
                else if (Exit_Bot(user_Question))
                {
                    // If the user wants to exit, break out of the loop
                    break;
                }
                else
                {
                    // If the user enters a valid question, process the response
                    GetBotResponse();
                    //memoryRecall.DisplayMemory();
                }

            } while (true);



        }
        //created a method that does not return anything, to store the words that will be ignored
        public static void Store_words_to_ignore()
        {
            Words_to_ignore.Add("tell");
            Words_to_ignore.Add("me");
            Words_to_ignore.Add("about");
            Words_to_ignore.Add("what");
            Words_to_ignore.Add("you");
            Words_to_ignore.Add("is");
            Words_to_ignore.Add("please");
            Words_to_ignore.Add("define");
            Words_to_ignore.Add("how");
            Words_to_ignore.Add("why");
            Words_to_ignore.Add("do");
            Words_to_ignore.Add("i");
            Words_to_ignore.Add("with");
            Words_to_ignore.Add("give");
            Words_to_ignore.Add("provide");
            Words_to_ignore.Add("tips");
            Words_to_ignore.Add("tip");
            Words_to_ignore.Add("and");
            Words_to_ignore.Add("am");

        }
        //created a method that will store the keywords and the responses
        //these responses are kewords are stationary, meaning they are not random
        public static void Store_Bot_Response()
        {
            // Store chatbot responses using a dictionary with keywords as keys and responses as values
            Bot_Response.Add("hello|hi|hey", "Hello " + userName + "! How can I assist you today?");
            Bot_Response.Add("thank you|thanks", "You're most welcome, " + userName + "! I'm always here to help.");
            Bot_Response.Add("how are you|how are you doing", "I'm just a bot, but I'm here to help, " + userName + "!");
            Bot_Response.Add("what is your purpose", "I'm here to help you gain knowledge about cybersecurity, " + userName + "!");
            Bot_Response.Add("cyber security", "Cybersecurity protects computers, networks, and data from unauthorized access and cyber threats.");
            Bot_Response.Add("attack|cyber attack|hacking", "A cyber attack is an attempt to gain unauthorized access to data, networks, or devices.");
            Bot_Response.Add("password", "A password is a secret combination of characters used for authentication. Protect it at all costs!");
            Bot_Response.Add("phishing", "Phishing is a cyber attack where attackers trick users into providing sensitive information.");
            Bot_Response.Add("malware", "Malware is malicious software designed to damage or disrupt systems.");
            Bot_Response.Add("ransomware", "Ransomware locks your files and demands payment for access.");
            Bot_Response.Add("ddos", "DDoS (Distributed Denial-of-Service) attacks flood a network with traffic to make it unavailable.");
            Bot_Response.Add("man-in-the-middle", "MitM attacks intercept communications to steal or alter information.");
            Bot_Response.Add("sql injection", "SQL Injection exploits database vulnerabilities to manipulate data.");
            Bot_Response.Add("credential stuffing", "Hackers use leaked credentials from previous breaches to access accounts.");
            Bot_Response.Add("brute force", "Brute force attacks try multiple password combinations until they succeed.");
            Bot_Response.Add("protect", "Keep software up-to-date, use antivirus tools, secure your Wi-Fi, and back up data regularly.");
            Bot_Response.Add("protection", "Laptop protection involves using strong passwords, enabling encryption, and avoiding public Wi-Fi.");
            Bot_Response.Add("social engineering", "Social engineering manipulates people into giving away confidential data.");

            Bot_Response.Add("security", "Security is about protecting assets, whether it's physical, digital, or personal safety.");
            Bot_Response.Add("physical security", "Physical security involves protecting buildings, assets, and people from threats.");
            Bot_Response.Add("data security", "Data security ensures that sensitive information is protected from unauthorized access.");
            Bot_Response.Add("network security", "Network security protects systems from cyber threats and unauthorized access.");
            Bot_Response.Add("password security", "A strong password helps prevent unauthorized access to your accounts.");
            Bot_Response.Add("online security", "Online security involves protecting your personal data while browsing the internet.");



        }

        public void GetBotResponse()
        {
            //Step 1: Remove stopwords from user input
            string[] words = user_Question.Split(' ');
            List<string> filteredWords = new List<string>();

            foreach (string word in words)
            {
                if (!Words_to_ignore.Contains(word.ToLower()))
                {
                    filteredWords.Add(word.ToLower());
                }
            }

            //Joining the words that are split into one line
            string cleanedInput = string.Join(" ", filteredWords);
            string responseText = string.Empty;
            bool foundRelevantResponse = false;
            bool foundSentiment = false;
            string userInterest = ""; // Define userInterest properly

            //Step 2: Checking if User Wants to Recall Their Interest **BEFORE CYBERSECURITY CHECK**
            if (cleanedInput.Contains("my interest") || cleanedInput.Contains("previous interests"))
            {
                string savedPreference = memoryRecall.GetUserInterest(userName);

                if (!string.IsNullOrEmpty(savedPreference))
                {
                    responseText += "You previously mentioned that you're interested in " + savedPreference + ". Would you like more information on this topic?\n";
                    foundRelevantResponse = true;
                }
                else
                {
                    responseText += "I don't have any stored interests for you yet. Feel free to tell me what you're interested in!\n";
                    foundRelevantResponse = true;
                }
            }

            //Step 3: Checking if User Mentions an Interest
            if (cleanedInput.Contains("interested in") && !cleanedInput.Contains("what am I interested in"))
            {
                // Extract the actual interest and store it
                userInterest = cleanedInput.Replace("interested in", "");

                if (!string.IsNullOrEmpty(userInterest) && userInterest.Length > 2) // Ensure it's not empty or too short
                {
                    memoryRecall.StoreUserInput(userName, userInterest, "Great! I'll remember that you're interested in " + userInterest + ". It's an important part of staying secure online.");
                    responseText += "Great! I'll remember that you're interested in " + userInterest + ". It's an important part of staying secure online.\n";
                    foundRelevantResponse = true;
                }
            }

            //Step 4: Checking if the user input has a sentiment as a keyword
            foreach (var sentiment in Sentiment_Response.Keys)
            {
                if (cleanedInput.Contains(sentiment))
                {
                    // Add sentiment-based empathy response
                    responseText += Sentiment_Response[sentiment] + "\n";
                    foundSentiment = true;
                }
            }

            //Step 5: Checking for multiple keyword matches, checking if the user input is found in the normal responses
            foreach (var entry in Bot_Response)
            {
                //Splitting the keywords and the responses, the keywords trigger the response
                string[] keywords = entry.Key.Split(',');

                foreach (string keyword in keywords)
                {
                    if (cleanedInput.Contains(keyword.ToLower()))
                    {
                        responseText += entry.Value + "\n";
                        foundRelevantResponse = true;
                    }
                }
            }

            //Step 6: If there is no cybersecurity match, but sentiment was detected, this option will provide general support
            if (!foundRelevantResponse && foundSentiment)
            {
                responseText += "If there's anything else you'd like to talk about, I'm here to listen.\n";
            }

            //Step 7: If no relevant matches, we check for random responses
            if (!foundRelevantResponse && !foundSentiment)
            {
                //Calling the random response method
                string randomResponse = randomResponder.GetResponse(cleanedInput);
                if (randomResponse != "Keyword not recognized.")
                {
                    responseText += randomResponse + "\n";
                }
                else
                {
                    validate.TriggerBeep();
                    validate.AddBotTypingEffect("Bot: Please enter something related to cybersecurity.", ConsoleColor.DarkRed);
                }
            }

            //Step 8: Storing the user name and the response in the txt **AFTER RETRIEVING INTEREST**
            if (!string.IsNullOrEmpty(userInterest)) // Ensure we store only valid interests
            {
                memoryRecall.StoreUserInput(userName, userInterest, responseText);
            }
            //memoryRecall.DisplayMemory();

            //Step 9: Display Latest Response, using the typing effect method
            validate.AddBotTypingEffect("Bot: " + responseText, ConsoleColor.DarkGreen);
            validate.AddBotTypingEffect("\nBot: Let me know if you'd like more assistance refining this further!\nOr please enter (stop/bye/exit/goodbye) to exit the application", ConsoleColor.DarkYellow); // Add extra instructions for the user

        }

        //created a method that checks if the user wants to exit the bot or not.
        public bool Exit_Bot(string response)
        {
            Boolean verify = false;
            //declared a arraylist that will store the exit words
            ArrayList Exitwords = new ArrayList();


            Exitwords.Add("goodbye");
            Exitwords.Add("bye");
            Exitwords.Add("stop");
            Exitwords.Add("exit");
            //used a loop to iterate trhough the arraylist and check for stop words
            foreach (string exits in Exitwords)
            {
                if (response.Contains(exits))
                {
                    validate.AddBotTypingEffect("************************************************************************\n", ConsoleColor.Green);
                    validate.AddBotTypingEffect("Bot: Goodbye " + userName + " Hope you had a nice experience. \n************************************************************************", ConsoleColor.Green);

                    System.Environment.Exit(0);
                    verify = true;
                }
            }
            return verify;
        }






    }
}