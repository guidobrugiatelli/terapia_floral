using System;
using System.Configuration;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;
using terapia_floral.UsuarioControl;

namespace terapia_floral.Formularios
{
    public partial class nueva_flor : Form
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        public nueva_flor()
        {
            InitializeComponent();
        }

        private void nueva_flor_Load(object sender, EventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO flores(nombre, id, descripcion, equivalente) VALUES(@nombre, @id, @descripcion, @equivalente)";

            if (!string.IsNullOrEmpty(textBoxNombre.Text))
            {
                using (SQLiteConnection connection = new SQLiteConnection(database))
                {
                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    command.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                    command.Parameters.AddWithValue("@id", GenerateId());
                    command.Parameters.AddWithValue("@descripcion", textBoxDescripcion.Text);
                    command.Parameters.AddWithValue("@equivalente", textBoxEquivalentes.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            mensajeCorrecto.Visible = true;
                            textBoxNombre.Text = "";
                            textBoxDescripcion.Text = "";
                            textBoxEquivalentes.Text = "";
                            this.Hide();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }

                    connection.Close();
                }
            
            } else
            {
                mensajeError.Visible = true;
            }
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            mensajeError.Visible = false;
            mensajeCorrecto.Visible = false;

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
