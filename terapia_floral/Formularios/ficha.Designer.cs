namespace terapia_floral.Formularios
{
    partial class ficha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nombre_paciente = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.header_ficha = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_finalizar_ficha = new Guna.UI2.WinForms.Guna2Button();
            this.panelGuna2 = new Guna.UI2.WinForms.Guna2Panel();
            this.comboBox_categoria = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.header_ficha.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.panelGuna2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nombre_paciente
            // 
            this.nombre_paciente.AutoSize = true;
            this.nombre_paciente.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.nombre_paciente.Location = new System.Drawing.Point(10, 15);
            this.nombre_paciente.Name = "nombre_paciente";
            this.nombre_paciente.Size = new System.Drawing.Size(204, 31);
            this.nombre_paciente.TabIndex = 0;
            this.nombre_paciente.Text = "Nombre y apellido";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.header_ficha, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 653);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // header_ficha
            // 
            this.header_ficha.ColumnCount = 3;
            this.header_ficha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.header_ficha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.header_ficha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.header_ficha.Controls.Add(this.guna2Panel1, 0, 0);
            this.header_ficha.Controls.Add(this.guna2Panel2, 2, 0);
            this.header_ficha.Controls.Add(this.panelGuna2, 1, 0);
            this.header_ficha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header_ficha.Location = new System.Drawing.Point(0, 0);
            this.header_ficha.Margin = new System.Windows.Forms.Padding(0);
            this.header_ficha.Name = "header_ficha";
            this.header_ficha.RowCount = 1;
            this.header_ficha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.header_ficha.Size = new System.Drawing.Size(882, 60);
            this.header_ficha.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.nombre_paciente);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(20, 60);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btn_finalizar_ficha);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(652, 0);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(230, 60);
            this.guna2Panel2.TabIndex = 1;
            // 
            // btn_finalizar_ficha
            // 
            this.btn_finalizar_ficha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_finalizar_ficha.Animated = true;
            this.btn_finalizar_ficha.AutoRoundedCorners = true;
            this.btn_finalizar_ficha.BorderRadius = 19;
            this.btn_finalizar_ficha.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_finalizar_ficha.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_finalizar_ficha.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_finalizar_ficha.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_finalizar_ficha.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(213)))), ((int)(((byte)(182)))));
            this.btn_finalizar_ficha.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_finalizar_ficha.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_finalizar_ficha.Location = new System.Drawing.Point(34, 15);
            this.btn_finalizar_ficha.Name = "btn_finalizar_ficha";
            this.btn_finalizar_ficha.Size = new System.Drawing.Size(185, 41);
            this.btn_finalizar_ficha.TabIndex = 0;
            this.btn_finalizar_ficha.Text = "Finalizar ficha";
            // 
            // panelGuna2
            // 
            this.panelGuna2.Controls.Add(this.comboBox_categoria);
            this.panelGuna2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGuna2.Location = new System.Drawing.Point(20, 0);
            this.panelGuna2.Margin = new System.Windows.Forms.Padding(0);
            this.panelGuna2.Name = "panelGuna2";
            this.panelGuna2.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.panelGuna2.Size = new System.Drawing.Size(632, 60);
            this.panelGuna2.TabIndex = 2;
            // 
            // comboBox_categoria
            // 
            this.comboBox_categoria.AutoRoundedCorners = true;
            this.comboBox_categoria.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_categoria.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.comboBox_categoria.BorderRadius = 18;
            this.comboBox_categoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_categoria.FocusedColor = System.Drawing.Color.ForestGreen;
            this.comboBox_categoria.FocusedState.BorderColor = System.Drawing.Color.ForestGreen;
            this.comboBox_categoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox_categoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(88)))));
            this.comboBox_categoria.ItemHeight = 32;
            this.comboBox_categoria.Location = new System.Drawing.Point(10, 12);
            this.comboBox_categoria.Name = "comboBox_categoria";
            this.comboBox_categoria.Size = new System.Drawing.Size(201, 38);
            this.comboBox_categoria.TabIndex = 0;
            this.comboBox_categoria.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel4.Location = new System.Drawing.Point(0, 60);
            this.guna2Panel4.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(882, 593);
            this.guna2Panel4.TabIndex = 1;
            // 
            // ficha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 653);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "ficha";
            this.Text = "ficha";
            this.Load += new System.EventHandler(this.ficha_load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.header_ficha.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.panelGuna2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nombre_paciente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel header_ficha;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btn_finalizar_ficha;
        private Guna.UI2.WinForms.Guna2Panel panelGuna2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox_categoria;
    }
}