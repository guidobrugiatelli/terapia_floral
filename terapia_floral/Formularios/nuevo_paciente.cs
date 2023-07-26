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

namespace terapia_floral.Formularios
{
    public partial class nuevo_paciente : Form
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        public nuevo_paciente()
        {
            InitializeComponent();

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevo_paciente_Load(object sender, EventArgs e)
        {

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

        private void btn_agregar_Click(object sender, EventArgs e)
        {
                string sql = "INSERT INTO pacientes(id,nombreapellido, fechanacimiento, lugarhora, dondevive, conviveanimal, ocupacion, enfermedades, celular, correo) VALUES(@id,@nombreapellido, @fechanacimiento, @lugarhora, @dondevive, @conviveanimal, @ocupacion, @enfermedades, @celular, @correo)";

                if (!string.IsNullOrEmpty(txt_nombreapellido.Text))
                {
                    using (SQLiteConnection connection = new SQLiteConnection(database))
                    {
                        SQLiteCommand command = new SQLiteCommand(sql, connection);
                        command.Parameters.AddWithValue("@id", GenerateId());
                        command.Parameters.AddWithValue("@nombreapellido", txt_nombreapellido.Text);
                        command.Parameters.AddWithValue("@fechanacimiento", txt_fechanacimiento.Text);
                        command.Parameters.AddWithValue("@lugarhora", txt_lugarhora.Text);
                        command.Parameters.AddWithValue("@lugarhora", txt_lugarhora.Text); 
                        command.Parameters.AddWithValue("@dondevive", txt_dondevive.Text);
                        command.Parameters.AddWithValue("@conviveanimal", txt_convivenciaanimal.Text);
                        command.Parameters.AddWithValue("@ocupacion", txt_ocupacion.Text);
                        command.Parameters.AddWithValue("@enfermedades", txt_enfermedades.Text);
                        command.Parameters.AddWithValue("@celular", txt_celular.Text);
                        command.Parameters.AddWithValue("@correo", txt_correo.Text);


                    try
                    {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Guardado correctamente");  
                                this.Hide();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al guardar: " + ex.Message);
                        }

                        connection.Close();
                    }

                }

            }
        }
}
