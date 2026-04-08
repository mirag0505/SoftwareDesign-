using System;
using System.Threading;

public static class Example5
{
    private static readonly ManualResetEventSlim _ready = new(false);

    public static void Run()
    {
        var producer = new Thread(() =>
        {
            Thread.Sleep(500);
            Console.WriteLine("init done");
            _ready.Set();
        });

        void Consumer(int id)
        {
            Console.WriteLine($"wait {id}");
            _ready.Wait();
            Console.WriteLine($"go {id}");
        }

        var c1 = new Thread(() => Consumer(1));
        var c2 = new Thread(() => Consumer(2));

        c1.Start();
        c2.Start();
        producer.Start();
        c1.Join();
        c2.Join();
        producer.Join();
    }
}
