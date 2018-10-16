namespace ConsultasInteligentes
{
    partial class frm_menu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_menu));
            this.lbl_hora = new System.Windows.Forms.Label();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.Lbl_gestionFormatos = new System.Windows.Forms.Label();
            this.gpb_consultas = new System.Windows.Forms.GroupBox();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.btn_gestionar = new System.Windows.Forms.Button();
            this.lbl_consultas = new System.Windows.Forms.Label();
            this.cbo_consultas = new System.Windows.Forms.ComboBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.gpb_data = new System.Windows.Forms.GroupBox();
            this.dgv_query = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_ayuda = new System.Windows.Forms.Button();
            this.gpb_consultas.SuspendLayout();
            this.gpb_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_query)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_hora
            // 
            this.lbl_hora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_hora.AutoSize = true;
            this.lbl_hora.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hora.Location = new System.Drawing.Point(9, 612);
            this.lbl_hora.Name = "lbl_hora";
            this.lbl_hora.Size = new System.Drawing.Size(40, 18);
            this.lbl_hora.TabIndex = 90;
            this.lbl_hora.Text = "TIME";
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha.Location = new System.Drawing.Point(9, 634);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(44, 18);
            this.lbl_fecha.TabIndex = 89;
            this.lbl_fecha.Text = "DATE";
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_usuario.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usuario.Location = new System.Drawing.Point(703, 634);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(202, 18);
            this.lbl_usuario.TabIndex = 88;
            this.lbl_usuario.Text = "USUARIO";
            this.lbl_usuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lbl_gestionFormatos
            // 
            this.Lbl_gestionFormatos.AutoSize = true;
            this.Lbl_gestionFormatos.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_gestionFormatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_gestionFormatos.Location = new System.Drawing.Point(26, 21);
            this.Lbl_gestionFormatos.Name = "Lbl_gestionFormatos";
            this.Lbl_gestionFormatos.Size = new System.Drawing.Size(256, 21);
            this.Lbl_gestionFormatos.TabIndex = 87;
            this.Lbl_gestionFormatos.Text = "CONSULTAS INTELIGENTES";
            // 
            // gpb_consultas
            // 
            this.gpb_consultas.BackColor = System.Drawing.Color.Transparent;
            this.gpb_consultas.Controls.Add(this.btn_consultar);
            this.gpb_consultas.Controls.Add(this.btn_gestionar);
            this.gpb_consultas.Controls.Add(this.lbl_consultas);
            this.gpb_consultas.Controls.Add(this.cbo_consultas);
            this.gpb_consultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpb_consultas.Location = new System.Drawing.Point(18, 76);
            this.gpb_consultas.Name = "gpb_consultas";
            this.gpb_consultas.Size = new System.Drawing.Size(881, 116);
            this.gpb_consultas.TabIndex = 85;
            this.gpb_consultas.TabStop = false;
            this.gpb_consultas.Text = "listado de consultas";
            // 
            // btn_consultar
            // 
            this.btn_consultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_consultar.Image = ((System.Drawing.Image)(resources.GetObject("btn_consultar.Image")));
            this.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_consultar.Location = new System.Drawing.Point(726, 39);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(61, 60);
            this.btn_consultar.TabIndex = 78;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btn_consultar, "Ejecuta la consulta seleccionada");
            this.btn_consultar.UseVisualStyleBackColor = true;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // btn_gestionar
            // 
            this.btn_gestionar.BackColor = System.Drawing.Color.Transparent;
            this.btn_gestionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_gestionar.Image = ((System.Drawing.Image)(resources.GetObject("btn_gestionar.Image")));
            this.btn_gestionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_gestionar.Location = new System.Drawing.Point(793, 39);
            this.btn_gestionar.Name = "btn_gestionar";
            this.btn_gestionar.Size = new System.Drawing.Size(61, 60);
            this.btn_gestionar.TabIndex = 79;
            this.btn_gestionar.Text = "Gestionar";
            this.btn_gestionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btn_gestionar, "Gestion de consultas (Agregar, Editar o Eliminar)");
            this.btn_gestionar.UseVisualStyleBackColor = false;
            this.btn_gestionar.Click += new System.EventHandler(this.btn_gestionar_Click);
            // 
            // lbl_consultas
            // 
            this.lbl_consultas.AutoSize = true;
            this.lbl_consultas.BackColor = System.Drawing.Color.Transparent;
            this.lbl_consultas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_consultas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_consultas.Location = new System.Drawing.Point(47, 51);
            this.lbl_consultas.Name = "lbl_consultas";
            this.lbl_consultas.Size = new System.Drawing.Size(159, 15);
            this.lbl_consultas.TabIndex = 72;
            this.lbl_consultas.Text = "CONSULTAS DISPONIBLES:";
            // 
            // cbo_consultas
            // 
            this.cbo_consultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_consultas.FormattingEnabled = true;
            this.cbo_consultas.Location = new System.Drawing.Point(212, 49);
            this.cbo_consultas.Name = "cbo_consultas";
            this.cbo_consultas.Size = new System.Drawing.Size(493, 21);
            this.cbo_consultas.TabIndex = 70;
            this.toolTip1.SetToolTip(this.cbo_consultas, "Consultas creadas con su usuario");
            this.cbo_consultas.SelectedIndexChanged += new System.EventHandler(this.cbo_consultas_SelectedIndexChanged);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Transparent;
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_salir.Location = new System.Drawing.Point(844, 12);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(61, 60);
            this.btn_salir.TabIndex = 86;
            this.btn_salir.Text = "Salir";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // gpb_data
            // 
            this.gpb_data.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gpb_data.Controls.Add(this.dgv_query);
            this.gpb_data.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpb_data.Location = new System.Drawing.Point(12, 219);
            this.gpb_data.Name = "gpb_data";
            this.gpb_data.Size = new System.Drawing.Size(893, 377);
            this.gpb_data.TabIndex = 84;
            this.gpb_data.TabStop = false;
            this.gpb_data.Text = "data";
            // 
            // dgv_query
            // 
            this.dgv_query.AllowUserToAddRows = false;
            this.dgv_query.AllowUserToDeleteRows = false;
            this.dgv_query.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_query.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_query.Location = new System.Drawing.Point(6, 19);
            this.dgv_query.Name = "dgv_query";
            this.dgv_query.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_query.Size = new System.Drawing.Size(881, 349);
            this.dgv_query.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_ayuda
            // 
            this.btn_ayuda.BackColor = System.Drawing.Color.Transparent;
            this.btn_ayuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ayuda.Image = ((System.Drawing.Image)(resources.GetObject("btn_ayuda.Image")));
            this.btn_ayuda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ayuda.Location = new System.Drawing.Point(777, 12);
            this.btn_ayuda.Name = "btn_ayuda";
            this.btn_ayuda.Size = new System.Drawing.Size(61, 60);
            this.btn_ayuda.TabIndex = 95;
            this.btn_ayuda.Text = "Ayuda";
            this.btn_ayuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btn_ayuda, "Mostrar ayuda");
            this.btn_ayuda.UseVisualStyleBackColor = false;
            this.btn_ayuda.Click += new System.EventHandler(this.btn_ayuda_Click);
            // 
            // frm_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(176)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(917, 661);
            this.Controls.Add(this.btn_ayuda);
            this.Controls.Add(this.lbl_hora);
            this.Controls.Add(this.lbl_fecha);
            this.Controls.Add(this.lbl_usuario);
            this.Controls.Add(this.Lbl_gestionFormatos);
            this.Controls.Add(this.gpb_consultas);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.gpb_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas Inteligentes";
            this.Load += new System.EventHandler(this.frm_menu_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frm_menu_HelpRequested);
            this.gpb_consultas.ResumeLayout(false);
            this.gpb_consultas.PerformLayout();
            this.gpb_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_query)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_hora;
        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.Label Lbl_gestionFormatos;
        private System.Windows.Forms.GroupBox gpb_consultas;
        private System.Windows.Forms.Button btn_consultar;
        private System.Windows.Forms.Button btn_gestionar;
        private System.Windows.Forms.Label lbl_consultas;
        private System.Windows.Forms.ComboBox cbo_consultas;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.GroupBox gpb_data;
        private System.Windows.Forms.DataGridView dgv_query;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_ayuda;
    }
}