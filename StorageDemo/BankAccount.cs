public sealed class BankAccount
{
    private double _balance;

    public BankAccount(double initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance cannot be negative.");
        }

        _balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive.");
        }

        _balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive.");
        }

        if (amount > _balance)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }

        _balance -= amount;
    }

    public double GetBalance()
    {
        return _balance;
    }
}
