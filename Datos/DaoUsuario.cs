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
    public class DaoUsuario
    {
        SqlConnection conexion;
        public DaoUsuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertUsuario(DtoUsuario pers)
        {
            SqlCommand cmd = new SqlCommand("sp_insertUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@usuario", pers.usuario);
            cmd.Parameters.AddWithValue("@clave", pers.clave);
            cmd.Parameters.AddWithValue("@estado", pers.estado);
            cmd.Parameters.AddWithValue("@codPerfil", pers.codPerfil);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public int getLastUsuario()
        {
            SqlCommand cmd = new SqlCommand("sp_getLastUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();
            int codUsuario = 0;

            if (hayRegistros)
            {
                codUsuario = Convert.ToInt32(reader[0].ToString());
            }

            conexion.Close();

            return codUsuario;
        }

        public void enableUsuario(DtoUsuario pers)
        {
            SqlCommand cmd = new SqlCommand("sp_enableUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codUsuario", pers.codUsuario);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void disableUsuario(DtoUsuario pers)
        {
            SqlCommand cmd = new SqlCommand("sp_disableUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codUsuario", pers.codUsuario);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public bool getUsuario(DtoUsuario user)
        {
            SqlCommand cmd = new SqlCommand("sp_getUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@usuario", user.usuario);
            cmd.Parameters.AddWithValue("@clave", user.clave);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                user.codUsuario = Convert.ToInt32(reader[0].ToString());
                user.estado = reader[3].ToString();
                user.codPerfil = Convert.ToInt32(reader[4].ToString());
            }

            conexion.Close();
            return hayRegistros;
        }
    }
}
