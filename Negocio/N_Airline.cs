using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Airline
    {
        public string Mensaje { get; set; }
        public List<E_Airline> Lista()
        {
            D_Airline airline1 = new D_Airline();
            if (airline1.Lista() != null)
            {
                return airline1.Lista();
            }
            else
            {
                Mensaje = airline1.Mensaje;
                return null;
            }
        }

        public E_Airline ObtenerAirline(string code)
        {
            D_Airline airline1 = new D_Airline();
            E_Airline airline2 = airline1.Obtener_Airline(code);
            if (airline2 != null)
            {
                return airline2;
            }
            else
            {
                Mensaje = airline1.Mensaje;
                return null;
            }
        }

        public bool Agregar(E_Airline airline1)
        {
            D_Airline airline2 = new D_Airline();
            if (airline2.Agregar(airline1))
            {
                return true;
            }
            else
            {
                Mensaje = airline2.Mensaje;
                return false;
            }
        }

        public bool Modificar(E_Airline airline1)
        {
            D_Airline airline2 = new D_Airline();
            if (airline2.Modificar(airline1))
            {
                return true;
            }
            else
            {
                Mensaje = airline2.Mensaje;
                return false;
            }
        }

        public bool Borrar(string code)
        {
            D_Airline airline1 = new D_Airline();
            if (airline1.Borrar(code))
            {
                return true;
            }
            else
            {
                Mensaje = airline1.Mensaje;
                return false;
            }
        }
    }
}
