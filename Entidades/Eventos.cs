using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tarea5.Entidades
{
    public class Eventos
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public Eventos()
        {
            Id = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
        }
    }
}
