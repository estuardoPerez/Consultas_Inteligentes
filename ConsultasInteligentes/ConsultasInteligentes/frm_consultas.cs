using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace ConsultasInteligentes
{
    public partial class frm_consultas : Form
    {
        private frm_menu menu;
        String[] modulo;
        String tablas;

        public frm_consultas(frm_menu anterior, String usuario, String[] modulo)
        {
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: constructor que inicializa variables globales
             */
            InitializeComponent();
            lbl_usuario.Text = usuario; // nombre de usuario
            this.modulo = modulo; // tablas disponibles
            menu = anterior; // formulario anterior
            getModulo();
            getOperador(1, cbo_funcion);
            getOperador(2, cbo_operador_comparacion);
            getOperador(3, cbo_operador_logico);
            getOperador(4, cbo_operador_by);
            actualizar();
        }

        private void getTabla(ComboBox temp)
        {
            /* 
             * programador: Josue Roberto Ponciaco Del Cid
             * descripcion: obtiene las tablas disponibles que tiene permiso de consultar el usuario
             */
            int num = modulo.Length;
            for (int i=0;i<num;i++)
            {
                temp.Items.Add(modulo[i]);
            }
        }

        private void getModulo()
        {
            /* 
             * programador: Josue Roberto Ponciaco Del Cid
             * descripcion: obtiene las tablas disponibles que tiene permiso de consultar el usuario
             */
            cmb_tablas_disp.Items.Clear();
            getTabla(cmb_tablas_disp);
            cbo_tabla.Items.Clear();
            getTabla(cbo_tabla);
            cbo_tabla_operando1.Items.Clear();
            getTabla(cbo_tabla_operando1);
            cbo_tabla_operando2.Items.Clear();
            getTabla(cbo_tabla_operando2);
            cbo_tabla_by.Items.Clear();
            getTabla(cbo_tabla_by);
        }

        private void getCampos(String modulo, ComboBox cbo_temp)
        {
            /* 
             * programador: Julio Ernesto Tánchez Vides
             * descripcion: obtiene los campos de la tabla seleccionada
             */
            try
            {
                OdbcConnection conexion = DB.getConnection(); // obtiene conexion con la DB // obtiene conexion con la DB
                string Query = string.Format("SELECT NOMBRE_CAMPO FROM TBL_Campo WHERE ID_TABLA = (SELECT ID_TABLA FROM TBL_Tabla WHERE NOMBRE_TABLA = '" + modulo + "');"); // query
                OdbcCommand cmd = new OdbcCommand(Query, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                cbo_temp.SelectedIndex = -1;
                cbo_temp.Items.Clear();
                while (reader.Read())
                {
                    cbo_temp.Items.Add(reader.GetString(0)); // agrega los campos a cbo_temp
                }
                conexion.Close(); // cierre de conexion con la DB // cierre de conexion con la DB
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getOperador(int operador, ComboBox cbo_temp)
        {
            /* 
             * programador: Julio Ernesto Tánchez Vides
             * descripcion: obtiene los operados disponibles segun el tipo de operador
             */
            try
            {
                OdbcConnection conexion = DB.getConnection(); // obtiene conexion con la DB
                string Query = string.Format("SELECT OPERADOR_OPERADOR FROM TBL_Operador WHERE ID_Tipo_Operador = " + operador + ";");
                OdbcCommand cmd = new OdbcCommand(Query, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                cbo_temp.SelectedIndex = -1;
                cbo_temp.Items.Clear();
                while (reader.Read())
                {
                    cbo_temp.Items.Add(reader.GetString(0)); // agrega los operadores a cbo_temp
                }
                conexion.Close(); // cierre de conexion con la DB
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void actualizar()
        {
            /* 
             * programador: Julio Ernesto Tánchez Vides
             * descripcion: obtiene las consultas creadas por usuario
             */
            try
            {
                OdbcConnection conexion = DB.getConnection(); // obtiene conexion con la DB
                string sql = string.Format("SELECT id_query, usu_codigo, nombre_query, select_query FROM TBL_Query WHERE usu_codigo = " + lbl_usuario.Text + " AND estatus = 0;");
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                dgv_query.Rows.Clear();
                while (reader.Read())
                {
                    dgv_query.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                }
                conexion.Close(); // cierre de conexion con la DB
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Josue Roberto Ponciaco Del Cid
             * descripcion: almacenamiento de consulta creada
             */
            String campos = "";
            int max = cbo_columnas.Items.Count;
            if (txt_nombre_consulta.Text != "" && (cbo_columnas.Items.Count > 0 || chk_all.Checked))
            {
                if (!chk_all.Checked)
                {
                    for (int i = 0; i < max; i++)
                    {
                        /* obtencion de campos selecionados */
                        cbo_columnas.SelectedIndex = i;
                        if (i == 0)
                        {
                            campos = "SELECT " + cbo_columnas.Text;
                        }
                        else
                        {
                            campos += ", " + cbo_columnas.Text;
                        }
                    }
                }
                else
                {
                    campos = "SELECT * ";
                }
                max = cmb_tabla.Items.Count;
                for (int i = 0; i < max; i++)
                {
                    cmb_tabla.SelectedIndex = i;
                    if (i == 0)
                    {
                        campos += " FROM " + cmb_tabla.Text;
                    }
                    else
                    {
                        campos += ", " + cmb_tabla.Text;
                    }
                } 
                max = cbo_condiciones.Items.Count;
                for (int i = 0; i < max; i++)
                {
                    /* obtencion de condiciones creadas */
                    cbo_condiciones.SelectedIndex = i;
                    if (i == 0)
                    {
                        campos += " WHERE " + cbo_condiciones.Text;
                    }
                    else
                    {
                        campos += " " + cbo_condiciones.Text;
                    }
                }
                max = cbo_condiciones_by.Items.Count;
                for (int i = 0; i < max; i++)
                {
                    /* obtencion de condiciones de agrupacion creadas */
                    cbo_condiciones_by.SelectedIndex = i;
                    campos += " " + cbo_condiciones_by.Text;
                }
                try
                {
                    OdbcConnection conexion = DB.getConnection(); // obtiene conexion con la DB
                    string sql = string.Format("INSERT INTO TBL_Query VALUES (NULL,'" + txt_nombre_consulta.Text + "'," + '"' + campos + '"' + "," + lbl_usuario.Text + ",0)");
                    OdbcCommand cmd = new OdbcCommand(sql, conexion);
                    cmd.ExecuteNonQuery();
                    limpiar();
                    menu.actualizar();
                    actualizar();
                    MessageBox.Show("GUARDADO!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conexion.Close(); // cierre de conexion con la DB
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Complete los campos obligatorios!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void frm_consultas_Load(object sender, EventArgs e)
        {
            /* 
             * programador: Pedro Javier Simón Batzibal
             * descripcion: inicia timer para obtencion de fecha y hora
             */
            timer1.Start();
            lbl_hora.Text = DateTime.Now.ToLongTimeString();
            lbl_fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* 
             * programador: Pedro Javier Simón Batzibal
             * descripcion: obtencion de fecha y hora
             */
            lbl_hora.Text = DateTime.Now.ToLongTimeString();
            lbl_fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void cbo_tabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Iván Estuardo Echeverría Catalán
             * descripcion: actualizacion de campos segun la tabla seleccionada
             */
            toolTip1.SetToolTip(cbo_tabla, cbo_tabla.Text);
            getCampos(cbo_tabla.Text, cbo_campo);
        }

        private void cbo_campo_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Iván Estuardo Echeverría Catalán
             * descripcion: actualizacion de toolTip para el nuevo campo seleccionado
             */
            toolTip1.SetToolTip(cbo_campo, cbo_campo.Text);
            if (cbo_tabla.SelectedIndex != -1 && cbo_campo.SelectedIndex != -1)
                txt_alias.Text = cbo_campo.Text;
        }

        private void txt_alias_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* 
             * programador: Josue Roberto Ponciaco Del Cid
             * descripcion: verificacion de caracteres aceptados para los alias
             */
            if ((e.KeyChar > 64 & e.KeyChar < 91) || (e.KeyChar > 96 & e.KeyChar < 123) || (e.KeyChar == '_') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btn_agregar_campo_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: agrega un nuevo campo para mostrar en la consulta
             */
            if (cbo_tabla.SelectedIndex != -1 && cbo_campo.SelectedIndex != -1)
            {
                if(cbo_funcion.SelectedIndex != -1 && cbo_funcion.Text != "Seleccione una funcion") // Existe alguna funcion seleccionada? Si la hay la agrega
                    if (txt_alias.Text != "") // Existe algun alias? Si lo hay, lo agrega
                    {
                        cbo_columnas.Items.Add(cbo_funcion.Text + "(" + cbo_tabla.Text + "." + cbo_campo.Text + ") AS " + txt_alias.Text);
                    }
                    else
                    {
                        cbo_columnas.Items.Add(cbo_funcion.Text + "(" + cbo_tabla.Text + "." + cbo_campo.Text + ")");
                    }
                else
                {
                    if (txt_alias.Text != "") // Existe algun alias? Si lo hay, lo agrega
                    {
                        cbo_columnas.Items.Add(cbo_tabla.Text + "." + cbo_campo.Text + " AS " + txt_alias.Text);
                    }
                    else
                    {
                        cbo_columnas.Items.Add(cbo_tabla.Text + "." + cbo_campo.Text);
                    }
                }
                // limpieza de campos
                cbo_tabla.SelectedIndex = -1;
                cbo_campo.SelectedIndex = -1;
                cbo_campo.Items.Clear();
                cbo_funcion.SelectedIndex = -1;
                cbo_columnas.SelectedIndex = -1;
                txt_alias.Text = "";
            }
            else
            {
                MessageBox.Show("Complete los campos obligatorios!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_campo_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: elimina campo seleccionado supuesto a mostrar en la consulta
             */
            if (cbo_columnas.SelectedIndex != -1)
            {
                cbo_columnas.Items.RemoveAt(cbo_columnas.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleccione un Item para eliminar!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_columnas_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cbo_columnas, cbo_columnas.Text);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Axel Andrés Carrera Alvarado
             * descripcion: habilitacion de items para agregar nuevos campos a mostrar
             */
            if (chk_all.Checked)
            {
                cbo_campo.Enabled = false;
                cbo_tabla.Enabled = false;
                cbo_funcion.Enabled = false;
                cbo_columnas.Enabled = false;
                txt_alias.Enabled = false;
                btn_agregar_campo.Enabled = false;
                btn_eliminar_campo.Enabled = false;
            }
            else
            {
                cbo_campo.Enabled = true;
                cbo_tabla.Enabled = true;
                cbo_funcion.Enabled = true;
                cbo_columnas.Enabled = true;
                txt_alias.Enabled = true;
                btn_agregar_campo.Enabled = true;
                btn_eliminar_campo.Enabled = true;
            }
        }

        private void limpiar()
        {
            /* 
             * programador: Axel Andrés Carrera Alvarado
             * descripcion: limpieza de items para nueva consulta
             */
            txt_nombre_consulta.Text = "";
            txt_alias.Text = "";
            txt_operando1.Text = "";
            txt_operando2.Text = "";
            cbo_tabla.SelectedIndex = -1;
            cbo_tabla_operando1.SelectedIndex = -1;
            cbo_tabla_operando2.SelectedIndex = -1;
            cbo_tabla_by.SelectedIndex = -1;
            cbo_campo.Items.Clear();
            cbo_campo.SelectedIndex = -1;
            cbo_campo_operando1.Items.Clear();
            cbo_campo_operando1.SelectedIndex = -1;
            cbo_campo_operando2.Items.Clear();
            cbo_campo_operando2.SelectedIndex = -1;
            cbo_campo_by.Items.Clear();
            cbo_campo_by.SelectedIndex = -1;
            cbo_funcion.SelectedIndex = -1;
            cbo_operador_logico.SelectedIndex = -1;
            cbo_operador_comparacion.SelectedIndex = -1;
            cbo_columnas.Items.Clear();
            cbo_columnas.SelectedIndex = -1;
            cbo_condiciones.Items.Clear();
            cbo_condiciones.SelectedIndex = -1;
            cmb_tabla.Items.Clear();
            cmb_tabla.SelectedIndex = -1;
            cmb_tablas_disp.SelectedIndex = -1;
            cbo_condiciones_by.Items.Clear();
            cbo_condiciones_by.SelectedIndex = -1;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cbo_funcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Jonathan David Pérez Barahona
             * descripcion: actualizacion de toolTip de la funcion seleccionada
             */
            toolTip1.SetToolTip(cbo_funcion, cbo_funcion.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void chk_operando_CheckedChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Axel Andrés Carrera Alvarado
             * descripcion: habilitacion de items para agregar nuevos operandos (campos o valor)
             */
            if (chk_operando2.Checked)
            {
                cbo_campo_operando2.Enabled = false;
                cbo_tabla_operando2.Enabled = false;
                cbo_campo_operando2.SelectedIndex = -1;
                cbo_tabla_operando2.SelectedIndex = -1;
                txt_operando2.Enabled = true;
            }
            else
            {
                cbo_campo_operando2.Enabled = true;
                cbo_tabla_operando2.Enabled = true;
                txt_operando2.Enabled = false;
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: elimina condicion seleccionada supuesta a estar en la consulta
             */
            if (cbo_condiciones_by.SelectedIndex != -1)
            {
                cbo_condiciones_by.Items.RemoveAt(cbo_condiciones_by.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleccione un Item para eliminar!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbo_campo_operando_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Jonathan David Pérez Barahona
             * descripcion: actualizacion de toolTip del campo de operador seleccionada
             */
            toolTip1.SetToolTip(cbo_campo_operando2, cbo_campo_operando2.Text);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Jonathan David Pérez Barahona
             * descripcion: actualizacion de campos segun la tabla seleccionada
             */
            toolTip1.SetToolTip(cbo_tabla_by, cbo_tabla_by.Text);
            getCampos(cbo_tabla_by.Text, cbo_campo_by);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Axel Andrés Carrera Alvarado
             * descripcion: cancelacion de consulta creada, limpieza de todos los campos
             */
            DialogResult resultado = MessageBox.Show("Esta seguro que desea cancelar?", "CANCELAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                limpiar();
            }
        }

        private void cbo_tabla_operando1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Iván Estuardo Echeverría Catalán
             * descripcion: actualizacion de campos segun la tabla seleccionada
             */
            toolTip1.SetToolTip(cbo_tabla_operando1, cbo_tabla_operando1.Text);
            getCampos(cbo_tabla_operando1.Text, cbo_campo_operando1);
        }

        private void cbo_tabla_operando2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Iván Estuardo Echeverría Catalán
             * descripcion: actualizacion de campos segun la tabla seleccionada
             */
            toolTip1.SetToolTip(cbo_tabla_operando2, cbo_tabla_operando2.Text);
            getCampos(cbo_tabla_operando2.Text, cbo_campo_operando2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /* 
            * programador: Axel Andrés Carrera Alvarado
            * descripcion: habilitacion de items para agregar nuevos operandos (campos o valor)
            */
            if (chk_operando1.Checked)
            {
                cbo_campo_operando1.Enabled = false;
                cbo_tabla_operando1.Enabled = false;
                cbo_campo_operando1.SelectedIndex = -1;
                cbo_tabla_operando1.SelectedIndex = -1;
                txt_operando1.Enabled = true;
            }
            else
            {
                cbo_campo_operando1.Enabled = true;
                cbo_tabla_operando1.Enabled = true;
                txt_operando1.Enabled = false;
            }
        }

        private void cbo_operador_logico_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: actualizacion de toolTip de operador logico
             */
            toolTip1.SetToolTip(cbo_operador_logico, cbo_operador_logico.Text);
        }

        private void cbo_operador_comparacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: actualizacion de toolTip de operador de comparacion
             */
            toolTip1.SetToolTip(cbo_operador_comparacion, cbo_operador_comparacion.Text);
        }

        private void cbo_operador_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: actualizacion de toolTip de operador para agrupacion
             */
            toolTip1.SetToolTip(cbo_operador_by, cbo_operador_by.Text);
        }

        private void cbo_campo_operando1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: actualizacion de toolTip de campo_operando1
             */
            toolTip1.SetToolTip(cbo_campo_operando1, cbo_campo_operando1.Text);
        }

        private void cbo_campo_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Julio Ernesto Tánchez Vides
             * descripcion: actualizacion de toolTip de cbo_campo_by 
             */
            toolTip1.SetToolTip(cbo_campo_by, cbo_campo_by.Text);
        }

        private void cbo_condiciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Julio Ernesto Tánchez Vides
             * descripcion: actualizacion de toolTip de condicion seleccionada
             */
            toolTip1.SetToolTip(cbo_condiciones, cbo_condiciones.Text);
        }

        private void cbo_condiciones_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 
             * programador: Julio Ernesto Tánchez Vides
             * descripcion: actualizacion de toolTip de condicion para agrupacion seleccionada
             */
            toolTip1.SetToolTip(cbo_condiciones_by, cbo_condiciones_by.Text);
        }

        private void btn_agregar_condicion_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Julio Ernesto Tánchez Vides
             * descripcion: agrega condicion supuesta a estar en la consulta que se esta creando
             */
            string condicion1, condicion2, condicion;
            if (cbo_operador_logico.SelectedIndex != -1 && cbo_operador_comparacion.SelectedIndex != -1 && ((chk_operando1.Checked && txt_operando1.Text != "") || (cbo_tabla_operando1.SelectedIndex != -1 && cbo_campo_operando1.SelectedIndex != -1)) && ((chk_operando2.Checked && txt_operando2.Text != "") || (cbo_tabla_operando2.SelectedIndex != -1 && cbo_campo_operando2.SelectedIndex != -1)))
            {
                if (chk_operando1.Checked)
                {
                    condicion1 = txt_operando1.Text;
                }
                else
                {
                    condicion1 = cbo_tabla_operando1.Text + "." + cbo_campo_operando1.Text;
                }
                if (chk_operando2.Checked)
                {
                    condicion2 = txt_operando2.Text; 
                } else {
                    condicion2 = cbo_tabla_operando2.Text + "." + cbo_campo_operando2.Text;
                }
                if (cbo_operador_logico.Text == "Seleccione un operador")
                {
                    condicion = "(" + condicion1 + " " + cbo_operador_comparacion.Text + " " + condicion2 + ")";
                }
                else
                {
                    condicion = cbo_operador_logico.Text + " (" + condicion1 + " " + cbo_operador_comparacion.Text + " " + condicion2 + ")";
                }
                // limpieza de items
                cbo_condiciones.Items.Add(condicion);
                txt_operando1.Text = "";
                txt_operando2.Text = "";
                cbo_tabla_operando1.SelectedIndex = -1;
                cbo_tabla_operando2.SelectedIndex = -1;
                cbo_campo_operando1.Items.Clear();
                cbo_campo_operando1.SelectedIndex = -1;
                cbo_campo_operando2.Items.Clear();
                cbo_campo_operando2.SelectedIndex = -1;
                cbo_operador_logico.SelectedIndex = -1;
                cbo_operador_comparacion.SelectedIndex = -1;
                cbo_condiciones.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Complete los campos obligatorios!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* 
            * programador: Anibal Estuardo Pérez Bonilla
            * descripcion: elimina condicion seleccionada supuesta a estar en la consulta
            */
            if (cbo_condiciones.SelectedIndex != -1)
            {
                cbo_condiciones.Items.RemoveAt(cbo_condiciones.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleccione un Item para eliminar!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_agregar_condicion_by_Click(object sender, EventArgs e)
        {
            /* 
            * programador: Julio Ernesto Tánchez Vides
            * descripcion: agrega condicion para agrupacion supuesta a estar en la consulta que se esta creando
            */
            if (cbo_operador_by.SelectedIndex != -1 && cbo_tabla_by.SelectedIndex != -1 && cbo_campo_by.SelectedIndex != -1)
            {
                cbo_condiciones_by.Items.Add(cbo_operador_by.Text + " " + cbo_tabla_by.Text + "." + cbo_campo_by.Text);
                cbo_operador_by.SelectedIndex = -1;
                cbo_tabla_by.SelectedIndex = -1;
                cbo_campo_by.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Complete los campos obligatorios!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_id_consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* 
             * programador: Josue Roberto Ponciaco Del Cid
             * descripcion: verificacion de caracteres aceptados para id_consulta
             */
            if ((e.KeyChar > 47 & e.KeyChar < 58) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* 
             * programador: Josue Roberto Ponciaco Del Cid
             * descripcion: verificacion de caracteres aceptados para id_consulta
             */
            if ((e.KeyChar > 47 & e.KeyChar < 58) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Julio Ernesto Tánchez Vides
             * descripcion: obtiene las consultas creadas por usuario
             */
            actualizar();
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Julio Ernesto Tánchez Vides
             * descripcion: eliminacion de consulta por id_consulta
             */
            if (txt_id_consulta.Text != "")
            {
                try
                {
                    OdbcConnection conexion = DB.getConnection(); // obtiene conexion con la DB
                    string sql = string.Format("DELETE FROM TBL_Query WHERE ID_QUERY = {0}", txt_id_consulta.Text);
                    OdbcCommand cmd = new OdbcCommand(sql, conexion);
                    int ban = cmd.ExecuteNonQuery();
                    if (ban == 1)
                    {
                        MessageBox.Show("Consulta eliminada!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        actualizar();
                    }
                    else
                        MessageBox.Show("Consulta no encontrada!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_id_consulta.Text = "";
                    txt_id_consulta_editar.Text = "";
                    menu.actualizar();
                    actualizar();
                    txt_id_consulta.Focus();
                    conexion.Close(); // cierre de conexion con la DB
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Escriba algun ID de una consulta!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_id_consulta.Focus();
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Josue Roberto Ponciaco Del Cid
             * descripcion: obtencion de datos de la consulta a editar
             */
            if (txt_id_consulta_editar.Text != "")
            {
                try
                {
                    OdbcConnection conexion = DB.getConnection(); // obtiene conexion con la DB
                    string sql = string.Format("SELECT NOMBRE_QUERY, SELECT_QUERY FROM TBL_Query WHERE ID_QUERY = " + txt_id_consulta_editar.Text);
                    OdbcCommand cmd = new OdbcCommand(sql, conexion);
                    OdbcDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        btn_guardar_editar.Enabled = true;
                        btn_cancelar_editar.Enabled = true;
                        txt_select.Enabled = true;
                        txt_query.Enabled = true;
                        btn_editar.Enabled = false;
                        btn_guardar.Enabled = false;
                        txt_id_consulta_editar.Enabled = false;
                        txt_query.Text = reader.GetString(0);
                        txt_select.Text = reader.GetString(1);
                    }
                    else
                    {
                        MessageBox.Show("Consulta no encontrada!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conexion.Close(); // cierre de conexion con la DB
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Escriba algun ID de una consulta!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_id_consulta_editar.Focus();
            }
        }

        private void btn_cancelar_editar_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Axel Andrés Carrera Alvarado
             * descripcion: cancelacion de edicion consulta, limpieza de todos los campos
             */
            btn_guardar_editar.Enabled = false;
            btn_cancelar_editar.Enabled = false;
            txt_select.Enabled = false;
            txt_query.Enabled = false;
            btn_editar.Enabled = true;
            btn_guardar.Enabled = true;
            txt_id_consulta_editar.Enabled = true;
            txt_query.Text = "";
            txt_select.Text = "";
        }

        private void btn_guardar_editar_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Josue Roberto Ponciaco Del Cid
             * descripcion: actualizacion de consulta
             */
            if (txt_query.Text != "" && txt_select.Text != "" )
            {
                try
                {
                    OdbcConnection conexion = DB.getConnection(); // obtiene conexion con la DB ;
                    string sql = string.Format("UPDATE TBL_Query SET NOMBRE_QUERY = '" + txt_query.Text + "', SELECT_QUERY = '" + txt_select.Text + "' WHERE ID_QUERY = " + txt_id_consulta_editar.Text);
                    OdbcCommand cmd = new OdbcCommand(sql, conexion);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Consulta actualizada!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_guardar_editar.Enabled = false;
                    btn_cancelar_editar.Enabled = false;
                    txt_select.Enabled = false;
                    txt_query.Enabled = false;
                    btn_editar.Enabled = true;
                    btn_guardar.Enabled = true;
                    txt_id_consulta_editar.Enabled = true;
                    txt_id_consulta_editar.Text = "";
                    txt_id_consulta.Text = "";
                    txt_query.Text = "";
                    txt_select.Text = "";
                    menu.actualizar();
                    actualizar();
                    conexion.Close(); // cierre de conexion con la DB
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
                MessageBox.Show("Complete todos los campos!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgv_query_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* 
             * programador: Pedro Javier Simón Batzibal
             * descripcion: fija el id de la consulta seleccionada en txt_id_consulta
             */
            if (this.dgv_query.RowCount > 0)
            {
                txt_id_consulta.Text = this.dgv_query.CurrentRow.Cells[0].Value.ToString();
                if (txt_id_consulta_editar.Enabled)
                    txt_id_consulta_editar.Text = this.dgv_query.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void btn_ayuda_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Jonathan David Pérez Barahona
             * descripcion: abre la pagina pricipal de ayuda
             */
            Help.ShowHelp(this, "C:/Users/chopes/Desktop/paginas/consulta.chm", "C:/Users/chopes/Desktop/paginas/Gestion/Gestion/gestion.html");
        }

        private void frm_consultas_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            /* 
             * programador: Jonathan David Pérez Barahona
             * descripcion: abre la pagina pricipal de ayuda
             */
            Help.ShowHelp(this, "C:/Users/chopes/Desktop/paginas/consulta.chm", "gestion.html");
        }

        private void frm_consultas_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* 
             * programador: Cristian Estuardo Pedroza Vaides
             * descripcion: abre el menu cuando el formulario se cierra
             */
            menu.Show();
        }

        private void btn_salir_Click_1(object sender, EventArgs e)
        {
            /* 
             * programador: Josue Roberto Ponciano del Cid
             * descripcion: cierre de formulario 
             */
            menu.Show();
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Josue Roberto Ponciano del Cid
             * descripcion: minimizar formulario 
             */
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_ayuda_Click_1(object sender, EventArgs e)
        {
            /* 
             * programador: Jonathan David Pérez Barahona
             * descripcion: abre la pagina pricipal de ayuda
             */
            Help.ShowHelp(this, "C:/Users/chopes/Desktop/paginas/consulta.chm", "C:/Users/chopes/Desktop/paginas/Gestion/Gestion/gestion.html");
        }

        private void dgv_query_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gpb_operando_Enter(object sender, EventArgs e)
        {

        }

        private void btn_drop_tabla_Click(object sender, EventArgs e)
        {
            /* 
            * programador: Josue Roberto Ponciano del Cid
            * descripcion: elimina tabla de ComboBox
            */
            if (cmb_tabla.SelectedIndex != -1)
            {
                cmb_tabla.Items.RemoveAt(cmb_tabla.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Seleccione un Item para eliminar!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_tabla_Click(object sender, EventArgs e)
        {
            /* 
            * programador: Josue Roberto Ponciano del Cid
            * descripcion: agrega tabla a ComboBox
            */
            if (cmb_tablas_disp.SelectedIndex != -1)
            {
                cmb_tabla.Items.Add(cmb_tablas_disp.Text);
                cmb_tablas_disp.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Complete los campos obligatorios!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
