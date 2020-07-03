using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tarea5.Entidades
{
    public class Contactos
    {
        [Key]
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefonos { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

        public Contactos()
        {
            Id = 0;
            Nombre = string.Empty;
            Apellidos = string.Empty;
            Telefonos = string.Empty;
            Direccion = string.Empty;
            Correo = string.Empty;
        }
    }
}
