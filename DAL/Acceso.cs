using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection oConection = new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaConexion"].ToString());

        public DataTable Leer(string Consulta)
        {
            DataTable dTable = new DataTable();

            try
            {
                SqlDataAdapter DA = new SqlDataAdapter(Consulta, oConection);
                DA.Fill(dTable);
            }
            catch (SqlException sqlex) { throw sqlex; }
            catch (Exception ex) { throw ex; }
            finally { oConection.Close(); }
            return dTable;
        }

        public bool Escribir(string Consulta)
        {
            oConection.Open();

            SqlTransaction miTransaccion;

            SqlCommand cmd;

            miTransaccion = oConection.BeginTransaction();

            try
            {
                cmd = new SqlCommand(Consulta);
                cmd.Transaction = miTransaccion;
                cmd.ExecuteNonQuery();
              
                miTransaccion.Commit();
                
                return true;
                
            }
           
            catch (Exception ex) 
            {
                
                miTransaccion.Rollback();
                throw ex;
            }
            finally { oConection.Close(); }

        }


        public bool LeerScalar(string Consulta)
        {
            oConection.Open();
            SqlCommand cmd = new SqlCommand(Consulta, oConection);
            cmd.CommandType = CommandType.Text;

            try
            {
                int valor = Convert.ToInt32(cmd.ExecuteScalar());
                if (valor > 0) { return true; }
                else { return false; }

            }
            catch (SqlException sqlex) { throw sqlex; }
            catch (Exception ex) { throw ex; }
            finally { oConection.Close(); }

        }

    }
}
