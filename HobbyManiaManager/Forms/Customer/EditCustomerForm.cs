using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HobbyManiaManager.Models;
using HobbyManiaManager.Repositories;
using HobbyManiaManager.ViewModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace HobbyManiaManager.Forms
{
    public partial class EditCustomerForm : Form
    {
        private static string _defaultAvatarUrlTemplate = "https://ui-avatars.com/api/?name={0}&size=150";
        //Es la plantilla para construir una URL que se usará para generar una imagen predeterminada de perfil (Avatar) del cliente.

        private readonly CustomersRepository _customersRepository;
        private readonly MoviesRepository _moviesRepository;
        private readonly RentalsRepository _rentalsRepository;
        //Repositorios (_customersRepository, _moviesRepository, _rentalsRepository): Son objetos que se
        //usan para obtener y guardar datos relacionados con clientes, películas y alquileres.
       
        private readonly Form _parent; //Es una referencia al formulario principal desde el cual se abrió este formulario de edición.

        private Customer _customer; //Es el cliente que estamos editando. 
        private string _loadedAvatarUrl;

        public EditCustomerForm(Form parent, Customer customer = null)
        { //_customer: Se recibe como parámetro un cliente, que puede ser null si estamos creando uno nuevo.
            InitializeComponent();
            _customer = customer;
            textBoxId.Enabled = false; // Se deshabilita el campo textBoxId para que no se pueda cambiar el ID del cliente
            _customersRepository = CustomersRepository.Instance;
            _rentalsRepository = RentalsRepository.Instance;
            _moviesRepository = MoviesRepository.Instance;
            _parent = parent;
        }

        private void CustomerEditForm_Load(object sender, EventArgs e)
        {
            if (_customer == null)
            {
                CreateCustomerLoad();
                buttonRentalHistory.Enabled = false;
                //Acá se carga la información si estamos editando un cliente (si existe _customer) o si estamos creando uno nuevo (si no existe _customer).
                //Si estamos creando un nuevo cliente, el botón de alquiler se deshabilita(ya que no tiene historial).

            }
            else
            {
                UpdateCustomerLoad();
            }
            dateTimePickerRegDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerRegDate.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void UpdateCustomerLoad()
        {
            //Si estamos editando un cliente, este método se encarga de cargar
            //los datos del cliente en los campos de texto y mostrar su avatar en la interfaz.
            buttonUpdateCreate.Text = "Update"; //Cambia el texto del botón
            //buttonUpdateCreate a "Update" (esto indica que el formulario está en modo de actualización, no de creación).

            textBoxId.Text = _customer.Id.ToString(); //Muestra el id del cliente en un campo de texto.
            textBoxName.Text = _customer.Name;
            textBoxEmail.Text = _customer.Email;
            textBoxPhone.Text = _customer.PhoneNumber;
            dateTimePickerRegDate.Value = _customer.RegistrationDate;
            pictureBoxAvatar.Load(_customer.Avatar);
            textBoxAvatarUrl.Text = _customer.Avatar;
            Text = $"Customer: {_customer.Name}({_customer.Id})";
            //También carga el historial de alquileres del cliente en un DataGridView.
            LoadRentalsDataGrid();
        }

        private void LoadRentalsDataGrid()
        {
            //Carga los alquileres activos del cliente en una tabla (DataGridView).
            //Muestra los detalles de las películas alquiladas por ese cliente.
            this.dataGridViewActiveRentals.DataSource = _rentalsRepository.GetCustomerRentals(_customer.Id)
                .Select(c => BuildRentalViewModel(c))
                .ToList();
            dataGridViewActiveRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewActiveRentals.ReadOnly = true;
            dataGridViewActiveRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewActiveRentals.Columns["Rental"].Visible = false;
            dataGridViewActiveRentals.Columns["EndDate"].Visible = false;
        }

        private RentalDataGridViewModel BuildRentalViewModel(Rental r)
        {
            var m = _moviesRepository.GetById(r.MovieId);
            if (m == null)
            {
                throw new ArgumentException("The given Movie does not exist.", nameof(r));
            }
            return new RentalDataGridViewModel(m, r);
        }

        private void CreateCustomerLoad()
        {
            //Si estamos creando un nuevo cliente, este método configura los valores
            //predeterminados: establece que el ID es "0", oculta el campo de ID, y
            //carga un avatar predeterminado para el cliente.
            textBoxId.Text = "0";
            textBoxId.Visible = false;
            labelId.Visible = false;
            dateTimePickerRegDate.Value = DateTime.Now;
            Text = "Create New Customer";

            string defaultAvatarUrl = BuildDefaultAvatarUrl();
            pictureBoxAvatar.Load(defaultAvatarUrl);
            _loadedAvatarUrl = defaultAvatarUrl;
        }

        private void buttonUpdateCreate_Click(object sender, EventArgs e)
        {
            if (_customer == null)
            { //Cuando el usuario presiona este botón, el formulario actúa de manera
              //diferente dependiendo de si estamos editando un cliente o creando uno nuevo.
                CreateCustomer();
                MessageBox.Show("The client has been created successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {   //Si estamos creando un cliente, lo guarda en el repositorio de clientes. Si estamos editando,
                //guarda los cambios en el cliente existente.
                UpdateCustomer();
                MessageBox.Show("The client has been updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxAvatarUrl.Text = _loadedAvatarUrl;
            _parent?.Refresh();
            Dispose();
        }

        private void CreateCustomer()
        {
            var newCustomer = GetFormCustomer();
            newCustomer.Id = Customer.NextCustomerId;
            _customersRepository.Add(newCustomer);
            buttonUpdateCreate.Text = "Update";
        }

        private void UpdateCustomer()
        {
            var updatedCustomer = GetFormCustomer(); ;
            _customersRepository.Update(updatedCustomer);
        }

        private Customer GetFormCustomer()
        {
            return new Customer
            {
                Id = int.Parse(textBoxId.Text),
                Name = textBoxName.Text,
                Email = textBoxEmail.Text,
                PhoneNumber = textBoxPhone.Text,
                RegistrationDate = dateTimePickerRegDate.Value,
                Avatar = _loadedAvatarUrl
            };
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            RefreshDefaultProfilePic();
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            RefreshDefaultProfilePic();
        }

        private void textBoxAvatarUrl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBoxAvatar.Load(textBoxAvatarUrl.Text);
                _loadedAvatarUrl = textBoxAvatarUrl.Text;
            }
            catch (Exception ex)
            {
                string defaultAvatarUrl = BuildDefaultAvatarUrl();
                pictureBoxAvatar.Load(defaultAvatarUrl);
                _loadedAvatarUrl = defaultAvatarUrl;
                Console.WriteLine("Error loading image, using default: " + _loadedAvatarUrl);
            }
        }

        private void RefreshDefaultProfilePic()
        {
            if (ShouldRefreshAvatar())
            {
                string defaultAvatarUrl = BuildDefaultAvatarUrl();
                try
                {
                    pictureBoxAvatar.Load(defaultAvatarUrl);
                    _loadedAvatarUrl = defaultAvatarUrl;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading avatar: " + ex.Message);
                }
            }
        }

        private bool ShouldRefreshAvatar()
        {
            return (string.IsNullOrEmpty(_loadedAvatarUrl) || string.IsNullOrEmpty(textBoxAvatarUrl.Text)) &&
                   (textBoxName.Text.Length % 5 == 0 || textBoxName.Text.Length == 1);
        }

        private string BuildDefaultAvatarUrl()
        {
            var name = string.IsNullOrEmpty(textBoxName.Text.Trim()) ?
                "C" : textBoxName.Text.Replace(" ", "+");
            var defaultAvatarUrl = string.Format(_defaultAvatarUrlTemplate, Uri.EscapeDataString(name));
            return defaultAvatarUrl;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (dataGridViewActiveRentals.Rows.Count == 0)
            {
                string mensaje = "No data to show.";
                Font font = new Font("Segoe UI", 12, FontStyle.Italic);
                SizeF textSize = e.Graphics.MeasureString(mensaje, font);
                float x = (dataGridViewActiveRentals.Width - textSize.Width) / 2;
                float y = (dataGridViewActiveRentals.Height - textSize.Height) / 2;
                e.Graphics.DrawString(mensaje, font, Brushes.Gray, x, y);
            }
        }

        private void dataGridViewActiveRentals_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewActiveRentals.Rows[e.RowIndex];
                var r = (Rental)selectedRow.Cells["Rental"].Value;
                var m = _moviesRepository.GetById(r.MovieId);
                var customerForm = new RentalForm(m, this);
                customerForm.ShowDialog();
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            LoadRentalsDataGrid();
            _customer = _customersRepository.GetById(_customer.Id);
        }

        private void buttonRentalHistory_Click(object sender, EventArgs e)
        {
            var rentalHistoryForm = new RentalHistoryForm(_customer);
            rentalHistoryForm.ShowDialog();
        }
    }
}
