namespace Avocado.Infrastructure.Implementations
{
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Avocado.Infrastructure.Hubs;
    using Microsoft.AspNetCore.SignalR;

    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageToAll(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReciveMessage", message);
        }
    }
}