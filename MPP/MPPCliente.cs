using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Abstraccion;
using BE;
using DAL;

namespace MPP
{
    public class MPPCliente : IGestor<BECliente>
    {
        public MPPCliente() 
        {
            oDatos = new Acceso();
        }

        Acceso oDatos;

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
            List<BECliente> ListaClientes = new List<BECliente>();
            string Consulta = "Select Codigo, Nombre, Apellido, DNI from Cliente";
            DataTable DTable = oDatos.Leer(Consulta);
            if (DTable.Rows.Count >= 1)
            {
                foreach (DataRow row in DTable.Rows)
                {
                    BECliente oCliente = new BECliente();
                    oCliente.Codigo = Convert.ToInt32(row["Codigo"]);
                    oCliente.Nombre = Convert.ToString(row["Nombre"]);
                    oCliente.Apellido = Convert.ToString(row["Apellido"]);
                    oCliente.DNI = Convert.ToInt32(row["Dni"]);

                    Acceso objDatos2 = new Acceso();
                    DataTable DTable2 = oDatos.Leer("Select * From CALEFACTOR_CLIENTE, CLIENTE as C , CALEFACTOR as P where CALEFACTOR_CLIENTE.Codigo_Cliente = C.Codigo and CALEFACTOR_CLIENTE.Codigo_Calefactor = P.Codigo and C.Codigo = '" + oCliente.Codigo + "'");
                    List<BECalefactor> ListaCalefactor = new List<BECalefactor>();
                    if (DTable2.Rows.Count > 0)
                    {
                        foreach (DataRow row2 in DTable2.Rows)
                        {
                            if (row2["TiroBalanceado"] is DBNull)
                            {
                                BECalefactorElectrico oBECalefactorElectrico = new BECalefactorElectrico();
                                oBECalefactorElectrico.Codigo = Convert.ToInt32(row2["Codigo"]);
                                oBECalefactorElectrico.Nombre = Convert.ToString(row2["Nombre"]);
                                oBECalefactorElectrico.Calorias = Convert.ToInt32(row2["Calorias"]);
                                oBECalefactorElectrico.Modelo = Convert.ToString(row2["Modelo"]);
                                oBECalefactorElectrico.Cantidad = Convert.ToInt32(row2["Cantidad"]);
                                oBECalefactorElectrico.Eficiencia = Convert.ToString(row2["Eficiencia"]);
                                
                                ListaCalefactor.Add(oBECalefactorElectrico);
                            }
                            else
                            {
                                BECalefactorGas oBECalefactorGas = new BECalefactorGas();
                                oBECalefactorGas.Codigo = Convert.ToInt32(row2["Codigo"]);
                                oBECalefactorGas.Nombre = Convert.ToString(row2["Nombre"]);
                                oBECalefactorGas.Calorias = Convert.ToInt32(row2["Calorias"]);
                                oBECalefactorGas.Modelo = Convert.ToString(row2["Modelo"]);
                                oBECalefactorGas.Cantidad = Convert.ToInt32(row2["Cantidad"]);
                                oBECalefactorGas.TiroBalanceado = Convert.ToByte(row2["TiroBalanceado"]);
                           
                                ListaCalefactor.Add(oBECalefactorGas);
                            }
                        }
                        oCliente.ListaCalefactores = ListaCalefactor;
                    }
                    ListaClientes.Add(oCliente);
                }
            }
            return ListaClientes;
        }
    }
}
