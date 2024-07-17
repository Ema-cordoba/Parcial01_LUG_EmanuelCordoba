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
    public class BLLCliente : IGestor<BECliente>
    {
        public BLLCliente() { oMPPCliente = new MPPCliente(); }

        MPPCliente oMPPCliente;


        public int ObtenerDescuentosCalElectrico(BECliente oBECliente, decimal precioUnitario)
        {
            decimal TotalCalElec = 0;
            decimal calculoDes = 0; 
           
            if (oBECliente.ListaCalefactores != null)
            {
                foreach (BECalefactor obj in oBECliente.ListaCalefactores)
                {
                    if (obj is BECalefactorElectrico)
                    {
                        TotalCalElec =  obj.Cantidad * precioUnitario;

                        if (TotalCalElec > obj.Cantidad)
                        {
                            calculoDes = TotalCalElec * 0.25m;
                            TotalCalElec = TotalCalElec - calculoDes;
                        }
                    }
                }
                return Convert.ToInt32( TotalCalElec);
            }
            else
            {
                return 0;
            }
        }


        public int ObtenerDescuentosCalGas(BECliente oBECliente, decimal precioUnitario)
        {
            decimal TotalCalElec = 0;
            decimal calculoDes = 0;

            if (oBECliente.ListaCalefactores != null)
            {
                foreach (BECalefactor obj in oBECliente.ListaCalefactores)
                {
                    if (obj is BECalefactorGas)
                    {
                        TotalCalElec = obj.Cantidad * precioUnitario;

                        if (TotalCalElec > obj.Cantidad)
                        {
                            calculoDes = TotalCalElec * 0.25m;
                            TotalCalElec = TotalCalElec - calculoDes;
                        }
                    }
                }
                return Convert.ToInt32(TotalCalElec);
            }
            else
            {
                return 0;
            }
        }

        public bool Borrar(BECliente objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BECliente objeto)
        {
            throw new NotImplementedException();
        }

        public List<BECliente> ListarTodo()
        {
            return oMPPCliente.ListarTodo();
        }
    }
}
