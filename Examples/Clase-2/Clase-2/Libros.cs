using System;

namespace Clase_2{
    public class Libros {
        private Libro[] libros = new Libro[100];
        public string Autor {get;set;}
        public int Volumenes {get;set;}

        public Libro[] LibrosComun {get {return libros;} set {libros = value;}}

        public Libro this[int i]{
            get{return libros[i];}
            set{libros[i] = value;}
        }
    }   

    public class Libro {
        public string Nombre {get;set;}
    }
}