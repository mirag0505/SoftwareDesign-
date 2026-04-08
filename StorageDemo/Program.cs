using System;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("=== BankAccount demo (логические баги без исключений) ===");
        BankAccountTest.Run();
        Console.WriteLine();
        Console.WriteLine("=== Storage demo (SQLite) ===");
        IStorage storage = new SqliteStorage("Data Source=storage.db");

        var ids = new List<long>
        {
            storage.Save("Первая строка"),
            storage.Save("Вторая строка"),
            storage.Save("Третья строка")
        };

        foreach (var id in ids)
        {
            Console.WriteLine($"{id} -> {storage.Retrieve(id)}");
        }
        Console.WriteLine();
        Console.WriteLine("=== Concurrency demos ===");
        Example1.Run();
        Example2.Run().GetAwaiter().GetResult();
        Example3.Run();
        Example4.Run();
        Example5.Run();
    }
}
