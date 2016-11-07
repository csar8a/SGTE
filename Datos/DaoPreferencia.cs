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
    public class DaoPreferencia
    {
        SqlConnection conexion;
        public DaoPreferencia()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void insertPreferencia(DtoPreferencia pref)
        {
            SqlCommand cmd = new SqlCommand("insertPreferencia", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@dia", pref.dia);
            cmd.Parameters.AddWithValue("@horaInicio", pref.horaInicio);
            cmd.Parameters.AddWithValue("@horaFin", pref.horaFin);
            cmd.Parameters.AddWithValue("@codTaller", pref.codTaller);
            cmd.Parameters.AddWithValue("@codPersona", pref.codPersona);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        //public DataSet getPreferencias()
        //{
        //    DtoPreferencia pers = new DtoPreferencia();
        //    SqlCommand cmd = new SqlCommand("sp_getpreferencia", conexion);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    conexion.Open();
        //    bool hayRegistros;

        //    SqlDataReader reader = cmd.ExecuteReader();
        //    hayRegistros = reader.Read();

        //    if (hayRegistros)
        //    {
        //        pers.dia = reader[1].ToString();
        //        pers.horaInicio = Convert.ToDateTime(reader[2].ToString());
        //        pers.horaFin = Convert.ToDateTime(reader[3].ToString());
        //        pers.codTaller = Convert.ToInt32(reader[4].ToString());
        //        pers.codPersona = Convert.ToInt32(reader[5].ToString());
        //    }

        //    conexion.Close();
        //    return pers;

        //    //SqlCommand cmd = new SqlCommand("sp_getTalleresxProfesor", conexion);
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.Parameters.AddWithValue("@codPersona", codPersona);
        //    //DataSet dstaller = new DataSet();
        //    //SqlDataAdapter unComando = new SqlDataAdapter(cmd);
        //    //unComando.Fill(dstaller, "ds_getTalleresxProfesor");
        //    //return dstaller;	
        //}
    }
}
