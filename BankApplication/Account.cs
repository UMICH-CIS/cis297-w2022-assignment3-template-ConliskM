using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// Base Account class, inherited by CheckingAccount and SavingAccount
    /// </summary>
    class Account
    {
        private decimal _balance;
        /// <summary>
        /// Balance property. get returns _balance, set assigns _balance only if positive value is passed.
        /// </summary>
        public decimal Balance 
        {
            get => _balance; 
            set
            {
                if (value < 0.00M)
                {
                    throw new ArgumentOutOfRangeException($"{ nameof(value) } must cannot be negative.");
                }
                _balance = value;
            }
        }
        /// <summary>
        /// Initializes _balance to value passed.
        /// </summary>
        /// <param name="bal"></param>
        public Account(decimal bal)
        {
            Balance = bal;
        }
        /// <summary>
        /// "Deposits" amount passed to _balance, unless amount passed is negative.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>
        /// True if amount is Credited.
        /// False if not.
        /// </returns>
        public virtual bool Credit(decimal amount)
        {
            if (amount < 0.0M)
            {
                Console.WriteLine("Cannot credit a negative value.");
                return false;
            }
            Balance += amount;
            return true;
        }
        /// <summary>
        /// "Withdraws" amount passed to _balance, unless _balance is less than withdrawl amount.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>
        /// True if amount is Debited.
        /// False if amount is not Debited.
        /// </returns>
        public virtual bool Debit(decimal amount)
        {
            if (Balance < amount)
            {
                Console.Write("Debit amount exceeded account balance.");
                return false;
            }
            Balance -= amount;
            return true;
        }
    }
}
