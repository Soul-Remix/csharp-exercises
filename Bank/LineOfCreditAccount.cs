namespace Bank;

class LineOfCreditAccount : BankAccount
{
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, creditLimit) { }

    public override void PerformMonthEndTransactions()
    {
        if (Balance < 0m)
        {
            decimal interest = -Balance * 0.05m;
            MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
        }
    }


}