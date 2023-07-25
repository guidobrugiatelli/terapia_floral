namespace terapia_floral.UsuarioControl
{
    partial class UC_pacientes
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_busqueda = new Guna.UI2.WinForms.Guna2Panel();
            this.txt_buscarpaciente = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_nuevopaciente = new Guna.UI2.WinForms.Guna2Button();
            this.panel_pacientes = new Guna.UI2.WinForms.Guna2Panel();
            this.panel_info_pacientes = new Guna.UI2.WinForms.Guna2Panel();
            this.panel_busqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_busqueda
            // 
            this.panel_busqueda.BackColor = System.Drawing.Color.White;
            this.panel_busqueda.Controls.Add(this.btn_nuevopaciente);
            this.panel_busqueda.Controls.Add(this.txt_buscarpaciente);
            this.panel_busqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_busqueda.Location = new System.Drawing.Point(0, 0);
            this.panel_busqueda.Margin = new System.Windows.Forms.Padding(0);
            this.panel_busqueda.MaximumSize = new System.Drawing.Size(0, 80);
            this.panel_busqueda.MinimumSize = new System.Drawing.Size(882, 80);
            this.panel_busqueda.Name = "panel_busqueda";
            this.panel_busqueda.Size = new System.Drawing.Size(882, 80);
            this.panel_busqueda.TabIndex = 0;
            // 
            // txt_buscarpaciente
            // 
            this.txt_buscarpaciente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_buscarpaciente.Animated = true;
            this.txt_buscarpaciente.AutoRoundedCorners = true;
            this.txt_buscarpaciente.BorderRadius = 23;
            this.txt_buscarpaciente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscarpaciente.DefaultText = "";
            this.txt_buscarpaciente.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_buscarpaciente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_buscarpaciente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_buscarpaciente.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_buscarpaciente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_buscarpaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_buscarpaciente.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_buscarpaciente.Location = new System.Drawing.Point(13, 14);
            this.txt_buscarpaciente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_buscarpaciente.Name = "txt_buscarpaciente";
            this.txt_buscarpaciente.PasswordChar = '\0';
            this.txt_buscarpaciente.PlaceholderText = "Buscar por nombre o apellido";
            this.txt_buscarpaciente.SelectedText = "";
            this.txt_buscarpaciente.Size = new System.Drawing.Size(660, 48);
            this.txt_buscarpaciente.TabIndex = 0;
            // 
            // btn_nuevopaciente
            // 
            this.btn_nuevopaciente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_nuevopaciente.Animated = true;
            this.btn_nuevopaciente.AutoRoundedCorners = true;
            this.btn_nuevopaciente.BorderRadius = 21;
            this.btn_nuevopaciente.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_nuevopaciente.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_nuevopaciente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_nuevopaciente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_nuevopaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_nuevopaciente.ForeColor = System.Drawing.Color.White;
            this.btn_nuevopaciente.Location = new System.Drawing.Point(679, 17);
            this.btn_nuevopaciente.Name = "btn_nuevopaciente";
            this.btn_nuevopaciente.Size = new System.Drawing.Size(180, 45);
            this.btn_nuevopaciente.TabIndex = 1;
            this.btn_nuevopaciente.Text = "+ Nuevo Paciente";
            // 
            // panel_pacientes
            // 
            this.panel_pacientes.BackColor = System.Drawing.Color.White;
            this.panel_pacientes.CustomizableEdges.BottomLeft = false;
            this.panel_pacientes.CustomizableEdges.BottomRight = false;
            this.panel_pacientes.CustomizableEdges.TopLeft = false;
            this.panel_pacientes.CustomizableEdges.TopRight = false;
            this.panel_pacientes.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_pacientes.Location = new System.Drawing.Point(0, 80);
            this.panel_pacientes.Margin = new System.Windows.Forms.Padding(0);
            this.panel_pacientes.MaximumSize = new System.Drawing.Size(1000, 0);
            this.panel_pacientes.Name = "panel_pacientes";
            this.panel_pacientes.Size = new System.Drawing.Size(286, 533);
            this.panel_pacientes.TabIndex = 1;
            // 
            // panel_info_pacientes
            // 
            this.panel_info_pacientes.BackColor = System.Drawing.Color.White;
            this.panel_info_pacientes.CustomBorderColor = System.Drawing.Color.Black;
            this.panel_info_pacientes.CustomBorderThickness = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.panel_info_pacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_info_pacientes.Location = new System.Drawing.Point(286, 80);
            this.panel_info_pacientes.Name = "panel_info_pacientes";
            this.panel_info_pacientes.Size = new System.Drawing.Size(596, 533);
            this.panel_info_pacientes.TabIndex = 2;
            // 
            // UC_pacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_info_pacientes);
            this.Controls.Add(this.panel_pacientes);
            this.Controls.Add(this.panel_busqueda);
            this.Name = "UC_pacientes";
            this.Size = new System.Drawing.Size(882, 613);
            this.Load += new System.EventHandler(this.UC_pacientes_Load);
            this.panel_busqueda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel_busqueda;
        private Guna.UI2.WinForms.Guna2TextBox txt_buscarpaciente;
        private Guna.UI2.WinForms.Guna2Button btn_nuevopaciente;
        private Guna.UI2.WinForms.Guna2Panel panel_pacientes;
        private Guna.UI2.WinForms.Guna2Panel panel_info_pacientes;
    }
}
