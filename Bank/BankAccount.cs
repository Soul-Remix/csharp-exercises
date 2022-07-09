using System;

namespace Bank;

public class BankAccount
{
    private static int _accountNumberSeed = 123456789;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (Transaction item in allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }


    public BankAccount(string name, decimal initialBalance)
    {
        Number = _accountNumberSeed.ToString();
        _accountNumberSeed++;
        Owner = name;
        this.MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    private List<Transaction> allTransactions = new List<Transaction>();

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Deposit amount cannot be zero or less");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Amount of withdraw must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdraw = new Transaction(-amount, date, note);
        allTransactions.Add(withdraw);
    }

    public string GetAccountHistory()
    {
        var history = new System.Text.StringBuilder();
        decimal balance = 0;

        history.AppendLine("Date\t\tAmount\tBalance\tNotes");

        foreach (Transaction item in allTransactions)
        {
            balance += item.Amount;
            history.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return history.ToString();
    }
}