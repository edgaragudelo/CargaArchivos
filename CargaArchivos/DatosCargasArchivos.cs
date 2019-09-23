using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaArchivos
{
    public partial class DatosCargasArchivos : Form
    {
        
        public DatosCargasArchivos()
        {
            InitializeComponent();           
        }

        WebBrowser navegador = new WebBrowser();

        private void DatosCargasArchivos_Load(object sender, EventArgs e)
        {
         
            navegador.ScriptErrorsSuppressed = true;
            navegador.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.datos_cargados);
            navegador.Navigate(LinkPagina.Text);

          
           

        }


        private void datos_cargados(object sender, EventArgs e)
        {
            String Vble = null;
            foreach (HtmlElement Etiqueta in navegador.Document.All)
            {

                Vble = (Etiqueta.GetAttribute("href"));
                if (Vble.Contains("http://informacioninteligente10.xm.com.co/demanda/Historico%20Demanda/Demanda_Energia_SIN_2019.xls"))
                {

                        ArchivoaBajar.Text = Etiqueta.InnerText;
                        //navegador.Document.GetElementsByTagName("href=").ToString();
                    
                }
            }
        }

        private void cmRutas_Click(object sender, EventArgs e)
        {
            ArchivoCargar.Text = new OpenFileDialog().FileName;
            



        }

        
    }
}
