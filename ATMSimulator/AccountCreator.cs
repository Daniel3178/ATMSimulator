using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    internal class AccountCreator
    {
        private static List<ulong> IDNumberList = new List<ulong>();
        private static List<int> CardNumberList = new List<int>();
        public static void Run()
        {
            Account newAccount;
            Console.WriteLine("please enter your full name:");
            string[] temp = GetUserFullName();
            Console.WriteLine("please enter your IdNumber:");
            ulong id = GetUserIDNumber(Console.ReadLine());
            Console.WriteLine("please choose a password");
            int password = GetUserPassword(Console.ReadLine());
            Console.WriteLine("your cardnumber is : ");
            int cardNum = CardNumGenerator();
            Console.WriteLine(cardNum);

            newAccount = new Account(id, temp[0], temp[1],cardNum,password);
            AccountManager.AddNewAccountToDictionary(newAccount, cardNum);
            AccountManager.ListAllTheAccounts();


        }

        public static bool IsUniqueID(ulong idToCheck)
        {
            if (IDNumberList.Contains(idToCheck))
            {
                return false;
            }
            return true;
        }
        public static int CardNumGenerator()
        {
            Random random = new Random();
            int generatedNumber;
            generatedNumber = random.Next(100000, 999999);
            while (CardNumberList.Contains(generatedNumber))
            {
                generatedNumber = random.Next(100000, 999999);

            }
            CardNumberList.Add(generatedNumber);
            return generatedNumber;

        }

        public static ulong GetUserIDNumber(string? input)
        {

            ulong temp;
            bool IsAccepted = false;
            while (!IsAccepted)
            {
                while (!ulong.TryParse(input, out temp) || string.IsNullOrWhiteSpace(input) || temp < 10000000 || temp > 99999999)
                {
                    input = Console.ReadLine();

                }
                if (IsUniqueID(temp))
                {
                    return temp;
                }

            }
            return 0;

        }

        public static int GetUserPassword(string? input)
        {
            int temp;
            while (!int.TryParse(input, out temp) || input == null || temp < 1000 || temp > 999999)
            {
                input = Console.ReadLine();
            }
            return temp;
        }

        public static string[] GetUserFullName()
        {
            bool IsAccepted = false;

            while (!IsAccepted)
            {
                string[] result;
                string? inputToCheck = Console.ReadLine();
                bool flag = false;

                if (!string.IsNullOrWhiteSpace(inputToCheck))
                {
                    result = inputToCheck.Trim().Split(',', ' ');
                    if (result.Length == 2)
                    {
                        foreach (string tempString in result)
                        {
                            bool testIfAllAlphabet = tempString.All(Char.IsLetter);
                            if (!testIfAllAlphabet)
                            {
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            IsAccepted = true;
                            return result;
                        }
                    }
                }
            }
            return null;

        }

        public static void PrintTheManula()
        {
            Console.WriteLine("Welcome to the account creating process, please follow the instructions" +
                "before you continue in order to ease this process");
        }

    }
}
