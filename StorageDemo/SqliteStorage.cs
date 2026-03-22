using Microsoft.Data.Sqlite;

public sealed class SqliteStorage : IStorage
{
    private readonly string _connectionString;

    public SqliteStorage(string connectionString)
    {
        _connectionString = connectionString;

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var cmd = connection.CreateCommand();
        cmd.CommandText = """
            CREATE TABLE IF NOT EXISTS storage (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                data TEXT NOT NULL
            );
            """;
        cmd.ExecuteNonQuery();
    }

    public long Save(string data)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var cmd = connection.CreateCommand();
        cmd.CommandText = "INSERT INTO storage(data) VALUES ($data); SELECT last_insert_rowid();";
        cmd.Parameters.AddWithValue("$data", data);

        var result = cmd.ExecuteScalar();
        return result is long id ? id : throw new InvalidOperationException("No id returned");
    }

    public string? Retrieve(long id)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT data FROM storage WHERE id = $id;";
        cmd.Parameters.AddWithValue("$id", id);

        using var reader = cmd.ExecuteReader();
        return reader.Read() ? reader.GetString(0) : null;
    }
}
