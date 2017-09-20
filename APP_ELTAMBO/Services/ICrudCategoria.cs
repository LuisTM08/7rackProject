using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_ELTAMBO.Services
{
    interface ICrudCategoria<T>
    {
        List<T> listarCategorias();
        T buscarCategoriaID(int id);
        void insertCategoria(T cat);
        void updateCategoria(T cat);
        void deleteCategoria(T cat);
    }
}
