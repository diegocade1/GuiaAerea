using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Airport
    {
        public string Mensaje { get; set; }
        public List<E_Airport> Lista()
        {
            D_Airport airport1 = new D_Airport();
            if (airport1.Lista() != null)
            {
                return airport1.Lista();
            }
            else
            {
                Mensaje = airport1.Mensaje;
                return null;
            }
        }

        public E_Airport ObtenerAirport(string id)
        {
            D_Airport airport1 = new D_Airport();
            E_Airport airport2 = airport1.Obtener_Airport(id);
            if (airport2 != null)
            {
                return airport2;
            }
            else
            {
                Mensaje = airport1.Mensaje;
                return null;
            }
        }

        public bool Agregar(E_Airport airport1)
        {
            D_Airport airport2 = new D_Airport();
            if (airport2.Agregar(airport1))
            {
                return true;
            }
            else
            {
                Mensaje = airport2.Mensaje;
                return false;
            }
        }

        public bool Modificar(E_Airport airport1)
        {
            D_Airport airport2 = new D_Airport();
            if (airport2.Modificar(airport1))
            {
                return true;
            }
            else
            {
                Mensaje = airport2.Mensaje;
                return false;
            }
        }

        public bool Borrar(string ID)
        {
            D_Airport airport1 = new D_Airport();
            if (airport1.Borrar(ID))
            {
                return true;
            }
            else
            {
                Mensaje = airport1.Mensaje;
                return false;
            }
        }
    }
}
