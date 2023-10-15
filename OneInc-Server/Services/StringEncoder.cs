namespace OneInc_Server.Services;

public class StringEncoder : IStringEncoder
{
    public async Task<string> EncodeAsync(string value)
    {
        try
        {
            var stringBytes = System.Text.Encoding.UTF8.GetBytes(value);
            var base64String = Convert.ToBase64String(stringBytes);
            return await Task.FromResult(base64String);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}