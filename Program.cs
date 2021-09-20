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
            
            JsonFileInfo JFI = new JsonFileInfo();
            User user = new User();
            MachineFunction machine = new MachineFunction();

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

                machine.Withdraw(verifiedUser);

                Console.WriteLine(verifiedUser.AccountBalance);

                JFI.UpdateJson(jsonFile, verifiedUser.UserName,verifiedUser.AccountBalance);
            }
        }
    }
}
