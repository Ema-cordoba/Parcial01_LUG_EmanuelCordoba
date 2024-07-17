using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using MPP;

namespace BLL
{
    public class BLLCalefactorGas : BLLCalefactor, IGestor<BECalefactorGas>
    {

        public BLLCalefactorGas() 
        {
            oMPPCalGas = new MPPCalefactorGas();
        }

        MPPCalefactorGas oMPPCalGas;

        public bool Borrar(BECalefactorGas oBECalefactorGas)
        {
            return oMPPCalGas.Borrar(oBECalefactorGas);
        }

        public bool Guardar(BECalefactorGas oBECalefactorGas)
        {
            return oMPPCalGas.Guardar(oBECalefactorGas);
        }

        public List<BECalefactorGas> ListarTodo()
        {
            return oMPPCalGas.ListarTodo();
        }

        public bool GuardarCalefactor_Cliente(BECliente oBECliente, BECalefactorGas oBECalefactorGas)
        {
            return oMPPCalGas.GuardarCalefactor_Cliente(oBECliente, oBECalefactorGas);
        }
    }
}
