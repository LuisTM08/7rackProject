using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP_ELTAMBO.Entity;

namespace APP_ELTAMBO.Services
{
    interface ICrubCarrito<T>
    {
        List<T> listarCarrito(string idlogin);
        void insertarItem(Producto pro, int cantidad, string idlogin);
        void quitarItem(int idprod, string idlogin);
    }
}
