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

                Detalle detalleFlor = new Detalle(id);
                detalleFlor.FormClosing += detalleFlor_FormClosing;
                detalleFlor.ShowDialog();
            }
        }

        private void detalleFlor_FormClosing(object sender, FormClosingEventArgs e)
        {
            obtenerFlores();
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

    }
}
