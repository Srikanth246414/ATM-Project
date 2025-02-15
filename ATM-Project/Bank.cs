using System;
using System.Collections.Generic;

public class Bank
{
    private List<Account> accounts;

    // Constructor: Initializes default accounts
    public Bank()
    {
        accounts = new List<Account>();
        for (int i = 100; i < 110; i++)
        {
            accounts.Add(new Account(i, 100, 3, $"User{i}"));
        }
    }

    // Method to retrieve an account by its number
    public Account RetrieveAccount(int accountNumber)
    {
        return accounts.Find(acc => acc.AccountNumber == accountNumber);
    }

    // Method to add a new account
    public void AddAccount(Account newAccount)
    {
        accounts.Add(newAccount);
    }
}

