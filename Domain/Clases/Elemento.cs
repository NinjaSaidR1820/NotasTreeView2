using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace winTreeView
{
    public class Elemento : IElemento
    {
        public string nodo;
        public string elemento;
        List<Elemento> lstElement = new List<Elemento>();

        public Elemento(string _nodo, string _elemento)
        {
            nodo = _nodo;
            elemento = _elemento;
        }


        public string getElementoCustom()
        {
            if(nodo == null)
            {
                info();
            }
            if(nodo == elemento){
                info2();   
            }
            return nodo;
        }

        public string info()
        {
            return "El nodo "+nodo +" Esta Vacio";
        }
        public string info2()
        {
            return "Proceda";
        }
    }
}
