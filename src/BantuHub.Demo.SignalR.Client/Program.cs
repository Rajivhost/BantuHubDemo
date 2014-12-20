using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace BantuHub.Demo.SignalR.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = @"http://localhost:8082/";
            var connection = new HubConnection(url);
            var hub = connection.CreateHubProxy("ChatHub");
            hub.On("ReceiveMessage", message => Console.WriteLine(message));
            connection.Start().Wait();

            string line;
            while ((line = Console.ReadLine()) != null)
            {
                hub.Invoke("SendMessage", line).Wait();
            }
        }
    }
}
