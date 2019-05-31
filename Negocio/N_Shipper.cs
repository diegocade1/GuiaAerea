using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Shipper
    {
        public string Mensaje { get; set; }
        public List<E_Shipper> Lista()
        {
            D_Shipper shipper1 = new D_Shipper();
            if (shipper1.Lista() != null)
            {
                return shipper1.Lista();
            }
            else
            {
                Mensaje = shipper1.Mensaje;
                return null;
            }
        }

        public E_Shipper ObtenerShipper(string id)
        {
            D_Shipper shipper1 = new D_Shipper();
            E_Shipper shipper2 = shipper1.Obtener_Shipper(id);
            if (shipper2 != null)
            {
                return shipper2;
            }
            else
            {
                Mensaje = shipper1.Mensaje;
                return null;
            }
        }

        public bool Agregar(E_Shipper shipper1)
        {
            D_Shipper shipper2 = new D_Shipper();
            if (shipper2.Agregar(shipper1))
            {
                return true;
            }
            else
            {
                Mensaje = shipper2.Mensaje;
                return false;
            }
        }

        public bool Modificar(E_Shipper shipper1)
        {
            D_Shipper shipper2 = new D_Shipper();
            if (shipper2.Modificar(shipper1))
            {
                return true;
            }
            else
            {
                Mensaje = shipper2.Mensaje;
                return false;
            }
        }

        public bool Borrar(string ID)
        {
            D_Shipper shipper1 = new D_Shipper();
            if (shipper1.Borrar(ID))
            {
                return true;
            }
            else
            {
                Mensaje = shipper1.Mensaje;
                return false;
            }
        }
    }
}
