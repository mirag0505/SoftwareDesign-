using System;
using System.Collections.Generic;
using System.Threading;

public sealed class Cache
{
    private readonly Dictionary<string, string> _map = new();
    private readonly ReaderWriterLockSlim _rw = new();

    public bool TryGet(string key, out string value)
    {
        _rw.EnterReadLock();
        try
        {
            return _map.TryGetValue(key, out value!);
        }
        finally
        {
            _rw.ExitReadLock();
        }
    }

    public void Put(string key, string value)
    {
        _rw.EnterWriteLock();
        try
        {
            _map[key] = value;
        }
        finally
        {
            _rw.ExitWriteLock();
        }
    }
}

public static class Example3
{
    public static void Run()
    {
        var c = new Cache();
        c.Put("k", "v");
        if (c.TryGet("k", out var v)) Console.WriteLine(v);
    }
}
