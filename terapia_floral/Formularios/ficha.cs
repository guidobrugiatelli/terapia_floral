using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Windows.Forms;

namespace terapia_floral.Formularios
{
    public partial class ficha : Form
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        private string idPaciente;
        private const int DefaultGroupBoxHeight = 40;
        private const int ExpandedGroupBoxHeight = 150;

        public ficha(string id)
        {
            InitializeComponent();
            idPaciente = id;            
        }

        private void mostrarPreguntas(string idCategoria, int posicionPanel)
        {

            string sql = "SELECT * FROM preguntas WHERE idcategoria = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idCategoria);
                connection.Open();

                command.CommandType = CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    int posicion = 0;
                    int posicionFicha1 = 40;
                    int preguntaCounter = 0;

                    while (reader.Read())
                    {
                        string pregunta = reader["pregunta"].ToString();
                        string idPregunta = reader["id"].ToString();

                        Guna2GroupBox groupBoxPregunta = new Guna2GroupBox();
                        Guna2TextBox textBoxRespuesta = new Guna2TextBox();

                        groupBoxPregunta.Location = new Point(0, posicion);
                        groupBoxPregunta.Width = tableLayoutPanel2.Width - 20;
                        groupBoxPregunta.Height = 40;
                        groupBoxPregunta.BorderThickness = 1;
                        groupBoxPregunta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        groupBoxPregunta.AutoSize = true;
                        groupBoxPregunta.BorderRadius = 3;
                        groupBoxPregunta.CustomBorderColor = Color.WhiteSmoke;
                        groupBoxPregunta.BorderColor = Color.WhiteSmoke;
                        groupBoxPregunta.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        groupBoxPregunta.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
                        groupBoxPregunta.Tag = idCategoria;
                        groupBoxPregunta.Text = pregunta;
                        groupBoxPregunta.Click += groupBoxPregunta_Click;
                        groupBoxPregunta.Padding = new Padding(3);

                        textBoxRespuesta.PlaceholderText = "Respuesta...";
                        textBoxRespuesta.PlaceholderForeColor = Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
                        textBoxRespuesta.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        textBoxRespuesta.Multiline = true;
                        textBoxRespuesta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        textBoxRespuesta.Width = groupBoxPregunta.Width - 6;
                        textBoxRespuesta.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
                        textBoxRespuesta.BorderThickness = 0;
                        textBoxRespuesta.Visible = false;
                        textBoxRespuesta.Dock = DockStyle.Fill;
                        textBoxRespuesta.Tag = idPregunta;

                        groupBoxPregunta.Controls.Add(textBoxRespuesta);

                        if (posicionPanel == 1) {
                            Label labelSeccion = new Label();
                            labelSeccion.Text = "PRESENTACION Y ENFOQUE / Fase de desarrollo con preguntas disparadoras";
                            labelSeccion.Location = new Point(0, 0);
                            labelSeccion.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
                            labelSeccion.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelSeccion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                            groupBoxPregunta.Location = new Point(0, posicionFicha1);
                            categoria_1.Controls.Add(labelSeccion); 
                            categoria_1.Controls.Add(groupBoxPregunta); 
                        }
                        else if (posicionPanel == 2) categoria_2.Controls.Add(groupBoxPregunta);
                        else if (posicionPanel == 3) categoria_3.Controls.Add(groupBoxPregunta);
                        else if (posicionPanel == 4) categoria_4.Controls.Add(groupBoxPregunta);

                        posicion += groupBoxPregunta.Height + 10;
                        posicionFicha1 += groupBoxPregunta.Height + 10;

                        preguntaCounter++;

                        if (preguntaCounter == 3 || preguntaCounter == 6 || preguntaCounter == 9 || preguntaCounter == 16 || preguntaCounter == 26 || preguntaCounter == 30 || preguntaCounter == 39)
                        {

                            string text = preguntaCounter == 3 ? "PREGUNTAS CLAVES DE CADA ENTREVISTA" :
                                          preguntaCounter == 6 ? "ACUERDO DE SESIÓN" :
                                          preguntaCounter == 9 ? "Preguntas por Interpretaciones de sentimientos" :
                                          preguntaCounter == 16 ? "Definir una meta para que el consultante sea el protagonista." :
                                          preguntaCounter == 26 ? "DETECCIÓN DE BRECHA. La propuesta es trabajar desde un espacio de RESPONSABILIDAD y MIRADA CONSCIENTE" :
                                          preguntaCounter == 30 ? "CUANDO EL CONSULTANTE GENERA CONCIENCIA PODEMOS PREGUNTARLE" :
                                          preguntaCounter == 39 ? "CIERRE" : "";


                            Label labelSeccion = new Label();
                            labelSeccion.Text = text; 
                            posicionFicha1 += labelSeccion.Height + 20;
                            labelSeccion.Location = new Point(0, posicionFicha1 - 30);
                            labelSeccion.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
                            labelSeccion.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                            labelSeccion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            // Agregar el label al panel correspondiente
                            if (posicionPanel == 1) categoria_1.Controls.Add(labelSeccion);

                        }

                    }


                    reader.Close();
                }
                connection.Close();
            }               
        }


        private void groupBoxPregunta_Click(object sender, EventArgs e)
        {
            if (sender is Guna2GroupBox clickedGroupBox)
            {
                
                int currentHeight = clickedGroupBox.Height;

                // Verificar si el GroupBox está expandido o no
                bool isExpanded = currentHeight == ExpandedGroupBoxHeight;

                clickedGroupBox.Height = isExpanded ? DefaultGroupBoxHeight : ExpandedGroupBoxHeight;

                if (!isExpanded)
                {
                    foreach (Guna2Panel panelCategoria in panel_preguntas_respuestas.Controls.OfType<Guna2Panel>())
                    {

                        foreach (Guna2GroupBox groupBox in panelCategoria.Controls.OfType<Guna2GroupBox>())
                        {
                            if (groupBox != clickedGroupBox && groupBox.Location.Y > clickedGroupBox.Location.Y && clickedGroupBox.Tag == panelCategoria.Tag)
                            {
                                groupBox.Location = new Point(groupBox.Location.X, groupBox.Location.Y + 110);
                            }
                        }
                        foreach (Label label in panelCategoria.Controls.OfType<Label>())
                        {
                            if (label.Location.Y > clickedGroupBox.Location.Y && clickedGroupBox.Tag == panelCategoria.Tag)
                            {
                                label.Location = new Point(label.Location.X, label.Location.Y + 110);
                            }
                        }
                    }
                }
                else
                {
                    foreach (Guna2Panel panelCategoria in panel_preguntas_respuestas.Controls.OfType<Guna2Panel>())
                    {

                        foreach (Guna2GroupBox groupBox in panelCategoria.Controls.OfType<Guna2GroupBox>())
                        {
                            if (groupBox != clickedGroupBox && groupBox.Location.Y > clickedGroupBox.Location.Y && clickedGroupBox.Tag == panelCategoria.Tag)
                            {
                                groupBox.Location = new Point(groupBox.Location.X, groupBox.Location.Y - 110);
                            }
                        }
                        foreach (Label label in panelCategoria.Controls.OfType<Label>())
                        {
                            if (label.Location.Y > clickedGroupBox.Location.Y && clickedGroupBox.Tag == panelCategoria.Tag)
                            {
                                label.Location = new Point(label.Location.X, label.Location.Y - 110);
                            }
                        }
                    }
                }


                Guna2TextBox textBox = clickedGroupBox.Controls.OfType<Guna2TextBox>().FirstOrDefault();

                if (textBox != null)
                {
                    textBox.Visible = !isExpanded;
                }

            }
        }

        private void btn_categoria_Click(object sender, EventArgs e)
        {
            panel_preguntas_respuestas.ColumnStyles[4] = new ColumnStyle(SizeType.Absolute, 0);

            Guna2Button botonCategoria = (Guna2Button)sender;

            int columnIndex = int.Parse(botonCategoria.Tag.ToString()); // Suponiendo que esto obtiene el índice de la columna
            int totalColumns = panel_preguntas_respuestas.ColumnCount; // Obtener el número total de columnas

            if (columnIndex >= 0 && columnIndex < totalColumns)
            {
                // Configurar la columna seleccionada para un ancho del 100% (SizeType.Percent)
                ColumnStyle selectedColumnStyle = new ColumnStyle(SizeType.Percent, 95);
                panel_preguntas_respuestas.ColumnStyles[columnIndex] = selectedColumnStyle;

                // Configurar las otras columnas para un ancho absoluto de 0 (SizeType.Absolute)
                for (int i = 0; i < totalColumns; i++)
                {
                    if (i != columnIndex)
                    {
                        ColumnStyle columnStyle = new ColumnStyle(SizeType.Absolute, 0);
                        panel_preguntas_respuestas.ColumnStyles[i] = columnStyle;
                    }
                }
            }
        }

        private void ficha_load(object sender, EventArgs e)
        {
            string sql = "SELECT p.nombreapellido AS nombre_paciente, c.idcategoria, c.nombrecategoria " +
                         "FROM pacientes p " +
                         "JOIN categorias c ON p.id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idPaciente);
                connection.Open();

                command.CommandType = CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    int posicion = 0;
                    int indexBtnCategoria = 0;
                    int posicionPanel = 1;

                    while (reader.Read())
                    {
                        string nombre = reader["nombre_paciente"].ToString();
                        nombre_paciente.Text = nombre;

                        string idCategoria = reader["idcategoria"].ToString();
                        string nombreCategoria = reader["nombrecategoria"].ToString();

                        Guna2Panel panelCategoria = new Guna2Panel();    
                        Guna2Button btnCategoria = new Guna2Button();

                        btnCategoria.Text = nombreCategoria;
                        btnCategoria.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                        btnCategoria.CheckedState.ForeColor = Color.White;
                        btnCategoria.CheckedState.FillColor = Color.ForestGreen;
                        btnCategoria.Tag = indexBtnCategoria;
                        btnCategoria.Location = new Point(posicion, 0);
                        btnCategoria.Cursor = Cursors.Hand;
                        btnCategoria.AutoSize = true;
                        btnCategoria.AutoRoundedCorners = true;
                        btnCategoria.FillColor = Color.White;
                        btnCategoria.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        btnCategoria.BorderColor = Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
                        btnCategoria.BorderThickness = 1;   
                        btnCategoria.Height = 55;
                        btnCategoria.Click += btn_categoria_Click;

                        if (posicionPanel == 1) categoria_1.Tag = idCategoria;                        
                        else if (posicionPanel == 2) categoria_2.Tag = idCategoria;                        
                        else if (posicionPanel == 3) categoria_3.Tag = idCategoria;                        
                        else if (posicionPanel == 4) categoria_4.Tag = idCategoria;                        

                        mostrarPreguntas(idCategoria, posicionPanel);

                        menu_categorias.Controls.Add(btnCategoria);

                        posicion += btnCategoria.Width + 10;
                        indexBtnCategoria++;
                        posicionPanel++;

                    }


                    reader.Close();
                }

                connection.Close();
            }

            DateTime fecha = DateTime.Now;

            label_fecha.Text = fecha.ToLongDateString();
        }

        private void btn_finalizar_ficha_Click(object sender, EventArgs e)
        {
            const string characters = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789";
            StringBuilder idBuilder = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 19; i++)
            {
                int index = random.Next(characters.Length);
                idBuilder.Append(characters[index]);
            }

            string idFicha = idBuilder.ToString();

            string receta = textBox_receta.Text;

            if (!string.IsNullOrEmpty(receta))
            {
                string sqlFicha = "INSERT INTO fichas(id, idpaciente, receta, fecha) VALUES(@id, @idPaciente, @receta, @fecha)";

                DateTime fecha = DateTime.Now;

                using (SQLiteConnection connection = new SQLiteConnection(database))
                {
                    connection.Open();

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            SQLiteCommand commandFicha = new SQLiteCommand(sqlFicha, connection);
                            commandFicha.Parameters.AddWithValue("@id", idFicha);
                            commandFicha.Parameters.AddWithValue("@idPaciente", idPaciente);
                            commandFicha.Parameters.AddWithValue("@receta", receta);
                            commandFicha.Parameters.AddWithValue("@fecha", fecha);

                            int rowsAffected = commandFicha.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                string sqlActualizarUltimaConsulta = "UPDATE pacientes SET ultimaconsulta = @fecha WHERE id = @idPaciente";

                                SQLiteCommand commandActualizar = new SQLiteCommand(sqlActualizarUltimaConsulta, connection);
                                commandActualizar.Parameters.AddWithValue("@fecha", fecha);
                                commandActualizar.Parameters.AddWithValue("@idPaciente", idPaciente);

                                commandActualizar.ExecuteNonQuery();

                                transaction.Commit();

                                foreach (Guna2Panel panelCategoria in panel_preguntas_respuestas.Controls.OfType<Guna2Panel>())
                                {
                                    foreach (Guna2GroupBox groupBox in panelCategoria.Controls.OfType<Guna2GroupBox>())
                                    {
                                        Guna2TextBox textBoxRespuesta = groupBox.Controls.OfType<Guna2TextBox>().FirstOrDefault();

                                        if (textBoxRespuesta != null)
                                        {

                                            string idCategoria = groupBox.Tag.ToString();
                                            string respuesta = textBoxRespuesta.Text;
                                            string idPregunta = textBoxRespuesta.Tag.ToString();

                                            if (!string.IsNullOrEmpty(respuesta))
                                            {
                                                string sqlPreguntas = "INSERT INTO respuestas(idficha, idpregunta, idcategoria, respuesta) VALUES(@id, @idPregunta, @idCategoria, @respuesta)";

                                                using (SQLiteConnection connection3 = new SQLiteConnection(database))
                                                {
                                                    connection3.Open();

                                                    using (SQLiteTransaction transaction3 = connection3.BeginTransaction())
                                                    {
                                                        try
                                                        {
                                                            SQLiteCommand commandRespuesta = new SQLiteCommand(sqlPreguntas, connection3);
                                                            commandRespuesta.Parameters.AddWithValue("@id", idFicha);
                                                            commandRespuesta.Parameters.AddWithValue("@idPregunta", idPregunta);
                                                            commandRespuesta.Parameters.AddWithValue("@idCategoria", idCategoria);
                                                            commandRespuesta.Parameters.AddWithValue("@respuesta", respuesta);

                                                            commandRespuesta.ExecuteNonQuery();

                                                            transaction3.Commit();
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MessageBox.Show("Error al guardar respuesta: " + ex.Message);
                                                            transaction3.Rollback();
                                                        }
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al guardar ficha: " + ex.Message);
                            transaction.Rollback();
                        }
                    }
                }


                this.Close();
            }
        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            string estado = guna2Button1.Tag.ToString();
            if(estado == "false")
            {
                tableLayoutPanel3.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 0);
                tableLayoutPanel3.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 100);
                guna2Button1.Text = "Receta";
                guna2Button1.Tag = "true";

            }
            else
            {
                tableLayoutPanel3.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 100);
                tableLayoutPanel3.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0);
                guna2Button1.Text = "Preguntas";
                guna2Button1.Tag = "false";

            }
        }
    }
}
