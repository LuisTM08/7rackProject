using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_ELTAMBO.Services
{
    interface ICrudCupon<T>
    {
        List<T> listarCupon();
        void registrarCupon(T p);
        void actualizaCupon(T p);
        void borrarCupon(T p);
        T buscarCuponID(int id);
        T buscarCuponTexto(string cod);
    }
}
