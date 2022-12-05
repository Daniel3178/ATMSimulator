using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace ATMSimulator
{
    internal class Validator
    {
        public static SecureString GetTheSecretPassword()
        {
            SecureString password = new SecureString();
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar) && !char.IsLetter(keyInfo.KeyChar))
                {
                    password.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.RemoveAt(password.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            {
                return password;
            }
        }

        public static void LogIn()
        {
            Console.WriteLine("Enter your card Number");
            uint userCardNum =  AccountCreator.GetUserCardNumber(Console.ReadLine());
            Console.WriteLine("Enter your password");
            SecureString pass = GetTheSecretPassword();

            string? input = new System.Net.NetworkCredential(string.Empty, pass).Password;
            uint userPassword = 0;
            while (!uint.TryParse(input, out userPassword) || string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Only PIN");
                Console.ResetColor();
               pass = GetTheSecretPassword();

                 input = new System.Net.NetworkCredential(string.Empty, pass).Password;
             

            }
            if (IsAuthorized(userCardNum, userPassword) && ServiceManager.currentUser != null)
            {

                Console.WriteLine("You logged in as " +
                    ServiceManager.currentUser.Name + ServiceManager.currentUser.LastName);
            }
            else if(!IsAuthorized(userCardNum, userPassword))
            {
                Console.WriteLine("\n \t Your are not authorized! ");
            }
        }
        public static bool IsAuthorized(uint cardNumber, uint password)
        {
            Account selectedAccount;
            try
            {

            selectedAccount = AccountManager.accountsDirectory[cardNumber];
            if(selectedAccount.Password == password)
            {
                ServiceManager.currentUser = selectedAccount;
                return true;
            }
            else
            {
                return false;
            }
            }
            catch
            {
                return false;
            }
        }
    }
}
