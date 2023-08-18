using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace terapia_floral.Formularios
{
    public partial class Detalle : Form
    {
        private static string database = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        private string idFlor;

        Guna2TextBox richTextBoxNombre = new Guna2TextBox();
        Guna2TextBox richTextBoxDescripcion = new Guna2TextBox();
        Guna2TextBox richTextBoxEquivalentes = new Guna2TextBox();
        public Detalle(string id)
        {
            InitializeComponent();
            idFlor = id;
            DetalleFlor();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM flores WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idFlor);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        this.Close();   
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar flor: " + ex.Message);
                }
                connection.Close();
            }
        }

        private void DetalleFlor()
        {
            string sql = "SELECT * FROM flores WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idFlor);
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

                        richTextBoxNombre.KeyUp += new KeyEventHandler(this.editar);
                        richTextBoxDescripcion.KeyUp += new KeyEventHandler(this.editar);
                        richTextBoxEquivalentes.KeyUp += new KeyEventHandler(this.editar);

                        richTextBoxNombre.Text = nombre;
                        richTextBoxNombre.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Pixel);
                        richTextBoxNombre.BackColor = Color.White;
                        richTextBoxNombre.BorderThickness = 0;
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
                        richTextBoxDescripcion.BorderRadius = 10;
                        richTextBoxDescripcion.BorderColor = Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
                        richTextBoxDescripcion.HoverState.BorderColor = Color.Green;
                        richTextBoxDescripcion.FocusedState.BorderColor = Color.Green;
                        richTextBoxDescripcion.Cursor = Cursors.Arrow;
                        richTextBoxDescripcion.Dock = DockStyle.Fill;
                        richTextBoxDescripcion.Multiline = true;

                        richTextBoxEquivalentes.Text = equivalente;
                        richTextBoxEquivalentes.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
                        richTextBoxEquivalentes.ForeColor = Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
                        richTextBoxEquivalentes.BackColor = Color.White;
                        richTextBoxEquivalentes.BorderRadius = 10;
                        richTextBoxEquivalentes.BorderColor = Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
                        richTextBoxEquivalentes.HoverState.BorderColor = Color.Green;
                        richTextBoxEquivalentes.FocusedState.BorderColor = Color.Green;
                        richTextBoxEquivalentes.Cursor = Cursors.Arrow;
                        richTextBoxEquivalentes.Dock = DockStyle.Fill;
                        richTextBoxEquivalentes.Multiline = true;

                        panelNombre.Controls.Add(richTextBoxNombre);
                        panelDescripcion.Controls.Add(richTextBoxDescripcion);
                        panelEquivalentes.Controls.Add(richTextBoxEquivalentes);
                    }

                    reader.Close();

                }
                connection.Close();
            }

        }

        private void editar(object sender, KeyEventArgs e)
        {
            string sql = "SELECT * FROM flores WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idFlor);

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
                            opcionesFlor.ColumnStyles[1].Width = 0;
                        }
                        else
                        {
                            btnGuardar.Visible = false;
                            btnCancelar.Visible = false;
                            opcionesFlor.ColumnStyles[1].Width = 130;

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

            string sql = "UPDATE flores SET nombre = @nombre, descripcion = @descripcion, equivalente = @equivalente WHERE id = @id";

            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", idFlor);
                command.Parameters.AddWithValue("@nombre", richTextBoxNombre.Text);
                command.Parameters.AddWithValue("@descripcion", richTextBoxDescripcion.Text);
                command.Parameters.AddWithValue("@equivalente", equivalente);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        DetalleFlor();
                        btnGuardar.Visible = false;
                        btnCancelar.Visible = false;
                        opcionesFlor.ColumnStyles[1].Width = 130;
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
                command.Parameters.AddWithValue("@id", idFlor);

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
                        opcionesFlor.ColumnStyles[1].Width = 130;
                    }

                    reader.Close();

                }
                connection.Close();
            }
        }

    }
}
