using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP_ELTAMBO.Entity;

namespace APP_ELTAMBO.Services
{
    interface ICrudContactoDAO<T>
    {
        void registerMensaje(T p);
    }
}
