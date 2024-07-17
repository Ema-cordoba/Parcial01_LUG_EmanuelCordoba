using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECliente : Entidad
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }

        public List<BECalefactor> ListaCalefactores;

        public override string ToString()
        {
            return Nombre + " " + Apellido + " " + DNI;
        }
    }
}
