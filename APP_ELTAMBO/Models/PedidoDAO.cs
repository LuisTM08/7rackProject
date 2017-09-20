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
    public class PedidoDAO : ICrudPedido<Pedido>
    {
        public void insertarDetalle(int idpedido, Carrito item)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_DETALLE_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            double subtotal = item.Cantidad * item.PrecioUnidad;
            cmd.Parameters.AddWithValue("@IDPEDIDO", idpedido);
            cmd.Parameters.AddWithValue("@IDPRODUCTO", item.IdProducto);
            cmd.Parameters.AddWithValue("@CANTIDAD", item.Cantidad);
            cmd.Parameters.AddWithValue("@PRECIOUNITARIO", item.PrecioUnidad);
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
        public List<Pedido> listarPedidos()
        {
            List<Pedido> lista = new List<Pedido>();
            Pedido pe = null;
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pe = new Pedido();

                    pe.IdPedido = Convert.ToInt32(dr[0]);
                    pe.FechaPedido = dr[1].ToString();
                    pe.FechaEntrega = dr[2].ToString();
                    pe.FechaEnvio = dr[3].ToString();
                    pe.SubTotal = Convert.ToDouble(dr[4]);
                    pe.Envio = Convert.ToDouble(dr[5]);
                    pe.Descuento = (dr[6] == null) ? 0 : 0;
                    pe.Total = Convert.ToDouble(dr[7]);
                    pe.Direccion = dr[8].ToString();
                    pe.Referencia = dr[9].ToString();
                    pe.Distrito = dr[10].ToString();
                    pe.Provincia = dr[11].ToString();
                    pe.Region = dr[12].ToString();
                    pe.Pago = Convert.ToInt32(dr[13]);
                    pe.Estado = Convert.ToInt32(dr[14]);
                    pe.nombreUsuario = dr[15].ToString();
                    
                    lista.Add(pe);
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
        public Pedido buscarPedidoID(int id)
        {
            Pedido pe = new Pedido();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_BUSCAR_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PEDIDO", id);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    pe.IdPedido = Convert.ToInt32(dr[0]);
                    pe.FechaPedido = dr[1].ToString();
                    pe.FechaEntrega = dr[2].ToString();
                    pe.FechaEnvio = dr[3].ToString();
                    pe.SubTotal = Convert.ToDouble(dr[4]);
                    pe.Envio = Convert.ToDouble(dr[5]);
                    pe.Descuento = (dr[6] == null) ? 0 : 0;
                    pe.Total = Convert.ToDouble(dr[7]);
                    pe.Direccion = dr[8].ToString();
                    pe.Referencia = dr[9].ToString();
                    pe.Distrito = dr[10].ToString();
                    pe.Provincia = dr[11].ToString();
                    pe.Region = dr[12].ToString();
                    pe.Pago = Convert.ToInt32(dr[13]);
                    pe.Estado = Convert.ToInt32(dr[14]);
                    pe.nombreUsuario = dr[15].ToString();
                    pe.listaProductos = detallePedido(id);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return pe;
        }
        public void borrarPedido(Pedido p)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_DELETE_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PEDIDO", p.IdPedido);
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
        public int insertarPedido(Pedido p)
        {
            int resultado = 0;
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_CREAR_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_LOGIN", string.IsNullOrEmpty(p.IdUsuario) ? DBNull.Value : (object)p.IdUsuario);
            cmd.Parameters.AddWithValue("@SUBTOTAL", (p.SubTotal == 0) ? DBNull.Value : (object)p.SubTotal);
            cmd.Parameters.AddWithValue("@TOTAL", (p.Total == 0) ? DBNull.Value : (object)p.Total);
            cmd.Parameters.AddWithValue("@ENVIO", (p.Envio == 0) ? DBNull.Value : (object)p.Envio);
            cmd.Parameters.AddWithValue("@DESCUENTO", (p.Descuento == 0) ? DBNull.Value : (object)p.Descuento);
            cmd.Parameters.AddWithValue("@DIRECCION", string.IsNullOrEmpty(p.Direccion) ? DBNull.Value : (object)p.Direccion);
            cmd.Parameters.AddWithValue("@REFERENCIA", string.IsNullOrEmpty(p.Referencia) ? DBNull.Value : (object)p.Referencia);
            cmd.Parameters.AddWithValue("@DISTRITO", string.IsNullOrEmpty(p.Distrito) ? DBNull.Value : (object)p.Distrito);
            cmd.Parameters.AddWithValue("@PROVINCIA", string.IsNullOrEmpty(p.Provincia) ? DBNull.Value : (object)p.Provincia);
            cmd.Parameters.AddWithValue("@REGION", string.IsNullOrEmpty(p.Region) ? DBNull.Value : (object)p.Region);

            try
            {
                cn.Open();
                resultado = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return resultado;
        }
        public Pedido MiPedido(string idLogin)
        {
            Pedido pe = null;
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_USER_PEDIDO", cn);
            cmd.Parameters.AddWithValue("@ID_LOGIN", idLogin);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    pe = new Pedido()
                    {
                        IdPedido = Convert.ToInt32(dr[0]),
                        FechaPedido = dr[1].ToString(),
                        SubTotal = Convert.ToDouble(dr[2]),
                        Envio = Convert.ToDouble(dr[3]),
                        Descuento = (dr[4]==null)? 0 : 0,
                        Total = Convert.ToDouble(dr[5]),
                        Pago = Convert.ToInt32(dr[6]),
                        Estado = Convert.ToInt32(dr[7]),
                        Direccion = dr[8].ToString(),
                        Referencia = dr[9].ToString(),
                        Distrito = dr[10].ToString(),
                        Provincia = dr[11].ToString(),
                        Region = dr[12].ToString()
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return pe;
        }
        public List<PedidoDetalle> detallePedido(int idPedido)
        {
            List<PedidoDetalle> lista = new List<PedidoDetalle>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_LISTA_DETALLE_PEDIDO", cn);
            cmd.Parameters.AddWithValue("@ID_PEDIDO", idPedido);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PedidoDetalle pe = new PedidoDetalle()
                    {
                        IdPedido = Convert.ToInt32(dr[0]),
                        IdProducto = Convert.ToInt32(dr[1]),
                        nomProducto = dr[2].ToString(),
                        PrecioUnidad = Convert.ToDouble(dr[3]),
                        Cantidad = Convert.ToInt32(dr[4]),
                        SubTotal = Convert.ToDouble(dr[5]),
                        Imagen = dr[6].ToString(),
                        Descripcion = dr[7].ToString()
                    };
                    lista.Add(pe);
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
    }
}