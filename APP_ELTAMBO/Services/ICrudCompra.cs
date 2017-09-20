using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP_ELTAMBO.Entity;

namespace APP_ELTAMBO.Services
{
    interface ICrudCompra<T>
    {
        List<T> listarCompra(string idlogin);
    }
}
