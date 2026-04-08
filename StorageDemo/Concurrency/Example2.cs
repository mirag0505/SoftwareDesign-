using System;
using System.Threading;
using System.Threading.Tasks;

public static class Example2
{
    private static readonly SemaphoreSlim _sem = new(3);

    private static async Task Work(int id)
    {
        await _sem.WaitAsync();
        try
        {
            Console.WriteLine($"start {id}");
            await Task.Delay(300);
            Console.WriteLine($"done {id}");
        }
        finally
        {
            _sem.Release();
        }
    }

    public static async Task Run()
    {
        var tasks = new Task[10];
        for (int i = 0; i < tasks.Length; i++) tasks[i] = Work(i);
        await Task.WhenAll(tasks);
    }
}
