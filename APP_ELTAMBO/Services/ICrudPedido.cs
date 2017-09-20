using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP_ELTAMBO.Entity;

namespace APP_ELTAMBO.Services
{
    interface ICrudPedido<T>
    {
        int insertarPedido(T p);
        void insertarDetalle(int idpedido, Carrito list);
    }
}
