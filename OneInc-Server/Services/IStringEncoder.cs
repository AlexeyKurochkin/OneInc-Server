namespace OneInc_Server.Services
{
    public interface IStringEncoder
    {
        Task<IEnumerable<char>> EncodeAsync(string value);
    }
}
