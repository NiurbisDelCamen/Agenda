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
    public class EventosBLL
    {
        public static bool Guardar(Eventos eventos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Eventos.Add(eventos) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;

        }

        public static bool Modificar(Eventos eventos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(eventos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
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
                var eliminar = db.Eventos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Eventos Buscar(int id)
        {
            Contexto db = new Contexto();
            Eventos eventos = new Eventos();
            try
            {
                eventos = db.Eventos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return eventos;
        }

        public static List<Eventos> GetList(Expression<Func<Eventos, bool>> eventos)
        {
            List<Eventos> Lista = new List<Eventos>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Eventos.Where(eventos).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }

    }
}
