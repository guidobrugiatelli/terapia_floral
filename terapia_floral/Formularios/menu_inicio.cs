using System;
using System.Windows.Forms;
using terapia_floral.UsuarioControl;

namespace terapia_floral
{
    public partial class menu_inicio : Form
    {
        public menu_inicio()
        {
            InitializeComponent();
        }

        private void agregarUC(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel_informacion.Controls.Clear();
            panel_informacion.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btn_pacientes_Click(object sender, EventArgs e)
        {
            UC_pacientes uc = new UC_pacientes();
            agregarUC(uc);
        }

        private void btn_flores_Click(object sender, EventArgs e)
        {
            UC_flores uc = new UC_flores();
            agregarUC(uc);
        }

        private void menu_inicio_Load(object sender, EventArgs e)
        {
            UC_pacientes uc = new UC_pacientes();
            agregarUC(uc);
        }

    }
}
