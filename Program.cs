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

            var logInChoice = user.GetUserLoginChoice();

            do
            {
                if (logInChoice == 1)
                {
                    JFI.AddNewJsonUser(jsonFile);
                    logInChoice = user.GetUserLoginChoice();
                }
                else if (logInChoice == 2)
                {
                    bool userLoggedIn = false;


                    User verifiedUser = user.ValidateUserLogin(jsonFile);

                    do
                    {
                        int selection = verifiedUser.GetUserMenuChoice();

                        if (selection == 1)
                        {
                            machine.CheckBalance(verifiedUser);
                        }
                        else if (selection == 2)
                        {
                            machine.Withdraw(verifiedUser);
                            JFI.UpdateJson(jsonFile, verifiedUser.UserName, verifiedUser.AccountBalance);
                        }
                        else if (selection == 3)
                        {
                            machine.Deposit(verifiedUser);
                            JFI.UpdateJson(jsonFile, verifiedUser.UserName, verifiedUser.AccountBalance);
                        }
                        else if (selection == 4)
                        {
                            Console.WriteLine("\tLogging Off\n");
                            userLoggedIn = true;
                            logInChoice = 3;
                        }
                        else
                        {
                            Console.WriteLine("Please make a valid selection");
                        }
                    } while (userLoggedIn == false);
                }
                

            } while (logInChoice < 3);

            Console.WriteLine("\tGoodbye");

        }
    }
}



