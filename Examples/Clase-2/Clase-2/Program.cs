using System;
using System.Collections;
using System.Collections.Generic;
namespace Clase_2
{
    public abstract class Simbolo
    {
        public string Letra { get; set; }
    }

    public abstract class NumericalValue
    {

    }
    public class A : Simbolo
    {
        public int Orden { get; set; }
    }

    public class Numero1<T> : Simbolo where T : Simbolo
    {
        public T X { get; set; }
        public int Valor { get; set; }
    }

    public class ExcepcionEspecial : Exception{

    }

    class Program
    {
        static int[] Notas { get; set; }

        static void Main(string[] args){
            var a = 1;
            var b = 0;
            // Exception no es un Error. 
            //int division0 = a/b;

            var array = new int[10];
            //array[-1] = 10;
            //array[100] = 10;

            Libro nullValue = null;
            //nullValue.Nombre = "Hola";

            Exception ex = new Exception();
           // throw new ExcepcionEspecial();

            try {
                //int division = a/b;      
                //throw new Exception("0001-Hola Mundo");
            }
            catch(DivideByZeroException exx)
            {
                Console.WriteLine(exx.Message);          
            }
            catch (Exception exxx){
                Console.WriteLine(exxx.Message);
            }
            finally{
                Console.WriteLine("Se hace indiferentemente");
            }
            Console.WriteLine("El programa se ejecuto");
        }

