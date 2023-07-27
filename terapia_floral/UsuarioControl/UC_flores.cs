using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Management.Instrumentation;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using terapia_floral.Formularios;
using static System.Net.Mime.MediaTypeNames;

namespace terapia_floral.UsuarioControl
{
    public partial class UC_flores : UserControl
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;

        public UC_flores()
        {
            InitializeComponent();
            DataGridViewTextBoxColumn columnaNombre = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnaDescripcion = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnaEquivalente = new DataGridViewTextBoxColumn();

            columnaNombre.HeaderText = "Nombre";
            columnaNombre.DataPropertyName = "Nombre"; // Nombre del campo en el origen de datos
            columnaNombre.Name = "columnaNombre"; // Nombre único para la columna (opcional)

            columnaDescripcion.HeaderText = "Descripción";
            columnaDescripcion.DataPropertyName = "Descripcion"; // Nombre del campo en el origen de datos
            columnaDescripcion.Name = "columnaDescripcion"; // Nombre único para la columna (opcional)

            columnaEquivalente.HeaderText = "Equivalente";
            columnaEquivalente.DataPropertyName = "Equivalente"; // Nombre del campo en el origen de datos
            columnaEquivalente.Name = "columnaEquivalente"; // Nombre único para la columna (opcional)

            tablaFlores.Columns.Add(columnaNombre);
            tablaFlores.Columns.Add(columnaDescripcion);
            tablaFlores.Columns.Add(columnaEquivalente);
        }

        private void UC_flores_Load(object sender, System.EventArgs e)
        {
            DetalleFlor(null);
            obtenerFlores();
        }

        public void obtenerFlores()
        {
            string sql = "SELECT * FROM flores";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                connection.Open();

                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    mostrarFlores(reader);
                }
                connection.Close();
            }
        }

        private void mostrarFlores(SQLiteDataReader reader)
        {

            tablaFlores.Rows.Clear();

            while (reader.Read())
            {
                string nombre = reader["nombre"].ToString();
                string descripcion = reader["descripcion"].ToString();
                string equivalente = reader["equivalente"].ToString();
                string id = reader["id"].ToString();

                int rowIndex = tablaFlores.Rows.Add(nombre, descripcion, equivalente);
                tablaFlores.Rows[rowIndex].Tag = id;
            }

            reader.Close();
        }

        private void tablaFlores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string id = tablaFlores.Rows[e.RowIndex].Tag.ToString();

                DetalleFlor(id);
                btnBorrar.Tag = id; 
            }
        }

        private void DetalleFlor(string id)
        {
            string sql = "SELECT * FROM flores WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id",id);
                connection.Open();

                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    panelNombre.Controls.Clear();
                    panelDescripcion.Controls.Clear();
                    panelEquivalentes.Controls.Clear();

                    while (reader.Read())
                    {
                        string nombre = reader["nombre"].ToString();
                        string descripcion = reader["descripcion"].ToString();
                        string equivalente = reader["equivalente"].ToString();

                        TextBox TextBoxNombre = new TextBox();
                        RichTextBox richTextBoxDescripcion = new RichTextBox();
                        RichTextBox richTextBoxEquivalentes = new RichTextBox();

                        if (string.IsNullOrEmpty(equivalente))
                        {
                            equivalente = "No tiene flores equivalentes";
                        }

                        TextBoxNombre.Text = nombre;
                        TextBoxNombre.Location = new Point(5, 5);
                        TextBoxNombre.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Pixel);
                        TextBoxNombre.BackColor = Color.White;
                        TextBoxNombre.BorderStyle = BorderStyle.None;
                        TextBoxNombre.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        TextBoxNombre.Cursor = Cursors.Arrow;
                        TextBoxNombre.Width = 230;
                        TextBoxNombre.Multiline = true;
                        TextBoxNombre.ReadOnly = true;

                        int preferredHeight = TextBoxNombre.GetPreferredSize(new Size(TextBoxNombre.Width, 0)).Height;
                        TextBoxNombre.Height = preferredHeight;

                        richTextBoxDescripcion.Text = descripcion;
                        richTextBoxDescripcion.ReadOnly = true; // Para que el texto no sea editable
                        richTextBoxDescripcion.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
                        richTextBoxDescripcion.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        richTextBoxDescripcion.BackColor = Color.White;
                        richTextBoxDescripcion.BorderStyle = BorderStyle.None;
                        richTextBoxDescripcion.Cursor = Cursors.Arrow;
                        richTextBoxDescripcion.Dock = DockStyle.Fill;

                        richTextBoxEquivalentes.Text = equivalente;
                        richTextBoxEquivalentes.ReadOnly = true; // Para que el texto no sea editable
                        richTextBoxEquivalentes.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
                        richTextBoxEquivalentes.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        richTextBoxEquivalentes.BackColor = Color.White;
                        richTextBoxEquivalentes.BorderStyle = BorderStyle.None;
                        richTextBoxEquivalentes.Cursor = Cursors.Arrow;
                        richTextBoxEquivalentes.Dock = DockStyle.Fill;


                        panelNombre.Controls.Add(TextBoxNombre);
                        panelDescripcion.Controls.Add(richTextBoxDescripcion);
                        panelEquivalentes.Controls.Add(richTextBoxEquivalentes);
                        //detalleFlor.Controls.Add(TextBoxNombre);

                        // Desplazar el panel para que el labelDescripcion sea visible
                    }

                    reader.Close();

                }
                connection.Close();
            }

            if (!string.IsNullOrEmpty(id)) tableLayoutPanel1.ColumnStyles[1].Width = 300;
                else tableLayoutPanel1.ColumnStyles[1].Width = 0;
            
        }

        private void btn_nueva_flor_Click(object sender, EventArgs e)
        {
            nueva_flor NuevaFlor = new nueva_flor();
            NuevaFlor.TopMost = true;
            NuevaFlor.ShowDialog();
            obtenerFlores();
        }

        private void buscadorFlor_TextChanged(object sender, EventArgs e)
        {
            string text = buscadorFlor.Text.Trim();
            string sql = "SELECT * FROM flores WHERE nombre LIKE @flor";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@flor", "%"+ text +"%");
                connection.Open();

                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    mostrarFlores(reader);
                }
                connection.Close();
            }
        }

        private void ocultarDetalleFlor(object sender, EventArgs e)
        {
            panelNombre.Controls.Clear();
            panelDescripcion.Controls.Clear();
            panelEquivalentes.Controls.Clear();
            tableLayoutPanel1.ColumnStyles[1].Width = 0;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM flores WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", btnBorrar.Tag);
            
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        obtenerFlores();
                        panelNombre.Controls.Clear();
                        panelDescripcion.Controls.Clear();
                        panelEquivalentes.Controls.Clear();
                        tableLayoutPanel1.ColumnStyles[1].Width = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar flor: " + ex.Message);
                }
                connection.Close();
            }
        }
    }
}
