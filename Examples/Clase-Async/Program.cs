using System;
using System.Threading;
using System.Threading.Tasks;
namespace Clase_Async
{
    class Program
    {

        private static readonly object lockObject = new object();
        private static decimal valor = 10000000;
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            // Task 
            // Una tarea en segundo plano

            // Task.Delay() Genera un proceso asincrono de espera
            // Thread.Sleep() Bloquea un Hilo en su totalidad.

            //Console.WriteLine("Tendremos que esperar 10 segundos para cerrar el programa");
            //Thread.Sleep(10000);

            /*Task.Run(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("Hola Mundo");
            });
            */

            //EjecutaSinEsperar();
            //EjecutarEsperando();

            //Console.WriteLine("Presiona una tecla para cerrar en cualquier momento");
            //Console.ReadKey();

            // Lock statement
            try
            {
                Parallel.Invoke(
                () =>
                {
                    for (int ii = 0; ii < 1; ii++)
                    {
                        Restador(200);;
                    }

                    Console.WriteLine("Termine For 1");
                },
                () =>
                {
                    for (int ii = 0; ii < 1; ii++)
                    {
                        Restador(23);
                    }

                    Console.WriteLine("Termine For 2");
                },
                () =>
                {
                    for (int ii = 0; ii < 1; ii++)
                    {
                       Restador(1);
                    }

                    Console.WriteLine("Termine For 3");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        public static decimal Restador(decimal monto)
        {
            lock (lockObject)
            {
                if (valor >= 0)
                {
                    valor = valor - monto;
                    Console.WriteLine("Su monto es:" + valor);
                    return valor;
                }
                return 0;
            }
        }

        public static void EjecutaSinEsperar()
        {
            Task.Delay(10000);
            Console.WriteLine("Saludo inmediato");
        }

        public static async void EjecutarEsperando()
        {
            await Task.Delay(10000);
            Console.WriteLine("Saludo postergado");
        }
    }

}
