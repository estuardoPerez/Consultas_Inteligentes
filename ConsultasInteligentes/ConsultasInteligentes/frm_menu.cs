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
    public partial class frm_menu : Form
    {
        String[] modulo;
        public frm_menu(String usuario, String[] modulo)
        {
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: constructor que inicializa variables globales
             */
            InitializeComponent();
            lbl_usuario.Text = usuario; // nombre de usuario
            this.modulo = modulo; // tablas disponibles
            actualizar();
        }

        private void frm_menu_Load(object sender, EventArgs e)
        {
            /* 
             * programador: Pedro Javier Simón Batzibal
             * descripcion: inicia timer para obtencion de fecha y hora
             */
            timer1.Start();
            lbl_hora.Text = DateTime.Now.ToLongTimeString();
            lbl_fecha.Text = DateTime.Now.ToLongDateString();
        }

        public void actualizar()
        {
            /* 
             * programador: Axel Andrés Carrera Alvarado
             * descripcion: procedimiento que actualiza el listado de consultas disponibles por usuario
             */
            OdbcConnection conexion = DB.getConnection(); // obtiene la conexion con la DB
            try
            {
                string sql = string.Format("SELECT NOMBRE_QUERY FROM tbl_query WHERE NICKNAME_USUARIO = '" + lbl_usuario.Text + "'"); // query
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                OdbcDataReader reader = cmd.ExecuteReader(); // ejecucion query
                cbo_consultas.Items.Clear();
                while (reader.Read())
                {
                    cbo_consultas.Items.Add(reader.GetString(0)); // agrega consultas disponibles a cbo_consultas
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
            conexion.Close(); // cierre de conexion con la DB
        }

        private void getConsulta(String sql)
        {
            /* 
             * programador: Josue Roberto Ponciaco Del Cid
             * descripcion: procedimiento que muestra el resultado de las consultas en dgv_query
             */
            OdbcConnection conexion = DB.getConnection(); // obtiene la conexion con la DB
            try
            {
                OdbcDataAdapter SDA = new OdbcDataAdapter(sql, conexion);
                DataTable dt = new DataTable();
                dgv_query.DataSource = null; 
                SDA.Fill(dt);
                dgv_query.DataSource = dt; // establece el origen de datos para el que DataGridView muestre datos
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conexion.Close(); // cierre de conexion con la DB
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Cristian Estuardo Pedroza Vaides
             * descripcion: cierre de formulario 
             */
            this.Close();
        }

        private void btn_gestionar_Click(object sender, EventArgs e)
        {
            /* 
            * programador: Cristian Estuardo Pedroza Vaides
            * descripcion: abre formulacion para las gestiones de consultas
            */
            frm_consultas nuevo = new frm_consultas(this, lbl_usuario.Text, modulo);
            nuevo.Show();
            this.Hide();
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

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Pedro Javier Simón Batzibal
             * descripcion: ejecucion de consulta seleccionada
             */
            if (cbo_consultas.SelectedIndex != -1)
            {
                OdbcConnection conexion = DB.getConnection(); // obtencion de conexion con la DB
                try
                {
                    string sql = string.Format("SELECT SELECT_QUERY FROM tbl_query WHERE NOMBRE_QUERY = '" + cbo_consultas.Text + "'"); // query
                    OdbcCommand cmd = new OdbcCommand(sql, conexion);
                    OdbcDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        getConsulta(reader.GetString(0)); // ejecucion consulta seleccionada
                    }
                    else
                    {
                        MessageBox.Show("Error consulta no encontrada!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conexion.Close(); // cierre de conexion DB
            }
            else
            {
                MessageBox.Show("Seleccione una consulta!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_consultar_all_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Pedro Javier Simón Batzibal
             * descripcion: consulta general de tabla principal
             */
        }

        private void cbo_consultas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_ayuda_Click(object sender, EventArgs e)
        {
            /* 
             * programador: Jonathan David Pérez Barahona
             * descripcion: abre la pagina pricipal de ayuda
             */
            Help.ShowHelp(this, "C:/Users/chopes/Desktop/paginas/consulta.chm", "C:/Users/chopes/Desktop/paginas/Gestion/Gestion/gestion.html");
        }

        private void frm_menu_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            /* 
             * programador: Jonathan David Pérez Barahona
             * descripcion: abre la pagina pricipal de ayuda
             */
            Help.ShowHelp(this, "C:/Users/chopes/Desktop/paginas/consulta.chm", "C:/Users/chopes/Desktop/paginas/Gestion/Gestion/gestion.html");
        }
    }
}
