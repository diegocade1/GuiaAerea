using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Consignee
    {
        public string Mensaje { get; set; }
        public List<E_Consignee> Lista()
        {
            D_Consignee consignee1 = new D_Consignee();
            if (consignee1.Lista() != null)
            {
                return consignee1.Lista();
            }
            else
            {
                Mensaje = consignee1.Mensaje;
                return null;
            }
        }

        public E_Consignee ObtenerConsignee(string id)
        {
            D_Consignee consignee1 = new D_Consignee();
            E_Consignee consignee2 = consignee1.Obtener_Consignee(id);
            if (consignee2 != null)
            {
                return consignee2;
            }
            else
            {
                Mensaje = consignee1.Mensaje;
                return null;
            }
        }

        public bool Agregar(E_Consignee consignee1)
        {
            D_Consignee consignee2 = new D_Consignee();
            if (consignee2.Agregar(consignee1))
            {
                return true;
            }
            else
            {
                Mensaje = consignee2.Mensaje;
                return false;
            }
        }

        public bool Modificar(E_Consignee consignee1)
        {
            D_Consignee consignee2 = new D_Consignee();
            if (consignee2.Modificar(consignee1))
            {
                return true;
            }
            else
            {
                Mensaje = consignee2.Mensaje;
                return false;
            }
        }

        public bool Borrar(string ID)
        {
            D_Consignee consignee1 = new D_Consignee();
            if (consignee1.Borrar(ID))
            {
                return true;
            }
            else
            {
                Mensaje = consignee1.Mensaje;
                return false;
            }
        }
    }
}
