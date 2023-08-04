using Guna.UI2.WinForms;
using System;
using System.Configuration;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using terapia_floral.Formularios;

namespace terapia_floral.UsuarioControl
{
    public partial class UC_paciente_seleccionado : UserControl
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        private string idPaciente;

        public UC_paciente_seleccionado(string id)
        {
            InitializeComponent();
            idPaciente = id;
        }

        private void UC_paciente_seleccionado_Load(object sender, EventArgs e)
        {
            obtenerPaciente();
            obtenerHistorial();
        }

        private void obtenerPaciente()
        {
            panelInfoPaciente.Controls.Clear();

            string sql = "SELECT * FROM pacientes WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idPaciente);
                connection.Open();

                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) { 
                        while (reader.Read())
                        {
                            string nombre = reader["nombreapellido"].ToString();
                            string fechaHora = reader["fechanacimiento"].ToString();
                            string lugarHoraNacimiento = reader["lugarhora"].ToString();
                            string dondeQuien = reader["dondevive"].ToString();
                            string conviveAnimal = reader["conviveanimal"].ToString();
                            string ocupacion = reader["ocupacion"].ToString();
                            string enfermedades = reader["enfermedades"].ToString();
                            string celular = reader["celular"].ToString();
                            string correo = reader["correo"].ToString();

                            NombreApellido.Text = nombre;

                            Label labelFechaHora = new Label();
                            Label labelLugarHoraNacimiento = new Label();
                            Label labelDondeQuien = new Label();
                            Label labelConviveAnimal = new Label();
                            Label labelOcupacion = new Label();
                            Label labelEnfermedades = new Label();
                            Label labelCelular = new Label();
                            Label labelCorreo = new Label();

                            labelFechaHora.Text = "Fecha de nacimiento: " + fechaHora;
                            labelFechaHora.BackColor = Color.Transparent;
                            labelFechaHora.Location = new Point(10, 10);
                            labelFechaHora.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelFechaHora.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                            labelFechaHora.Width = panelInfoPaciente.Width;

                            labelLugarHoraNacimiento.Text = "Lugar y hora de nacimiento: " + lugarHoraNacimiento;
                            labelLugarHoraNacimiento.BackColor = Color.Transparent;
                            labelLugarHoraNacimiento.Location = new Point(10, 35);
                            labelLugarHoraNacimiento.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelLugarHoraNacimiento.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                            labelLugarHoraNacimiento.Width = panelInfoPaciente.Width;

                            labelDondeQuien.Text = "Donde y con quien vive: " + dondeQuien;
                            labelDondeQuien.BackColor = Color.Transparent;
                            labelDondeQuien.Location = new Point(10, 60);
                            labelDondeQuien.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelDondeQuien.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                            labelDondeQuien.Width = panelInfoPaciente.Width;

                            labelConviveAnimal.Text = "¿Convive con algún animal?: " + conviveAnimal;
                            labelConviveAnimal.BackColor = Color.Transparent;
                            labelConviveAnimal.Location = new Point(10, 85);
                            labelConviveAnimal.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelConviveAnimal.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                            labelConviveAnimal.Width = panelInfoPaciente.Width;

                            labelOcupacion.Text = "Ocupación: " + ocupacion;
                            labelOcupacion.BackColor = Color.Transparent;
                            labelOcupacion.Location = new Point(10, 110);
                            labelOcupacion.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelOcupacion.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                            labelOcupacion.Width = panelInfoPaciente.Width;

                            labelEnfermedades.Text = "Enfermedades / Alergias: " + enfermedades;
                            labelEnfermedades.BackColor = Color.Transparent;
                            labelEnfermedades.Location = new Point(10, 135);
                            labelEnfermedades.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelEnfermedades.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                            labelEnfermedades.Width = panelInfoPaciente.Width;

                            labelCelular.Text = "Celular: " + celular;
                            labelCelular.BackColor = Color.Transparent;
                            labelCelular.Location = new Point(10, 160);
                            labelCelular.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelCelular.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                            labelCelular.Width = panelInfoPaciente.Width;

                            labelCorreo.Text = "Correo electrónico: " + correo;
                            labelCorreo.BackColor = Color.Transparent;
                            labelCorreo.Location = new Point(10, 185);
                            labelCorreo.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelCorreo.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                            labelCorreo.Width = panelInfoPaciente.Width;

                            panelInfoPaciente.Controls.Add(labelFechaHora);
                            panelInfoPaciente.Controls.Add(labelLugarHoraNacimiento);
                            panelInfoPaciente.Controls.Add(labelDondeQuien);
                            panelInfoPaciente.Controls.Add(labelConviveAnimal);
                            panelInfoPaciente.Controls.Add(labelOcupacion);
                            panelInfoPaciente.Controls.Add(labelEnfermedades);
                            panelInfoPaciente.Controls.Add(labelCelular);
                            panelInfoPaciente.Controls.Add(labelCorreo);
                        }

                        reader.Close();

                    } else
                    {
                        if (this.Parent is Panel panelInfoPacientes)
                        {
                            UC_paciente_sin_seleccion ucPacienteSinSeleccion = new UC_paciente_sin_seleccion();


                            if (panelInfoPacientes != null)
                            {
                                ucPacienteSinSeleccion.Dock = DockStyle.Fill;
                                ucPacienteSinSeleccion.BringToFront();
                                panelInfoPacientes.Controls.Remove(this);
                                panelInfoPacientes.Controls.Add(ucPacienteSinSeleccion);
                            }
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void obtenerHistorial()
        {
            panel_historial_consultas.Controls.Clear();

            string sql = "SELECT * FROM fichas WHERE idpaciente = @id ORDER BY fecha DESC";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idPaciente);
                connection.Open();

                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int posicion = 0; 
                        int altoPanelHistorialConsultas = 0;
                        
                        while (reader.Read())
                        {
                            string fecha = reader["fecha"].ToString();
                            string receta = reader["receta"].ToString();
                            string idFicha = reader["id"].ToString();

                            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel(); 
                            Label labelFecha = new Label();
                            Guna2Button btnVerConsulta = new Guna2Button();
                            Guna2TextBox textboxReceta = new Guna2TextBox();

                            altoPanelHistorialConsultas += tableLayoutPanel.Height + 10;
                            panel_historial_consultas.Height = altoPanelHistorialConsultas;

                            tableLayoutPanel.ColumnCount = 3;
                            tableLayoutPanel.RowCount = 1;
                            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
                            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
                            tableLayoutPanel.Controls.Add(labelFecha, 0, 0);
                            tableLayoutPanel.Controls.Add(textboxReceta, 1, 0);
                            tableLayoutPanel.Controls.Add(btnVerConsulta, 2, 0);
                            tableLayoutPanel.Location = new Point(0, posicion);
                            tableLayoutPanel.Width = panel_historial_consultas.Width;
                            tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            tableLayoutPanel.Height = 65;

                            string[] resultado = fecha.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                            labelFecha.Text = resultado[2] + '/' + resultado[1] + '/' + resultado[0];
                            labelFecha.TextAlign = ContentAlignment.TopRight;
                            labelFecha.Padding = new Padding(0, 10, 5, 0);
                            labelFecha.Dock = DockStyle.Fill;
                            labelFecha.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelFecha.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);

                            textboxReceta.Dock = DockStyle.Fill;
                            textboxReceta.Height = 60;
                            textboxReceta.Multiline = true;
                            textboxReceta.ReadOnly = true;
                            textboxReceta.BorderThickness = 0;
                            textboxReceta.AutoSize = false;
                            textboxReceta.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            textboxReceta.Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Pixel);
                            textboxReceta.Text = receta;
                            textboxReceta.Width = tableLayoutPanel.Width - labelFecha.Width - btnVerConsulta.Width - 30;

                            btnVerConsulta.Text = "Ver consulta";
                            //btnVerConsulta.Dock = DockStyle.Fill;
                            btnVerConsulta.FillColor = Color.White; 
                            btnVerConsulta.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            btnVerConsulta.BorderRadius = 5;
                            btnVerConsulta.Height = 30;
                            btnVerConsulta.Cursor = Cursors.Hand;

                            panel_historial_consultas.Controls.Add(tableLayoutPanel);
                            posicion = posicion + tableLayoutPanel.Height + 10;
                        }

