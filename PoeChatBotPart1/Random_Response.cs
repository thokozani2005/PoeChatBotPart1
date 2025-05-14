using System.Collections.Generic;
using System;

namespace PoeChatBotPart1
{
    //created a class that will store random responses
    public class Random_Response
    {


        // Dictionary to store keywords and their responses
        private Dictionary<string, List<string>> responses;
        private Random random;


        public Random_Response()
        {
            random = new Random();
            responses = new Dictionary<string, List<string>>()
            //used dictionary and list to store keywords and their random responses, each keyword has 3 random responses
        {
            { "security", new List<string> {
                "Stay safe online!",
                "Data protection is key.",
                "Enable firewalls for better security."
            } },
            { "vpn", new List<string> {
              "VPNs encrypt your internet connection for privacy.",
              "Use a reputable VPN to secure data when browsing.",
              "Public Wi-Fi poses risks—always use a VPN when accessing sensitive accounts."
             } },
            { "social engineering", new List<string> {
              "Be cautious of unsolicited emails or phone calls.",
              "Never share personal information with strangers online.",
              "Verify before trusting—social engineering relies on manipulation."
             } },
            { "database", new List<string> {
                "Backup your data often.",
                "Use proper indexing for faster queries.",
                "Data integrity is important." } },
            { "cloud", new List<string> {
                "Leverage cloud scalability.",
                "Ensure data redundancy.",
                "Monitor your cloud resources." } },
            { "encryption", new List<string> {
                "Encryption protects sensitive information.",
                "Always encrypt your passwords.",
                "Secure your communication with SSL/TLS." } },
            { "authentication", new List<string> {
                "Two-factor authentication is recommended.",
                "Password complexity matters.",
                "Avoid using the same password for multiple accounts." } },
            { "firewall", new List<string> {
                "Firewalls block unauthorized access.",
                "Regularly update your firewall rules.",
                "Check logs for suspicious activities." } },
            { "malware", new List<string> {
                "Install anti-malware software.",
                "Avoid suspicious downloads.",
                "Keep your system up to date." } },
            { "backup", new List<string> {
                "Always have a recovery plan.",
                "Backup important data regularly.",
                "Cloud backups are a good option." } }
        };
        }

        // Method to get a random response for a given keyword
        public string GetResponse(string keyword)
        {

            if (responses.ContainsKey(keyword.ToLower()))
            {
                List<string> possibleResponses = responses[keyword];
                int index = random.Next(possibleResponses.Count);
                return possibleResponses[index];
            }
            else
            {
                return "Keyword not recognized.";
            }
        }
    }
}
}