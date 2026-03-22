using System;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
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
    }
}
