using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Accounting_Info
    {
        public string Mensaje { get; set; }
        public List<E_Accounting_Info> Lista()
        {
            D_Accounting_Info accounting1 = new D_Accounting_Info();
            if(accounting1.Lista()!=null)
            {
                return accounting1.Lista();
            }
            else
            {
                Mensaje = accounting1.Mensaje;
                return null;
            }         
        }

        public E_Accounting_Info ObtenerAccountingInfo(string id)
        {
            D_Accounting_Info accounting1 = new D_Accounting_Info();
            E_Accounting_Info accounting2 = accounting1.Obtener_Accounting_Info(id);
            if (accounting2 !=null)
            {
                return accounting2;
            }
            else
            {
                Mensaje = accounting1.Mensaje;
                return null;
            }
        }

        public bool Agregar(E_Accounting_Info accounting1)
        {
            D_Accounting_Info accounting2 = new D_Accounting_Info();
            if(accounting2.Agregar(accounting1))
            {
                return true;
            }
            else
            {
                Mensaje=accounting2.Mensaje;
                return false;
            }
        }

        public bool Modificar(E_Accounting_Info accounting1)
        {
            D_Accounting_Info accounting2 = new D_Accounting_Info();
            if (accounting2.Modificar(accounting1))
            {
                return true;
            }
            else
            {
                Mensaje = accounting2.Mensaje;
                return false;
            }
        }

        public bool Borrar(string ID)
        {
            D_Accounting_Info accounting1 = new D_Accounting_Info();
            if (accounting1.Borrar(ID))
            {
                return true;
            }
            else
            {
                Mensaje = accounting1.Mensaje;
                return false;
            }
        }
    }
}
