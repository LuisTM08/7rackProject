using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_ELTAMBO.Services
{
    interface ICrudProducto<T>
    {
        void registerProducto(T p);
        void updateProducto(T p);
        List<T> listarProductos();
    }
}
