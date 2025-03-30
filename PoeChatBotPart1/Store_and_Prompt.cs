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
        public Store_and_Prompt()
        {

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
        }
    }
}