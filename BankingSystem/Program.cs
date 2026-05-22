
class BankingSystem
{
    static void Main(string[] args)
    {
        SavingsAccount sa = new SavingsAccount("SAV001", "Rahim", 50000, 5);
        sa.Deposit(10000);
        // ✅ Deposited 10,000.00. New Balance: 60,000.00

        sa.ApplyInterest();
        // ✅ Deposited 3,000.00. New Balance: 63,000.00  (5% of 60000)
        // 💰 Interest applied: 3000 at 5%

        sa.PrintStatement();
        // Statement with all transactions
    }
}
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

class TestAccount : ITransactable
{
    public void Deposit(decimal amount)
    {
        Console.WriteLine($"Deposited: {amount}");
    }
    public void Withdraw(decimal amount)
    {
        Console.WriteLine($"Withdrew: {amount}");
    }
    public void PrintStatement()
    {
        Console.WriteLine("Statement printed.");
    }
}