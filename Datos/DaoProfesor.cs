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
    public class DaoProfesor
    {
        SqlConnection conexion;
        public DaoProfesor()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertProfesor(DtoProfesor prof)
        {
            SqlCommand cmd = new SqlCommand("sp_insertProfesor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            if (prof.latitud == null)
                cmd.Parameters.AddWithValue("@latitud", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@latitud", prof.latitud);
            if (prof.longitud == null)
                cmd.Parameters.AddWithValue("@longitud", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@longitud", prof.longitud);
            if (prof.diasDisponible == null)
                cmd.Parameters.AddWithValue("@diasDisponible", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@diasDisponible", prof.diasDisponible);
            cmd.Parameters.AddWithValue("@urlCV", prof.urlCV);
            cmd.Parameters.AddWithValue("@estadoProfesor", prof.estadoProfesor);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void updateProfesor(DtoProfesor prof)
        {
            SqlCommand cmd = new SqlCommand("sp_updateProfesor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codPersona", prof.codPersona);
            if (prof.latitud == null)
                cmd.Parameters.AddWithValue("@latitud", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@latitud", prof.latitud);
            if (prof.longitud == null)
                cmd.Parameters.AddWithValue("@longitud", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@longitud", prof.longitud);
            if (prof.diasDisponible == null)
                cmd.Parameters.AddWithValue("@diasDisponible", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@diasDisponible", prof.diasDisponible);
            cmd.Parameters.AddWithValue("@urlCV", prof.urlCV);
            cmd.Parameters.AddWithValue("@estadoProfesor", prof.estadoProfesor);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public bool getProfesor(DtoProfesor trab)
        {
            SqlCommand cmd = new SqlCommand("sp_getProfesor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codPersona", trab.codPersona);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                if (reader[1] == DBNull.Value)
                    trab.latitud = null;
                else
                    trab.latitud = Convert.ToDouble(reader[1].ToString());
                if (reader[2] == DBNull.Value)
                    trab.longitud = null;
                else
                    trab.longitud = Convert.ToDouble(reader[2].ToString());
                trab.diasDisponible = reader[3].ToString();
                trab.urlCV = reader[4].ToString();
                trab.estadoProfesor = reader[5].ToString();
            }

            conexion.Close();
            return hayRegistros;
        }

        public DataSet getTalleresxProfesor(int codPersona)
        {
            SqlCommand cmd = new SqlCommand("sp_getTalleresxProfesor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codPersona", codPersona);
            DataSet dstaller = new DataSet();									
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);							
            unComando.Fill(dstaller, "ds_getTalleresxProfesor");						
            return dstaller;											
        }

        public bool getLastProfesor(DtoProfesor prof)
        {
            SqlCommand cmd = new SqlCommand("sp_getProfesor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                prof.codPersona = Convert.ToInt32(reader[0].ToString());
                prof.numDocumento = reader[1].ToString();
                prof.nombres = reader[2].ToString();
                prof.apPaterno = reader[3].ToString();
                prof.apMaterno = reader[4].ToString();
                prof.telefono = reader[5].ToString();
                prof.email = reader[6].ToString();
                prof.direccion = reader[7].ToString();
                prof.sexo = Convert.ToChar(reader[8].ToString());
                prof.fechaNacimiento = Convert.ToDateTime(reader[9].ToString());
                if (reader[10] == DBNull.Value)
                    prof.codUsuario = null;
                else
                    prof.codUsuario = Convert.ToInt32(reader[10].ToString());
                prof.codDistrito = Convert.ToInt32(reader[11].ToString());
            }

            conexion.Close();
            return hayRegistros;
        }

        public void disableProfesor(DtoProfesor prof)
        {
            SqlCommand cmd = new SqlCommand("sp_disableProfesor", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codPersona", prof.codPersona);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //public void deleteProfesor(DtoProfesor prof)
        //{
        //    SqlCommand cmd = new SqlCommand("sp_deleteProfesor", conexion);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@codPersona", prof.codPersona);
        //    cmd.Parameters.AddWithValue("@estadoProfesor", prof.estadoProfesor);

        //    conexion.Open();
        //    cmd.ExecuteNonQuery();
        //    conexion.Close();
        //}

        public DataSet getProfesores(string estadoTrabajador)
        {
            SqlCommand cmd = new SqlCommand("sp_getProfesores", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@estadoTrabajador", estadoTrabajador);
            DataSet dsProfesores = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);
            unComando.Fill(dsProfesores, "ds_getProfesores");
            return dsProfesores;
        }

        public DataSet getProfesores1(string estadoTrabajador, string nombre)
        {
            SqlCommand cmd = new SqlCommand("sp_getProfesores1", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@estadoTrabajador", estadoTrabajador);
            cmd.Parameters.AddWithValue("@nombres", nombre);
            DataSet dsProfesores1 = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);
            unComando.Fill(dsProfesores1, "ds_getProfesores1");
            return dsProfesores1;
        }

        public DataSet getProfTrabajadores()
        {
            SqlCommand cmd = new SqlCommand("sp_getProfesor2", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet dsProfTrabajadores = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);
            unComando.Fill(dsProfTrabajadores, "ds_getProfTrabajadores");
            return dsProfTrabajadores;
        }
    }
}