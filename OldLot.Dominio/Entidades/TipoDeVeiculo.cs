using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Dominio.Entidades
{
    public class TipoDeVeiculo : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public string Habilidades { get; set; }
    }
}
