using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Services;
using APP_ELTAMBO.DataBase;
using System.Data;
using System.Data.SqlClient;


namespace APP_ELTAMBO.Models
{
    public class UsuarioDAO : ICrudUsuario<Usuario>
    {
        public Usuario BuscarUsuarioPorID(string IdLogin)
        {
            Usuario user = new Usuario();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_SEARCH_USER_IDLOGIN", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_LOGIN", IdLogin);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                        user.IdUsuario = (int)(dr[0]);
                        user.IdLogin = dr[1].ToString();
                        user.Nombre = dr[2].ToString();
                        user.Apellido = dr[3].ToString();
                        user.Email = dr[4].ToString();
                        user.Sexo = dr[5].ToString();
                        user.DNI = dr[6].ToString();
                        user.Telefono = dr[7].ToString();
                        user.FechaNacimiento = dr[8].ToString();
                        user.Direccion = dr[9].ToString();
                        user.Referencia = dr[10].ToString();
                        user.IdRegion = (int)(dr[11]);
                        user.IdProvincia = (int)(dr[12]);
                        user.IdDistrito = (int)(dr[13]);
                        user.Avatar = dr[14].ToString();
                   
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            
            return user;
            }
        public Usuario BuscarDetalleUsuarioID(string IdLogin)
        {
            Usuario user = new Usuario();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_SEARCH_USER_ENTIDAD_IDLOGIN", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_LOGIN", IdLogin);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    user.IdUsuario = (int)(dr[0]);
                    user.IdLogin = dr[1].ToString();
                    user.Nombre = dr[2].ToString();
                    user.Apellido = dr[3].ToString();
                    user.Email = dr[4].ToString();
                    user.Sexo = dr[5].ToString();
                    user.DNI = dr[6].ToString();
                    user.Telefono = dr[7].ToString();
                    user.FechaNacimiento = dr[8].ToString();
                    user.Direccion = dr[9].ToString();
                    user.Referencia = dr[10].ToString();
                    user.IdRegion = (int)(dr[11]);
                    user.NombreRegion = dr[12].ToString();
                    user.IdProvincia = (int)(dr[13]);
                    user.NombreProvincia = dr[14].ToString();
                    user.IdDistrito = (int)(dr[15]);
                    user.NombreDistrito = dr[16].ToString();
                    user.Avatar = dr[17].ToString();

                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return user;
        }
        public void registerUserInSystems(ApplicationUser p) {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_REGISTER_USER", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_LOGIN", p.Id.ToString());
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

        public void Detele(Usuario p)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_ELIMINAR_USUARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDLOGIN", p.IdLogin);
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

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_LIST_USERS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario user = new Usuario ()
                    {
                        IdUsuario = Convert.ToInt32(dr[0]),
                        IdLogin = dr[1].ToString(),
                        Nombre = dr[2].ToString(),
                        Apellido = dr[3].ToString(),
                        DNI = dr[4].ToString(),
                        Username = dr[5].ToString(),
                        Email = dr[6].ToString(),
                        Telefono = dr[7].ToString()
                    };
                    lista.Add(user);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lista;
        }

        public void UpdateUser(Usuario p)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_UPDATE_USER", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_USUARIO", p.IdUsuario);
            cmd.Parameters.AddWithValue("@ID_LOGIN", p.IdLogin);
            cmd.Parameters.AddWithValue("@NOMBRE", string.IsNullOrEmpty(p.Nombre) ? DBNull.Value : (object)p.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", string.IsNullOrEmpty(p.Apellido) ? DBNull.Value : (object)p.Apellido);
            cmd.Parameters.AddWithValue("@SEXO", string.IsNullOrEmpty(p.Sexo) ? DBNull.Value : (object)p.Sexo);
            cmd.Parameters.AddWithValue("@DNI", string.IsNullOrEmpty(p.DNI) ? DBNull.Value : (object) p.DNI);
            cmd.Parameters.AddWithValue("@TELEFONO", string.IsNullOrEmpty(p.Telefono) ? DBNull.Value : (object)p.Telefono);
            cmd.Parameters.AddWithValue("@FECHA_NAC", string.IsNullOrEmpty(p.FechaNacimiento) ? DBNull.Value : (object)p.FechaNacimiento);
            cmd.Parameters.AddWithValue("@DIRECCION", string.IsNullOrEmpty(p.Direccion) ? DBNull.Value : (object)p.Direccion);
            cmd.Parameters.AddWithValue("@REFERENCIA", string.IsNullOrEmpty(p.Referencia) ? DBNull.Value : (object)p.Referencia);
            cmd.Parameters.AddWithValue("@ID_REGION", (p.IdRegion == 0 ) ? DBNull.Value : (object)p.IdRegion);
            cmd.Parameters.AddWithValue("@ID_PROVINCIA", (p.IdProvincia == 0) ? DBNull.Value : (object)p.IdProvincia);
            cmd.Parameters.AddWithValue("@ID_DISTRITO", (p.IdDistrito == 0) ? DBNull.Value : (object)p.IdDistrito);
            
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
        public List<Combo> getSexo() {
            Combo masculino = new Combo();
            Combo femenino = new Combo();
            List<Combo> lista = new List<Combo>();
            masculino.idCombo = "M";
            masculino.Descripcion = "Masculino";
            lista.Add(masculino);
            femenino.idCombo = "F";
            femenino.Descripcion = "Femenino";
            lista.Add(femenino);
            return lista;
        }

        public string BuscarEmailUsuario(string IdLogin)
        {
            string Email = null;
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_BUSCAR_EMAIL_USER", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_LOGIN", IdLogin);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Email = dr[0].ToString();                }
                    dr.Close();
                    cn.Close();
                }
            catch (SqlException ex)
            {
                throw ex;
            }
            return Email;
        }
    }
}