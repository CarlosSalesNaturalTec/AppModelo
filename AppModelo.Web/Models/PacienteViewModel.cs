using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppModelo.Web.Models
{
    public class PacienteViewModel
    {
        [Display(Name = "ID do Paciente")]
        public int ID { get; set; }

        [Display(Name = "Nome do Paciente")]
        public string Nome { get; set; }

        [Display(Name = "Numero do Cartão SUS")]
        public string CartaoSUS { get; set; }
    }
}