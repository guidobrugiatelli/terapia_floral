using System;
using System.Configuration;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using terapia_floral.Formularios;

namespace terapia_floral.UsuarioControl
{
    public partial class UC_flores : UserControl
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        RichTextBox richTextBoxNombre = new RichTextBox();
        RichTextBox richTextBoxDescripcion = new RichTextBox();
        RichTextBox richTextBoxEquivalentes = new RichTextBox();

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

                if (!btnGuardar.Visible)
                {
                    DetalleFlor(id);
                    btnBorrar.Tag = id;
                }
                else
                {
                    MessageBox.Show("Guarda los cambios antes de salir del detalle");
                }
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

                        if (string.IsNullOrEmpty(equivalente))
                        {
                            equivalente = "No tiene flores equivalentes";
                        }

                        richTextBoxNombre.KeyUp += new KeyEventHandler(this.editar);
                        richTextBoxDescripcion.KeyUp += new KeyEventHandler(this.editar);
                        richTextBoxEquivalentes.KeyUp += new KeyEventHandler(this.editar);

                        richTextBoxNombre.Text = nombre;
                        richTextBoxNombre.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Pixel);
                        richTextBoxNombre.BackColor = Color.White;
                        richTextBoxNombre.BorderStyle = BorderStyle.None;
                        richTextBoxNombre.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        richTextBoxNombre.Cursor = Cursors.Arrow;
                        richTextBoxNombre.Dock = DockStyle.Fill;
                        richTextBoxNombre.Multiline = true;

                        int preferredHeight = richTextBoxNombre.GetPreferredSize(new Size(richTextBoxNombre.Width, 0)).Height;
                        richTextBoxNombre.Height = preferredHeight;

                        richTextBoxDescripcion.Text = descripcion;
                        richTextBoxDescripcion.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
                        richTextBoxDescripcion.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        richTextBoxDescripcion.BackColor = Color.White;
                        richTextBoxDescripcion.BorderStyle = BorderStyle.None;
                        richTextBoxDescripcion.Cursor = Cursors.Arrow;
                        richTextBoxDescripcion.Dock = DockStyle.Fill;

                        richTextBoxEquivalentes.Text = equivalente;
                        richTextBoxEquivalentes.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
                        richTextBoxEquivalentes.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        richTextBoxEquivalentes.BackColor = Color.White;
                        richTextBoxEquivalentes.BorderStyle = BorderStyle.None;
                        richTextBoxEquivalentes.Cursor = Cursors.Arrow;
                        richTextBoxEquivalentes.Dock = DockStyle.Fill;

                        panelNombre.Controls.Add(richTextBoxNombre);
                        panelDescripcion.Controls.Add(richTextBoxDescripcion);
                        panelEquivalentes.Controls.Add(richTextBoxEquivalentes);

                        richTextBoxNombre.Tag = id;
                        richTextBoxDescripcion.Tag = id;
                        richTextBoxEquivalentes.Tag = id;

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
            if (!btnGuardar.Visible)
            {
                panelNombre.Controls.Clear();
                panelDescripcion.Controls.Clear();
                panelEquivalentes.Controls.Clear();
                tableLayoutPanel1.ColumnStyles[1].Width = 0;
                btnGuardar.Visible = false;
            } else
            {
                MessageBox.Show("Guarda o Cancela los cambios antes de salir del detalle");
            }
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
                        btnGuardar.Visible = false;
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

        private void editar(object sender, KeyEventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;

            string id = richTextBox.Tag.ToString();

            string sql = "SELECT * FROM flores WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string nombre = reader["nombre"].ToString();
                        string descripcion = reader["descripcion"].ToString();
                        string equivalente = reader["equivalente"].ToString();

                        if (nombre != richTextBoxNombre.Text || descripcion != richTextBoxDescripcion.Text || equivalente != richTextBoxEquivalentes.Text)
                        {
                            btnGuardar.Visible = true;
                            btnCancelar.Visible = true;
                            opcionesFlor.ColumnStyles[2].Width = 0;

                            btnGuardar.Tag = id;
                            btnCancelar.Tag = id;
                        }
                        else
                        {
                            btnGuardar.Visible = false;
                            btnCancelar.Visible = false;
                            opcionesFlor.ColumnStyles[2].Width = 30;

                        }
                    }

                    reader.Close();

                }
                connection.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string equivalente = richTextBoxEquivalentes.Text;
            string id = btnGuardar.Tag.ToString();

            if (equivalente == "No tiene flores equivalentes")
            {
                equivalente = "";
            }

            string sql = "UPDATE flores SET nombre = @nombre, descripcion = @descripcion, equivalente = @equivalente WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nombre", richTextBoxNombre.Text);
                command.Parameters.AddWithValue("@descripcion", richTextBoxDescripcion.Text);
                command.Parameters.AddWithValue("@equivalente", equivalente);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        obtenerFlores();
                        DetalleFlor(id);
                        btnGuardar.Visible = false;
                        btnCancelar.Visible = false;    
                        opcionesFlor.ColumnStyles[2].Width = 30;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }

                connection.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM flores WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", btnCancelar.Tag);

                connection.Open();

                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string nombre = reader["nombre"].ToString();
                        string descripcion = reader["descripcion"].ToString();
                        string equivalente = reader["equivalente"].ToString();

                        richTextBoxNombre.Text = nombre;
                        richTextBoxDescripcion.Text = descripcion;
                        richTextBoxEquivalentes.Text = equivalente;

                        btnGuardar.Visible = false;
                        btnCancelar.Visible = false;
                        opcionesFlor.ColumnStyles[2].Width = 30;
                    }

                    reader.Close();

                }
                connection.Close();
            }
        }
    }
}
