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
    public class ProductoDAO: ICrudProducto<Producto>
    {
        public void registerProducto(Producto p)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_CREATE_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", string.IsNullOrEmpty(p.NombreProd) ? DBNull.Value : (object)p.NombreProd);
            cmd.Parameters.AddWithValue("@DESCRIPCION", string.IsNullOrEmpty(p.DescripcionPro) ? DBNull.Value : (object)p.DescripcionPro);
            cmd.Parameters.AddWithValue("@PRECIO", (p.PrecioUnitario == 0) ? DBNull.Value : (object)p.PrecioUnitario);
            cmd.Parameters.AddWithValue("@STOCK", (p.Stock == 0) ? DBNull.Value : (object)p.Stock);
            cmd.Parameters.AddWithValue("@IDCATEGORIA", (p.IdCategoria == 0) ? DBNull.Value : (object)p.IdCategoria);
            cmd.Parameters.AddWithValue("@IDMARCA", (p.IdMarca == 0) ? DBNull.Value : (object)p.IdMarca);
            cmd.Parameters.AddWithValue("@ENPORTADA", (p.EnPortada == 0) ? DBNull.Value : (object)p.EnPortada);
            cmd.Parameters.AddWithValue("@IMAGEN", string.IsNullOrEmpty(p.ImagenProducto) ? DBNull.Value : (object)p.ImagenProducto);
            cmd.Parameters.AddWithValue("@ESTADO", p.Estado);
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
        //Por Categoria

        public List<Producto> listarCategoriaProductos(int? CategoriaID)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_SEARCH_PRODUCTO_CATEGORIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCategoria", CategoriaID);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto prod = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        NombreProd = dr[1].ToString(),
                        DescripcionPro = dr[2].ToString(),
                        PrecioUnitario = Convert.ToDouble(dr[3]),
                        Stock = Convert.ToInt32(dr[4]),
                        IdCategoria = Convert.ToInt32(dr[5]),
                        NombreCategoria = dr[6].ToString(),
                        IdMarca = Convert.ToInt32(dr[7]),
                        NombreMarca = dr[8].ToString(),
                        EnPortada = Convert.ToInt32(dr[9]),
                        ImagenProducto = dr[10].ToString(),
                        Estado = Convert.ToInt32(dr[11])
                    };
                    lista.Add(prod);
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
        public List<Producto> listarProductos()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_LIST_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto prod = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        NombreProd = dr[1].ToString(),
                        DescripcionPro = dr[2].ToString(),
                        PrecioUnitario = Convert.ToDouble(dr[3]),
                        Stock = Convert.ToInt32(dr[4]),
                        IdCategoria = Convert.ToInt32(dr[5]),
                        NombreCategoria = dr[6].ToString(),
                        IdMarca = Convert.ToInt32(dr[7]),
                        NombreMarca = dr[8].ToString(),
                        EnPortada = Convert.ToInt32(dr[9]),
                        ImagenProducto = dr[10].ToString(),
                        Estado = Convert.ToInt32(dr[11])
                    };
                    lista.Add(prod);
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

        public List<Producto> listarProductosHome()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_CURRENT_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto prod = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        NombreProd = dr[1].ToString(),
                        DescripcionPro = dr[2].ToString(),
                        PrecioUnitario = Convert.ToDouble(dr[3]),
                        Stock = Convert.ToInt32(dr[4]),
                        IdCategoria = Convert.ToInt32(dr[5]),
                        NombreCategoria = dr[6].ToString(),
                        IdMarca = Convert.ToInt32(dr[7]),
                        NombreMarca = dr[8].ToString(),
                        EnPortada = Convert.ToInt32(dr[9]),
                        ImagenProducto = dr[10].ToString(),
                        Estado = Convert.ToInt32(dr[11])
                    };
                    lista.Add(prod);
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

        public List<Producto> listarProductosRecomendados()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_RECOMENDADO_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto prod = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        NombreProd = dr[1].ToString(),
                        DescripcionPro = dr[2].ToString(),
                        PrecioUnitario = Convert.ToDouble(dr[3]),
                        Stock = Convert.ToInt32(dr[4]),
                        IdCategoria = Convert.ToInt32(dr[5]),
                        NombreCategoria = dr[6].ToString(),
                        IdMarca = Convert.ToInt32(dr[7]),
                        NombreMarca = dr[8].ToString(),
                        EnPortada = Convert.ToInt32(dr[9]),
                        ImagenProducto = dr[10].ToString(),
                        Estado = Convert.ToInt32(dr[11])
                    };
                    lista.Add(prod);
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

        public List<Producto> listarProductosPortada()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_PORTADA_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto prod = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        NombreProd = dr[1].ToString(),
                        DescripcionPro = dr[2].ToString(),
                        PrecioUnitario = Convert.ToDouble(dr[3]),
                        Stock = Convert.ToInt32(dr[4]),
                        IdCategoria = Convert.ToInt32(dr[5]),
                        NombreCategoria = dr[6].ToString(),
                        IdMarca = Convert.ToInt32(dr[7]),
                        NombreMarca = dr[8].ToString(),
                        EnPortada = Convert.ToInt32(dr[9]),
                        ImagenProducto = dr[10].ToString(),
                        Estado = Convert.ToInt32(dr[11])
                    };
                    lista.Add(prod);
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
        public Producto buscarProductoID(int id)
        {
            Producto prod = null;
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_SEARCH_PRODUCTO_ID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDPRODUCTO", id);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    prod = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        NombreProd = dr[1].ToString(),
                        DescripcionPro = dr[2].ToString(),
                        PrecioUnitario = Convert.ToDouble(dr[3]),
                        Stock = Convert.ToInt32(dr[4]),
                        IdCategoria = Convert.ToInt32(dr[5]),
                        NombreCategoria = dr[6].ToString(),
                        IdMarca = Convert.ToInt32(dr[7]),
                        NombreMarca = dr[8].ToString(),
                        EnPortada = Convert.ToInt32(dr[9]),
                        ImagenProducto = dr[10].ToString(),
                        Estado = Convert.ToInt32(dr[11])
                    };
                }
            }
            catch (SqlException ex) { throw ex; }
            return prod;
        }

        public void updateProducto(Producto p)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_UPDATE_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDPRODUCTO", (p.IdProducto==0) ? DBNull.Value : (object)p.IdProducto);
            cmd.Parameters.AddWithValue("@NOMBRE", string.IsNullOrEmpty(p.NombreProd) ? DBNull.Value : (object)p.NombreProd);
            cmd.Parameters.AddWithValue("@DESCRIPCION", string.IsNullOrEmpty(p.DescripcionPro) ? DBNull.Value : (object)p.DescripcionPro);
            cmd.Parameters.AddWithValue("@PRECIO", (p.PrecioUnitario == 0) ? DBNull.Value : (object)p.PrecioUnitario);
            cmd.Parameters.AddWithValue("@STOCK", (p.Stock == 0) ? DBNull.Value : (object)p.Stock);
            cmd.Parameters.AddWithValue("@IDCATEGORIA", (p.IdCategoria == 0) ? DBNull.Value : (object)p.IdCategoria);
            cmd.Parameters.AddWithValue("@IDMARCA", (p.IdMarca == 0) ? DBNull.Value : (object)p.IdMarca);
            cmd.Parameters.AddWithValue("@ENPORTADA", (p.EnPortada == 0) ? 0 : (object)p.EnPortada);
            cmd.Parameters.AddWithValue("@IMAGEN", string.IsNullOrEmpty(p.ImagenProducto) ? DBNull.Value : (object)p.ImagenProducto);
            cmd.Parameters.AddWithValue("@ESTADO", p.Estado);
            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        //FILTROS

        //Por Nombre o Descripción

        public List<Producto> listarSearchProductos(string filtro)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_SEARCH_ALL_PRODUCTOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@filter", filtro);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto prod = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        NombreProd = dr[1].ToString(),
                        DescripcionPro = dr[2].ToString(),
                        PrecioUnitario = Convert.ToDouble(dr[3]),
                        Stock = Convert.ToInt32(dr[4]),
                        IdCategoria = Convert.ToInt32(dr[5]),
                        NombreCategoria = dr[6].ToString(),
                        IdMarca = Convert.ToInt32(dr[7]),
                        NombreMarca = dr[8].ToString(),
                        EnPortada = Convert.ToInt32(dr[9]),
                        ImagenProducto = dr[10].ToString(),
                        Estado = Convert.ToInt32(dr[11])
                    };
                    lista.Add(prod);
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