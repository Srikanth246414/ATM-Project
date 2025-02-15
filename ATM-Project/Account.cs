using System;
using System.Collections.Generic;

public class Account
{
    public int AccountNumber { get; private set; }
    public double Balance { get; private set; }
    public double InterestRate { get; private set; }
    public string AccountHolderName { get; private set; }
    private List<string> Transactions;

    // Constructor: Initializes a new account
    public Account(int accountNumber, double initialBalance, double interestRate, string accountHolderName)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        InterestRate = interestRate;
        AccountHolderName = accountHolderName;
        Transactions = new List<string>();
    }

    // Method to deposit money
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(" Deposit amount must be greater than 0!");
            return;
        }
        Balance += amount;
        Transactions.Add($"Deposited: ${amount}");
        Console.WriteLine($" Successfully deposited ${amount}. New balance: ${Balance}");
    }

    // Method to withdraw money
    public bool Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(" Withdrawal amount must be greater than 0!");
            return false;
        }
        if (amount > Balance)
        {
            Console.WriteLine(" Insufficient funds! Transaction canceled.");
            return false;
        }
        Balance -= amount;
        Transactions.Add($"Withdrawn: ${amount}");
        Console.WriteLine($" Withdrawal of ${amount} successful. Remaining balance: ${Balance}");
        return true;
    }

    // Method to display balance
    public void DisplayBalance()
    {
        Console.WriteLine($" Account {AccountNumber} - Balance: ${Balance}");
    }

    // Method to display transaction history
    public void DisplayTransactions()
    {
        Console.WriteLine($" Transaction history for Account {AccountNumber}:");
        if (Transactions.Count == 0)
        {
            Console.WriteLine("No transactions yet.");
        }
        else
        {
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}

