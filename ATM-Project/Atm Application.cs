using System;

class AtmApplication
{
    static Bank bank = new Bank();

    private static void Main()
       

    {
        while (true)
        {
            Console.WriteLine("\n === Welocome To ATM Application === ");
            Console.WriteLine("1️.Create Account");
            Console.WriteLine("2️.Select Account");
            Console.WriteLine("3️.Exit");
            Console.Write(" Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    SelectAccount();
                    break;
                case "3":
                    Console.WriteLine(" Thank you for using our ATM. Goodbye!");
                    return;
                default:
                    Console.WriteLine(" Invalid option. Please select 1, 2, or 3.");
                    break;
            }
        }
    }

    static void CreateAccount()
    {
        Console.Write(" Enter Account Number (100-999): ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine(" Invalid input! Please enter a number.");
            return;
        }

        Console.Write(" Enter Initial Balance: ");
        if (!double.TryParse(Console.ReadLine(), out double balance) || balance < 0)
        {
            Console.WriteLine(" Invalid input! Please enter a valid amount.");
            return;
        }

        Console.Write(" Enter Interest Rate: ");
        if (!double.TryParse(Console.ReadLine(), out double interestRate))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }

        Console.Write(" Enter Account Holder Name: ");
        string name = Console.ReadLine();

        Account newAccount = new Account(accountNumber, balance, interestRate, name);
        bank.AddAccount(newAccount);
        Console.WriteLine($" Account created successfully for {name}!");
    }

    static void SelectAccount()
    {
        Console.Write(" Enter Account Number: ");
        if (!int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            Console.WriteLine(" Invalid input! Please enter a number.");
            return;
        }

        Account selectedAccount = bank.RetrieveAccount(accountNumber);
        if (selectedAccount == null)
        {
            Console.WriteLine(" Account not found.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\n Account Menu ");
            Console.WriteLine("1️ Check Balance");
            Console.WriteLine("2️ Deposit");
            Console.WriteLine("3️ Withdraw");
            Console.WriteLine("4️ Display Transactions");
            Console.WriteLine("5️ Exit Account");
            Console.Write(" Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    selectedAccount.DisplayBalance();
                    break;
                case "2":
                    Console.Write(" Enter Deposit Amount: ");
                    if (double.TryParse(Console.ReadLine(), out double depositAmount))
                        selectedAccount.Deposit(depositAmount);
                    else
                        Console.WriteLine(" Invalid input! Please enter a valid amount.");
                    break;
                case "3":
                    Console.Write(" Enter Withdrawal Amount: ");
                    if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        selectedAccount.Withdraw(withdrawAmount);
                    else
                        Console.WriteLine(" Invalid input! Please enter a valid amount.");
                    break;
                case "4":
                    selectedAccount.DisplayTransactions();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine(" Invalid option. Try again.");
                    break;
            }
        }
    }
}

