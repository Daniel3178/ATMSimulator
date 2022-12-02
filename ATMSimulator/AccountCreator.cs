using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace ATMSimulator
{
    internal class AccountCreator
    {
        public static List<uint> IDNumberList = new List<uint>();
        public static List<uint> CardNumberList = new List<uint>();
        public static void Run()
        {
            for (uint i = 0; i < 1; i++)
            {

                Account newAccount;
                Console.WriteLine("please enter your full name:");
                string[] temp = GetUserFullName();
                Console.WriteLine("please enter your IdNumber:");
                uint id = GetUserIDNumber(Console.ReadLine());
                Console.WriteLine("please choose a password");
                uint password = GetUserPassword();
                Console.WriteLine("your cardnumber is : ");
                uint cardNum = CardNumGenerator();
                Console.WriteLine(cardNum);

                newAccount = new Account(id, temp[0], temp[1], cardNum, password);
                AccountManager.AddNewAccountToDictionary(newAccount, cardNum);
            }
            AccountManager.ListAllTheAccounts();
            DataHandler.WriteToDatabase();
        }

        public static bool IsUniqueID(uint idToCheck)
        {
            if (IDNumberList.Contains(idToCheck))
            {
                return false;
            }
            return true;
        }
        public static uint CardNumGenerator()
        {
            Random random = new Random();
            uint generatedNumber;
            generatedNumber = (uint)random.Next(1000000000, 2000000000);
            while (CardNumberList.Contains(generatedNumber))
            {
                generatedNumber = (uint)random.Next(1000000000, 2000000000);

            }
            CardNumberList.Add(generatedNumber);
            return generatedNumber;

        }
        public static uint GetUserPassword()
        {
            string input;
            SecureString pass = Validator.GetTheSecretPassword();

            input = new System.Net.NetworkCredential(string.Empty, pass).Password;
            uint temp;
            while (!uint.TryParse(input, out temp) || input == null || temp < 100000 || temp > 999999)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nTry Again");
                Console.ResetColor();
                 pass = Validator.GetTheSecretPassword();

                input = new System.Net.NetworkCredential(string.Empty, pass).Password;
            }
            return temp;

        }
        public static uint GetUserIDNumber(string? input)
        {

            uint temp;
            while (!uint.TryParse(input, out temp) || string.IsNullOrWhiteSpace(input)
                || temp > 30000000 || temp < 10000000 || !IsUniqueID(temp))
            {
                input = Console.ReadLine();
            }
            IDNumberList.Add(temp);
            return temp;
        }
        public static uint GetUserCardNumber(string? input)
        {
            uint temp;
            while (!uint.TryParse(input, out temp) || string.IsNullOrWhiteSpace(input)
                || temp > 2000000000 || temp < 1000000000 || !IsUniqueID(temp))
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
    }
}
