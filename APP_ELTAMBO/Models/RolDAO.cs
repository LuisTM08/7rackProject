using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Services;
using APP_ELTAMBO.DataBase;
using System.Data;
using System.Data.SqlClient;

namespace APP_ELTAMBO.Models
{
    public class RolDAO : ICrudRol<Rol>
    {
        public void createRol(Rol r)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var rolManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                //Creamos el rol
                var resultado = rolManager.Create(new IdentityRole(r.NombreRol));
            }
        }

        public void deleteRol(Rol r)
        {
            throw new NotImplementedException();
        }

        public List<Rol> listarRoles()
        {
            List<Rol> lista = new List<Rol>();
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("USO_LIST_ROL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Rol r = new Rol()
                    {
                        idRol = dr[0].ToString(),
                        NombreRol = dr[1].ToString(),
                    };
                    lista.Add(r);
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

        public void updateRol(Rol r)
        {
            throw new NotImplementedException();
        }
    }
}