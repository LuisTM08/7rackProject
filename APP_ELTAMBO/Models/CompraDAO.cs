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
    public class CompraDAO : ICrudCompra<DetalleCompra>
    {
        public List<DetalleCompra> listarCompra(string idlogin)
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_LISTACOMPRAS", cn);
            cmd.Parameters.AddWithValue("@ID_LOGIN", idlogin);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DetalleCompra compra = new DetalleCompra()
                    {
                        IdLogin = dr[0].ToString(),
                        IdProducto = Convert.ToInt32(dr[1]),
                        NombreProducto = dr[2].ToString(),
                        Descripcion = dr[3].ToString(),
                        FechaPedido =dr[4].ToString(),
                        Cantidad = Convert.ToInt32(dr[5]),
                        Total = Convert.ToDouble(dr[6]) 
                    };
                    lista.Add(compra);
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