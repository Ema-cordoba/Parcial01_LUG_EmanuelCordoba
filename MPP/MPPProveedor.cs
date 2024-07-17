using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPProveedor : IGestor<BEProveedor>
    {
        public MPPProveedor() { oDatos = new Acceso(); }

        Acceso oDatos;

        public bool Borrar(BEProveedor objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEProveedor oBEProveedor)
        {
            string Consulta = "Insert Into Proveedor(RazonSocial, CUIT) values ('" + oBEProveedor.RazonSocial + "', '" + oBEProveedor.CUIT + "')";
            return oDatos.Escribir(Consulta);
        }

        public List<BEProveedor> ListarTodo()
        {
            List<BEProveedor> ListaProveedores = new List<BEProveedor>();
            string Consulta = "Select Codigo, RazonSocial, CUIT from PROVEEDOR";
            DataTable DTable = oDatos.Leer(Consulta);
            if (DTable.Rows.Count >= 0)
            {
                foreach (DataRow row in DTable.Rows)
                {
                    BEProveedor oBEProveedor = new BEProveedor();
                    oBEProveedor.Codigo = Convert.ToInt32(row["Codigo"]);
                    oBEProveedor.RazonSocial = Convert.ToString(row["RazonSocial"]);
                    oBEProveedor.CUIT = Convert.ToInt32(row["CUIT"]);
                    ListaProveedores.Add(oBEProveedor);
                }
            }
            return ListaProveedores;
        }
    }
}
