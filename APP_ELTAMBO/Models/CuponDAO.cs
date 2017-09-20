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
    public class CuponDAO: ICrudCupon<Cupon>
    {
        public void actualizaCupon(Cupon p)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_UPDATE_CUPON", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCUPON", (p.IdCupon == 0) ? DBNull.Value : (object)p.IdCupon);
            cmd.Parameters.AddWithValue("@NOMBRECUPON", string.IsNullOrEmpty(p.NombreCupon) ? DBNull.Value : (object)p.NombreCupon);
            cmd.Parameters.AddWithValue("@CODIGO_CUPON", string.IsNullOrEmpty(p.CodigoCupon) ? DBNull.Value : (object)p.CodigoCupon);
            cmd.Parameters.AddWithValue("@PORCENTAJE", (p.Porcentaje == 0) ? DBNull.Value : (object)p.Porcentaje);
            cmd.Parameters.AddWithValue("@VISIBILIDAD", (p.Visibilidad == 0) ? DBNull.Value : (object)p.Visibilidad);
            cmd.Parameters.AddWithValue("@ESTADO", (p.Estado == 0) ? DBNull.Value : (object)p.Estado);
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

        public void borrarCupon(Cupon p)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_DELETE_CUPON", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCUPON", p.IdCupon);
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

        public List<Cupon> listarCupon()
        {
            List<Cupon> lista = new List<Cupon>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_CUPON", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cupon cupon = new Cupon()
                    {
                        IdCupon = Convert.ToInt32(dr[0]),
                        NombreCupon = dr[1].ToString(),
                        CodigoCupon = dr[2].ToString(),
                        Porcentaje = Convert.ToInt32(dr[3]),
                        Visibilidad = Convert.ToInt32(dr[4]),
                        Estado = Convert.ToInt32(dr[5])
                    };
                    lista.Add(cupon);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex) { throw ex; }
            return lista;
        }

        public void registrarCupon(Cupon p)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_CREATE_CUPON", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRECUPON", string.IsNullOrEmpty(p.NombreCupon) ? DBNull.Value : (object)p.NombreCupon);
            cmd.Parameters.AddWithValue("@CODIGO_CUPON", string.IsNullOrEmpty(p.CodigoCupon) ? DBNull.Value : (object)p.CodigoCupon);
            cmd.Parameters.AddWithValue("@PORCENTAJE", (p.Porcentaje == 0) ? DBNull.Value : (object)p.Porcentaje);
            cmd.Parameters.AddWithValue("@VISIBILIDAD", (p.Visibilidad == 0) ? DBNull.Value : (object)p.Visibilidad);
            cmd.Parameters.AddWithValue("@ESTADO", (p.Estado == 0) ? DBNull.Value : (object)p.Estado);
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
        public Cupon buscarCuponID(int id)
        {
            Cupon cup = null;
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_SEARCH_CUPON_ID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCUPON", id);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cup = new Cupon()
                    {
                        IdCupon = Convert.ToInt32(dr[0]),
                        NombreCupon = dr[1].ToString(),
                        CodigoCupon = dr[2].ToString(),
                        Porcentaje = Convert.ToInt32(dr[3]),
                        Visibilidad = Convert.ToInt32(dr[4]),
                        Estado = Convert.ToInt32(dr[5])
                    };
                }
            }
            catch (SqlException ex) { throw ex; }
            return cup;
        }

        public Cupon buscarCuponTexto(string cupon)
        {
            Cupon cup = null;
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_SEARCH_CUPON_CODE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO_CUPON", cupon);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cup = new Cupon()
                    {
                        IdCupon = Convert.ToInt32(dr[0]),
                        NombreCupon = dr[1].ToString(),
                        CodigoCupon = dr[2].ToString(),
                        Porcentaje = Convert.ToInt32(dr[3]),
                        Visibilidad = Convert.ToInt32(dr[4]),
                        Estado = Convert.ToInt32(dr[5])
                    };
                }
            }
            catch (SqlException ex) { throw ex; }
            return cup;
        }
        public void asignarCuponUser(Cupon p, string idLogin)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_CREATE_CUPON_USER", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_LOGIN", string.IsNullOrEmpty(idLogin) ? DBNull.Value : (object)idLogin);
            cmd.Parameters.AddWithValue("@CODIGO_CUPON", string.IsNullOrEmpty(p.CodigoCupon) ? DBNull.Value : (object)p.CodigoCupon);
            cmd.Parameters.AddWithValue("@VALOR", (p.Porcentaje == 0) ? DBNull.Value : (object)p.Porcentaje);
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