using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_ELTAMBO.Services
{
    interface ICrudRol<T>
    {
        void createRol(T r);
        void updateRol(T r);
        List<T> listarRoles();
        void deleteRol(T r);
    }
}
