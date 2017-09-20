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
    public class UbigeoDAO : IcrudRegion<Region>
    {
        SqlConnection cn = AccesoDB.getConnecta();

        public Region BuscarRegionID(int id)
        {
            Region obj = new Region();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_BUSCAR_REGION", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                obj.IdRegion = Convert.ToInt32(dr[0]);
                obj.NombreRegion = dr[1].ToString();
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return obj;
        }

        public List<Region> listarRegion()
        {
            List<Region> lista = new List<Region>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_REGION", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Region re = new Region()
                    {
                        IdRegion = Convert.ToInt32(dr[0]),
                        NombreRegion = dr[1].ToString()
                    };
                    lista.Add(re);
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

        public List<Provincia> listarProvincia(int idRegion)
        {
            List<Provincia> lista = new List<Provincia>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_BUSCAR_PROVINCIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_REGION", idRegion);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Provincia pro = new Provincia()
                    {
                        codProvincia = Convert.ToInt32(dr[0]),
                        NombreProvincia = dr[1].ToString()
                    };
                    lista.Add(pro);
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
        public List<Distrito> listarDistrito(int idProvincia)
        {
            List<Distrito> lista = new List<Distrito>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_BUSCAR_DISTRITO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PROV", idProvincia);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Distrito dis = new Distrito()
                    {
                        IdDistrito = Convert.ToInt32(dr[0]),
                        NombreDistrito = dr[1].ToString()
                    };
                    lista.Add(dis);
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