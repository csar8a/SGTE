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
    public class DaoTallerApert
    {
        SqlConnection conexion;
        public DaoTallerApert()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }



        public String getTallerAperturado2(DtoTallerAperturado trab)
        {
            SqlCommand cmd = new SqlCommand("sp_getTallerxTallerAperturado", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codTA", trab.codTallerAperturado);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                return reader[0].ToString();
            }

            conexion.Close();
            return "No existe :v";
        }


        public bool getTallerAperturado3(DtoTallerAperturado trab)
        {
            SqlCommand cmd = new SqlCommand("sp_getTallerAperturado", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codTallerAperturado", trab.codTallerAperturado);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {
                trab.dia = reader[1].ToString();
                trab.horaInicio = Convert.ToDateTime(reader[2].ToString());
                trab.Fin = Convert.ToDateTime(reader[3].ToString());
                trab.estado = reader[4].ToString();
                trab.codVenta = int.Parse(reader[5].ToString());
                trab.codTaller = int.Parse(reader[6].ToString());
                trab.codProfesor = int.Parse(reader[7].ToString());
            }

            conexion.Close();
            return hayRegistros;
        }


        public void insertAlumnoXtallerAperturado(DtoTallerAperturado prof)
        {
            SqlCommand cmd = new SqlCommand("insertAlumnoXtallerAperturado", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codPersona", prof.codPersona);
            cmd.Parameters.AddWithValue("@codTallerAperturado", prof.codTallerAperturado);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }




        public void updateTallerAperturadoProfesor(int codTallerAperturado, int codProfesor)
        {
            SqlCommand cmd = new SqlCommand("sp_updateTallerAperturadoProfe", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codTallerAperturado", codTallerAperturado);
            cmd.Parameters.AddWithValue("@codProfesor", codProfesor);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
