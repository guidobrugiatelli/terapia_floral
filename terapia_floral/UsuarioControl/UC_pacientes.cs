using System;
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
            UC_paciente_sin_seleccion uc = new UC_paciente_sin_seleccion();
            agregarUC_Paciente(uc);
        }

        private void btn_nuevopaciente_Click(object sender, EventArgs e)
        {
            Form nuevo_paciente = new Formularios.nuevo_paciente();
            nuevo_paciente.ShowDialog();
        }
    }
}
