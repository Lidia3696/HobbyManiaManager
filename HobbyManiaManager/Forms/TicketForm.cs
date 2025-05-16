using HobbyManiaManager.Models;
using HobbyManiaManager.Repositories;
using HobbyManiaManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HobbyManiaManager.Forms.Rental
{
    public partial class TicketForm : Form
    {
        Models.Customer Customer;
        Models.Movie Movie;
        Models.Rental Rental;
        RentalService RentalService;

        private float euroSecond = 0.0001f;
        private float totalSeconds;
        private float totalAmount;

        public TicketForm(Models.Customer customer, Models.Movie movie, Models.Rental rental)
        {
            InitializeComponent();
            Movie = movie;
            Customer = customer;
            Rental = rental;
            RentalService = new RentalService();
        }

        private void TicketForm_Load(object sender, EventArgs e)
        {
            //Get name and title
            lblCustomerName.Text = Customer.Name;
            lblMovieTitle.Text = Movie.Title;
            //Get dates
            lblStartDate.Text = Rental.StartDate.ToString();
            lblEndDate.Text = Rental.EndDate.ToString();
            //Calculate seconds
            totalSeconds = (float)DateTimeUtils.GetDifferenceInSeconds(Rental.StartDate, Rental.EndDate.Value);
            //Calculate total amount
            totalAmount = totalSeconds * euroSecond;
            //Write total amount in textbox
            lblTotalAmount.Text = totalAmount.ToString();
        }
    }
}
