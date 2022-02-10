using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// CheckingAccount class, inherits from Account. Includes fee charged for each transaction.
    /// Fee is only charged if transaction is completed.
    /// </summary>
    class CheckingAccount : Account
    {
        decimal _fee;
        public decimal Fee {
            get => _fee; 
            set
            {
                _fee = value;
            }
        }
        /// <summary>
        /// Constructor initializes _fee and _balance.
        /// </summary>
        /// <param name="fee"></param>
        /// <param name="bal"></param>
        public CheckingAccount(decimal bal, decimal fee) : base(bal)
        {
            Fee = fee;
        }
        /// <summary>
        /// Overriden from base, will charge fee if amount is valid.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>
        /// True if fee is charged.
        /// False if not.
        /// </returns>
        public override bool Credit(decimal amount)
        {
            if (base.Credit(amount))
            {
                Balance -= Fee;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Overriden from base, will charge fee if amount is valid.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>
        /// True if fee is charged.
        /// False if not.
        /// </returns>
        public override bool Debit(decimal amount)
        {
            if (base.Debit(amount))
            {
                Balance -= Fee;
                return true;
            }
            return false;
        }
    }
}
