using System.IO;
using System.Media;
using System;

namespace PoeChatBotPart1
{
    public class Voice
    {
        //built in constructor
        public Voice()
        {
            //getting the full location
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine(full_location);
            //using a new filePath
            string new_path = full_location.Replace("bin\\Debug", "");

            //used exception handling
            try
            {
                //Playing the voice over if the file is found
                string full_path = Path.Combine(new_path, "Welcome.wav");
                using (SoundPlayer myplayer = new SoundPlayer(full_path))
                {
                    myplayer.PlaySync();
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

        }
    }
}