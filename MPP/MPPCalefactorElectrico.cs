using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Abstraccion;
using BE;
using System.Data;

namespace MPP
{
    public class MPPCalefactorElectrico : IGestor<BECalefactorElectrico>
    {
        public MPPCalefactorElectrico()
        {
            oDatos = new Acceso();
        }

        Acceso oDatos;

        public bool Borrar(BECalefactorElectrico oBECalefactorElectrico)
        {
            string Consulta = "Delete from CALEFACTOR where Codigo = '" + oBECalefactorElectrico.Codigo + "'";
            return oDatos.Escribir(Consulta);
        }

        public bool Guardar(BECalefactorElectrico oBECalefactorElectrico)
        {
            string Consulta = string.Empty;
            if (oBECalefactorElectrico.Codigo == 0)
            {
                Consulta = "Insert Into CALEFACTOR(Nombre, Calorias, Modelo, Cantidad,Eficiencia, CodProveedor) Values('" + oBECalefactorElectrico.Nombre + "', '" + oBECalefactorElectrico.Calorias + "', '" + oBECalefactorElectrico.Modelo + "', '" + oBECalefactorElectrico.Cantidad + "', '" + oBECalefactorElectrico.Eficiencia + "', '" + oBECalefactorElectrico.Proveedor +  "')";
            }
            else
            {
                Consulta = "Update CALEFACTOR Set Nombre = '" + oBECalefactorElectrico.Nombre + "', Calorias = '" + oBECalefactorElectrico.Calorias + "', Modelo = '" + oBECalefactorElectrico.Modelo + "', Cantidad = '" + oBECalefactorElectrico.Cantidad + "', Eficiencia = '" + oBECalefactorElectrico.Eficiencia + "', CodProveedor = '" + oBECalefactorElectrico.Proveedor +  "' Where Codigo = '" + oBECalefactorElectrico.Codigo + "'";
            }
            return oDatos.Escribir(Consulta);
        }

        public List<BECalefactorElectrico> ListarTodo()
        {
            List<BECalefactorElectrico> ListaCalefactorElectrico = new List<BECalefactorElectrico>();
            string Consulta = "Select * from CALEFACTOR, PROVEEDOR where CALEFACTOR.TiroBalenceado is NULL and PROVEEDOR.Codigo = CALEFACTOR.CodProveedor";
            DataTable DTable = oDatos.Leer(Consulta);
            if (DTable.Rows.Count >= 1)
            {
                foreach (DataRow row in DTable.Rows)
                {
                    BECalefactorElectrico oBECalefactorElectrico = new BECalefactorElectrico();
                    oBECalefactorElectrico.Codigo = Convert.ToInt32(row["Codigo"]);
                    oBECalefactorElectrico.Nombre = Convert.ToString(row["Nombre"]);
                    oBECalefactorElectrico.Calorias = Convert.ToInt32(row["Calorias"]);
                    oBECalefactorElectrico.Modelo = Convert.ToString(row["Modelo"]);
                    oBECalefactorElectrico.Cantidad = Convert.ToInt32(row["Cantidad"]);
                    oBECalefactorElectrico.Eficiencia = Convert.ToString(row["Eficiencia"]);

                    BEProveedor oBEProveedor = new BEProveedor();
                    oBEProveedor.Codigo = Convert.ToInt32(row["CodProveedor"]);
                    oBEProveedor.RazonSocial = Convert.ToString(row["RazonSocial"]);
                    oBEProveedor.CUIT = Convert.ToInt32(row["CUIT"]);
                    oBECalefactorElectrico.Proveedor = oBEProveedor;
                    ListaCalefactorElectrico.Add(oBECalefactorElectrico);
                }
            }
            return ListaCalefactorElectrico;
        }


        public bool GuardarCalefactor_Cliente(BECliente oBECliente, BECalefactorElectrico oBECalefactorElectrico)
        {
            if (oBECalefactorElectrico.Codigo != 0 && oBECliente.Codigo != 0)
            {
                string Consulta = "Insert Into CALEFACTOR_CLIENTE(Codigo_Calefactor, Codigo_Cliente, CantidadCompra) values('" + oBECalefactorElectrico.Codigo + "','" + oBECliente.Codigo + "', '" + oBECalefactorElectrico.Cantidad + "')";
                return oDatos.Escribir(Consulta);
            }
            else
            {
                return false;
            }
        }

    }
}
