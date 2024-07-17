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
    public class BLLCalefactorElectrico : BLLCalefactor , IGestor<BECalefactorElectrico>
    {
        public BLLCalefactorElectrico() { oMPPCElectrico = new MPPCalefactorElectrico(); }

        MPPCalefactorElectrico oMPPCElectrico;

        public bool Borrar(BECalefactorElectrico oBECalefactorElectrico)
        {
            return oMPPCElectrico.Borrar(oBECalefactorElectrico);
        }

        public bool Guardar(BECalefactorElectrico oBECalefactorElectrico)
        {
            return oMPPCElectrico.Guardar(oBECalefactorElectrico);
        }

        public List<BECalefactorElectrico> ListarTodo()
        {
            return oMPPCElectrico.ListarTodo();
        }

        public bool GuardarCalefactor_Cliente(BECliente oBECliente, BECalefactorElectrico oBECalefactorElectrico)
        {
            return oMPPCElectrico.GuardarCalefactor_Cliente(oBECliente, oBECalefactorElectrico);
        }

    }
}
