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
            header_ficha.ColumnStyles[0].Width = nombre_paciente.Width + 15;

            string sql = "SELECT * FROM categorias";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                connection.Open();

                command.CommandType = CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader["nombrecategoria"].ToString();
                        string idCategoria = reader["idcategoria"].ToString();

                        opciones.Add(new Opcion(idCategoria, nombre));
                    }

                    comboBox_categoria.DataSource = opciones;
                    comboBox_categoria.DisplayMember = "Texto";
                    comboBox_categoria.ValueMember = "Id";

                    reader.Close();
                }
                connection.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_categoria.SelectedItem != null && comboBox_categoria.SelectedItem is Opcion opcionSeleccionada)
            {
                string idSeleccionado = opcionSeleccionada.Id;
                string textoSeleccionado = opcionSeleccionada.Texto;

                //MessageBox.Show($"ID: {idSeleccionado}, Texto: {textoSeleccionado}");
                //hacer el llamado a la base de datos seccion, recupero el nombre y id
                //cuando se hace click en una se las secciones, se aplía y se hace otro llamado a la base de datos
                //a la de preguntas y se obtienen todas las prguntas que tengan el mismo id de categoria y de seccion
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
            string sql = "SELECT * FROM pacientes WHERE id = @id";

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
                        string nombre = reader["nombreapellido"].ToString();
                        nombre_paciente.Text = nombre;                        
                    }

                    reader.Close();

                }
                connection.Close();
            }
        }
    }
}
