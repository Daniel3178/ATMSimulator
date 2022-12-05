using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    internal class ServiceManager
    {
        public static Account? currentUser;
        private static bool ServiceManagerIsActive = false;
        private static bool ServiceManagerOptionIsActive = false;
        private enum Options { Balance = 1, Withdraw, SettIn, Send, LogAsNew, Back }

        public static void Run()
        {
            ServiceManagerIsActive = true;
            while (ServiceManagerIsActive)
            {
                Menu.ShowTheSummary();
                Validator.LogIn();
                OptionsManager();

            }
            DataHandler.WriteToDatabase();
        }
        public static void OptionsManager()
        {
            ServiceManagerOptionIsActive = true;
            while (ServiceManagerOptionIsActive)
            {

                Console.WriteLine("\t" + "[PRESS 1] Show the balance");
                Console.WriteLine("\t" + "[PRESS 2] To with draw money");

                Console.WriteLine("\t" + "[PRESS 3] To sett in money");
                Console.WriteLine("\t" + "[PRESS 4] To send money");
                Console.WriteLine("\t" + "[PRESS 5] To log in as a new customer");
                Console.WriteLine("\t" + "[PRESS 6] Get back to Simulator");



                int temp = 0;
                while (temp > 6 || temp < 1)
                {
                    temp = Menu.GetTheUserChoice(Console.ReadLine());
                }
                switch (temp)
                {
                    case (int)Options.Balance:
                        CheckYourBalance();
                        break;

                    case (int)Options.Withdraw:
                        WithDrawMoney();
                        break;
                    case (int)Options.SettIn:
                        SettInMoney();
                        break;
                    case (int)Options.Send:
                        SendMoney();
                        break;
                    case (int)Options.LogAsNew:
                        ServiceManagerOptionIsActive = false;
                        break;
                    case (int)Options.Back:
                        ServiceManagerOptionIsActive = false;
                        ServiceManagerIsActive = false;
                        break;

                }
            }
        }
        public static void CheckYourBalance()
        {
            if (currentUser != null)
            {
                Console.WriteLine(currentUser.Balance);
            }
        }

        public static void WithDrawMoney()

        {
            Console.WriteLine("Enter the amount you want to withdraw");

            if (currentUser != null)
            {
                bool isAcceptedAmmount = false;
                decimal amount = 0;
                while (!isAcceptedAmmount)
                {
                    string? input = Console.ReadLine();
                    decimal tempAmount;
                    if (decimal.TryParse(input, out tempAmount) && tempAmount < currentUser.Balance)
                    {
                        isAcceptedAmmount = true;
                        amount = tempAmount;
                    }
                }
                currentUser.Balance -= amount;
            }

        }

        public static void SettInMoney()

        {
            Console.WriteLine("Enter the amount you want to withdraw");

            if (currentUser != null)
            {
                bool isAcceptedAmmount = false;
                decimal amount = 0;
                while (!isAcceptedAmmount)
                {
                    string? input = Console.ReadLine();
                    decimal tempAmount;
                    if (decimal.TryParse(input, out tempAmount))
                    {
                        isAcceptedAmmount = true;
                        amount = tempAmount;
                    }
                }
                currentUser.Balance += amount;
            }

        }

        public static void SendMoney()
        {
            Console.Write("Enter the card number you want to transfer money to: ");
            string? input = Console.ReadLine();
            uint cardNumberToSendMoneyTo;
            while (!uint.TryParse(input, out cardNumberToSendMoneyTo) || string.IsNullOrWhiteSpace(input))
            {
                input = Console.ReadLine();
            }
            Console.WriteLine("Enter the amount you want to send: ");
            string? input2 = Console.ReadLine();
            decimal TheSumToSend;
            while (!decimal.TryParse(input2, out TheSumToSend) || string.IsNullOrWhiteSpace(input2))
            {
                input2 = Console.ReadLine();
            }
            if (AccountCreator.CardNumberList.Contains(cardNumberToSendMoneyTo) &&
                currentUser != null && TheSumToSend < currentUser.Balance)
            {
                Account selectedAccount = AccountManager.accountsDirectory[cardNumberToSendMoneyTo];
                selectedAccount.Balance += TheSumToSend;
                currentUser.Balance -= TheSumToSend;

            }
            else
            {
                Console.WriteLine("The cardnumber doesn't exist!");
            }
        }


    }
}
