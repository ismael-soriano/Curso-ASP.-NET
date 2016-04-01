using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericos
{
    public class Factura: EntityBase<Factura>
    {
        public DateTime Date { get; set; }
        public Cliente Cliente { get; set; }
    }
}
