using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Automated_Teller_Machine
{
    public class JsonFileInfo
    {

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        public void CreateEmptyFile(string filename)
        {
            File.Create(filename).Dispose();
        }

        public void IfEmptyWriteFirstUser(string filename)
        {
            var jsonFileRead = File.ReadAllText(filename);

            List<User> userList = new List<User>();
            if (new FileInfo(filename).Length == 0)
            {
                userList.Add(new User()
                {
                    UserId = 1,
                    UserName = "temp",
                    FirstName = "temp",
                    LastName = "temp",
                    Password = "asdf",
                    AccountBalance = 25f
                });

                string writeFirstUser = JsonSerializer.Serialize(userList, jsonOptions);
                File.WriteAllText(filename, writeFirstUser);

            }
        }

        public void AddNewJsonUser(string filename)
        {
            string userFirst, userLast, userScreenName, userPass;
            List<User> userList = new List<User>();
            List<int> idList = new List<int>();

            var jsonFileRead = File.ReadAllText(filename);
            var jsonUserList = JsonSerializer.Deserialize<User[]>(jsonFileRead);

            foreach (var i in jsonUserList)
            {
                idList.Add(i.UserId);
            }

            Console.Write("UserName: ");
            userScreenName = Console.ReadLine();
            Console.Write("FirstName: ");
            userFirst = Console.ReadLine();
            Console.Write("LastName: ");
            userLast = Console.ReadLine();
            Console.Write("Password: ");
            userPass = (Console.ReadLine());
            var id = idList.Count + 1;
            Console.WriteLine(id);

            userList.Add(new User()
            {

                UserName = userScreenName,
                Password = userPass,
                FirstName = userFirst,
                LastName = userLast,
                AccountBalance = 25f,
                UserId = Convert.ToInt32(id)
            });

            foreach (User user in jsonUserList)
            {
                userList.Add(user);
            }

            string toJson = JsonSerializer.Serialize(userList, jsonOptions);
            File.WriteAllText(filename, toJson);
        }

        public void UpdateJson(string filename, string userName,float newAccountBalance)
        {
            var jsonFileRead = File.ReadAllText(filename);
            var jsonUserList = JsonSerializer.Deserialize<User[]>(jsonFileRead);

            List<string> usersList = new List<string>();

            foreach (var users in jsonUserList)
            {
                usersList.Add(users.UserName);
            }

            int userIndex = usersList.IndexOf(userName);

            Console.WriteLine(jsonUserList[userIndex].UserName);

            jsonUserList[userIndex].AccountBalance = newAccountBalance;
            Console.WriteLine(jsonUserList[userIndex].AccountBalance);

            string toJson = JsonSerializer.Serialize(jsonUserList, jsonOptions);
            File.WriteAllText(filename, toJson);

        }
    }
}
