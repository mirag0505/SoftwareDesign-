using System;

public static class BankAccountTest
{
    public static void Run()
    {
        var account = new BankAccount(100.0);

        account.Deposit(50.0);
        account.Withdraw(30.0);
        Console.WriteLine($"Баланс после обычных операций: {account.GetBalance()}");

        account.Deposit(-200.0);
        Console.WriteLine($"Баланс после депозита отрицательной суммы: {account.GetBalance()}");

        account.Withdraw(1000.0);
        Console.WriteLine($"Баланс после снятия большой суммы (может стать отрицательным): {account.GetBalance()}");
    }
}
