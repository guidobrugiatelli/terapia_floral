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
            this.btn_nuevopaciente = new Guna.UI2.WinForms.Guna2Button();
            this.txt_buscarpaciente = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel_pacientes = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_todoslospacientes = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_info_pacientes = new Guna.UI2.WinForms.Guna2Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_busqueda.SuspendLayout();
            this.panel_pacientes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // btn_nuevopaciente
            // 
            this.btn_nuevopaciente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_nuevopaciente.Animated = true;
            this.btn_nuevopaciente.AutoRoundedCorners = true;
            this.btn_nuevopaciente.BorderRadius = 23;
            this.btn_nuevopaciente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nuevopaciente.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_nuevopaciente.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_nuevopaciente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_nuevopaciente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_nuevopaciente.FillColor = System.Drawing.Color.ForestGreen;
            this.btn_nuevopaciente.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_nuevopaciente.ForeColor = System.Drawing.Color.White;
            this.btn_nuevopaciente.Location = new System.Drawing.Point(631, 14);
            this.btn_nuevopaciente.Name = "btn_nuevopaciente";
            this.btn_nuevopaciente.Size = new System.Drawing.Size(231, 48);
            this.btn_nuevopaciente.TabIndex = 1;
            this.btn_nuevopaciente.Text = "+ Nuevo Paciente";
            this.btn_nuevopaciente.Click += new System.EventHandler(this.btn_nuevopaciente_Click);
            // 
            // txt_buscarpaciente
            // 
            this.txt_buscarpaciente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_buscarpaciente.Animated = true;
            this.txt_buscarpaciente.AutoRoundedCorners = true;
            this.txt_buscarpaciente.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.txt_buscarpaciente.BorderRadius = 23;
            this.txt_buscarpaciente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscarpaciente.DefaultText = "";
            this.txt_buscarpaciente.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_buscarpaciente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_buscarpaciente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_buscarpaciente.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_buscarpaciente.FocusedState.BorderColor = System.Drawing.Color.ForestGreen;
            this.txt_buscarpaciente.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txt_buscarpaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.txt_buscarpaciente.HoverState.BorderColor = System.Drawing.Color.ForestGreen;
            this.txt_buscarpaciente.Location = new System.Drawing.Point(13, 14);
            this.txt_buscarpaciente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_buscarpaciente.Name = "txt_buscarpaciente";
            this.txt_buscarpaciente.PasswordChar = '\0';
            this.txt_buscarpaciente.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.txt_buscarpaciente.PlaceholderText = "Buscar por nombre o apellido";
            this.txt_buscarpaciente.SelectedText = "";
            this.txt_buscarpaciente.Size = new System.Drawing.Size(612, 48);
            this.txt_buscarpaciente.TabIndex = 0;
            this.txt_buscarpaciente.TextChanged += new System.EventHandler(this.txt_buscarpaciente_TextChanged);
            // 
            // panel_pacientes
            // 
            this.panel_pacientes.BackColor = System.Drawing.Color.White;
            this.panel_pacientes.Controls.Add(this.tableLayoutPanel1);
            this.panel_pacientes.CustomizableEdges.BottomLeft = false;
            this.panel_pacientes.CustomizableEdges.BottomRight = false;
            this.panel_pacientes.CustomizableEdges.TopLeft = false;
            this.panel_pacientes.CustomizableEdges.TopRight = false;
            this.panel_pacientes.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_pacientes.Location = new System.Drawing.Point(0, 80);
            this.panel_pacientes.Margin = new System.Windows.Forms.Padding(0);
            this.panel_pacientes.MaximumSize = new System.Drawing.Size(350, 0);
            this.panel_pacientes.MinimumSize = new System.Drawing.Size(350, 500);
            this.panel_pacientes.Name = "panel_pacientes";
            this.panel_pacientes.Padding = new System.Windows.Forms.Padding(10);
            this.panel_pacientes.Size = new System.Drawing.Size(350, 533);
            this.panel_pacientes.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel_todoslospacientes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 513);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_todoslospacientes
            // 
            this.panel_todoslospacientes.AutoScroll = true;
            this.panel_todoslospacientes.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.panel_todoslospacientes.BackColor = System.Drawing.Color.White;
            this.panel_todoslospacientes.CustomBorderThickness = new System.Windows.Forms.Padding(2);
            this.panel_todoslospacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_todoslospacientes.Location = new System.Drawing.Point(3, 53);
            this.panel_todoslospacientes.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.panel_todoslospacientes.Name = "panel_todoslospacientes";
            this.panel_todoslospacientes.Size = new System.Drawing.Size(324, 440);
            this.panel_todoslospacientes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pacientes";
            // 
            // panel_info_pacientes
            // 
            this.panel_info_pacientes.BackColor = System.Drawing.Color.White;
            this.panel_info_pacientes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panel_info_pacientes.BorderRadius = 20;
            this.panel_info_pacientes.BorderThickness = 1;
            this.panel_info_pacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_info_pacientes.Location = new System.Drawing.Point(5, 5);
            this.panel_info_pacientes.Margin = new System.Windows.Forms.Padding(0);
            this.panel_info_pacientes.Name = "panel_info_pacientes";
            this.panel_info_pacientes.Padding = new System.Windows.Forms.Padding(10);
            this.panel_info_pacientes.Size = new System.Drawing.Size(507, 508);
            this.panel_info_pacientes.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel_info_pacientes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(350, 80);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 5, 20, 20);
            this.panel1.Size = new System.Drawing.Size(532, 533);
            this.panel1.TabIndex = 3;
            // 
            // UC_pacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_pacientes);
            this.Controls.Add(this.panel_busqueda);
            this.Name = "UC_pacientes";
            this.Size = new System.Drawing.Size(882, 613);
            this.Load += new System.EventHandler(this.UC_pacientes_Load);
            this.panel_busqueda.ResumeLayout(false);
            this.panel_pacientes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel_busqueda;
        private Guna.UI2.WinForms.Guna2TextBox txt_buscarpaciente;
        private Guna.UI2.WinForms.Guna2Button btn_nuevopaciente;
        private Guna.UI2.WinForms.Guna2Panel panel_pacientes;
        private Guna.UI2.WinForms.Guna2Panel panel_info_pacientes;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Panel panel_todoslospacientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
