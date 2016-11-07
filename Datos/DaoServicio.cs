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
    public class DaoServicio
    {
        SqlConnection conexion;
        public DaoServicio()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void InsertServicio(DtoServicio serv)
        {
            SqlCommand cmd = new SqlCommand("sp_insertServicio",conexion);
            cmd.CommandType = CommandType.StoredProcedure;

           
            cmd.Parameters.AddWithValue("@nombre", serv.nombre);
            cmd.Parameters.AddWithValue("@descripcion",serv.descripcion);
            



           

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void updateServicio(DtoServicio serv)
        {
            SqlCommand cmd = new SqlCommand("sp_updateServicio", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codServicio", serv.codServicio);
            cmd.Parameters.AddWithValue("@nombre", serv.nombre);
            cmd.Parameters.AddWithValue("@descripcion",serv.descripcion);    
            cmd.Parameters.AddWithValue("@estado",serv.estado);

         

             conexion.Open();
             cmd.ExecuteNonQuery();
             conexion.Close();
        }

       

        public void disableServicio(DtoServicio serv)
        {
            SqlCommand cmd = new SqlCommand("sp_disableServicio", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public bool getServicio(DtoServicio serv)
        {
            SqlCommand cmd = new SqlCommand("sp_getServicio",conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codServicio",serv.codServicio);

            conexion.Open();
            bool hayRegistros;

            SqlDataReader reader = cmd.ExecuteReader();
            hayRegistros = reader.Read();

            if (hayRegistros)
            {

               serv.nombre = reader[1].ToString();
                serv.descripcion = reader[2].ToString();
                //serv.estado = int.Parse(reader[3].ToString());
            }

            conexion.Close();
            return hayRegistros;

        }
       


        public DataSet getServicios (int  estado)
        {
            SqlCommand cmd = new SqlCommand("sp_getServicios", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@estado", estado);
            DataSet dsServicio = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);
            unComando.Fill(dsServicio, "ds_getServicios");
            return dsServicio;
        }

        public DataSet getServicios2(int estado, string nombre)
        {
            SqlCommand cmd = new SqlCommand("sp_getServicios2", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            DataSet dsServicios2 = new DataSet();
            SqlDataAdapter unComando = new SqlDataAdapter(cmd);
            unComando.Fill(dsServicios2, "ds_getServicios2");
            return dsServicios2;
        }

    }
}
