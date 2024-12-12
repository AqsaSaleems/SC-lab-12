using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ServerApplication
{
    internal class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(8888);
            server.Start();
            Console.WriteLine("Server Started");
            Socket clientdoor = server.AcceptSocket();  
            if( clientdoor.Connected)
            {
                NetworkStream ns = new NetworkStream(clientdoor);  // Server messages
                Console.WriteLine("Server>> Hello Client I am Server");
                StreamWriter writer = new StreamWriter(ns);
                writer.WriteLine("Message from Server");
                writer.Flush();
                while (true)
                {
                    StreamReader sr = new StreamReader(ns);
                    Console.WriteLine("Client>>" + sr.ReadLine());

                }

            }
            server.Stop();

        }
    }
}
