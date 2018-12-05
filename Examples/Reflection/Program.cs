using System;
using System.Reflection;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.All)]
    class CustomLogAttribute : Attribute
    {
        public string Message { get; set; }
        public CustomLogAttribute(string message)
        {
            Message = message;
        }
    }



    [CustomLog("TestMethod tiene datos")]
    class ReflextionClass
    {
        public void TestMethod()
        {
            Console.WriteLine("Invocamos el metodo");
        }

        [CustomLog("Reflection Program se ejecuto")]
        public void ReflectionProgram()
        {

            // Carga de un ensamblado en la carpeta
            // WebServerProj.dll

            Console.WriteLine("Leyendo el ensamblado WebServerProj.dll");
            try
            {
                Assembly webServerAssembly = Assembly.LoadFrom("WebServerProj.dll");

                // Revisar tipos de datos
                var iterator = 0;
                foreach (var t in webServerAssembly.GetTypes())
                {
                    Console.WriteLine($"{iterator}-{t.FullName}");
                    iterator++;
                }
                var index = -1;
                while (index < 0 || index >= webServerAssembly.GetTypes().Length)
                {
                    Program.RecibirInput(ref index);
                }

                Type type = webServerAssembly.GetTypes()[index];

                Console.WriteLine($"Selecciono el tipo {type.FullName}");

                Console.WriteLine("----Constructores------");
                foreach (ConstructorInfo constructor in type.GetConstructors())
                {
                    Console.WriteLine($"--{constructor.Name}--");
                }

                Console.WriteLine("----Fields------");
                foreach (var constructor in type.GetFields())
                {
                    Console.WriteLine($"--{constructor.Name}--");
                }

                Console.WriteLine("----Properties------");
                foreach (var constructor in type.GetProperties())
                {
                    Console.WriteLine($"--{constructor.Name}--");
                }

                Console.WriteLine("----Meethods------");
                iterator = 0;
                foreach (var constructor in type.GetMethods())
                {
                    Console.WriteLine($"{iterator}-{constructor.Name}--");
                    iterator++;
                }

                var indexMethods = -1;
                while (indexMethods < 0 || indexMethods >= type.GetMethods().Length)
                {
                    Program.RecibirInput(ref indexMethods);
                }

                var objectToInstance = webServerAssembly.CreateInstance(type.FullName, false);
                var methodToInvoke = type.GetMethods()[indexMethods];
                Console.WriteLine(methodToInvoke.Name);
                var resultado = methodToInvoke.Invoke(objectToInstance, null);

                //var pm = typeof(ReflextionClass).GetMethod("TestMethod");
                //var r = pm.Invoke(this, null);
                //Console.WriteLine(r);

                foreach (var constructor in type.GetProperties())
                {
                    Console.WriteLine($"{iterator}-{constructor.Name}--");
                    iterator++;
                }

                var setProperty = type.GetProperty("SetProperty");
                Console.WriteLine("Escribe un valor");
                setProperty.SetValue(objectToInstance, Console.ReadLine());

                Console.WriteLine(setProperty.GetValue(objectToInstance));




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
    class Program
    {
        public static void RecibirInput(ref int value)
        {
            try
            {
                value = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Elija un Numero");
            }
        }
        static void Main(string[] args)
        {
            var cl = new ReflextionClass();

            object[] attrs = cl.GetType().GetCustomAttributes(true);
            foreach (Attribute attr in attrs)
            {
                Console.WriteLine(attr);
            }

            //cl.ReflectionProgram();
            Console.ReadLine();
        }
    }
}
