#region Usos
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
#endregion

namespace Dominio.Entidades
{
    public interface BaseM : Modelo1<String>
    {
        String Guardar(string text);
    }
}