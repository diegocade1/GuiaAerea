using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emision_de_Guia_Aerea
{
    public partial class frmEmisionGuiaEmbarqueAerea : Form
    {
        public frmEmisionGuiaEmbarqueAerea()
        {
            InitializeComponent();
        }

        private void frmEmisionGuiaEmbarqueAerea_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            N_PDF pdf = new N_PDF();
            try
            {
                pdf.GenerarPDF();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
