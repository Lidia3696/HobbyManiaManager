using HobbyManiaManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HobbyManiaManager.Forms
{
    public partial class ImdbForm : Form
    {


        // Constructor that receives the IMDb URL
        public ImdbForm(string imdbUrl)
        {
            InitializeComponent();
            LoadImdbPage(imdbUrl);  // Load the IMDb page
        }

        // Method to initialize WebView2 and navigate to IMDb
        private void LoadImdbPage(string imdbUrl)
        {

            // Ensure WebView2 is ready to navigate
            webView21.CoreWebView2InitializationCompleted += (s, e) =>
            {
                if (webView21.CoreWebView2 != null)
                {
                    webView21.CoreWebView2.Navigate(imdbUrl);  // Navigate to the IMDb page
                }
            };

            // Initialize the WebView2 control
            webView21.EnsureCoreWebView2Async();
        }



        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}
