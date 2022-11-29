﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    internal class AccountCreator
    {
        private static List<int> IDNumberList = new List<int>();
        private static List<int> CardNumberList = new List<int>();
        public static void Run()
        {
            string[] s = GetUserFullName();
            Console.WriteLine(s[0]);
            Console.ReadKey();
        }

        public static bool IsUniqueID(int idToCheck)
        {
            if (IDNumberList.Contains(idToCheck))
            {
                return false;
            }
            return true;
        }
        //public static int CardNumGenerator()
        //{

        //}

        public static int GetUserIDNumber(string? input)
        {

            int temp;
            while (!int.TryParse(input, out temp) || input == null || temp < 1000 || temp > 9999)
            {
                input = Console.ReadLine();
            }
            return temp;
        }

        public static string[] GetUserFullName()
        {
            bool IsAccepted = false;
            string[] result;

            while (IsAccepted == false){
                string s = Console.ReadLine();
                bool test = s.All(Char.IsLetter);
                if (test == true){
                    result = new string []{s};
                    return result;
                }
            }
            return null;



        }
    }
}
