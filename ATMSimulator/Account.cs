using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    internal class Account
    {
        #region Fields
        public uint IDnum { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public uint CardNum { get; set; }
        public uint Password { get; set; }
        public decimal Balance { get; set; }
        #endregion
        public Account(uint iDnum, string name, string lastName, uint cardNum, uint password)
        {
            IDnum = iDnum;
            Name = name;
            LastName = lastName;
            CardNum = cardNum;
            Password = password;
            Balance = 0;
        }

        public static string ToString(Account account)
        {
            string result = account.Name + "," + account.LastName + "," + account.IDnum
                + "," + account.CardNum + "," + account.Password + "," + account.Balance;
            return result;

        }
    }
}
