using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_ELTAMBO.Services
{
    interface ICrudMarca<T>
    {
        List<T> listarMarcas();
        T buscarMarcaID(int id);
        void insertMarca(T cat);
        void updateMarca(T cat);
        void deleteMarca(T cat);
    }
}
