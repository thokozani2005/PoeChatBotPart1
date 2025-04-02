using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PoeChatBotPart1
{
    //created an external class where i am going to store the methods that validate user input and the Typing effect method
    class Store_ValidationMethods
    {

        //created a boolean method whill check if the  name is empty or has double spaces
        public Boolean CheckUserName(string user_Name)
        {
            //checking if the user's name is empty
            if (string.IsNullOrEmpty(user_Name) )
            {
                TriggerBeep();
                AddBotTypingEffect("Bot: Please enter a valid name, name cannot be empty", ConsoleColor.DarkRed);


                return false;
            }
            // Checking if the user's name is double spaces 
            else if (user_Name.Contains("  "))
            {
                TriggerBeep();
                AddBotTypingEffect("Bot: Please enter a valid name, name cannot contain double spaces", ConsoleColor.DarkRed);

                return false;
            }
            //since a name is a unique identifier i used regex to check if the name, contains numbers or any special characters
            else if (Regex.IsMatch(user_Name, @"[0-9!@#$%^&*(),.?:{ }|<>]"))
           {
                TriggerBeep();
                AddBotTypingEffect("Bot: Please enter a valid name, name cannot contain numbers or special characters", ConsoleColor.DarkRed);
                return false;
            }

            return true;
        }

        //creating a method that will check if the question is not or not

        public Boolean VerifyUserQuestion(String Question)
        {
            if (string.IsNullOrEmpty(Question))
            {
                TriggerBeep();
                AddBotTypingEffect("Bot: Please enter a valid Question, Question cannot be empty", ConsoleColor.DarkRed);
                return false;
            }
            else if (Question.Contains("  "))
            {
                AddBotTypingEffect("Bot: Please enter a valid Question, Question cannot contain double spaces", ConsoleColor.DarkRed);
                return false;
            }

            return true;
        }


        //created a method that changes the Bot typing effect, making it more user friendly
        //passed the message,message color and the speed of the message as parameters
        public void AddBotTypingEffect(string Bot_message, ConsoleColor text_color, int text_speed = 30)// this method parses a string
        {
            Console.ForegroundColor = text_color;
            foreach (char messages in Bot_message)
            {
                Console.Write(messages);
                System.Threading.Thread.Sleep(text_speed); // Adjust speed for effect
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        /*
         *created a method will trigger a sound when user input is wrong
        passed two parameters the first one is for the frequency, it controls the pitch of the sound
        second parameter is the duration, it is for the time the sound will take
        
         */
        public void TriggerBeep(int frequency = 500, int duration = 1000)
        {
            //used exception Handling
            try
            {
                // This will play a beep with the specified frequency and duration
                Console.Beep(frequency, duration);
                //Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.WriteLine("Beep sound triggered!");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while playing the beep: {ex.Message}");
            }
        }


    }
}
