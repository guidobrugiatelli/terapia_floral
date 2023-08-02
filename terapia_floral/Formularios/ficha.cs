using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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

        private void btn_categoria_Click(object sender, EventArgs e)
        {

            Guna2Button botonCategoria = (Guna2Button)sender;
            string idCategoria = botonCategoria.Tag.ToString();
            string nombreCategoria = botonCategoria.Text;

            panel_preguntas_respuestas.Controls.Clear();

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

                    while (reader.Read())
                    {
                        string pregunta = reader["pregunta"].ToString();
                        string idPregunta = reader["id"].ToString();

                        Guna2GroupBox groupBoxPregunta = new Guna2GroupBox();
                        Guna2TextBox textBoxRespuesta = new Guna2TextBox();

                        groupBoxPregunta.Location = new Point(0, posicion);
                        groupBoxPregunta.Width = panel.Width - 30;
                        groupBoxPregunta.Height = 40;
                        groupBoxPregunta.BorderThickness = 1;
                        groupBoxPregunta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        groupBoxPregunta.AutoSize = true;
                        groupBoxPregunta.BorderRadius = 5;
                        groupBoxPregunta.CustomBorderColor = Color.WhiteSmoke;
                        groupBoxPregunta.BorderColor = Color.WhiteSmoke;
                        groupBoxPregunta.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        groupBoxPregunta.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
                        groupBoxPregunta.Tag = idPregunta;
                        groupBoxPregunta.Text = pregunta;
                        groupBoxPregunta.Click += groupBoxPregunta_Click;
                        groupBoxPregunta.Padding = new Padding(3);

                        textBoxRespuesta.PlaceholderText = "Respuesta...";
                        textBoxRespuesta.PlaceholderForeColor = Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170))))); 
                        textBoxRespuesta.Multiline = true;
                        textBoxRespuesta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        textBoxRespuesta.Width = groupBoxPregunta.Width - 4;
                        textBoxRespuesta.Height = groupBoxPregunta.Height - 45;
                        textBoxRespuesta.BorderThickness = 0;
                        textBoxRespuesta.Visible = false;
                        textBoxRespuesta.Dock = DockStyle.Fill;
                        textBoxRespuesta.Tag = idPregunta;


                        groupBoxPregunta.Controls.Add(textBoxRespuesta);
                        panel_preguntas_respuestas.Controls.Add(groupBoxPregunta);

                        posicion += groupBoxPregunta.Height + 10;
                    }

                    reader.Close();
                }
                connection.Close();
            }

                //hacer el llamado a la base de datos seccion, recupero el nombre y id
                //cuando se hace click en una se las secciones, se aplía y se hace otro llamado a la base de datos
                //a la de preguntas y se obtienen todas las prguntas que tengan el mismo id de categoria y de seccion
                
        }


        private void groupBoxPregunta_Click(object sender, EventArgs e)
        {
            if (sender is Guna2GroupBox clickedGroupBox)
            {
                
                int currentHeight = clickedGroupBox.Height;

                // Verificar si el GroupBox está expandido o no
                bool isExpanded = currentHeight == ExpandedGroupBoxHeight;

                clickedGroupBox.Height = isExpanded ? DefaultGroupBoxHeight : ExpandedGroupBoxHeight;

                Guna2TextBox textBox = clickedGroupBox.Controls.OfType<Guna2TextBox>().FirstOrDefault();

                if (textBox != null)
                {
                    textBox.Visible = !isExpanded;
                }

                if (!isExpanded)
                {
                    foreach (Guna2GroupBox groupBox in panel_preguntas_respuestas.Controls.OfType<Guna2GroupBox>())
                    {
                        if (groupBox != clickedGroupBox && groupBox.Location.Y > clickedGroupBox.Location.Y)
                        {
                            groupBox.Location = new Point(groupBox.Location.X, groupBox.Location.Y + 110);
                        }
                    }
                }
                else
                {
                    foreach (Guna2GroupBox groupBox in panel_preguntas_respuestas.Controls.OfType<Guna2GroupBox>())
                    {
                        if (groupBox != clickedGroupBox && groupBox.Location.Y > clickedGroupBox.Location.Y)
                        {
                            groupBox.Location = new Point(groupBox.Location.X, groupBox.Location.Y - 110);
                        }
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

                    while (reader.Read())
                    {
                        string nombre = reader["nombre_paciente"].ToString();
                        nombre_paciente.Text = nombre;

                        string idCategoria = reader["idcategoria"].ToString();
                        string nombreCategoria = reader["nombrecategoria"].ToString();

                        Guna2Button btnCategoria = new Guna2Button();

                        btnCategoria.Text = nombreCategoria;
                        btnCategoria.Tag = idCategoria;
                        btnCategoria.Location = new System.Drawing.Point(posicion, 0);
                        btnCategoria.Cursor = Cursors.Hand;
                        btnCategoria.AutoSize = true;
                        btnCategoria.AutoRoundedCorners = true;
                        btnCategoria.FillColor = Color.White;
                        btnCategoria.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        btnCategoria.BorderColor = Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
                        btnCategoria.BorderThickness = 1;   
                        btnCategoria.Height = 55;
                        btnCategoria.Click += btn_categoria_Click;

                        menu_categorias.Controls.Add(btnCategoria);

                        posicion += btnCategoria.Width + 10;
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
        }
    }
}
