﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Dominio.Entidades
{
    public class Fabricante : EntidadeBase
    {
        public virtual IEnumerable<Veiculo> Veiculos { get; set; }
    }
}
