using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using terapia_floral.UsuarioControl;

namespace terapia_floral.Formularios
{
    public partial class cargar_preguntas : Form
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        public cargar_preguntas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbox_categoria.Controls.Clear();           
            preguntas.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO preguntas(id, pregunta, idcategoria) VALUES(@id, @pregunta, @idcategoria)";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", GenerateId());
                command.Parameters.AddWithValue("@pregunta", preguntas.Text);
                command.Parameters.AddWithValue("@idcategoria", cbox_categoria.Text);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        cbox_categoria.Controls.Clear();
                        preguntas.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }

                connection.Close();
            }
        }

        public static string GenerateId()
        {
            const string characters = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789";
            StringBuilder idBuilder = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 19; i++)
            {
                int index = random.Next(characters.Length);
                idBuilder.Append(characters[index]);
            }

            return idBuilder.ToString();
        }
    }
}
