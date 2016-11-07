using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DaoUbigeo
    {
        SqlConnection conexion;
        public DaoUbigeo()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataSet getDepartamentos()
        {
            SqlCommand cmd = new SqlCommand("sp_getDepartamentos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dsDep = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);
            unComando.Fill(dsDep, "ds_departamentos");
            return dsDep;
        }

        public DataSet getProvincias(int codDepartamento)
        {
            SqlCommand cmd = new SqlCommand("sp_getProvincias", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codDepartamento", codDepartamento);
            DataSet dsProv = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);
            unComando.Fill(dsProv, "ds_provincias");
            return dsProv;
        }

        public DataSet getDistritos(int codProvincia)
        {
            SqlCommand cmd = new SqlCommand("sp_getDistritos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codProvincia", codProvincia);
            DataSet dsDist = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);
            unComando.Fill(dsDist, "ds_distritos");
            return dsDist;
        }

        public int getProvincia(int codDistrito)
        {
            int provincia = 0;
            SqlCommand cmd = new SqlCommand("sp_getProvincia", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codDistrito", codDistrito);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
                provincia = Convert.ToInt32(reader[0]);

            conexion.Close();
            return provincia;
        }

        public int getDepartamento(int codProvincia)
        {
            int departamento = 0;
            SqlCommand cmd = new SqlCommand("sp_getDepartamento", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codProvincia", codProvincia);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                departamento = Convert.ToInt32(reader[0]);
            }

            conexion.Close();
            return departamento;
        }
    }
}
