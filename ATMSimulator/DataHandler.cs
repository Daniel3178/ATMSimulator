using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    internal class DataHandler
    {
        public static void WriteToDatabase()
        {
            List<string> files = new();
            foreach (Account item in AccountManager.accountsDirectory.Values)
            {
                files.Add(Account.ToString(item));
            }
            using StreamWriter file = new("Database.txt", false);
            foreach (string myString in files)
            {
                file.WriteLine(myString);
            }
        }
        public static void ReadFromDatabase()
        {
            string[] tempString = File.ReadAllLines("Database.txt");
            string[][] newTemp = new string[tempString.Length][];

            for (int i = 0; i < tempString.Length; i++)
            {
                newTemp[i] = SplitTheString(tempString[i]);
            }

            for (int i = 0; i < tempString.Length; i++)
            {
                Account newAccount = new(uint.Parse(newTemp[i][2]),
                    newTemp[i][0], newTemp[i][1], uint.Parse(newTemp[i][3]),
                    uint.Parse(newTemp[i][4]));
                AccountManager.AddNewAccountToDictionary(newAccount, uint.Parse(newTemp[i][3]));
                AccountCreator.IDNumberList.Add(uint.Parse(newTemp[i][2]));
                AccountCreator.CardNumberList.Add(uint.Parse(newTemp[i][3]));
            }
        }
        private static string[] SplitTheString(string input)
        {
            string[] tempString = input.Split(',');
            return tempString;
        }
    }
}
