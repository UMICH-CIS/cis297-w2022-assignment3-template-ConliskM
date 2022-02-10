using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// Test class for account class hierarchy
    /// </summary>
    public class AccountTest
    {
        /// <summary>
        /// Entry point for program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //create array of accounts
            Account[] accounts = new Account[4];

            //initialize array with accounts
            accounts[0] = new SavingAccount(25M, .03M);
            accounts[1] = new CheckingAccount(80M, 1M);
            accounts[2] = new SavingAccount(200M, .015M);
            accounts[3] = new CheckingAccount(400M, .5M);

            //loop through array, prompting user for debit and credit amounts
            for (int i = 0; i < accounts.Length; i++)
            {
                Console.WriteLine($"Account {i + 1} balance: {accounts[i].Balance:C}");

                Console.Write($"\nEnter an amount to withdraw from Account {i + 1}: ");
                decimal withdrawalAmount = decimal.Parse(Console.ReadLine());

                accounts[i].Debit(withdrawalAmount); //attempt to debit
                Console.Write($"\nEnter an amount to deposit into Account {i + 1}: ");
                decimal depositAmount = decimal.Parse(Console.ReadLine());

                //credit amount to Account
                accounts[i].Credit(depositAmount);
                //if Account is a SavingAccount, calculate and add interest
                if (accounts[i] is SavingAccount)
                {
                    //downcast
                    SavingAccount currentAccount = (SavingAccount)accounts[i];
                    decimal interestEarned = currentAccount.CalculateInterest();
                    Console.WriteLine($"Adding {interestEarned:C} interest to Account {i + 1} (a Savings Account).");
                    currentAccount.Credit(interestEarned);
                }
                Console.WriteLine($"\nUpdated Account {i + 1} balance: {accounts[i].Balance:C}.\n\n");
            }
        }
    }
}
