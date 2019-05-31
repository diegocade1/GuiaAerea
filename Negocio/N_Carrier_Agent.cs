using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Carrier_Agent
    {
        public string Mensaje { get; set; }
        public List<E_Carrier_Agent> Lista()
        {
            D_Carrier_Agent agent1 = new D_Carrier_Agent();
            if (agent1.Lista() != null)
            {
                return agent1.Lista();
            }
            else
            {
                Mensaje = agent1.Mensaje;
                return null;
            }
        }

        public E_Carrier_Agent ObtenerCarrierAgent(string id)
        {
            D_Carrier_Agent agent1 = new D_Carrier_Agent();
            E_Carrier_Agent agent2 = agent1.Obtener_Agent(id);
            if (agent2 != null)
            {
                return agent2;
            }
            else
            {
                Mensaje = agent1.Mensaje;
                return null;
            }
        }

        public bool Agregar(E_Carrier_Agent agent1)
        {
            D_Carrier_Agent agent2 = new D_Carrier_Agent();
            if (agent2.Agregar(agent1))
            {
                return true;
            }
            else
            {
                Mensaje = agent2.Mensaje;
                return false;
            }
        }

        public bool Modificar(E_Carrier_Agent agent1)
        {
            D_Carrier_Agent agent2 = new D_Carrier_Agent();
            if (agent2.Modificar(agent1))
            {
                return true;
            }
            else
            {
                Mensaje = agent2.Mensaje;
                return false;
            }
        }

        public bool Borrar(string ID)
        {
            D_Carrier_Agent agent1 = new D_Carrier_Agent();
            if (agent1.Borrar(ID))
            {
                return true;
            }
            else
            {
                Mensaje = agent1.Mensaje;
                return false;
            }
        }
    }
}
