using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AppModelo.Services.Models;

namespace AppModelo.Services.AppService
{
    public class PacienteService
    {
        public Paciente GetByID(int? id)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                return (from n in context.Paciente where n.Id == id select n).SingleOrDefault();
            }
        }
        public IEnumerable<Paciente> GetAll()
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                return (from n in context.Paciente orderby n.Nome select n).ToList();
            }
        }

        public IEnumerable<Paciente> GetAllByID(int id)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                return (from n in context.Paciente where n.Id == id select n).ToList();
            }
        }

        public IEnumerable<Paciente> GetAllByNome(string str)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                return (from n in context.Paciente where n.Nome.Contains(str) orderby n.Nome select n).ToList();
            }
        }

        public IEnumerable<Paciente> GetAllByCartaoSUS(string str)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                return (from n in context.Paciente where n.CartaoSUS.Contains(str) orderby n.Nome select n).ToList();
            }
        }

        public Paciente Create(Paciente obj)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                context.Paciente.Add(obj);
                context.SaveChanges();
                return obj;
            }
        }

        public Paciente Edit(Paciente obj)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
                return obj;
            }
        }

        public Paciente Delete(Paciente obj)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                context.Entry(obj).State = EntityState.Deleted;
                context.SaveChanges();
                return obj;
            }
        }
    }
}
