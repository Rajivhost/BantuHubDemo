using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BantuHub.Demo.SignalR.Server
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Le message '{0}' a été reçu d'un client", message);
            Clients.All.ReceiveMessage(message);
        }
    }
}