// Librerias externas
using System;

// Categorizar / Segmentar su codigo
namespace Demo1
{
    public struct CarroPorValor
    {

        private string tipo;
        
        public string Tipo 
        {
            get 
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }
        int NumeroLlantas {get ; set;}
        string Placa {get;set;}

        int NumeroMotores {get ; set;}
    }
    // Representacion de un objeto
    public class Program
    {
        public const string ID = "MOCH";

        public event EventHandler Click;

        // Metodo
        public static void Main(string[] args)
        {
            // EjemplosTipoPorValor();
            /*
                EjemploTiposPorReferencia(); 
            */          
            //EjemploTiposPorStructuraValor();
            //EjemploStaticVsNonStatic();
            EjemploReadOnlyVsConst();
            Click += new EventHandler(EjemploReadOnlyVsConst);
            Click -= new EventHandler(EjemploReadOnlyVsConst);
            DateTime d = new DateTime(); // Es un Struct
        }

        public static void EjemploReadOnlyVsConst(){
            Console.WriteLine("-------Ejemplo ReadOnly Vs Const");            
            var carro = new Carro("Asigne un valor en ReadOnly solo por su constructor");
            // ID = "Hey"; // Genera un error
            Console.WriteLine(carro.marca);
            Console.WriteLine(ID);
        }

        public static void EjemploStaticVsNonStatic(){
            Console.WriteLine("-------Ejemplo Tipo Static vs Non-Static");
            // Ejemplo de Elementos estaticos
            Carro.Manejar();
            // Carro.MiNombre(); // Esto es un error
            Carro c = new Carro();
            c.Tipo = "Hola coloque el tipo";
            c.MiNombre();

        }
        public static void EjemploTiposPorStructuraValor(){
            Console.WriteLine("---Tipos por Refencia---");
            CarroPorValor c1 = new CarroPorValor() 
            {
                Tipo = "Soy el Carro 1"
            };
            CarroPorValor c2 = c1;
            
            Console.WriteLine($"Valor1:{c1.Tipo}");
            Console.WriteLine($"Valor2:{c2.Tipo}");
            c2.Tipo = "Ahora Soy el Carro 2";
            Console.WriteLine($"Valor1:{c1.Tipo}");
            Console.WriteLine($"Valor2:{c2.Tipo}");
            c2 = new CarroPorValor() 
            {
                Tipo = "Soy Otro Carro"
            };
            Console.WriteLine($"Valor1:{c1.Tipo}");
            Console.WriteLine($"Valor2:{c2.Tipo}");
        }
        public static void EjemploTiposPorReferencia(){
            Console.WriteLine("---Tipos por Refencia---");
            Carro c1 = new Carro() 
            {
                Tipo = "Soy el Carro 1"
            };
            Carro c2 = c1;
            
            Console.WriteLine($"Valor1:{c1.Tipo}");
            Console.WriteLine($"Valor2:{c2.Tipo}");
            c2.Tipo = "Ahora Soy el Carro 2";
            Console.WriteLine($"Valor1:{c1.Tipo}");
            Console.WriteLine($"Valor2:{c2.Tipo}");
            c2 = new Carro() 
            {
                Tipo = "Soy Otro Carro"
            };
            Console.WriteLine($"Valor1:{c1.Tipo}");
            Console.WriteLine($"Valor2:{c2.Tipo}");
        }

        public static void EjemplosTipoPorValor()
        {
            // Tipos por valor enteros
            Console.WriteLine("---Tipos por Valor Numeros---");
            int valor1 = 10;
            int valor2 = valor1;
            Console.WriteLine($"Valor1:{valor1}");
            Console.WriteLine($"Valor2:{valor2}");
            valor2 = 5;
            Console.WriteLine($"Valor1:{valor1}");
            Console.WriteLine($"Valor2:{valor2}");

            Console.WriteLine("---Tipos por Valor Strings---");
            string s1 = "10";
            string s2 = s1;
            Console.WriteLine($"Valor1:{s1}");
            Console.WriteLine($"Valor2:{s2}");
            s2 = "5";
            Console.WriteLine($"Valor1:{s1}");
            Console.WriteLine($"Valor2:{s2}");
        }
    }

    public class Vehiculo 
    {
        public string tipo;
        
        public string Tipo 
        {
            get 
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }

        public int Puertas {get;set;}

        protected string TipoCombustible {get;set;}
        int CantidadCombustigle {get;set;}
        decimal Precio {get;set;}
        int CantidadAsientos {get;set;}
        decimal Aceleracion {get;set;}
        string[] Piloto {get;set;}
        string Modelo {get;set;}
        int NumeroMotores {get;set;}

        public void Acelerar (int a, int b){
            return ;
        }
    }

    public class Carro : Vehiculo {
        public Carro()
        {

        }
        public Carro(string valor)
        {
            marca = valor;
        }
        public readonly string marca;
        public string Marca 
        {
            get {
                return marca;
                }
        
            set
            {
                // Esto genera un error de compilacion
                // marca = value;
            }
        }
        int NumeroLlantas {get ; set;}
        string Placa {get;set;}

        int NumeroMotores {get ; set;}
        public static void Manejar(){
            Console.WriteLine("Estoy Manejando");
        }
        public void MiNombre(){
            Console.WriteLine(Tipo);
        }
    }

    class Avion: Vehiculo {
        int NumeroLlantas {get;set;}
        int NumeroAlas {get; set;}
        string Helice {get;set;}
        string Barometro {get;set;}
        string Altimetro {get;set;}

    }

    class Barco : Vehiculo {
        string MaterialProa {get;set;}
        int NumeroVelas {get;set;}
        string TipoMotor {get;set;}
        string TipoDeHelice {get;set;}
        int BotesEmergencia {get;set;}
    }
}
