using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_MySQL
    {
        public void setConnectionString(string conexion)
        {
            D_MySQL.StringConexion = conexion;
        }
    }
}
