using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OldLot.Web.ViewModels
{
    public class FabricanteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Display(Name = "Veiculos")]
        [Editable(false)]
        public int NumeroVeiculos { get; set; }
    }
}