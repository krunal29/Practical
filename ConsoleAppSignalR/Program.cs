using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace ConsoleAppSignalR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var url = "https://localhost:44363/notificationHub";
            HubConnection connection = new HubConnectionBuilder()
                 .WithUrl(new Uri(url)).WithAutomaticReconnect().Build();

            connection.StartAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}", task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                    connection.On<string>("Message", (name) =>
                    {
                        Console.WriteLine(name);
                    });
                    while (true)
                    {
                        string message = Console.ReadLine();
                        if (string.IsNullOrEmpty(message))
                        {
                            break;
                        }
                    }
                }

            }).Wait();
        }
    }
}
