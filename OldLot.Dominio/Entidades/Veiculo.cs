using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Dominio.Entidades
{
    public class Veiculo : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public int Ano { get; set; }

        public virtual Fabricante Fabricante { get; set; }
    }
}
