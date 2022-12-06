using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    internal class AccountManager
    {
        public static Dictionary<uint, Account> accountsDirectory = new ();
        public static void Run()
        {
            //Some features in future
        }

        public static void AddNewAccountToDictionary(Account newAccount, uint cardNumber)
        {
            accountsDirectory.Add(cardNumber, newAccount);
        }
        public static void ListAllTheAccounts()
        {
            foreach(Account account in accountsDirectory.Values)
            {
                Console.WriteLine(account.Name + " " + account.LastName + " "+ account.IDnum + " " + account.CardNum);
            }
        }
    }
}
