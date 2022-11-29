using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    internal class AccountManager
    {
        public static Dictionary<int, Account> accountsDirectory = new Dictionary<int, Account>();

        public static void Run()
        {
            Account selectedAccount;
            Account newAccount = new Account(01252, "Oska", "Isaksson", 4564, 4564);
            accountsDirectory.Add(4564, newAccount);
            int cardNum = 4564;
            int password = 464;
            selectedAccount = accountsDirectory[cardNum];
            if(selectedAccount.Password == password)
            {
                Console.WriteLine(selectedAccount.ToString());
                Console.WriteLine("found");
            }
            else
            {
                Console.WriteLine("not found");
            }
            

        }

        public static void AddNewAccountToDictionary(Account newAccount, int cardNumber)
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
