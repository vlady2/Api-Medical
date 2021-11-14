using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApiMedical.Models;

namespace WebApiMedical.Data
{
    public class ConsultasData
    {
        ConexionBL conbl = new ConexionBL();
        SqlConnection con;
        IDataReader reader;
        List<Consultas> list;
        public bool crearConsulta(Consultas en, int opcion)
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                object res;
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_CrearCita", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@opcion", opcion);
                cmd.Parameters.AddWithValue("@cit_Id", en.con_Id);
                cmd.Parameters.AddWithValue("@cit_paciente", en.con_Paciente);
                cmd.Parameters.AddWithValue("@doc_Id", Convert.ToInt32(en.doc_Fk));
                cmd.Parameters.AddWithValue("@cit_fecha", en.con_Fecha);
                cmd.Parameters.AddWithValue("@cit_hora", en.con_Hora);
                cmd.CommandTimeout = 1;
                res = cmd.ExecuteScalar();
                bool boolena = res == null ? false : (bool)res;
                if (boolena != true & cmd.CommandTimeout >= 1) { con.Close(); }
                return true;
            }
            catch (Exception ex)
            {
                if (con != null) { con.Close(); }
                return true;
            }
        }
        public List<Consultas> getConsultas(string valor)
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_MostrarCitas", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@opcion", valor);
                reader = da.SelectCommand.ExecuteReader();
                list = new List<Consultas>();
                while (reader.Read())
                {
                    Consultas en = new Consultas
                    {
                        con_Id = reader.GetInt64(0),
                        con_Paciente = reader.GetString(1),
                        doc_Fk = reader.GetString(2),
                        con_Fecha = reader.GetString(3),
                        con_Hora = reader.GetString(4)
                    };
                    list.Add(en);
                }
                reader.Close();
                con.Close();
                return list;
            }
            catch
            {
                if (con != null)
                {
                    con.Close();
                }
                return null;
            }
        }
    }
}