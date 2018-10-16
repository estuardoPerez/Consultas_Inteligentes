using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasInteligentes
{
    public class Consulta
    {
        /* 
         * programador: Anibal Estuardo Pérez Bonilla
         * descripcion: clase a ultilizar por las demas dll 
         */
        private String usuario;
        private String[] modulo;
        private frm_menu nuevo;

        public Consulta (String usuario, String[] modulo){
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: constructor que inicializa variables globales
             */
            this.usuario = usuario; // nombre de usuario
            this.modulo = modulo; // tablas disponibles
        }
        

        public void abrir()
        {
            /* 
             * programador: Anibal Estuardo Pérez Bonilla
             * descripcion: abre el formulario principal de consultas inteligentes
             */
            nuevo = new frm_menu(usuario, modulo);
            nuevo.Show();
        }
    }
}
