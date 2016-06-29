using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OldLot.Web.ViewModels
{
    public class VeiculoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        [Display(Name = "Fabricante")]
        public int IdFabricante { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public int IdTipoDeVeiculo { get; set; }

        [Editable(false)]
        public string Fabricante { get; set; }

        [Editable(false)]
        public string Tipo { get; set; }
    }
}