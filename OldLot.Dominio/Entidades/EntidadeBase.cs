using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Dominio.Entidades
{
    public class EntidadeBase<T> where T : struct
    {
        public T Id { get; set; }
    }
}
