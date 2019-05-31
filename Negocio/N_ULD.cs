using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_ULD
    {
        public string Mensaje { get; set; }
        public List<E_ULD> Lista()
        {
            D_ULD udl1 = new D_ULD();
            if (udl1.Lista() != null)
            {
                return udl1.Lista();
            }
            else
            {
                Mensaje = udl1.Mensaje;
                return null;
            }
        }

        public E_ULD ObtenerULD(string id)
        {
            D_ULD udl1 = new D_ULD();
            E_ULD udl2 = udl1.Obtener_ULD(id);
            if (udl2 != null)
            {
                return udl2;
            }
            else
            {
                Mensaje = udl1.Mensaje;
                return null;
            }
        }

        public bool Agregar(E_ULD udl1)
        {
            D_ULD udl2 = new D_ULD();
            if (udl2.Agregar(udl1))
            {
                return true;
            }
            else
            {
                Mensaje = udl2.Mensaje;
                return false;
            }
        }

        public bool Modificar(E_ULD udl1)
        {
            D_ULD udl2 = new D_ULD();
            if (udl2.Modificar(udl1))
            {
                return true;
            }
            else
            {
                Mensaje = udl2.Mensaje;
                return false;
            }
        }

        public bool Borrar(string ID)
        {
            D_ULD udl1 = new D_ULD();
            if (udl1.Borrar(ID))
            {
                return true;
            }
            else
            {
                Mensaje = udl1.Mensaje;
                return false;
            }
        }
    }
}
