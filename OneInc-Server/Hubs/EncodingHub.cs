using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace OneInc_Server.Hubs
{
    [EnableCors("AllowAll")]
    public class EncodingHub : Hub
    {
        public async Task StartEncoding(string message)
        {
            
            await Clients.Caller.SendAsync("ReceiveSymbol", user, message);
        }
    }
}
