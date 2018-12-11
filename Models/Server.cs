using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace WebServerProj
{
    /// TODO: Clase 5 - Actividad 3: Enlazar en server eventos
    /// Que Program.cs controla, y conoce cuando se recibe un Request Message.
    
    public static class Server
    {
        //private static HttpListener listener;

        // Numero maximo de conexiones concurrentes
        public static int maxSimultaneousConnections = 20;

        // 

        // Semaforo es una clase que se encarga de limitar accesso concurrentes.
        private static Semaphore sem = new Semaphore(maxSimultaneousConnections, maxSimultaneousConnections);

        // Obtener el IP local de nuestro ordenador para permitir el enlace.
        private static List<IPAddress> GetLocalHostIPs()
        {
            Console.WriteLine("Paso 1");
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            List<IPAddress> net = new List<IPAddress>();
            foreach (IPAddress item in host.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    net.Add(item);
                }
            }

            // Linq Example
            // net = host.AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetwork).ToList();

            return net;
        }

        // Instanciar el listener de HTTP de la libreria de Microsoft, con las direcciones IP Locales.
        // Y/O externas en algun momento.
        private static HttpListener InitializeListener(List<IPAddress> localhostIps)
        {
            Console.WriteLine("Paso2");
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost/");

            // Listen for IP
            foreach (IPAddress ipAddress in localhostIps)
            {
                Console.WriteLine($"Escuchando IP {ipAddress.ToString()}/");
                listener.Prefixes.Add($"http://{ipAddress.ToString()}/");
            }

            // LinQ
            //localhostIps.ForEach(ipAddress => {
            //    Console.WriteLine($"Escuchando IP {ipAddress.ToString()}/");
            //    listener.Prefixes.Add($"http://{ipAddress.ToString()}/");
            //});

            return listener;
        }

        // Empezar server
        private static void Start(HttpListener listen)
        {
            listen.Start();
            Task.Run(() => RunServer(listen));
        }

        // Ejecutar conexiones.
        private static void RunServer(HttpListener listener)
        {
            while (true)
            {
                // Empieza una conexion, hasta el numero 20 en espera. Y luego espera que cada conexion
                // se libere antes de empezar otra.
                sem.WaitOne();
                StartConnectionListener(listener);
            }
        }

        // Procesar HTTP.
        private static async void StartConnectionListener(HttpListener listener)
        {
            // Esperar por una conexion. Y Retornar al invocador mientras espera.
            HttpListenerContext context = await listener.GetContextAsync();

            // El semaforo termina. Y permite que otro Listener pueda empezar.
            sem.Release();
            byte[] encodedMessage;
            HttpRequestConverter rc = new HttpRequestConverter();
            
            // Subscribe
            rc.OnRequestHeaderMissing += LogErrorMessage;
            // unsubscribe
            //rc.OnRequestHeaderMissing -= LogErrorMessage;

            rc.OnRequestHeaderMissing += (obj, arg) => { Console.WriteLine("Lambda Function," + arg.ErrorMessage); };
            encodedMessage = rc.AnalyzeRequest(context.Request);

            // TODO: Actividad.
            // Hacer un Metodo estatico que Recibe el Context y datos, y Devuelve el context con un Response
            await context.Response.OutputStream.WriteAsync(encodedMessage, 0, encodedMessage.Length);
            context.Response.OutputStream.Close();
        }

        public static void LogErrorMessage(object obj, CustomArgs args)
        {
            Console.WriteLine(args.ErrorMessage);
        }

        // Iniciar servidor desde Program.cs
        public static void Start()
        {
            List<IPAddress> localhostIPs = GetLocalHostIPs();
            HttpListener listener = InitializeListener(localhostIPs);
            Start(listener);

            // 1 Line call
            //Start(InitializeListener(GetLocalHostIPs()));
        }
    }
}