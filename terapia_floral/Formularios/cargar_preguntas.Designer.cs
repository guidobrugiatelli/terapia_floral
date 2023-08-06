namespace terapia_floral.Formularios
{
    partial class cargar_preguntas
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
            this.button1 = new System.Windows.Forms.Button();
            this.preguntas = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbox_categoria = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // preguntas
            // 
            this.preguntas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.preguntas.DefaultText = "";
            this.preguntas.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.preguntas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.preguntas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.preguntas.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.preguntas.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.preguntas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.preguntas.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.preguntas.Location = new System.Drawing.Point(12, 106);
            this.preguntas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.preguntas.Name = "preguntas";
            this.preguntas.PasswordChar = '\0';
            this.preguntas.PlaceholderText = "";
            this.preguntas.SelectedText = "";
            this.preguntas.Size = new System.Drawing.Size(776, 46);
            this.preguntas.TabIndex = 1;
            // 
            // cbox_categoria
            // 
            this.cbox_categoria.BackColor = System.Drawing.Color.Transparent;
            this.cbox_categoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbox_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_categoria.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbox_categoria.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbox_categoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbox_categoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbox_categoria.ItemHeight = 30;
            this.cbox_categoria.Items.AddRange(new object[] {
            "Y53aoONPIrserEGegJw",
            "2k2qñG61ZzpRbu8eiPb",
            "ybTzTt3jSma9cGIño4I",
            "ÑTmPwSsKwZUec2feLzh"});
            this.cbox_categoria.Location = new System.Drawing.Point(13, 43);
            this.cbox_categoria.Name = "cbox_categoria";
            this.cbox_categoria.Size = new System.Drawing.Size(775, 36);
            this.cbox_categoria.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Categoría";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pregunta";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(273, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 54);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cargar_preguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 232);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbox_categoria);
            this.Controls.Add(this.preguntas);
            this.Controls.Add(this.button1);
            this.Name = "cargar_preguntas";
            this.Text = "cargar_preguntas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2TextBox preguntas;
        private Guna.UI2.WinForms.Guna2ComboBox cbox_categoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}