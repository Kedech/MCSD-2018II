using System;

namespace Clase_2
{
    public abstract class Comida
    {
        public string Nombre {get;set;}
        public float Temperatura {get;set;}

        public string[] Ingredientes {get;set;}
    }

    public class Liquida : Comida {
        public float PuntoDeEvaporacion {get;set;}
        public float PuntoDeCongelacion {get;set;}
    }

    public class Fisica : Comida {
        public float PuntoDeQueme {get;set;}
        public float PuntoDeDorado {get;set;}
    }

    public class Menu {
        public Fisica[] ComidasFisicas {get;set;}
        public Liquida[] ComidasLiquidas{get;set;}
    }

    public class MenuSelecto<T> where T : Comida {
        public T[] Comidas {get;set;}

        public void MostrarMenu (){
            foreach(var c in Comidas){
                Console.WriteLine(c.Nombre);
            }
        }
    }
}