                        reader.Close();
                    }
                    else
                    {

                        Label label = new Label();

                        label.Text = "Todavia no hay consultas";
                        label.AutoSize = false;
                        label.Dock = DockStyle.Fill;
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        label.ForeColor = Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
                        label.Font = new Font("Segoe UI", 16f, FontStyle.Regular, GraphicsUnit.Pixel);

                        panel_historial_consultas.Controls.Add(label);
                    }
                connection.Close();
                }
            }
        }

        private void btn_nueva_consulta_Click(object sender, EventArgs e)
        {
            Form ficha = new ficha(idPaciente);
            ficha.FormClosing += Ficha_FormClosing;
            ficha.TopMost = true;
            ficha.Show();
        }

        private void Ficha_FormClosing(object sender, FormClosingEventArgs e)
        {
            obtenerHistorial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Eliminar registros de la tabla "respuestas" que coincidan con el id_ficha
                        string deleteRespuestasQuery = "DELETE FROM respuestas WHERE idficha IN " +
                                                       "(SELECT id FROM fichas WHERE idpaciente = @idPaciente)";
                        using (SQLiteCommand command = new SQLiteCommand(deleteRespuestasQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@idPaciente", idPaciente);
                            command.ExecuteNonQuery();
                        }

                        // Eliminar registros de la tabla "fichas" que coincidan con el id_paciente
                        string deleteFichasQuery = "DELETE FROM fichas WHERE id = @idPaciente";
                        using (SQLiteCommand command = new SQLiteCommand(deleteFichasQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@idPaciente", idPaciente);
                            command.ExecuteNonQuery();
                        }

                        // Eliminar registro de la tabla "pacientes" que coincida con el id_paciente
                        string deletePacienteQuery = "DELETE FROM pacientes WHERE id = @idPaciente";
                        using (SQLiteCommand command = new SQLiteCommand(deletePacienteQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@idPaciente", idPaciente);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();


                        if (this.Parent is Panel panelInfoPacientes)
                        {
                            UC_paciente_sin_seleccion ucPacienteSinSeleccion = new UC_paciente_sin_seleccion();
                            

                            if (panelInfoPacientes != null)
                            {
                                ucPacienteSinSeleccion.Dock = DockStyle.Fill;
                                ucPacienteSinSeleccion.BringToFront();
                                panelInfoPacientes.Controls.Remove(this);
                                panelInfoPacientes.Controls.Add(ucPacienteSinSeleccion);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, hacer rollback para deshacer cambios
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private void btn_editar_paciente_Click(object sender, EventArgs e)
        {
            editar_paciente formularioEditarPaciente = new editar_paciente(idPaciente);
            formularioEditarPaciente.TopMost = true; 
            formularioEditarPaciente.ShowDialog();
            obtenerPaciente();

        }


    }
}