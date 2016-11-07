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
    public class DaoTrabajador
    {
        SqlConnection conexion;
        public DaoTrabajador()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertTrabajador(DtoTrabajador trab)
        {
            SqlCommand cmd = new SqlCommand("sp_insertTrabajador", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@urlFoto", trab.urlFoto);
            if (trab.fechaContrato == null)
                cmd.Parameters.AddWithValue("@fechaContrato", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@fechaContrato", trab.fechaContrato);
            if (trab.duracionContrato == null)
                cmd.Parameters.AddWithValue("@duracionContrato", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@duracionContrato", trab.duracionContrato);
            cmd.Parameters.AddWithValue("@tipoTrabajador", trab.tipoTrabajador);
            cmd.Parameters.AddWithValue("@estadoTrabajador", trab.estadoTrabajador);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void updateTrabajador(DtoTrabajador trab)
        {
            SqlCommand cmd = new SqlCommand("sp_updateTrabajador", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codPersona", trab.codPersona);
            cmd.Parameters.AddWithValue("@urlFoto", trab.urlFoto);
            if (trab.fechaContrato == null)
                cmd.Parameters.AddWithValue("@fechaContrato", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@fechaContrato", trab.fechaContrato);
            if (trab.duracionContrato == null)
                cmd.Parameters.AddWithValue("@duracionContrato", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@duracionContrato", trab.duracionContrato);
            cmd.Parameters.AddWithValue("@tipoTrabajador", trab.tipoTrabajador);
            cmd.Parameters.AddWithValue("@estadoTrabajador", trab.estadoTrabajador);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void deleteLastTrabajador(DtoTrabajador trab)
        {
            SqlCommand cmd = new SqlCommand("sp_deleteLastTrabajador", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codPersona", trab.codPersona);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void disableTrabajador(DtoTrabajador trab)
        {
            SqlCommand cmd = new SqlCommand("sp_disableTrabajador", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codPersona", trab.codPersona);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //public void deleteTrabajador(DtoTrabajador trab)
        //{
        //    SqlCommand cmd = new SqlCommand("sp_deleteTrabajador", conexion);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@codPersona", trab.codPersona);
        //    cmd.Parameters.AddWithValue("@estadoTrabajador", trab.estadoTrabajador);

        //    conexion.Open();
        //    cmd.ExecuteNonQuery();
        //    conexion.Close();
        //}

        public bool getTrabajador(DtoTrabajador trab)
        {
            SqlCommand cmd = new SqlCommand("sp_getTrabajador", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codPersona", trab.codPersona);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                trab.urlFoto = reader[1].ToString();
                if (reader[2] == DBNull.Value)
                    trab.fechaContrato = null;
                else
                    trab.fechaContrato = Convert.ToDateTime(reader[2].ToString());
                if (reader[3] == DBNull.Value)
                    trab.duracionContrato = null;
                else
                    trab.duracionContrato = Convert.ToInt32(reader[3].ToString());
                trab.tipoTrabajador = reader[4].ToString();
                trab.estadoTrabajador = reader[5].ToString();
            }

            conexion.Close();
            return hayRegistros;
        }
    }
}
