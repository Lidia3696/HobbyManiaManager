using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace HobbyManiaManager
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
            this.Load += DataForm_Load;
        }
        private async void DataForm_Load(object sender, EventArgs e)
        {
            // Obtengo la ruta física al archivo HTML, eso he ido haciendo. 
            string manualPath = Path.Combine(Application.StartupPath, "DataApplication.html");

            // Convierto esa ruta en un URI válido para file
            string manualUri = new Uri(manualPath).AbsoluteUri;

            // Muestro la ruta para debug
            MessageBox.Show("Cargando archivo desde: " + manualUri);
            await DataAppWeb.EnsureCoreWebView2Async(null);

            // Primero verifico que exista el archivo
            if (File.Exists(manualPath))
            {
                // Asigno el URI convertido al WebView2 para que cargue el HTML
                DataAppWeb.Source = new Uri(manualUri);
            }
            else
            {
                MessageBox.Show("Error: archivo no encontrado en:\n" + manualPath);
            }
        }
    }
}
