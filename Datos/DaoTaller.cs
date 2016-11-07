using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoTaller
    {
        SqlConnection conexion;

        public DaoTaller()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertTaller(DtoTaller tall)
        {
            SqlCommand cmd = new SqlCommand("sp_insertTaller", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", tall.nombre);
            cmd.Parameters.AddWithValue("@nivel", tall.nivel);
            cmd.Parameters.AddWithValue("@rango", tall.rango);
            cmd.Parameters.AddWithValue("@descripcion", tall.descripcion);
            cmd.Parameters.AddWithValue("@totalHoras", tall.totalHoras);
            cmd.Parameters.AddWithValue("@urlSilabo", tall.urlSilabo);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void updateTaller(DtoTaller tall)
        {
            SqlCommand cmd = new SqlCommand("sp_updateTaller", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codTaller", tall.codTaller);
            cmd.Parameters.AddWithValue("@nombre", tall.nombre);
            cmd.Parameters.AddWithValue("@nivel", tall.nivel);
            cmd.Parameters.AddWithValue("@rango", tall.rango);
            cmd.Parameters.AddWithValue("@descripcion", tall.descripcion);
            cmd.Parameters.AddWithValue("@totalHoras", tall.totalHoras);
            cmd.Parameters.AddWithValue("@urlSilabo", tall.urlSilabo);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        //public void deleteTaller(DtoTaller tall)
        //{
        //    SqlCommand cmd = new SqlCommand("sp_deleteTaller", conexion);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@codTaller", tall.codTaller);

        //    conexion.Open();
        //    cmd.ExecuteNonQuery();
        //    conexion.Close();
        //}

        public bool getTaller(DtoTaller taller)
        {
            SqlCommand cmd = new SqlCommand("sp_getTaller", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                taller.codTaller = Convert.ToInt32(reader[0].ToString());
                taller.nombre = reader[1].ToString();
                taller.nivel = reader[2].ToString();
                taller.rango = reader[3].ToString();
                taller.descripcion = reader[4].ToString();
                taller.totalHoras = Convert.ToInt32(reader[5].ToString());
                taller.urlSilabo = reader[6].ToString();
            }
            conexion.Close();
            return hayRegistros;
        }

        public DataSet getTalleres()
        {
            SqlCommand cmd = new SqlCommand("sp_getTaller", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dsTalleres = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);
            unComando.Fill(dsTalleres, "ds_getTalleres");
            return dsTalleres;
        }
    }
}
