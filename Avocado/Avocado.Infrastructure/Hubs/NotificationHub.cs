namespace Avocado.Infrastructure.Hubs
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    public class NotificationHub : Hub
    {
        public async Task SendMessage(string call)
        {
            await this.Clients.Caller.SendAsync("ReciveMessage", call);
        }
    }
}
