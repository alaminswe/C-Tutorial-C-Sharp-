
interface ITransactable
{
    public void Deposit(decimal amount);
    public void Withdraw(decimal amount);
    public void PrintStatement();
}

interface IInterestBearing
{
    public decimal InterestRate { get; }
    public void ApplyInterest();
}
public abstract class BankAccount : ITransactable
{
    private decimal _balance;

    public BankAccount(string accountNumber, string ownerName, decimal initialBalance)
    {
        AccountNumber=accountNumber;
        OwnerName=ownerName;
        Balance=initialBalance;
        CreatedDate = DateTime.Now;
    }

    // Properties:
    public string AccountNumber { get; init; }
    public string OwnerName { get; private set; }
    public DateTime CreatedDate { get; init; }

    // Protected property:  ← child পাবে, বাইরে পাবে না
    public decimal Balance
    {
        get => _balance;
        protected set
        {
            if (value < 0)
                throw new InvalidOperationException("Balance cannot be negative!");
            _balance = value;
        }
    }

    // Abstract properties: ← child অবশ্যই implement করবে
    public abstract string AccountType { get; }
    public abstract decimal MinimumBalance { get; }

    // Protected method:  ← child use করতে পারবে
    private List<string> _transactions = new List<string>();
    protected void LogTransaction(string msg)
    {
        _transactions.Add($"[{DateTime.Now:HH:mm:ss}] {msg}");
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit must be positive!");
        }
        Balance+=amount;
        LogTransaction($"Deposited {amount:N2} | Balance: {Balance:N2}");
        Console.WriteLine($"✅ Deposited {amount:N2}. New Balance: {Balance:N2}");
    }
    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdraw must be positive!");
        }
        if (Balance - amount < MinimumBalance)
        {
            throw new InvalidOperationException("Minimum 1k-BDT balance required!");
        }
        Balance -= amount;
        LogTransaction($"Withdrew {amount:N2} | Balance: {Balance:N2}");
        Console.WriteLine($"✅ Withdrew {amount:N2}. New Balance: {Balance:N2}");
    }

    public void PrintStatement()
    {
        Console.WriteLine($"\n{"=",30}");
        Console.WriteLine($"  {AccountType} — {AccountNumber}");
        Console.WriteLine($"  Owner  : {OwnerName}");
        Console.WriteLine($"  Balance: {Balance:N2}");
        Console.WriteLine($"{"=",30}");
        foreach (string t in _transactions)
            Console.WriteLine($"  {t}");
        Console.WriteLine($"{"=",30}");
    }


}

class SavingsAccount : BankAccount , IInterestBearing
{

    public SavingsAccount(string accountNumber, string ownerName, decimal balance, decimal rate) : base(accountNumber,ownerName,balance)
    {
        InterestRate=rate;
    }

    // Abstract property implement করতে override লাগে

    public override string AccountType => "Savings Account";
    public override decimal MinimumBalance => 1000m;

    public decimal InterestRate{get;private set;}
    public void ApplyInterest()
    {
        decimal interest = Balance * InterestRate / 100;
        Deposit(interest);
        Console.WriteLine($"{interest:N2} BDT added as interest! | Total Balance: {Balance:N2}");
    }

}


class CurrentAccount : BankAccount
{
    private decimal _overdraftLimit;

    public override string AccountType => "Current Account";
    public override decimal MinimumBalance => 0m;

    public CurrentAccount(string accNo, string owner, decimal balance, decimal overdraft): base(accNo, owner, balance)
    {
        _overdraftLimit = overdraft;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive!");
        if (Balance - amount < -_overdraftLimit)
            throw new InvalidOperationException($"Overdraft limit {_overdraftLimit:C} exceeded!");

        Balance -= amount;
        LogTransaction($"Withdrew {amount:N2} | Balance: {Balance:N2}");
        Console.WriteLine($"✅ Withdrew {amount:N2}. Balance: {Balance:N2}");
    }

}

sealed class FixedDepositAccount : BankAccount, IInterestBearing
{
    public override string AccountType => "Fixed Deposit";
    public override decimal MinimumBalance => 10000m;
    public decimal InterestRate { get; private set; }
    public DateTime MaturityDate { get; init; }

    public bool IsMatured => DateTime.Now >= MaturityDate;

    public FixedDepositAccount(string accNo, string owner, decimal balance, decimal rate, int months)
        : base(accNo, owner, balance)
    {
        InterestRate = rate;
        MaturityDate = DateTime.Now.AddMonths(months);
    }

    public override void Withdraw(decimal amount)
    {
        if (!IsMatured)
            throw new InvalidOperationException( $"FD matures on {MaturityDate:dd/MM/yyyy}. Cannot withdraw yet!");

        base.Withdraw(amount);
    }

    public void ApplyInterest()
    {
        decimal interest = Balance * InterestRate / 100;
        Deposit(interest);
    }
}

class Bank
{
    private string _bankName;
    private List<BankAccount> _accounts = new List<BankAccount>();

    public Bank(string name) => _bankName = name;

    public void AddAccount(BankAccount account)
    {
        _accounts.Add(account);
        Console.WriteLine($"✅ {account.AccountType} opened for {account.AccountNumber}");
    }

    public BankAccount FindAccount(string accNo)
    {
        return _accounts.Find(a => a.AccountNumber == accNo) ?? throw new KeyNotFoundException($"Account {accNo} not found!");
    }

    public void ApplyAllInterest()
    {
        foreach (var acc in _accounts)
        {
            if (acc is IInterestBearing ib)   // Interface check!
                ib.ApplyInterest();
        }
    }

    public void PrintAllStatements()
    {
        Console.WriteLine($"\n===== {_bankName} — All Accounts =====");
        foreach (var acc in _accounts)
            acc.PrintStatement();
    }
}

class BankingSystem
{
    static void Main(string[] args)
    {
        Bank bank = new Bank("BD National Bank");

        var savings = new SavingsAccount("SAV001", "Rahim", 50000, 5);
        var current = new CurrentAccount("CUR001", "Karim Ltd", 100000, 20000);
        var fd = new FixedDepositAccount("FD001", "Nasrin", 200000, 8, 12);

        bank.AddAccount(savings);
        bank.AddAccount(current);
        bank.AddAccount(fd);

        // Transactions
        try
        {
            savings.Deposit(10000);
            savings.Withdraw(5000);
            savings.ApplyInterest();

            current.Deposit(50000);
            current.Withdraw(120000);   // Overdraft use করবে

            fd.Withdraw(10000);   // Error! মাগুর আগে withdraw করা যাবে না
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }

        bank.ApplyAllInterest();
        bank.PrintAllStatements();
    }
}