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
    public class CarritoDAO : ICrubCarrito<Carrito>
    {
        public void insertarItem(Producto pro, int cantidad, string idlogin)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_ADD_CARRITO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            double subtotal = cantidad * pro.PrecioUnitario;
            cmd.Parameters.AddWithValue("@ID_LOGIN", idlogin);
            cmd.Parameters.AddWithValue("@ID_PRODUCTO", pro.IdProducto);
            cmd.Parameters.AddWithValue("@NOMBRE_PRO", pro.NombreProd);
            cmd.Parameters.AddWithValue("@CANTIDAD", cantidad);
            cmd.Parameters.AddWithValue("@PRECIOXUNIDAD", pro.PrecioUnitario);
            cmd.Parameters.AddWithValue("@SUBTOTAL", subtotal);
            cmd.Parameters.AddWithValue("@IMAGEN", pro.ImagenProducto);
            cmd.Parameters.AddWithValue("@DESCRIP", pro.DescripcionPro);
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

        public void aumentarItem(Producto pro, int cantidad, string idlogin)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_AUMENTAR_ITEM", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            double subtotal = cantidad * pro.PrecioUnitario;
            cmd.Parameters.AddWithValue("@ID_LOGIN", idlogin);
            cmd.Parameters.AddWithValue("@ID_PRODUCTO", pro.IdProducto);
            cmd.Parameters.AddWithValue("@CANTIDAD", cantidad);
            cmd.Parameters.AddWithValue("@SUBTOTAL", subtotal);
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
        public List<Carrito> listarCarrito(string idlogin)
        {
            List<Carrito> lista = new List<Carrito>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_CARRITO_IDUSER", cn);
            cmd.Parameters.AddWithValue("@ID_LOGIN", idlogin);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Carrito car = new Carrito()
                    {
                        IdLogin = dr[0].ToString(),
                        IdProducto = Convert.ToInt32(dr[1]),
                        NombreProducto = dr[2].ToString(),
                        Cantidad = Convert.ToInt32(dr[3]),
                        PrecioUnidad = Convert.ToDouble(dr[4]),
                        SubTotal = Convert.ToDouble(dr[5]),
                        Imagen = dr[6].ToString(),
                        Descripcion = dr[7].ToString()
                    };
                    lista.Add(car);
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

        public void quitarItem(int idprod, string idlogin)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_QUITAR_ITEM_CARRITO", cn);
            cmd.Parameters.AddWithValue("@ID_LOGIN", idlogin);
            cmd.Parameters.AddWithValue("@ID_PRODUCTO", idprod);
            cmd.CommandType = CommandType.StoredProcedure;
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

        public void vaciarCarrito(string idlogin)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_DELETE_CARRITO", cn);
            cmd.Parameters.AddWithValue("@ID_LOGIN", idlogin);
            cmd.CommandType = CommandType.StoredProcedure;
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

        public string totalItems(string idLogin)
        {
            string total = "0";
            if (idLogin != null)
            {
                SqlConnection cn = AccesoDB.getConnecta();
                SqlCommand cmd = new SqlCommand("USP_TOTAL_ITEMS_CARRITO", cn);
                cmd.Parameters.AddWithValue("@ID_LOGIN", idLogin);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        total = dr[0].ToString();
                    }
                    dr.Close();
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            return total;
        }
    }
}