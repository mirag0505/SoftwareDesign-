using System;

public static class BankAccountTest
{
    public static void Run()
    {
        var account = new BankAccount(1000.0);
        Console.WriteLine($"Начальный баланс: {account.GetBalance()}");

        account.Deposit(500.0);
        Console.WriteLine($"Баланс после депозита 500: {account.GetBalance()}");

        account.Withdraw(200.0);
        Console.WriteLine($"Баланс после снятия 200: {account.GetBalance()}");

        Try("Снятие 2000", () => account.Withdraw(2000.0));
        Console.WriteLine($"Баланс после снятия 2000: {account.GetBalance()}");

        Try("Депозит -100", () => account.Deposit(-100.0));
        Console.WriteLine($"Баланс после некорректного депозита -100: {account.GetBalance()}");

        Try("Снятие -50", () => account.Withdraw(-50.0));
        Console.WriteLine($"Баланс после некорректного снятия -50: {account.GetBalance()}");
    }

    private static void Try(string operation, Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{operation}: ошибка -> {ex.GetType().Name}: {ex.Message}");
        }
    }
}
