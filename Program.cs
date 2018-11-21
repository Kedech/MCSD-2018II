using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WebServerProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Servidor Web pequeño");
            Server.Start();
            Console.WriteLine("Se termino de cargar");
            Console.ReadLine();
        }
    }
}
