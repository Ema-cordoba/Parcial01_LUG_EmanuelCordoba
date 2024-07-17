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
    public class MPPCalefactorGas : IGestor<BECalefactorGas>
    {
        public MPPCalefactorGas()
        {
            oDatos = new Acceso();
        }

        Acceso oDatos;

        public bool Borrar(BECalefactorGas oBECalefactorGas)
        {
            string Consulta = "Delete from CALEFACTOR where Codigo = '" + oBECalefactorGas.Codigo + "'";
            return oDatos.Escribir(Consulta);
        }

        public bool Guardar(BECalefactorGas oBECalefactorGas)
        {
            string Consulta = string.Empty;
            if (oBECalefactorGas.Codigo == 0)
            {
                Consulta = "Insert Into CALEFACTOR(Nombre, Calorias, Modelo, Cantidad,TiroBalanceado, CodProveedor) Values('" + oBECalefactorGas.Nombre + "', '" + oBECalefactorGas.Calorias + "', '" + oBECalefactorGas.Modelo + "', '" + oBECalefactorGas.Cantidad + "', '" + oBECalefactorGas.TiroBalanceado + "', '" + oBECalefactorGas.Proveedor + "')";
            }
            else
            {
                Consulta = "Update CALEFACTOR Set Nombre = '" + oBECalefactorGas.Nombre + "', Calorias = '" + oBECalefactorGas.Calorias + "', Modelo = '" + oBECalefactorGas.Modelo + "', Cantidad = '" + oBECalefactorGas.Cantidad + "', Eficiencia = '" + oBECalefactorGas.TiroBalanceado + "', CodProveedor = '" + oBECalefactorGas.Proveedor + "' Where Codigo = '" + oBECalefactorGas.Codigo + "'";
            }
            return oDatos.Escribir(Consulta);
        }

        public List<BECalefactorGas> ListarTodo()
        {
            List<BECalefactorGas> ListaCalefactorGas = new List<BECalefactorGas>();
            string Consulta = "Select Codigo, Nombre , Calorias , Modelo , Cantidad TiroBalanceado from CALEFACTOR, PROVEEDOR where CALEFACTOR.Eficiencia is NULL and PROVEEDOR.Codigo = CALEFACTOR.CodProveedor";
            DataTable DTable = oDatos.Leer(Consulta);
            if (DTable.Rows.Count >= 1)
            {
                foreach (DataRow row in DTable.Rows)
                {
                    BECalefactorGas oBECalefactorGas = new BECalefactorGas();
                    oBECalefactorGas.Codigo = Convert.ToInt32(row["Codigo"]);
                    oBECalefactorGas.Nombre = Convert.ToString(row["Nombre"]);
                    oBECalefactorGas.Calorias = Convert.ToInt32(row["Calorias"]);
                    oBECalefactorGas.Modelo = Convert.ToString(row["Modelo"]);
                    oBECalefactorGas.Cantidad = Convert.ToInt32(row["Cantidad"]);
                    oBECalefactorGas.TiroBalanceado = Convert.ToByte(row["TiroBalanceado"]);

                    BEProveedor oBEProveedor = new BEProveedor();
                    oBEProveedor.Codigo = Convert.ToInt32(row["CodProveedor"]);
                    oBEProveedor.RazonSocial = Convert.ToString(row["RazonSocial"]);
                    oBEProveedor.CUIT = Convert.ToInt32(row["CUIT"]);
                    oBECalefactorGas.Proveedor = oBEProveedor;
                    ListaCalefactorGas.Add(oBECalefactorGas);
                }
            }
            return ListaCalefactorGas;
        }


        public bool GuardarCalefactor_Cliente(BECliente oBECliente, BECalefactorGas oBECalefactorGas)
        {
            if (oBECalefactorGas.Codigo != 0 && oBECliente.Codigo != 0)
            {
                string Consulta = "Insert Into CALEFACTOR_CLIENTE(Codigo_Calefactor, Codigo_Cliente, CantidadCompra) values('" + oBECalefactorGas.Codigo + "','" + oBECliente.Codigo + "', '" + oBECalefactorGas.Cantidad + "')";
                return oDatos.Escribir(Consulta);
            }
            else
            {
                return false;
            }
        }

    }
}
