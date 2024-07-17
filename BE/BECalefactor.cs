using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;


namespace BE
{
    public abstract class BECalefactor : Entidad
    {
        public string Nombre { get; set; }
        public int Calorias { get; set; }
        public string Modelo { get; set; }
        public int Cantidad { get; set; }
        public BEProveedor Proveedor { get; set; }


    }
}
