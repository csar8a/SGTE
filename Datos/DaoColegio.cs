using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;


namespace DAO
{
    public class DaoColegio
    {
        SqlConnection conexion;
        public DaoColegio()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public bool getColegio(DtoColegio trab)
        {
            SqlCommand cmd = new SqlCommand("sp_getColegio", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codColegio", trab.codColegio);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                trab.nombre = reader[1].ToString();
                trab.direccion = reader[2].ToString();
                trab.caracter = reader[3].ToString();
                trab.latitud = Convert.ToDouble(reader[4].ToString());
                trab.longitud = Convert.ToDouble(reader[5].ToString());
                trab.estado = reader[6].ToString();
                trab.codDistrito = int.Parse(reader[7].ToString());
            }

            conexion.Close();
            return hayRegistros;
        }
    }
}
