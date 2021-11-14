using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApiMedical.Models;

namespace WebApiMedical.Data
{
    public class DoctoresData
    {
        ConexionBL conbl = new ConexionBL();
        SqlConnection con;
        IDataReader reader;
        List<Doctores> list;
        public bool insertDoctores(Doctores doc)
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                object res;
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_InsertDoctor", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@nombre", doc.doc_Nombre);
                cmd.Parameters.AddWithValue("@especialidad", doc.doc_Especialidad);
                cmd.CommandTimeout = 1;
                res = cmd.ExecuteScalar();
                bool boolena = res == null ? false : (bool)res;
                if(boolena != true & cmd.CommandTimeout >= 1) { con.Close(); }
                return true;
            }
            catch (Exception ex)
            {
                if(con != null) { con.Close(); }
                return true;
            }
        }
        
        public bool updateDoctores(Doctores doc)
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                object res;
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateDoctor", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@doc_ID", doc.doc_Id);
                cmd.Parameters.AddWithValue("@nombre", doc.doc_Nombre);
                cmd.Parameters.AddWithValue("@especialidad", doc.doc_Especialidad);
                cmd.CommandTimeout = 1;
                res = cmd.ExecuteScalar();
                bool boolena = res == null ? false : (bool)res;
                if (boolena != true & cmd.CommandTimeout >= 1)
                {
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (con != null) { con.Close(); }
                return true;
            }
        }
        
        public bool removeDoctores(int id)
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                object res;
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_removeDoctor", con){ CommandType = System.Data.CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);
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
        public List<Doctores> getDoctores()
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_getDoctor", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                reader = da.SelectCommand.ExecuteReader();
                list = new List<Doctores>();
                while (reader.Read())
                {
                    Doctores en = new Doctores
                    {
                        doc_Id = reader.GetInt64(0),
                        doc_Nombre = reader.GetString(1),
                        doc_Especialidad = reader.GetString(2)
                    };
                    list.Add(en);
                }
                reader.Close();
                con.Close();
                return list;
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                {
                    con.Close();
                }
                return null;
            }
        }

        public List<Doctores> getDoctor(int id)
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_getDoctorID", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                reader = da.SelectCommand.ExecuteReader();
                list = new List<Doctores>();
                while (reader.Read())
                {
                    Doctores en = new Doctores
                    {
                        doc_Id = reader.GetInt64(0),
                        doc_Nombre = reader.GetString(1),
                        doc_Especialidad = reader.GetString(2)
                    };
                    list.Add(en);
                }
                reader.Close();
                con.Close();
                return list;
            }
            catch
            {
                if(con != null)
                {
                    con.Close();
                }
                return null;
            }
        }
    }
}