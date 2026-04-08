using System;
using System.Threading;

public sealed class Accounts
{
    private readonly object _sync = new();
    private int _a;
    private int _b;

    public Accounts(int a, int b)
    {
        _a = a;
        _b = b;
    }

    public void TransferAtoB(int amount)
    {
        lock (_sync)
        {
            _a -= amount;
            _b += amount;
        }
    }

    public (int, int) Snapshot()
    {
        lock (_sync)
        {
            return (_a, _b);
        }
    }
}

public static class Example1
{
    public static void Run()
    {
        var acc = new Accounts(100000, 0);
        var t1 = new Thread(() =>
        {
            for (int i = 0; i < 10000; i++) acc.TransferAtoB(1);
        });
        var t2 = new Thread(() =>
        {
            for (int i = 0; i < 10000; i++) acc.TransferAtoB(1);
        });
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        var (a, b) = acc.Snapshot();
        Console.WriteLine($"{a}+{b}={a + b}");
    }
}
