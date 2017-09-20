using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Services;
using APP_ELTAMBO.DataBase;
using System.Data;
using System.Data.SqlClient;

namespace APP_ELTAMBO.Models
{
    public class UtilitarioDAO
    {
        public void insertImageUser(string idUser, string nombreImagen)
        {
            SqlConnection cn = AccesoDB.getConnecta();
            SqlCommand cmd = new SqlCommand("INSERT_IMAGE_USER", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_LOGIN", idUser);
            cmd.Parameters.AddWithValue("@NAMEIMAGEN", nombreImagen);
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
        public List<Combo> listarEstados()
        {
            List<Combo> lista = new List<Combo>();
            Combo Inactivo = new Combo();
            Combo Activo = new Combo();
            Activo.idCombo = "1";
            Activo.Descripcion = "Activo";
            lista.Add(Activo);

            Inactivo.idCombo = "2";
            Inactivo.Descripcion = "Inactivo";
            lista.Add(Inactivo);

            return lista;
        }
        public List<Combo> listarEstadoPago()
        {
            List<Combo> lista = new List<Combo>();
            Combo pagado = new Combo();
            Combo nopagado = new Combo();
            Combo cancelado = new Combo();
            pagado.idCombo = "1";
            pagado.Descripcion = "Pagado";
            lista.Add(pagado);

            nopagado.idCombo = "2";
            nopagado.Descripcion = "No pagado";
            lista.Add(nopagado);

            cancelado.idCombo = "3";
            cancelado.Descripcion = "Cancelado";
            lista.Add(cancelado);

            return lista;
        }
        public List<Combo> enPortada()
        {
            List<Combo> lista = new List<Combo>();
            Combo Home = new Combo();
            Combo Especial = new Combo();
            Combo NoMostrar = new Combo();
            Home.idCombo = "1";
            Home.Descripcion = "Por defecto";
            lista.Add(Home);
            Especial.idCombo = "2";
            Especial.Descripcion = "Visualizar en portada";
            lista.Add(Especial);
            NoMostrar.idCombo = "3";
            NoMostrar.Descripcion = "";
            
            return lista;
        }
        public List<Combo> listaEstadoPedido()
        {
            List<Combo> lista = new List<Combo>();
            Combo pedido = new Combo();
            Combo Enviado = new Combo();
            Combo Entregado = new Combo();
            pedido.idCombo = "1";
            pedido.Descripcion = "Pedido reservado";
            lista.Add(pedido);
            Enviado.idCombo = "2";
            Enviado.Descripcion = "Pedido enviado";
            lista.Add(Enviado);
            Entregado.idCombo = "3";
            Entregado.Descripcion = "Pedido Entregado";
            lista.Add(Entregado);
            return lista;
        }
    }
    
}