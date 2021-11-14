using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMedical.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebApiMedical.Data
{
    public class UsuarioData
    {
        ConexionBL conbl = new ConexionBL();
        SqlConnection con;
        IDataReader reader;
        List<Usuarios> list;
        public bool insertUsuario(Usuarios en)
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                object res;
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_registrar", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@nombre", en.nombre);
                cmd.Parameters.AddWithValue("@Correo", en.correo);
                cmd.Parameters.AddWithValue("@Pass", en.pass);
                cmd.CommandTimeout = 1;
                res = cmd.ExecuteScalar();
                bool boolena = res == null ? false : (bool)res;
                if (boolena != true & cmd.CommandTimeout >= 1) { con.Close(); }
                return true;
            }
            catch (Exception ex)
            {
                if (con != null) { con.Close(); }
                return false;
            }
        }

        public bool updateUsuarios(Usuarios en)
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                object res;
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_modificar", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", en.id);
                cmd.Parameters.AddWithValue("@Nombre", en.nombre);
                cmd.Parameters.AddWithValue("@Correo", en.correo);
                cmd.Parameters.AddWithValue("@Pass", en.pass);
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

        public bool removeUsuarios(int id)
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                object res;
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_eliminar", con) { CommandType = System.Data.CommandType.StoredProcedure };
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
        public List<Usuarios> obtenerUsuarios(int id)
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_getUsuarioID", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                reader = da.SelectCommand.ExecuteReader();
                list = new List<Usuarios>();
                while (reader.Read())
                {
                    Usuarios en = new Usuarios
                    {
                        id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        correo = reader.GetString(2),
                        pass = reader.GetString(3)
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
        public bool logIn(Usuarios us)
        {
            

            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_Login", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@correo", us.correo);
                da.SelectCommand.Parameters.AddWithValue("@pass", us.pass);
                reader = da.SelectCommand.ExecuteReader();
                list = new List<Usuarios>();
                while (reader.Read())
                {
                    Usuarios en = new Usuarios
                    {
                        id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        correo = reader.GetString(2),
                        pass = reader.GetString(3)
                    };
                    list.Add(en);
                }
                reader.Close();
                con.Close();
                if(list.Count > 0){
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                if (con != null)
                {
                    con.Close();
                }
                return false;
            }
        }
        public List<Usuarios> getUsuario()
        {
            string conn = conbl.conexionSQL();
            try
            {
                con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("usp_Obtener", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                reader = da.SelectCommand.ExecuteReader();
                list = new List<Usuarios>();
                while (reader.Read())
                {
                    Usuarios en = new Usuarios
                    {
                        id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        correo = reader.GetString(2),
                        pass = reader.GetString(3)
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
    }
}