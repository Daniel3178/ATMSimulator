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
        private static bool AccountCreatorOptionIsActive = false;
        private static bool AccountCreatorIsActive = false;
        public static List<uint> IDNumberList = new List<uint>();
        public static List<uint> CardNumberList = new List<uint>();
        private static Account? activeAccount;
        private enum Options { Profile = 1, New, Back }
        public static void Run()
        {
            AccountCreatorIsActive = true;
            while (AccountCreatorIsActive)
            {
                Menu.ShowTheSummary();
                CreateAccount();
                OptionsManager();

            }
            DataHandler.WriteToDatabase();
        }

        private static void CreateAccount()
        {
            Account newAccount;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t" + "please enter your full name: ");
            string[] temp = GetUserFullName();
            Console.Write("\t" + "please enter your IdNumber: ");
            uint id = GetUserIDNumber(Console.ReadLine());
            Console.Write("\t" + "please choose a 6-digit PIN kod: ");
            uint password = GetUserPassword();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n \t Congratulation!! Your account has been created!" +
                "\n \t Your cardnumber is: ");
            uint cardNum = CardNumGenerator();
            Console.WriteLine(cardNum);
            Console.ResetColor();

            newAccount = new Account(id, temp[0], temp[1], cardNum, password);
            AccountManager.AddNewAccountToDictionary(newAccount, cardNum);
            activeAccount = newAccount;

        }
        private static void ShowTheProfile()
        {
            if (activeAccount != null)
            {
                Console.WriteLine(activeAccount.ToString(activeAccount));
            }
        }
        public static void OptionsManager()
        {
            AccountCreatorOptionIsActive = true;
            while (AccountCreatorOptionIsActive)
            {

                Console.WriteLine("\t" + "[PRESS 1] Show the account profile");
                Console.WriteLine("\t" + "[PRESS 2] Create a new account");

                Console.WriteLine("\t" + "[PRESS 3] Get back to Simulator");

                int temp = 0;
                while (temp > 3 || temp < 1)
                {
                    temp = Menu.GetTheUserChoice(Console.ReadLine());
                }
                switch (temp)
                {
                    case (int)Options.Profile:
                        ShowTheProfile();
                        break;

                    case (int)Options.New:
                        AccountCreatorOptionIsActive = false;
                        break;
                    case (int)Options.Back:
                        AccountCreatorOptionIsActive = false;
                        AccountCreatorIsActive = false;
                        break;

                }
            }
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
