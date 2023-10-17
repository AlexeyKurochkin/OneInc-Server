using Microsoft.AspNetCore.SignalR;
using OneInc_Server.Hubs;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace OneInc_Server.Services;

public class StringEncoderManager : IStringEncoderManager
{
    private readonly IStringEncoder _stringEncoder;

    public StringEncoderManager(IStringEncoder stringEncoder)
    {
        _stringEncoder = stringEncoder;
    }

    public async IAsyncEnumerable<char> StartEncodingStream(string message,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var base64String = await _stringEncoder.EncodeAsync(message);
        var random = new Random();

        foreach (var symbol in base64String)
        {
            var delay = random.Next(1, 6) * 1000;
            await Task.Delay(delay);
            cancellationToken.ThrowIfCancellationRequested();
            yield return symbol;
        }
    }
}