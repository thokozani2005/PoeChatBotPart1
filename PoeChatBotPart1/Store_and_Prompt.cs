using System;
using System.Collections;

namespace PoeChatBotPart1
{
    public class Store_and_Prompt
    {
        //declared my variables and the arrylist as private so that they can be only accessible int this class
        private static ArrayList Bot_Response = new ArrayList();
        private static ArrayList Words_to_ignore = new ArrayList();
        private static string userName = string.Empty;
        private static string user_Question = string.Empty;

        //object calling in the class so that the methods can access the typing effect method
        Store_ValidationMethods validate = new Store_ValidationMethods();

        public Store_and_Prompt()
        {

            validate.AddBotTypingEffect("Bot: Please Enter your name: ", ConsoleColor.Yellow);
            //used a do while to reprompt the user for the name if it is empty or has double spaces
            do
            {


                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("User: ");
                userName = Console.ReadLine();
            } while (!validate.CheckUserName(userName));



            //calling my methods

            Store_Bot_Response();
            Store_words_to_ignore();


            validate.AddBotTypingEffect("Bot: Please Enter a Question related to CyberSecurity: ", ConsoleColor.Yellow);
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
                    CheckResponse();
                }

            } while (true);
        }


        //a method that will store the bot responses
        public static void Store_Bot_Response()
        {
            // Store the bot responses
            //the arraylist has this : meaning i want to split it into two, i want to have triggering words that will automatically alter the response
            Bot_Response.Add("hello|hi|hey: Hello " + userName + "! How can I assist you today?");
            Bot_Response.Add("thank you|thanks: You're most welcome," + userName + "I'm always here to help and bounce ideas with you. If there's anything else you'd like to improve or create, just let me know—I'm all in! ");
            Bot_Response.Add("how are you | How are you doing: I'm just a bot, but I'm here to help, " + userName + "!");
            Bot_Response.Add("what is your purpose: I'm here to help you to gain knowledge about cyber security, " + userName + "!");
            Bot_Response.Add("cyber security: Cybersecurity is the practice of protecting computers, networks, data, and systems from digital attacks, unauthorized access, and cyber threats. It helps ensure confidentiality, integrity, and availability of information online.");
            Bot_Response.Add("attack|cyber attack|hacking: A cyber attack is an attempt by hackers or malicious actors to damage, disrupt, steal, or gain unauthorized access to computer systems, networks, or data. These attacks can target individuals, businesses, or even government institutions, aiming to exploit vulnerabilities for financial gain, espionage, or disruption.");
            Bot_Response.Add("password: is a secret combination of characters (letters, numbers, and symbols) used to verify a user's identity when accessing a system, application, or online service. It helps protect personal information, accounts, and devices from unauthorized access.Passwords must be protected.");
            Bot_Response.Add("security: Security refers to the protection of systems, networks, data, and individuals from threats, attacks, and unauthorized access. It ensures confidentiality, integrity, and availability of information and resources.");
            Bot_Response.Add("phishing:Phishing is a cyber attack where attackers trick users into providing sensitive information.");
            Bot_Response.Add("malware:Malware is malicious software designed to damage or disrupt systems.");
            Bot_Response.Add("ransomware:Ransomware is a type of malware that locks your files and demands payment for access.");
            Bot_Response.Add("ddos:DDoS (Distributed Denial-of-Service) attacks flood a network with traffic to make it unavailable.");
            Bot_Response.Add("man-in-the-middle:MitM attacks intercept communications to steal or alter information.");
            Bot_Response.Add("sql injection:SQL Injection exploits vulnerabilities in databases to manipulate data.");
            Bot_Response.Add("credential stuffing:Hackers use leaked credentials from previous breaches to access accounts.");
            Bot_Response.Add("brute force:Brute force attacks try multiple password combinations until they succeed.");
            Bot_Response.Add("protect: To protect your laptop from cyberattacks, ensure software is up-to-date, use antivirus tools, avoid suspicious links, secure your Wi-Fi, and back up data regularly.");
            Bot_Response.Add("protection: Laptop protection involves using strong passwords, enabling disk encryption, avoiding public Wi-Fi, and installing advanced security solutions.");
            Bot_Response.Add("social engineering:Social engineering manipulates people into giving away confidential data.");

        }

        //a method that will store the words that the bot should ignore
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

        }



        //creating a boolean method 
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


        //
        private void CheckResponse()
        {
            // Split the input and filter out stopwords
            string[] words = user_Question.Split(' '); // Splitting user input into individual words
            ArrayList filteredWords = new ArrayList(); // Create a list to hold filtered words 
            // Filter the user's words by excluding stopwords
            foreach (string word in words)
            {
                if (!Words_to_ignore.Contains(word.ToLower())) // Check if the word is not in the stopword list
                {
                    filteredWords.Add(word.ToLower()); 
                }
            }

            bool foundResponse = false; 
            string concatenatedReply = ""; 

            // Iterate through all predefined responses
            foreach (string response in Bot_Response)
            {
                // Split the response into keywords and actual reply
                string[] parts = response.Split(':');
                string keywords = parts[0];  // First part contains keywords that trigger the response
                string reply = parts[1];     // Second part contains the chatbot's response text

                
                foreach (string word in filteredWords)
                {
                    ///conditional statement to check if the response is found
                    if (keywords.Contains(word)) 
                    {
                        concatenatedReply += "Bot: " + reply + "\n"; //concatenating the responses
                        foundResponse = true; 
                        break; 
                    }
                }
            }

            // Displaying the  concatenated response if matches were found
            if (foundResponse && !string.IsNullOrEmpty(concatenatedReply))
            {
                validate.AddBotTypingEffect(concatenatedReply, ConsoleColor.DarkGreen); 
                validate.AddBotTypingEffect("\nLet me know if you'd like more assistance refining this further!\nOr please enter (stop/bye/exit/goodbye) to exit the application", ConsoleColor.DarkYellow); // Add extra instructions for the user
            }
            else
            {
                // Response if no match is found, it will start by playing the beep method first then display the validation message
                validate.TriggerBeep(); 
                validate.AddBotTypingEffect("Bot: Please search for something related to cybersecurity, " + userName + ".", ConsoleColor.DarkRed); // Notify the user when no match is found
            }
        }


    }
}