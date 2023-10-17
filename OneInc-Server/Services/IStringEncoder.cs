namespace OneInc_Server.Services
{
    public interface IStringEncoder
    {
        Task<string> EncodeAsync(string value);
    }
}
