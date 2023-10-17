using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using OneInc_Server.Services;
using System.Runtime.CompilerServices;

namespace OneInc_Server.Hubs;

[EnableCors("AllowWebClient")]
public class EncodingHub : Hub
{
    private readonly IStringEncoderManager _encoderManager;

    public EncodingHub(IStringEncoderManager encoderManager)
    {
        _encoderManager = encoderManager;
    }

    public async IAsyncEnumerable<char> StartEncodingStream(string message,[EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var symbol in _encoderManager.StartEncodingStream(message, cancellationToken))
        {
            yield return symbol;
        }
    }
}