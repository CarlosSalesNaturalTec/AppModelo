using System.Collections.Generic;
using System.Linq;
using AppModelo.Services.Models;

namespace AppModelo.Services.AppService
{
    public class PacienteService
    {
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
    }
}
