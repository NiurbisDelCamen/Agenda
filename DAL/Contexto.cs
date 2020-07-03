using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tarea5.Entidades;

namespace Tarea5.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Contactos> Contactos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Agenda.db");
        }
    }
}
