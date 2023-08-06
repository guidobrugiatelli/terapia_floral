namespace terapia_floral
{
    partial class menu_inicio
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_superior = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_flores = new Guna.UI2.WinForms.Guna2Button();
            this.btn_pacientes = new Guna.UI2.WinForms.Guna2Button();
            this.panel_informacion = new Guna.UI2.WinForms.Guna2Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_superior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_superior
            // 
            this.panel_superior.BackColor = System.Drawing.Color.White;
            this.panel_superior.Controls.Add(this.button1);
            this.panel_superior.Controls.Add(this.btn_flores);
            this.panel_superior.Controls.Add(this.btn_pacientes);
            this.panel_superior.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panel_superior.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.panel_superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_superior.Location = new System.Drawing.Point(0, 0);
            this.panel_superior.Margin = new System.Windows.Forms.Padding(0);
            this.panel_superior.MaximumSize = new System.Drawing.Size(0, 42);
            this.panel_superior.Name = "panel_superior";
            this.panel_superior.Size = new System.Drawing.Size(912, 39);
            this.panel_superior.TabIndex = 0;
            // 
            // btn_flores
            // 
            this.btn_flores.Animated = true;
            this.btn_flores.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btn_flores.CheckedState.FillColor = System.Drawing.Color.White;
            this.btn_flores.CheckedState.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_flores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_flores.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_flores.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_flores.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_flores.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_flores.FillColor = System.Drawing.Color.White;
            this.btn_flores.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_flores.ForeColor = System.Drawing.Color.Gray;
            this.btn_flores.Location = new System.Drawing.Point(135, 1);
            this.btn_flores.Margin = new System.Windows.Forms.Padding(1);
            this.btn_flores.Name = "btn_flores";
            this.btn_flores.Size = new System.Drawing.Size(92, 34);
            this.btn_flores.TabIndex = 1;
            this.btn_flores.Text = "Flores";
            this.btn_flores.Click += new System.EventHandler(this.btn_flores_Click);
            // 
            // btn_pacientes
            // 
            this.btn_pacientes.Animated = true;
            this.btn_pacientes.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btn_pacientes.Checked = true;
            this.btn_pacientes.CheckedState.FillColor = System.Drawing.Color.White;
            this.btn_pacientes.CheckedState.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_pacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pacientes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_pacientes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_pacientes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_pacientes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_pacientes.FillColor = System.Drawing.Color.White;
            this.btn_pacientes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_pacientes.ForeColor = System.Drawing.Color.Gray;
            this.btn_pacientes.Location = new System.Drawing.Point(0, 1);
            this.btn_pacientes.Margin = new System.Windows.Forms.Padding(1);
            this.btn_pacientes.Name = "btn_pacientes";
            this.btn_pacientes.Size = new System.Drawing.Size(133, 34);
            this.btn_pacientes.TabIndex = 0;
            this.btn_pacientes.Text = "Consultantes";
            this.btn_pacientes.Click += new System.EventHandler(this.btn_pacientes_Click);
            // 
            // panel_informacion
            // 
            this.panel_informacion.BackColor = System.Drawing.Color.White;
            this.panel_informacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_informacion.Location = new System.Drawing.Point(0, 39);
            this.panel_informacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_informacion.Name = "panel_informacion";
            this.panel_informacion.Size = new System.Drawing.Size(912, 622);
            this.panel_informacion.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(787, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menu_inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 661);
            this.Controls.Add(this.panel_informacion);
            this.Controls.Add(this.panel_superior);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(899, 698);
            this.Name = "menu_inicio";
            this.Text = "Software Terapia Floral";
            this.Load += new System.EventHandler(this.menu_inicio_Load);
            this.panel_superior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel_superior;
        private Guna.UI2.WinForms.Guna2Button btn_pacientes;
        private Guna.UI2.WinForms.Guna2Panel panel_informacion;
        private Guna.UI2.WinForms.Guna2Button btn_flores;
        private System.Windows.Forms.Button button1;
    }
}

