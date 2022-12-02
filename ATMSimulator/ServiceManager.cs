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

        public static void SendMoney(uint cardNumberToSendMoneyTo, decimal TheSumToSend)
        {
            if (AccountCreator.CardNumberList.Contains(cardNumberToSendMoneyTo) && 
                currentUser!= null && TheSumToSend<currentUser.Balance )
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
