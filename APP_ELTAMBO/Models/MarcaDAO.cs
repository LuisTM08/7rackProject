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
    public class MarcaDAO : ICrudMarca<Marca>
    {
        public Marca buscarMarcaID(int id)
        {
            Marca mar = new Marca();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_SEARCH_MARCA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_MAR", id);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    mar.IdMarca = (int)dr[0];
                    mar.NombreMarca = dr[1].ToString();
                    mar.Estado = (int)dr[2];
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return mar;
        }

        public void deleteMarca(Marca cat)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_DELETE_MARCA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_MAR", cat.IdMarca);
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

        public void insertMarca(Marca cat)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_CREATE_MARCA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", cat.NombreMarca);
            cmd.Parameters.AddWithValue("@ESTADO", cat.Estado);
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

        public List<Marca> listarMarcas()
        {
            List<Marca> lista = new List<Marca>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_LISTA_MARCA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Marca mar = new Marca()
                    {
                        IdMarca = Convert.ToInt32(dr[0]),
                        NombreMarca = dr[1].ToString(),
                        Estado = Convert.ToInt32(dr[2])
                    };
                    lista.Add(mar);
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

        public void updateMarca(Marca cat)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_UPDATE_MARCA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_MAR", cat.IdMarca);
            cmd.Parameters.AddWithValue("@NOMBRE", cat.NombreMarca);
            cmd.Parameters.AddWithValue("@ESTADO", cat.Estado);
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