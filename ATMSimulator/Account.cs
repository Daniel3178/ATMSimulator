using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    internal class Account
    {
        public uint IDnum { get; set; }
        public  string Name { get; set; }
        public string LastName { get; set; }
        public uint CardNum { get; set; }
        public uint Password { get; set; }

        public Account(uint iDnum, string name, string lastName, uint cardNum, uint password)
        {
            IDnum = iDnum;
            Name = name;
            LastName = lastName;
            CardNum = cardNum;
            Password = password;
        }

        public string ToString(Account account)
        {
            string result = account.Name + "," + account.LastName + "," + account.IDnum + "," + account.CardNum +","+account.Password;
            return result;

        }
    }
}
