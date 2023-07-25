using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace terapia_floral.UsuarioControl
{
    public partial class UC_pacientes : UserControl
    {
        public UC_pacientes()
        {
            InitializeComponent();
        }

        private void agregarUC_Paciente(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel_info_pacientes.Controls.Clear();
            panel_info_pacientes.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void contenedor_boton_nuevaconsulta_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_pacientes_Load(object sender, EventArgs e)
        {
            UC_paciente_sin__seleccion uc = new UC_paciente_sin__seleccion();
            agregarUC_Paciente(uc);
        }
    }
}
