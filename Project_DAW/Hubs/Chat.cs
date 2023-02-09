using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace Project_DAW.Hubs
{
    [SignalRHub]
    public class Chat : Hub
    {
        public async Task Message(string email, string message)
        {
            await Clients.All.SendAsync(email, message);
        }
    }
}
