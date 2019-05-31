using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Guide
    {
        public string Mensaje { get; set; }
        public List<E_Guide> Lista()
        {
            D_Guide guide1 = new D_Guide();
            if (guide1.Lista() != null)
            {
                return guide1.Lista();
            }
            else
            {
                Mensaje = guide1.Mensaje;
                return null;
            }
        }

        public E_Guide ObtenerGuide(string guide)
        {
            D_Guide guide1 = new D_Guide();
            E_Guide accounting2 = guide1.Obtener_Guide(guide);
            if (accounting2 != null)
            {
                return accounting2;
            }
            else
            {
                Mensaje = guide1.Mensaje;
                return null;
            }
        }

        public bool Agregar(E_Guide guide1)
        {
            D_Guide accounting2 = new D_Guide();
            if (accounting2.Agregar(guide1))
            {
                return true;
            }
            else
            {
                Mensaje = accounting2.Mensaje;
                return false;
            }
        }

        public bool Modificar(E_Guide guide1)
        {
            D_Guide accounting2 = new D_Guide();
            if (accounting2.Modificar(guide1))
            {
                return true;
            }
            else
            {
                Mensaje = accounting2.Mensaje;
                return false;
            }
        }

        public bool Borrar(string guide)
        {
            D_Guide guide1 = new D_Guide();
            if (guide1.Borrar(guide))
            {
                return true;
            }
            else
            {
                Mensaje = guide1.Mensaje;
                return false;
            }
        }
    }
}
