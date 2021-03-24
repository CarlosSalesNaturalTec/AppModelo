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

        public IEnumerable<Paciente> GetAllByNome(string Nome)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                return (from n in context.Paciente where n.Nome.Contains(Nome) orderby n.Nome select n).ToList();
            }
        }

        public IEnumerable<Paciente> GetAllByCartaoSUS(string cartaoSUS)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                return (from n in context.Paciente where n.CartaoSUS.Contains(cartaoSUS) orderby n.Nome select n).ToList();
            }
        }

        public Paciente Create(Paciente paciente)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                context.Paciente.Add(paciente);
                context.SaveChanges();
                return paciente;
            }
        }

        public Paciente Edit(Paciente paciente)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                context.Entry(paciente).State = EntityState.Modified;
                context.SaveChanges();
                return paciente;
            }
        }

        public Paciente Delete(Paciente paciente)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                context.Entry(paciente).State = EntityState.Deleted;
                context.SaveChanges();
                return paciente;
            }
        }
    }
}
