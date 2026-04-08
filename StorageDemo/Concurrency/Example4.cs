using System;
using System.Threading;

public static class Example4
{
    public static void Run()
    {
        int n = 4;
        var barrier = new Barrier(n);
        void Worker(int id)
        {
            Console.WriteLine($"stage1 {id}");
            Thread.Sleep(100 + id * 50);
            barrier.SignalAndWait();
            Console.WriteLine($"stage2 {id}");
        }

        var threads = new Thread[n];
        for (int i = 0; i < n; i++)
        {
            int id = i;
            threads[i] = new Thread(() => Worker(id));
            threads[i].Start();
        }
        foreach (var t in threads) t.Join();
    }
}
