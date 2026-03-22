public interface IStorage
{
    long Save(string data);
    string? Retrieve(long id);
}
