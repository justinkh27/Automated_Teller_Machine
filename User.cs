using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Automated_Teller_Machine
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }
        public float AccountBalance { get; set; }

        public int GetID(User user)
        {
            return user.UserId;
        }

        public string GetUserName(User user)
        {
            return user.UserName;
        }

        public float GetUserBalance(User user)
        {
            return user.AccountBalance;
        }

        public int GetUserChoice()
        {
            int choice;
            string entry = Console.ReadLine();

            while (!Int32.TryParse(entry, out choice))
            {
                Console.WriteLine("Not a valid number, try again.");

                entry = Console.ReadLine();
            }
            return choice;
        }

        public User ValidateUserLogin(string filename)
        {
            List<string> userNames = new List<string>();

            var jsonFileRead = File.ReadAllText(filename);
            var jsonUserList = JsonSerializer.Deserialize<User[]>(jsonFileRead);
            var passwordIndex = 0;

            Console.WriteLine("\tPlease enter user name");
            var userNameToValidate = Console.ReadLine();
            bool userValidated = false;

            foreach (User user in jsonUserList)
            {
                userNames.Add(user.UserName);
            }

            do
            {
                if (userNames.Contains(userNameToValidate))
                {
                    Console.WriteLine("\tUsername Found");
                    passwordIndex = userNames.IndexOf(userNameToValidate);

                    Console.WriteLine("\tPassword");

                    string attemptedPassword = Console.ReadLine();



                    if (attemptedPassword == jsonUserList[passwordIndex].Password)
                    {
                        Console.WriteLine("\tPassword Match");
                        Console.WriteLine("\tWelcome " + userNameToValidate);
                        userValidated = true;
                    }
                }
            }
            while (userValidated == false);


            return jsonUserList[passwordIndex];
        }

        
    }
}
