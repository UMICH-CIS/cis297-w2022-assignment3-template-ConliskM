using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// SavingAccount class, inherits from Account. Includes interestRate.
    /// </summary>
    class SavingAccount : Account
    {
        decimal interestRate;
        /// <summary>
        /// Constructor, initializes interest rate and balance.
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="bal"></param>
        public SavingAccount(decimal bal, decimal rate) : base(bal)
        {
            interestRate = rate;
        }
        /// <summary>
        /// Calculates interest earned from balance.
        /// </summary>
        /// <returns>Earned interest</returns>
        public decimal CalculateInterest()
        {
            return Balance * interestRate;
        }
    }
}
