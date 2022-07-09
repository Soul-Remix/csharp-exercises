namespace Bank;

public class BankAccount
{
    private static int _accountNumberSeed = 123456789;
    private readonly decimal _minimumBalance;
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


    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }


    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Number = _accountNumberSeed.ToString();
        _accountNumberSeed++;
        Owner = name;
        _minimumBalance = minimumBalance;

        if (initialBalance > 0)
        {
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

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
        if (Balance - amount < _minimumBalance && _minimumBalance == 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        if (Balance - amount < _minimumBalance && _minimumBalance != 0)
        {
            var fee = new Transaction(-20, date, "Overdraft fee");
            allTransactions.Add(fee);
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

    public virtual void PerformMonthEndTransactions() { }
}