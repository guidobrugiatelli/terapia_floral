using Guna.UI2.WinForms;
using System;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Linq;
using System.Globalization;

namespace terapia_floral.Formularios
{
    public partial class ficha_completada : Form
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        private string idFicha;
        private string idPaciente;
        private const int DefaultGroupBoxHeight = 40;
        private const int ExpandedGroupBoxHeight = 150;

        public ficha_completada(string idFicha, string idPaciente)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;   
            this.idFicha = idFicha;
        }

        private void mostrarPreguntas(string idCategoria, int posicionPanel)
        {

            string sql = "SELECT * FROM preguntas WHERE idcategoria = @idCategoria";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@idCategoria", idCategoria);
                connection.Open();

                command.CommandType = CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    int posicion = 0;

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

                        if (posicionPanel == 1) categoria_1.Controls.Add(groupBoxPregunta);
                        else if (posicionPanel == 2) categoria_2.Controls.Add(groupBoxPregunta);
                        else if (posicionPanel == 3) categoria_3.Controls.Add(groupBoxPregunta);
                        else if (posicionPanel == 4) categoria_4.Controls.Add(groupBoxPregunta);

                        posicion += groupBoxPregunta.Height + 10;
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
                    }
                }


                Guna2TextBox textBox = clickedGroupBox.Controls.OfType<Guna2TextBox>().FirstOrDefault();

                if (textBox != null)
                {
                    textBox.Visible = !isExpanded;
                    string idPregunta = textBox.Tag.ToString();

                    if (!isExpanded)
                    {
                        string sql = "SELECT respuesta FROM respuestas WHERE idFicha = @idFicha and idpregunta = @idPregunta";
                        using (SQLiteConnection connection = new SQLiteConnection(database))
                        {
                            SQLiteCommand command = new SQLiteCommand(sql, connection);
                            command.Parameters.AddWithValue("@idFicha", idFicha);
                            command.Parameters.AddWithValue("@idPregunta", idPregunta);

                            connection.Open();

                            command.CommandType = CommandType.Text;

                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    textBox.Text = reader["respuesta"].ToString();
                                }
                            }
                        }
                    }
                }

            }
        }

        private void btn_preguntas_Click(object sender, System.EventArgs e)
        {
                string estado = btn_preguntas.Tag.ToString();
                if (estado == "false")
                {
                    tableLayoutPanel3.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 50);
                    tableLayoutPanel3.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 50);
                    btn_preguntas.Tag = "true";
                }
                else
                {
                    tableLayoutPanel3.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 100);
                    tableLayoutPanel3.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0);
                    btn_preguntas.Tag = "false";
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

        private void ficha_completada_Load(object sender, EventArgs e)
        {
            string sql = "SELECT p.nombreapellido AS nombre_paciente, c.idcategoria, c.nombrecategoria, f.fecha, f.receta " +
                         "FROM pacientes p " +
                         "JOIN categorias c ON p.id = @idPaciente " +
                         "JOIN fichas f ON f.idpaciente = p.id " +
                         "WHERE f.id = @idFicha";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@idPaciente", idPaciente);
                command.Parameters.AddWithValue("@idFicha", idFicha);
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

                        string fechaFicha = reader["fecha"].ToString();
                        DateTime fechaDesdeBD = DateTime.Parse(fechaFicha);

                        string fechaLarga = fechaDesdeBD.ToLongDateString();

                        fecha_ficha.Text = fechaLarga;

                        string idCategoria = reader["idcategoria"].ToString();
                        string nombreCategoria = reader["nombrecategoria"].ToString();
                        string receta = reader["receta"].ToString();

                        textBox_receta.Text = receta;

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
        }
    }
}
