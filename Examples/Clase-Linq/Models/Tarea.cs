using System;

namespace Clase_Linq.Models
{
    public class Tarea
    {
        public Guid TareaId { get; set; }
        public Guid ListaId { get; set; }
        public string Descripcion { get; set; }

        // Los objetos que referencia algun padre, necesitan una propiedad
        // para representarlos.
        public Lista ListaPadre { get; set; }
    }
}