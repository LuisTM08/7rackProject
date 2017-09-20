using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using APP_ELTAMBO.DataBase;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Services;

namespace APP_ELTAMBO.Models
{
    public class ContactoDAO: ICrudContactoDAO<Contacto>
    {
       public void registerMensaje(Contacto c)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_REGISTER_CONTACT", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", string.IsNullOrEmpty(c.Name) ? DBNull.Value : (object)c.Name);
            cmd.Parameters.AddWithValue("@EMAIL", string.IsNullOrEmpty(c.Email) ? DBNull.Value : (object)c.Email);
            cmd.Parameters.AddWithValue("@ASUNTO", string.IsNullOrEmpty(c.Subject) ? DBNull.Value : (object)c.Subject);
            cmd.Parameters.AddWithValue("@MENSAJE", string.IsNullOrEmpty(c.Message) ? DBNull.Value : (object)c.Message);
            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}