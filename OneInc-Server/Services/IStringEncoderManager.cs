namespace OneInc_Server.Services;

public interface IStringEncoderManager
{
    IAsyncEnumerable<char> StartEncodingStream(string message, CancellationToken cancellationToken);
}