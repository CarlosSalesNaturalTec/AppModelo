using System.Collections.Generic;
using System.Linq;
using AppModelo.Services.Models;

namespace AppModelo.Services.AppService
{
    public class PacienteService
    {
        public IList<Paciente> GetAllByNome(string Nome)
        {
            using (AppModeloEntities context = new AppModeloEntities())
            {
                return (from n in context.Paciente where n.Nome.Contains(Nome) orderby n.Nome select n).ToList();
            }
        }
    }
}
