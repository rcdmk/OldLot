using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Dominio.Entidades
{
    public class TipoDeVeiculo : EntidadeBase
    {
        public string Habilidades { get; set; }

        public virtual IEnumerable<Veiculo> Veiculos { get; set; }
    }
}
