using System.Data.SQLite;
using System;
using System.Windows.Forms;
using System.Configuration;

namespace terapia_floral.Formularios
{
    public partial class editar_paciente : Form
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        private string idPaciente;
        public editar_paciente(string id)
        {
            InitializeComponent();
            idPaciente = id;
        }

        private void btn_cancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btn_agregar_Click(object sender, System.EventArgs e)
        {

            string sql = 
                "UPDATE pacientes SET " +
                "fechanacimiento = @fechanacimiento, dondevive = @dondevive, conviveanimal = @conviveanimal, " +
                "ocupacion = @ocupacion, celular = @celular, correo = @correo, primeravez = @primeravez " +
                "WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idPaciente);
                command.Parameters.AddWithValue("@fechanacimiento", txt_fechanacimiento.Text);
                command.Parameters.AddWithValue("@dondevive", txt_dondevive.Text);
                command.Parameters.AddWithValue("@conviveanimal", txt_convivenciaanimal.Text);
                command.Parameters.AddWithValue("@ocupacion", txt_ocupacion.Text);
                command.Parameters.AddWithValue("@celular", txt_celular.Text);
                command.Parameters.AddWithValue("@correo", txt_correo.Text);
                command.Parameters.AddWithValue("@primeravez", textBox_primeravez.Text);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }

                connection.Close();
            }

        }

        private void editar_paciente_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM pacientes WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idPaciente);
                connection.Open();

                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string nombre = reader["nombreapellido"].ToString();
                        string fechaHora = reader["fechanacimiento"].ToString();
                        string dondeQuien = reader["dondevive"].ToString();
                        string conviveAnimal = reader["conviveanimal"].ToString();
                        string ocupacion = reader["ocupacion"].ToString();
                        string celular = reader["celular"].ToString();
                        string correo = reader["correo"].ToString();
                        string primeraVez = reader["primeravez"].ToString();

                        label1.Text = "Editar a " + nombre;

                        txt_fechanacimiento.Text = fechaHora;
                        txt_dondevive.Text = dondeQuien;
                        txt_convivenciaanimal.Text = conviveAnimal;
                        txt_ocupacion.Text = ocupacion;
                        txt_celular.Text = celular;
                        txt_correo.Text = correo;
                        textBox_primeravez.Text = primeraVez;
                    }
                }
            }
        }
    }    
}
