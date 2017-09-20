using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Services
{
    interface IcrudRegion<T>
    {
        List<T> listarRegion();
        T BuscarRegionID(int id);
    }
}