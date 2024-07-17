using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLProveedor : IGestor<BEProveedor>
    {

        public BLLProveedor() 
        {
            oMPPProveedor = new MPPProveedor();
        }

        MPPProveedor oMPPProveedor;

        public bool Borrar(BEProveedor objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEProveedor oBEProveedor)
        {
            return oMPPProveedor.Guardar(oBEProveedor);
        }

        public List<BEProveedor> ListarTodo()
        {
            return oMPPProveedor.ListarTodo();
        }
    }
}
