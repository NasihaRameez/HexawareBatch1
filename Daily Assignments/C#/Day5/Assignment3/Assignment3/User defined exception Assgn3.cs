using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class User_defined_exception_Assgn3
    {
        class InsufficientFundsException : Exception
        {
            public InsufficientFundsException(string message) : base(message) { }
        }
        class BankAccount
        {
            public string AccountHolder { get; set; }
            public double Balance { get; private set; }

            public BankAccount(string accountHolder, double initialBalance)
            {
                AccountHolder = accountHolder;
                Balance = initialBalance;
            }

            public void TransferFunds(double amount)
            {
                if (amount > Balance)
                {
                    throw new InsufficientFundsException("Insufficient funds for transfer.");
                }
                Balance -= amount;
                Console.WriteLine("Transfer Successful! Remaining Balance: " + Balance);
            }
        }
        class Program
        {
            static void Main()
            {
                Console.Write("Enter Account Holder Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Initial Balance: ");
                double initialBalance = Convert.ToDouble(Console.ReadLine());

                BankAccount account = new BankAccount(name, initialBalance);

                Console.Write("Enter Amount to Transfer: ");
                double transferAmount = Convert.ToDouble(Console.ReadLine());

                try
                {
                    account.TransferFunds(transferAmount);
                }
                catch (InsufficientFundsException ex)
                {
                    Console.WriteLine("Transaction Failed: " + ex.Message);
                }
            }
        }
    }
}


