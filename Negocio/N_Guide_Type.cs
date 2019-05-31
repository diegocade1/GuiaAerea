using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Guide_Type
    {
        public string Mensaje { get; set; }
        public List<E_Guide_Type> Lista()
        {
            D_Guide_Type type1 = new D_Guide_Type();
            if (type1.Lista() != null)
            {
                return type1.Lista();
            }
            else
            {
                Mensaje = type1.Mensaje;
                return null;
            }
        }

        public E_Guide_Type ObtenerTypeGuide(string id)
        {
            D_Guide_Type type1 = new D_Guide_Type();
            E_Guide_Type type2 = type1.Obtener_Type(id);
            if (type2 != null)
            {
                return type2;
            }
            else
            {
                Mensaje = type1.Mensaje;
                return null;
            }
        }

        public bool Agregar(E_Guide_Type type1)
        {
            D_Guide_Type type2 = new D_Guide_Type();
            if (type2.Agregar(type1))
            {
                return true;
            }
            else
            {
                Mensaje = type2.Mensaje;
                return false;
            }
        }

        public bool Modificar(E_Guide_Type type1)
        {
            D_Guide_Type type2 = new D_Guide_Type();
            if (type2.Modificar(type1))
            {
                return true;
            }
            else
            {
                Mensaje = type2.Mensaje;
                return false;
            }
        }

        public bool Borrar(string ID)
        {
            D_Guide_Type type1 = new D_Guide_Type();
            if (type1.Borrar(ID))
            {
                return true;
            }
            else
            {
                Mensaje = type1.Mensaje;
                return false;
            }
        }
    }
}
