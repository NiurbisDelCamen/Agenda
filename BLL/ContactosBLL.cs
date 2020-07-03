using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tarea5.DAL;
using Tarea5.Entidades;

namespace Tarea5.BLL
{
    public class ContactosBLL
    {
        public static bool Guardar(Contactos contactos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Contactos.Add(contactos) != null)
                    paso = db.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
            
        }
        public static bool Modificar(Contactos contactos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(contactos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Contactos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static Contactos Buscar(int id)
        {
            Contexto db = new Contexto();
            Contactos contactos = new Contactos();
            try
            {
                contactos = db.Contactos.Find(id);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return contactos;
        }

        public static List<Contactos> GetList(Expression<Func<Contactos, bool>> contactos)
        {
            List<Contactos> Lista = new List<Contactos>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Contactos.Where(contactos).ToList();
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}
