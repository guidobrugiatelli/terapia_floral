using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace terapia_floral.Formularios
{
    public partial class ficha : Form
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        private List<Opcion> opciones = new List<Opcion>();
        private string idPaciente;
        public ficha(string id)
        {
            InitializeComponent();
            idPaciente = id;            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_preguntas_respuestas.Controls.Clear();

            if (comboBox_categoria.SelectedItem != null && comboBox_categoria.SelectedItem is Opcion opcionSeleccionada)
            {
                string idSeleccionado = opcionSeleccionada.Id;
                string textoSeleccionado = opcionSeleccionada.Texto;

                string sql = "SELECT * FROM secciones WHERE idcategoria = @id";

                using (SQLiteConnection connection = new SQLiteConnection(database))
                {
                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", idSeleccionado);
                    connection.Open();

                    command.CommandType = CommandType.Text;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        int posicion = 0;

                        while (reader.Read())
                        {
                            string nombre = reader["nombreseccion"].ToString();
                            string idSeccion = reader["idseccion"].ToString();

                            Guna2CheckBox seccionFicha = new Guna2CheckBox();

                            seccionFicha.Text = nombre;                           
                            seccionFicha.Width = panel_preguntas_respuestas.Width;
                            seccionFicha.Location = new System.Drawing.Point(0, posicion);
                            seccionFicha.CheckedState.BorderColor = System.Drawing.Color.ForestGreen;
                            seccionFicha.CheckedState.BorderRadius = 2;
                            seccionFicha.CheckedState.BorderThickness = 1;
                            seccionFicha.CheckedState.FillColor = System.Drawing.Color.ForestGreen;
                            seccionFicha.Cursor = Cursors.Hand;
                            seccionFicha.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
                            seccionFicha.UncheckedState.BorderRadius = 2;
                            seccionFicha.UncheckedState.BorderThickness = 1;
                            seccionFicha.UncheckedState.FillColor = System.Drawing.Color.White;
                            seccionFicha.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                            seccionFicha.CheckedChanged += seccionFicha_Changed;
                            seccionFicha.Tag = idSeccion;

                            panel_preguntas_respuestas.Controls.Add(seccionFicha);
                            posicion = posicion + 30;
                        }

                        reader.Close();
                    }
                    connection.Close();
                }

                    //hacer el llamado a la base de datos seccion, recupero el nombre y id
                    //cuando se hace click en una se las secciones, se aplía y se hace otro llamado a la base de datos
                    //a la de preguntas y se obtienen todas las prguntas que tengan el mismo id de categoria y de seccion
                }
        }

        private void seccionFicha_Changed(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                string tag = checkBox.Tag.ToString();
                bool checkEstado = checkBox.Checked;

                if(checkEstado)
                {
                    // buscar en la tabla preguntas todas las que tienen el id que coincide con el "tag"
                    string sql = "SELECT * FROM preguntas WHERE idseccion = @id";

                    using (SQLiteConnection connection = new SQLiteConnection(database))
                    {
                        SQLiteCommand command = new SQLiteCommand(sql, connection);
                        command.Parameters.AddWithValue("@id", tag);
                        connection.Open();

                        command.CommandType = CommandType.Text;

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                //Mostrar las prguntas con su respectivo TextBox
                                //Para guardar la respuesta para que tenga relacion con su pregunta
                                //hay que ponerle en la propiedad Tag del TextBox el id de la pregunta
                            }

                            reader.Close();
                        }
                        connection.Close();
                            }
                    } else
                {
                    MessageBox.Show("deseleccionado");

                }
            }
        }

        public class Opcion
        {
            public string Id { get; set; }
            public string Texto { get; set; }

            public Opcion(string id, string texto)
            {
                Id = id;
                Texto = texto;
            }
            public override string ToString()
            {
                return Texto; // Método ToString se usa para mostrar el texto en la lista desplegable
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

                    while (reader.Read())
                    {
                        string nombre = reader["nombre_paciente"].ToString();
                        nombre_paciente.Text = nombre;
                        header_ficha.ColumnStyles[0].Width = nombre_paciente.Width + 15;

                        string idCategoria = reader["idcategoria"].ToString();
                        string nombreCategoria = reader["nombrecategoria"].ToString();
                        opciones.Add(new Opcion(idCategoria, nombreCategoria));
                    }


                    reader.Close();
                }

                comboBox_categoria.DataSource = opciones;
                comboBox_categoria.ValueMember = "Id";
                comboBox_categoria.DisplayMember = "Texto";

                connection.Close();
            }
        }


    }
}
