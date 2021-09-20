using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Teller_Machine
{
    public class MachineFunction
    {
        public float Withdraw(User user)
        {
            Console.WriteLine("\tEnter withdraw amount");
            float withdrawAmount = Convert.ToInt32(Console.ReadLine());
            return user.AccountBalance -= withdrawAmount;

        }
    }
}
