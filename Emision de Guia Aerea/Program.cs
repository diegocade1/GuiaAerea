using Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emision_de_Guia_Aerea
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            N_MySQL con = new N_MySQL();
            con.setConnectionString(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString);
            Application.Run(new frmEmisionGuiaEmbarqueAerea());
        }
    }
}
