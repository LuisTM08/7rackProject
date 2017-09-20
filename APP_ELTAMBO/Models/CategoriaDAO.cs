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
    public class CategoriaDAO : ICrudCategoria<Categoria>
    {
        public Categoria buscarCategoriaID(int id)
        {
            Categoria cat = new Categoria();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_SEARCH_CATEGORIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CAT", id);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cat.IdCategoria = (int)dr[0];
                    cat.NombreCat = dr[1].ToString();
                    cat.Estado = (int)dr[2];
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return cat;
        }

        public void deleteCategoria(Categoria cat)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_DELETE_CATEGORIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CAT", cat.IdCategoria);
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

        public void insertCategoria(Categoria cat)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_CREATE_CATEGORIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", cat.NombreCat);
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

        public List<Categoria> listarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_LISTA_CATERGORIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Categoria user = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(dr[0]),
                        NombreCat = dr[1].ToString(),
                        Estado = Convert.ToInt32(dr[2])
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

        public void updateCategoria(Categoria cat)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USP_UPDATE_CATEGORIA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CAT", cat.IdCategoria);
            cmd.Parameters.AddWithValue("@NOMBRE", cat.NombreCat);
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