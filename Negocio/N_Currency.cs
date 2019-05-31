using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Currency
    {
        public string Mensaje { get; set; }
        public List<E_Currency> Lista()
        {
            D_Currency currency1 = new D_Currency();
            if (currency1.Lista() != null)
            {
                return currency1.Lista();
            }
            else
            {
                Mensaje = currency1.Mensaje;
                return null;
            }
        }

        public E_Currency ObtenerCurrency(string id)
        {
            D_Currency currency1 = new D_Currency();
            E_Currency currency2 = currency1.Obtener_Currency(id);
            if (currency2 != null)
            {
                return currency2;
            }
            else
            {
                Mensaje = currency1.Mensaje;
                return null;
            }
        }

        public bool Agregar(E_Currency currency1)
        {
            D_Currency currency2 = new D_Currency();
            if (currency2.Agregar(currency1))
            {
                return true;
            }
            else
            {
                Mensaje = currency2.Mensaje;
                return false;
            }
        }

        public bool Modificar(E_Currency currency1)
        {
            D_Currency currency2 = new D_Currency();
            if (currency2.Modificar(currency1))
            {
                return true;
            }
            else
            {
                Mensaje = currency2.Mensaje;
                return false;
            }
        }

        public bool Borrar(string ID)
        {
            D_Currency currency1 = new D_Currency();
            if (currency1.Borrar(ID))
            {
                return true;
            }
            else
            {
                Mensaje = currency1.Mensaje;
                return false;
            }
        }
    }
}
