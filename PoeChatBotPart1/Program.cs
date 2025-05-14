using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeChatBotPart1
{
    class Program
    {
        static void Main(string[] args)
        {
            //called my classes in my mainMethod
            //Voice Chat class
            new Voice() { };
            //Logo class
            new Logo_Image() { };
            //called this class that does not have a constructor
            Store_ValidationMethods validate = new Store_ValidationMethods();

            //used the typing effect method to enhance the Bot
            validate.AddBotTypingEffect("************************************************************************\nWelcome to the Cyber Security Awareness Bot (Cyber Sheild) \n************************************************************************", ConsoleColor.Green);

            //used the typing effect method to enhance the Bot
            validate.AddBotTypingEffect("Bot: Hello! I'm here to help you stay safe online.", ConsoleColor.Yellow);



            // called the store and promt classs
            new Store_and_Prompt() { };
            new Random_Response() { };
            new memory_Recall() { };

        }
    }
}
