using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace BantuHub.Demo.SignalR.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = @"http://localhost:8082/";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Le Serveur a demarré à l'adresse {0}", url);
                Console.ReadLine();
            }
        }
    }
}
