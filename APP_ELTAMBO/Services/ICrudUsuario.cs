using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_ELTAMBO.Services
{
    interface ICrudUsuario<T>
    {
        void UpdateUser(T p);
        void Detele(T p);
        List<T> ListarUsuarios();
        T BuscarUsuarioPorID(string IdLogin);
        string BuscarEmailUsuario(string IdLogin);
    }
}
