
Cyber Security Artificial Intelligence Bot part 2 Improvements

This AI is a system that is used to validate user input, and check if the user asks a question related to cyber security meaning this AI is based on cyber security only.
I n my project, i have 7 classes including the main project which executes the exeternal classes and their methods. I have a class that displays the logo, a class that plays the voice, a class that validates user input and a class where the responses are stored and where the use is prompted, I also added 2 classed for the random response and for the Memory response

Purpose
This program aims at giving users knowledge about cyber security
It creates a user-friendly environment, as it consists of the logo which captures the user's attention and the voice chat.
To Facilitate the interaction between users and the chatbot by integrating validation and response mechanisms.
The improvements enhance the bot to be more advances as it now able to detect sentiments, store and use random responses.

Functionalities
Implementation of Classes and Methods
The Voice class, has constructor, this where the entire voice code is implemented and this class is called in the main program, this plays ana engaging voice message to users.
The logo class also has an constructor where the logo code is implemented, used Bitmap to convert an image to ascii.
Store and prompt class, this class launches the chatbot's functionality to prompt, validate and process user questions.
Welcome Message
Created a typing effect method i the validate class to make the bot user friendly, also used foreground colour to make the welcome message to be aye catching.
Improvements
I changed the store and prompt class, at first I was using arraysLists to store this now I used generics to store the responses, I added more things , I created a class for random responses meaning then the original responses are stored in a method in the store and prompt class. I implemented a method that checks if the user inputs requires a regular response or if it requires random responses, then i also implemented sentiment detection, this go hand in hand with keyword recognition as the bot is required to check for the triggering keyword it can be a cyber security keyword or a sentiment. then in my getresponse method I have 9 steps, each steps has it own function.

Features
To make the Bot more user friendly
-Added the typing effect method in the validate class, passed the frequency Nand duration as parameters
Added method that validate user input, it checks if the user enters the required input, then i also crated a method that beeps if the user input doesn’t not meet the requirements.
Used Colour, to output messages int various colours to visually distinguish bot responses and enhance readability.
Also added the concatenate feature meaning it adds the responses for example the user if the user enters please tell me about password and phishing it displays the two responses.
Added new features such as random responses, meaning one keyword can have more than one response each have 3. Added the memory recall part where the user's interests are stored then displayed if the user wants to see them, then the bot automatically recognizes the user and asks if the user would like to resume the previous conversation then it displays the prevous conversation. Also included the sentiment part where the bot is able to respond to the user's emotions in a correct manner.



Conclusion
The Main Program brings together the various modules of the Cyber Security Awareness Bot to deliver a cohesive and engaging user experience. By combining multimedia features with interactive chatbot functionalities, it ensures that users not only learn about cybersecurity but also enjoy a dynamic and user-friendly environment.



Pictures
First picture is user friendly it display the ascii with colours and the welcoming messages are also there

![image](https://github.com/user-attachments/assets/9f18ad66-320b-4cc4-9b02-7d3ce14ba7bc)




Second picture is for input validation, it Bot checks if the user input is valid, meaning it checks for numbers name should not consist of numbers since it is a unique identifier, it also checks if  the name is empty

![image](https://github.com/user-attachments/assets/244e03a8-d4e2-4c40-b968-1c2a813455f5)

Third picture is also for input validation but know the user question, it checks if the question is empty, if the question has double spaces and if the question is related to cyber security

![image](https://github.com/user-attachments/assets/3a4a0a0a-57d9-425e-a15a-167596eedbb9)

Fourth picture shows how the bot functions when the user inpyuts the correct details
![image](https://github.com/user-attachments/assets/886aa534-beba-4a22-a747-cce7c7cb9a85)
Fifth picture shows how the bot stores meaning it identifies the user's name
![poe-first](https://github.com/user-attachments/assets/17b2da7a-c56b-4df3-91b8-d0ce127b8397)

The sixth picture is for sentiment detection, the bot responses to the user by considering the user's emotions

![poe-second](https://github.com/user-attachments/assets/28414ac6-bebc-41ed-9464-ce8dcab34519)

The seventh picture is for the random responses
![poe-third](https://github.com/user-attachments/assets/b0c33651-7652-4679-9b4e-108daaa30f57)




