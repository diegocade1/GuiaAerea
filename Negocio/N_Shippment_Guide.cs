using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Shippment_Guide
    {
        public string Mensaje { get; set; }

        public bool Agregar(E_Shipment_Guide guide1)
        {
            D_Shippment_Guide guide2 = new D_Shippment_Guide();
            if(guide2.Agregar(guide1))
            {
                return true;
            }
            else
            {
                Mensaje = guide2.Mensaje;
                return false;
            }
        }
    }
}
