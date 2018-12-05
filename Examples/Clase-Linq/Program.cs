using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Clase_Linq.Models;

namespace Clase_Linq
{
    class Program
    {
        static void Method1()
        {
            Console.WriteLine("Task Async");
        }
        static void Main(string[] args)
        {

            CancellationTokenSource cts = new CancellationTokenSource();
            var tks = cts.Token;

            Task t3 = Task.Run(() => { for (int i = 1; i < 100000000; i+=2) { Console.WriteLine("Estoy en el numero:"+i); }; }, tks);
            // Duerme el Hilo principal de la aplicacion, Bloqueando el Programa
            Thread.Sleep(6000);

            // Duerme Tareas de forma asincrona. Sin bloquear el programa
            Task.Delay(10000);
            
            cts.Cancel();
            Console.WriteLine("------------------------------------------Cancelando");
            Thread.Sleep(2500);
            cts.Dispose();

            return;

            Action a;
            // Crear una referencia a la tarea.
            Task t1 = new Task(new Action(Method1));

            // Ejecutar una tarea
            t1.Start();

            // Esperar para que una tarea termine
            t1.Wait();

            var contenedorT = Task.Run(new Action(Method1));


            Func<int, int, string> f;
            f = ((z, b) => { return "Hola"; });

            Task<string> t2 = Task.Run(() => f(2, 3));
            t2.Wait();
            var r1 = t2.Result;

            

            using (var db = new DataContext("SQLite"))
            {
                // Agregar
                Lista l = new Lista()
                {
                    ListaId = Guid.NewGuid(),
                    Nombre = Path.GetRandomFileName() + " Clase",
                };

                db.Listas.Add(l);

                db.SaveChanges();

                Console.WriteLine("Agregar:");
                foreach (var y in db.Listas)
                {
                    Console.WriteLine(y.Nombre);
                }

                // Modificar
                Tarea t = new Tarea()
                {
                    TareaId = Guid.NewGuid(),
                    ListaId = l.ListaId,
                    Descripcion = "Hola Mundo",
                };
                l.Nombre += "Modificado";
                l.Tareas = new List<Tarea>();
                l.Tareas.Add(t);

                db.SaveChanges();
                Console.WriteLine("Modificar:");
                foreach (var y in db.Listas)
                {
                    if (y.Tareas != null)
                        Console.WriteLine(y.Nombre + y.Tareas.Count());
                    else
                        Console.WriteLine(y.Nombre);
                }

                // Borrar
                var aBorrar = db.Listas.FirstOrDefault();
                db.Listas.Remove(aBorrar);

                db.SaveChanges();
                Console.WriteLine("Borrar:");
                foreach (var y in db.Listas)
                {
                    Console.WriteLine(y.Nombre);
                }

                foreach (var y in db.Tareas)
                {
                    Console.WriteLine($"{y.TareaId}------" + y.Descripcion);
                }
            }

        }

        static void LinqBasics()
        {
            using (var db = new DataContext("SQLite"))
            {
                // Recuperar objeto simple
                var query = from lista in db.Listas
                            where lista.Nombre.Contains("o") || lista.Nombre.Contains("c")
                            select lista;

                // Recuperar tipo de datos dinamico (Anonimo)
                var query2 = from lista in db.Listas
                             select new { Moises = lista.Nombre, Dato = lista.ListaId };

                // Personalizar el Select
                var query3 = from lista in db.Listas
                             select new Tarea() { Descripcion = lista.Nombre, TareaId = Guid.NewGuid() };

                // Igual al query 1
                var query4 = db.Listas.Where(lista => lista.Nombre.Contains("o") || lista.Nombre.Contains("c"));

                foreach (var l in query2.ToArray())
                {
                    Console.WriteLine($"{l.Moises} --- {l.Dato}");
                }
            }
        }
        static void DatabaseManualProvider()
        {
            List<string> proveedores = new List<string>()
            {
                "SQLServer",
                "SQLite"
            };

            foreach (var proveedor in proveedores)
            {
                Console.WriteLine("Database Provider:" + proveedor);
                // Apunta a SQLite
                using (var db = new DataContext(proveedor))
                {
                    db.Listas.Add(
                        new Lista()
                        {
                            ListaId = Guid.NewGuid(),
                            Nombre = Path.GetRandomFileName() + "Lista",
                        }
                    );
                    db.SaveChanges();

                    foreach (var lista in db.Listas)
                    {
                        Console.WriteLine(lista.Nombre);
                    }
                }
            }
        }
    }
}