        static void Iterators(string[] args)
        {
            foreach (var x in Numeros())
            {
                Console.WriteLine(x);
            }

            // Iterador facilita el uso de Foreach y LINQ
            // trabaja con Yield. Yield retorna valores de forma independiente y mantiene el indice activo.
            foreach (var y in NumerosYield())
            {
                Console.WriteLine(y);
            }

            try
            {
                Console.WriteLine("Ejemplo con Yield");
                foreach (var x in NumerosCondicionalYield())
                {
                    Console.WriteLine(x);
                }
            }
            catch (Exception ex)
            {

            }

            try
            {

                Console.WriteLine("Ejemplo sin Yield");
                foreach (var y in NumerosCondicional())
                {
                    Console.WriteLine(y);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static int[] Numeros()
        {
            int a = 1;
            int b = 5;
            int c = 10;
            int[] numbers = new int[3] { a, b, c };
            return numbers;
        }

        public static IEnumerable NumerosYield()
        {
            yield return 1;
            yield return 5;
            yield return 10;
        }

        public static IEnumerable NumerosCondicional()
        {
            List<int> numeros = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<int> numerosMostrar = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                if (numeros[i] % 3 == 0)
                {
                    numerosMostrar.Add(numeros[i]);
                }
                if (numeros[i] == 11)
                {
                    throw new Exception();
                }
            }
            return numerosMostrar;
        }

        public static IEnumerable NumerosCondicionalYield()
        {
            List<int> numeros = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            for (int i = 0; i < 15; i++)
            {
                if (numeros[i] % 3 == 0)
                {
                    yield return numeros[i];
                }
                if (numeros[i] == 11)
                {
                    throw new Exception();
                }
            }
        }

        static void Indexers(string[] args)
        {
            var libros = new Libros();
            libros.Autor = "Moises";
            libros.Volumenes = 1;
            libros.LibrosComun = new Libro[100];
            libros.LibrosComun[0] = new Libro();
            libros.LibrosComun[0].Nombre = "HP";

            Console.WriteLine(libros[0].Nombre);
        }
        static void EstructurasDeControl(string[] args)
        {
            // Estructura de control Condicionales
            // IF 
            if (true)
            {

            }
            if (2 == 3)
            {
                // No se ejecuta esta linea porque 2 no puede ser igual a 3. 
            }
            bool condicion = "Hola" == "Hola";
            bool igualdad = "Derecha Igual a Izquierda" == "Derecha Igual a Izquierda";
            bool and = true && true;  // Todos los elementos de la comparacion son verdaderos
            bool or = true || false; // Cuando alguno de los elementos es verdad
            bool negate = !true;
            if (condicion)
            {

            }

            if (true)
            {

            }
            else if (true)
            {

            }
            else
            {

            }

            // Switch Case
            // Toma un valor y lo evalua para diferentes casos, funciona con tipos primitivos y enumeraciones
            int num = 10;
            switch (num)
            {
                case 1:
                    // ejecuta estas lineas
                    break;
                case 5:
                    goto case 1;
                    // ejecuta estas lineas
                    break;
                default:
                    break;
            }

        Punto1:
            Console.WriteLine("Hey");

            Frutas en = Frutas.Fresa;
            goto Punto1;
            switch (en)
            {
                case Frutas.Manzana:
                    //ejecuta esto
                    break;
                case Frutas.Sandia:
                    break;
            }


            // Estructura de Iteracion
            string s = "0";
            //do
            //{
            //Console.Write("Elije una opcion");
            //s = Console.ReadLine();
            //}
            //while (s != "99"); // Nunca hagan while true, nunca termina.

            //while (s == "99")
            //{
            //Console.WriteLine("Se ejecuta si la condicion es verdad");
            //}

            // For
            for (int i = 0; i < 100; i += 10)
            {
                Console.WriteLine($"{i}");
            }

            Menu m = new Menu();
            m.ComidasFisicas = new Fisica[2];
            m.ComidasFisicas[0] = new Fisica();
            m.ComidasFisicas[0].Nombre = "Tamal";
            m.ComidasFisicas[1] = new Fisica();
            m.ComidasFisicas[1].Nombre = "Enchilada";

            foreach (var l in m.ComidasFisicas)
            {
                Console.WriteLine(l.Nombre);
                break;// Rompe un Ciclo. 
                continue; // Funciona en los For, 
                return;
                throw new Exception();

            }
        }

        public static void Generics()
        {
            ArrayList coleccion = new ArrayList();
            coleccion.Add("Hola");
            coleccion.Add(1);
            coleccion.Add(true);
            coleccion.Add(new Libros());
            foreach (var y in coleccion){
                var z = y as string;
            }

            List<string> lista = new List<string>();
            lista.Add("Hola");
            foreach(var l in lista){
                var z = l.Length;
            }

            Menu m = new Menu();
            m.ComidasFisicas = new Fisica[2];
            m.ComidasFisicas[0].Nombre = "Tamal";
            m.ComidasFisicas[0].Nombre = "Enchilada";
            foreach (var l in m.ComidasFisicas)
            {
                Console.WriteLine(l.Nombre);
            }
            foreach (var l in m.ComidasLiquidas)
            {
                Console.WriteLine(l.Nombre);
            }

            List<string> lista = new List<string>();
            MenuSelecto<Fisica> m1 = new MenuSelecto<Fisica>();
            m1.Comidas = new Fisica[2];
            MenuSelecto<Liquida> m2 = new MenuSelecto<Liquida>();
            m2.Comidas = new Liquida[2];
        }

        public static T MostrarDatos<T>(T parametro)
        {
            return parametro;
        }

        public static void Arrays()
        {
            Notas = new int[6];
            Notas[0] = 1245;
            // Notas[-1] = 123;//esto falla
            Notas[6] = 123;// esto tambien falla.
                           // Arreglo de una dimension
            Frutas[] HolaFrutas = new Frutas[10];
            DateTime[] tiempos = new DateTime[100];
            Notas = new int[8];
            //  Arreglo Multidimensional
            Clima[,,,,] matriz = new Clima[6, 4, 2, 2, 5];

            // Jagged Array
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[5];
            jaggedArray[0][1] = 2;
            jaggedArray[1] = new int[10];
            jaggedArray[1][1] = 30000;
        }
        public static void MostrarFrutas()
        {
            Frutas val = (Frutas)5;
            Frutas vel = Frutas.Mora;
            Console.WriteLine($"Val:{val}");
            Console.WriteLine($"Vel:{(int)vel}");
        }
    }



    // Es un tipo de datos, que representa de forma ordenada elementos en base a numeros.
    enum Frutas
    {
        Manzana, Mora, Fresa, Tomate, Pera, Melon, Sandia, Banana
    }

    enum Genero
    {
        Masculino = 3, Femenino = 5
    }

    enum Clima
    {
        Soleado, Lluvioso, Humedo, Seco, Nublado
    }
    enum Status
    {
        SinProblema, Dudas, Alerta, Peligro, Caos
    }
}
