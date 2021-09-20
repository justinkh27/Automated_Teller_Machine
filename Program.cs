using System;
using System.IO;
using Automated_Teller_Machine;

namespace Automated_Teller_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonFile = (filePath + "\\userAccount.json");
            Console.WriteLine(jsonFile);

            User JohnSmith = new User()
            {
                UserId = 1,
                FirstName = "John",
                LastName = "Smith",
                UserName = "JSmith",
                AccountBalance = 25f
            };

            JsonFileInfo JFI = new JsonFileInfo();
            User user = new User();

            if (!File.Exists(jsonFile))
            {
                JFI.CreateEmptyFile(jsonFile);
            }
            JFI.IfEmptyWriteFirstUser(jsonFile);

            Console.WriteLine("\tSelect an option");
            Console.WriteLine("\t1. Create New User");
            Console.WriteLine("\t2. Log In Existing User");

            var logInChoice = user.GetUserChoice();

            if (logInChoice == 1)
            {
                JFI.AddNewJsonUser(jsonFile);
            }

            if (logInChoice == 2)
            {
                User verifiedUser = user.ValidateUserLogin(jsonFile);

                Console.WriteLine(verifiedUser.UserName);
                Console.WriteLine(verifiedUser.Password);
                Console.WriteLine(verifiedUser.AccountBalance);
            }

            //We have the user, now we need banking stuff. 
        }
    }
}
