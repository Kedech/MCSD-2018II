using System;
using System.Collections.Generic;

namespace Clase_Linq.Models
{
    public class Lista
    {
        public Guid ListaId { get; set; }
        public string Nombre { get; set; }
        public List<Tarea> Tareas { get; set; }
    }
}