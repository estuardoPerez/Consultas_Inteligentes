using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace ConsultasInteligentes
{
    class DB
    {
        public static OdbcConnection getConnection()
        {
            /* 
             * programador: Josue Roberto Ponciaco Del Cid
             * descripcion: obtiene y retorna la conexion con la DB en la nube 
             */
            try
            {
                OdbcConnection cnx = new OdbcConnection("Driver={MySQL ODBC 5.3 ANSI Driver};server=104.154.63.216;uid=pruebas;pwd=umg;database=BdColchoneria;port=3306");
                cnx.Open();
                return cnx;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }
    }
}
