using Guna.UI2.WinForms;
using System;
using System.Configuration;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using terapia_floral.Formularios;

namespace terapia_floral.UsuarioControl
{
    public partial class UC_pacientes : UserControl
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        public UC_pacientes()
        {
            InitializeComponent();
        }

        public void agregarUC_Paciente(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel_info_pacientes.Controls.Clear();
            panel_info_pacientes.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void UC_pacientes_Load(object sender, EventArgs e)
        {
            UC_paciente_sin_seleccion uc = new UC_paciente_sin_seleccion();
            agregarUC_Paciente(uc);
            GenerarPanelesPacientes();
        }

        private void btn_nuevopaciente_Click(object sender, EventArgs e)
        {
            nuevo_paciente formularioNuevoPaciente = new nuevo_paciente();
            formularioNuevoPaciente.FormClosed += FormularioNuevoPaciente_FormClosed;
            formularioNuevoPaciente.TopMost = true;
            formularioNuevoPaciente.ShowDialog();
        }

        private void FormularioNuevoPaciente_FormClosed(object sender, FormClosedEventArgs e)
        {
            nuevo_paciente formularioNuevoPaciente = (nuevo_paciente)sender;

            string nuevoIDPaciente = formularioNuevoPaciente.PacienteID;

            detallePaciente(nuevoIDPaciente);
            GenerarPanelesPacientes();
        }

        public void GenerarPanelesPacientes()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(database))
                {
                    connection.Open();

                    // Consulta SQL para obtener los campos nombreapellido y ultimaconsulta
                    string consulta = "SELECT id, nombreapellido, ultimaconsulta FROM pacientes";

                    using (SQLiteCommand command = new SQLiteCommand(consulta, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            panel_todoslospacientes.Controls.Clear();
                            Obtener_pacientes(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pacientes: " + ex.Message);
            }
        }

        private void Filtrar_por_nombreyapellido(string busqueda)   
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(database))
                {
                    connection.Open();

                    // Consulta SQL para obtener los campos nombreapellido y ultimaconsulta
                    string consulta = "SELECT id, nombreapellido, ultimaconsulta FROM Pacientes WHERE nombreapellido LIKE @busqueda";

                    using (SQLiteCommand command = new SQLiteCommand(consulta, connection))
                    {
                        command.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            panel_todoslospacientes.Controls.Clear(); // Limpiamos los paneles actuales
                            Obtener_pacientes(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pacientes: " + ex.Message);
            }
        }

        private void txt_buscarpaciente_TextChanged(object sender, EventArgs e)
        {
            Filtrar_por_nombreyapellido(txt_buscarpaciente.Text);
        }

        public void detallePaciente(string id)
        {
            UC_paciente_seleccionado uc = new UC_paciente_seleccionado(id);
            agregarUC_Paciente(uc);
        }

        private void Obtener_pacientes(SQLiteDataReader reader)
        {
            int panelOffsetY = 5; // Espaciado vertical entre paneles
            while (reader.Read())
            {
                // Obtenemos los valores de cada fila
                string nombreApellido = reader["nombreapellido"].ToString();
                string ultimaConsulta = reader["ultimaconsulta"].ToString();
                string id = reader["id"].ToString();

                // Crear el panel para el paciente
                Panel panelPaciente = new Panel();
                panelPaciente.BorderStyle = BorderStyle.None;
                panelPaciente.Size = new Size(panel_todoslospacientes.Width - 20 , 50);
                panelPaciente.Location = new Point(0, panelOffsetY); // Ubicación del panel

                // Crear los labels para los datos del paciente
                Label labelNombreApellido = new Label();
                labelNombreApellido.Text = nombreApellido;
                labelNombreApellido.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
                labelNombreApellido.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                labelNombreApellido.AutoSize = true;
                labelNombreApellido.Location = new Point(5, 5); // Ubicación del primer label

                if (nombreApellido.Length > 20)
                {
                    labelNombreApellido.Text = nombreApellido.Substring(0, 20) + "...";
                    ToolTip toolTip = new ToolTip();
                    toolTip.SetToolTip(labelNombreApellido, nombreApellido); // Mostrar el nombre completo en el tooltip
                }
                else
                {
                    labelNombreApellido.Text = nombreApellido;
                }


                Label labelUltimaConsulta = new Label();
                
                if (!string.IsNullOrEmpty(ultimaConsulta))
                {
                    string[] resultado = ultimaConsulta.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    labelUltimaConsulta.Text = "Última consulta: " + resultado[2] + '/' + resultado[1] + '/' + resultado[0];
                } else
                {
                    string[] resultado = ultimaConsulta.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    labelUltimaConsulta.Text = "Última consulta: --/--/----";
                }

                labelUltimaConsulta.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                labelUltimaConsulta.ForeColor = Color.DarkGray;
                labelUltimaConsulta.AutoSize = true;
                labelUltimaConsulta.Location = new Point(5, labelNombreApellido.Bottom + 1); // Ubicación del segundo label

                Guna2Button btnVerDetalles = new Guna2Button();
                btnVerDetalles.AutoRoundedCorners = true;
                btnVerDetalles.Tag = id;
                btnVerDetalles.FillColor = Color.ForestGreen;
                btnVerDetalles.Animated = true;
                btnVerDetalles.Cursor = Cursors.Hand;
                btnVerDetalles.Text = "Ver";
                btnVerDetalles.Size = new Size(50, 30);
                btnVerDetalles.Location = new Point(panelPaciente.Width - btnVerDetalles.Width - 5, (panelPaciente.Height - btnVerDetalles.Height) / 2); // Ubicación del botón a la derecha
                btnVerDetalles.Click += (sender, e) => detallePaciente(id);

                btnVerDetalles.Anchor = AnchorStyles.Right | AnchorStyles.Top;

                panelPaciente.Controls.Add(labelNombreApellido);
                panelPaciente.Controls.Add(labelUltimaConsulta);
                panelPaciente.Controls.Add(btnVerDetalles);

                panel_todoslospacientes.Controls.Add(panelPaciente);
                
                panelOffsetY += panelPaciente.Height + 5;
            }
        }

    }
}
