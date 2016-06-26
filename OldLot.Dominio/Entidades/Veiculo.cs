using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Dominio.Entidades
{
    public class Veiculo : EntidadeBase
    {
        public int Ano { get; set; }

        public virtual Fabricante Fabricante { get; set; }
    }
}
