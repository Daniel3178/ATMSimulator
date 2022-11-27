using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    internal class Account
    {
        public int IDnum { get; set; }
        public  string Name { get; set; }
        public string LastName { get; set; }
        public int CardNum { get; set; }
        public int Password { get; set; }

        public Account(int iDnum, string name, string lastName, int cardNum, int password)
        {
            IDnum = iDnum;
            Name = name;
            LastName = lastName;
            CardNum = cardNum;
            Password = password;
        }
    }
}
