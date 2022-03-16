#region Usos
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
#endregion

namespace Dominio.Entidades
{
    public interface Modelo1<T>
    {
        void Add(T t, T g);
        string Read(T t);
    }
}