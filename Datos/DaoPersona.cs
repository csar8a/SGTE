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
    public class DaoPersona
    {
        SqlConnection conexion;
        public DaoPersona()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertPersona(DtoPersona pers)
        {
            SqlCommand cmd = new SqlCommand("sp_insertPersona", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@numDocumento", pers.numDocumento);
            cmd.Parameters.AddWithValue("@nombres", pers.nombres);
            cmd.Parameters.AddWithValue("@apPaterno", pers.apPaterno);
            cmd.Parameters.AddWithValue("@apMaterno", pers.apMaterno);
            if (pers.telefono == null)
                cmd.Parameters.AddWithValue("@telefono", DBNull.Value);
            else
            cmd.Parameters.AddWithValue("@telefono", pers.telefono);
            cmd.Parameters.AddWithValue("@email", pers.email);
            cmd.Parameters.AddWithValue("@direccion", pers.direccion);
            cmd.Parameters.AddWithValue("@sexo", pers.sexo);
            cmd.Parameters.AddWithValue("@fechaNacimiento", pers.fechaNacimiento);
            if(pers.codUsuario == null)
                cmd.Parameters.AddWithValue("codUsuario", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@codUsuario", pers.codUsuario);
            cmd.Parameters.AddWithValue("@codDistrito", pers.codDistrito);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void updatePersona(DtoPersona pers)
        {
            SqlCommand cmd = new SqlCommand("sp_updatePersona", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codPersona", pers.codPersona);
            cmd.Parameters.AddWithValue("@numDocumento", pers.numDocumento);
            cmd.Parameters.AddWithValue("@nombres", pers.nombres);
            cmd.Parameters.AddWithValue("@apPaterno", pers.apPaterno);
            cmd.Parameters.AddWithValue("@apMaterno", pers.apMaterno);
            if (pers.telefono == null)
                cmd.Parameters.AddWithValue("@telefono", DBNull.Value);
            else
            cmd.Parameters.AddWithValue("@telefono", pers.telefono);
            cmd.Parameters.AddWithValue("@email", pers.email);
            cmd.Parameters.AddWithValue("@direccion", pers.direccion);
            cmd.Parameters.AddWithValue("@sexo", pers.sexo);
            cmd.Parameters.AddWithValue("@fechaNacimiento", pers.fechaNacimiento);
            if(pers.codUsuario == null)
                cmd.Parameters.AddWithValue("codUsuario", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@codUsuario", pers.codUsuario);
            cmd.Parameters.AddWithValue("@codDistrito", pers.codDistrito);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void deleteLastPersona(DtoPersona pers)
        {
            SqlCommand cmd = new SqlCommand("sp_deleteLastPersona", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public bool getPersona(DtoPersona pers)
        {
            SqlCommand cmd = new SqlCommand("sp_getPersona", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codPersona", pers.codPersona);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                pers.numDocumento = reader[1].ToString();
                pers.nombres = reader[2].ToString();
                pers.apPaterno = reader[3].ToString();
                pers.apMaterno = reader[4].ToString();
                pers.telefono = reader[5].ToString();
                pers.email = reader[6].ToString();
                pers.direccion = reader[7].ToString();
                pers.sexo = Convert.ToChar(reader[8].ToString());
                pers.fechaNacimiento = Convert.ToDateTime(reader[9].ToString());
                if(reader[10] == DBNull.Value)
                    pers.codUsuario = null;
                else
                    pers.codUsuario = Convert.ToInt32(reader[10].ToString());
                pers.codDistrito = Convert.ToInt32(reader[11].ToString());
            }

            conexion.Close();
            return hayRegistros;
        }

        public bool getPersonaxcodUsuario(DtoPersona pers)
        {
            SqlCommand cmd = new SqlCommand("sp_getPersonaxcodUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codUsuario", pers.codUsuario);  

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                pers.codPersona = Convert.ToInt32(reader[0].ToString());
                pers.numDocumento = reader[1].ToString();
                pers.nombres = reader[2].ToString();
                pers.apPaterno = reader[3].ToString();
                pers.apMaterno = reader[4].ToString();
                pers.telefono = reader[5].ToString();
                pers.email = reader[6].ToString();
                pers.direccion = reader[7].ToString();
                pers.sexo = Convert.ToChar(reader[8].ToString());
                pers.fechaNacimiento = Convert.ToDateTime(reader[9].ToString());
                pers.codDistrito = Convert.ToInt32(reader[11].ToString());
            }

            conexion.Close();
            return hayRegistros;
        }

        public bool getNumDocxPersona(string numDocumento)
        {
            SqlCommand cmd = new SqlCommand("sp_getNumDocxPersona", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numDocumento", numDocumento);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            conexion.Close();
            return hayRegistros;
        }

        public bool getEmailxPersona(string email)
        {
            SqlCommand cmd = new SqlCommand("sp_getEmailxPersona", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            conexion.Close();
            return hayRegistros;
        }



        public String getAlumnoXcode(int codPersona)
        {
            SqlCommand cmd = new SqlCommand("getGradeAlumno", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codPersona", codPersona);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                return reader[1].ToString();
            }

            conexion.Close();
            return "No existe :v";
        }


        public DataSet getTalleresxCole(int codPersona)
        {
            SqlCommand cmd = new SqlCommand("getTallerAperturadoxCole", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codPersona", codPersona);
            DataSet dstaller = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);
            unComando.Fill(dstaller, "getTallerAperturadoxCole");
            return dstaller;
        }
    }
}
