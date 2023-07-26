using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Management.Instrumentation;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using terapia_floral.Formularios;

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
                connection.Close();
            }
        }

        private void tablaFlores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string id = tablaFlores.Rows[e.RowIndex].Tag.ToString();

                DetalleFlor(id);
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
                    detalleFlor.Controls.Clear();

                    while (reader.Read())
                    {
                        string nombre = reader["nombre"].ToString();
                        string descripcion = reader["descripcion"].ToString();
                        string equivalente = reader["equivalente"].ToString();

                        TextBox TextBoxNombre = new TextBox();
                        RichTextBox richTextBoxDescripcion = new RichTextBox();
                        RichTextBox labelEquivalentes = new RichTextBox();
                        //Guna2Panel paneldescripcion = new Guna2Panel();
                        Guna2ImageButton btnCruz = new Guna2ImageButton();


                        btnCruz.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
                        btnCruz.BackColor = Color.Transparent;
                        btnCruz.CheckedState.ImageSize = new Size(14, 14);
                        btnCruz.HoverState.ImageSize = new Size(15, 15);
                        //btnCruz.Image = global::terapia_floral.Properties.Resources.cruz;
                        btnCruz.ImageOffset = new Point(0, 0);
                        btnCruz.ImageRotate = 0F;
                        btnCruz.ImageSize = new Size(14, 14);
                        btnCruz.Location = new Point(246, 5);
                        btnCruz.Name = "guna2ImageButton1";
                        btnCruz.PressedState.ImageSize = new Size(11, 11);
                        btnCruz.Size = new Size(20, 20);
                        btnCruz.TabIndex = 0;
                        btnCruz.Cursor = Cursors.Hand;
                        btnCruz.Click += new System.EventHandler(this.guna2ImageButton1_Click);

                        TextBoxNombre.Text = nombre;
                        TextBoxNombre.Location = new Point(5,5);
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
                        richTextBoxDescripcion.Width = 260;
                        richTextBoxDescripcion.Location = new Point(10, TextBoxNombre.Height + 20);
                        richTextBoxDescripcion.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
                        richTextBoxDescripcion.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        richTextBoxDescripcion.BackColor = Color.White;
                        richTextBoxDescripcion.BorderStyle = BorderStyle.None;
                        richTextBoxDescripcion.Cursor = Cursors.Arrow;
                        richTextBoxDescripcion.ScrollBars = RichTextBoxScrollBars.Vertical;

                        detalleFlor.Controls.Add(richTextBoxDescripcion);
                        detalleFlor.Controls.Add(TextBoxNombre);
                        detalleFlor.Controls.Add(btnCruz);

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
                connection.Close();
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            detalleFlor.Controls.Clear();
            tableLayoutPanel1.ColumnStyles[1].Width = 0;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
