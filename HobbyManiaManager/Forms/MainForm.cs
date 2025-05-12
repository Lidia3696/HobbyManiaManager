using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using HobbyManiaManager.Models;
using HobbyManiaManager.Forms;
using System.Drawing;
using HobbyManiaManager.Utils;
using static System.Resources.ResXFileRef;
using System.Collections;

namespace HobbyManiaManager
{
    public partial class MainForm : Form
    {
        private readonly MoviesRepository _moviesRepository;
        private readonly CustomersRepository _customersRepository;
        //Declara las variables y el readonly es que se
        //pueden asignar solo una vez: en el constructor o cuando se declaran.
        public MainForm()
        {
            InitializeComponent();
            _moviesRepository = MoviesRepository.Instance;
            _customersRepository = CustomersRepository.Instance;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.None;

            LoadMovies();
            CreateRandomCustomers();
            BuildTabs();

            labelMoviesCounter.Text = $"{_moviesRepository.Count} movies loaded.";
        }

        private void BuildTabs()
        {
            tabControlMain.Font = new Font("Segoe UI", 16, FontStyle.Regular);

            var catalog = new CatalogForm();
            ConfigureForm(catalog); //Acá lo llama y le pasa las peliculas. 
            tabPageCatalog.Controls.Add(catalog);
            //agrega este control (en este caso catalog) dentro de tabPageCatalog.
            catalog.Show();

            var customers = new ListCustomersForm();
            ConfigureForm(customers); //Acá lo llama y el pasa los clientes.
            tabPageCustomers.Controls.Add(customers);
        }

        private void ConfigureForm(Form form)
        {
            //Este método recibe un Form (por ejemplo tu CatalogForm o ListCustomersForm)
            //y le modifica varias propiedades para "convertirlo" en un control visual que pueda vivir adentro de otro contenedor (como un TabPage).
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.AutoScaleMode = AutoScaleMode.None;
            form.Visible = true;
            form.Font = Font;
            form.Location = new Point(0, 0);
        }

        private void LoadMovies()
        {
            try
            {
                string filePath = "Resources/tmdb_top_movies_small.json";
                //Define la ruta del archivo JSON.
                string json = File.ReadAllText(filePath);
                //Lee todo el contenido del archivo y lo guarda como un string en la variable json.
                var movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                //Convierte el texto JSON en una lista real de objetos Movie.
                if (movies != null) //Hace una verificación, si movie no es nulo, haz esto:
                //Que realmente exista un valor en esa variable.Si movies no es nulo → tienes algo válido, puedes usarlo.
                {
                    _moviesRepository.AddAll(movies);
                }
                else
                {
                    MessageBox.Show("No movies data found or the file is corrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading movies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateRandomCustomers()
        {
            var generator = new RandomCustomerGenerator();
            for (int i = 0; i < 100; i++) {
                generator.Generate(); //El nextcustomerId empieza desde 0 y se va incrementando.
                var c = new Customer(Customer.NextCustomerId, generator.AvatarUrl, generator.FullName, generator.Email, generator.PhoneNumber, generator.RegistrationDate);
                _customersRepository.Add(c); //Acá lo añade al repositorio. 
                //_customersRepository = CustomersRepository.Instance; para no llamar a todo el
                //método.
            }
        }

        private void buttonCatalog_Click(object sender, EventArgs e)
        {
            var catalogForm = new CatalogForm();
            catalogForm.ShowDialog();
        }

        private void buttonCreateCustomer_Click(object sender, EventArgs e)
        {
            var createCustomer = new EditCustomerForm(this);
            createCustomer.ShowDialog(); //Se pasa "this" para que el nuevo formulario
            //(EditCustomerForm) tenga una referencia al formulario padre o llamador.
             
        }

        private void buttonUpdateCustomer_Click(object sender, EventArgs e)
        {
            //El private void buttonUpdateCustomer_Click,el código está diseñado para actualizar los
            //datos de un cliente. Primero, busca al cliente con ID 1 en el repositorio
            //(_customersRepository.GetById(1)) y lo guarda en la variable c. Luego, crea una nueva
            //instancia del formulario EditCustomerForm, pasándole el cliente c para que se edite, y lo
            //muestra con form.ShowDialog(). Este formulario permite al usuario modificar los datos del cliente,
            //y una vez que el formulario se cierra, los cambios pueden ser aplicados al repositorio para actualizar
            //la información del cliente.

            var c = _customersRepository.GetById(1); //Crea una nueva variable.
            //Busca en el repositorio de clientes el cliente que tenga ID igual a 1, y guárdalo en la variable c
            var form = new EditCustomerForm(this, c);
            form.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


