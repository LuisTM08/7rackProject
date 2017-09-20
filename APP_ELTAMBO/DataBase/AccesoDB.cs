using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace APP_ELTAMBO.DataBase {
    public class AccesoDB {
        public static SqlConnection getConnecta() {
            SqlConnection cnx = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Tambo"].ConnectionString
                );
            return cnx;
        }
    }
}