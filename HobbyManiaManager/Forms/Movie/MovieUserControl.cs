using System;
using System.Drawing;
using System.Globalization;
using System.Reflection.Emit;
using System.Windows.Forms;
using HobbyManiaManager.Forms;
using HobbyManiaManager.Models;

namespace HobbyManiaManager
{
    public partial class MovieUserControl : UserControl
    {
        private CultureInfo cultureInfo;
        private RentalService service;
        private Movie Movie;

        public MovieUserControl()
        {
            InitializeComponent();
            this.cultureInfo = new CultureInfo("es-ES");
            this.service = new RentalService();
        }

        public void Load(Movie movie)
        {
            this.Movie = movie;
            this.labelId.Text = $"ID: {Movie.Id.ToString()}";
            this.labelId.AutoSize = true;

            this.labelTitle.Text = $"{Movie.Title}({Movie.ReleaseDate.Year})";
            this.labelTitle.AutoSize = true;

            this.labelOriginalTitle.Text = Movie.OriginalTitle;
            this.labelOriginalTitle.AutoSize = true;

            this.pictureBoxPoster.Load(Movie.PosterUrl(200));

            this.labelOverview.Text = Movie.Overview;
            this.labelOverview.AutoSize = true;
            this.labelVotesCount.Text = $"{Movie.VoteCount.ToString("N0", cultureInfo)} Votes";

            this.pictureBoxAvailable.BorderStyle = BorderStyle.None;

            this.circularProgressBarVotes.Value = (int)Math.Round(Movie.VoteAverage * 10);
            this.circularProgressBarVotes.Text = $"{Math.Round(Movie.VoteAverage * 10)}%";

            this.labelOriginalTitle.Location = new Point(this.labelOriginalTitle.Location.X, this.labelTitle.Bottom + 10);
            this.circularProgressBarVotes.Location = new Point(this.circularProgressBarVotes.Location.X, this.labelOriginalTitle.Bottom + 10);
            this.labelOverview.Location = new Point(this.circularProgressBarVotes.Right + 10, this.labelOriginalTitle.Bottom + 10);
            this.labelVotesCount.Location = new Point(this.labelVotesCount.Location.X, this.circularProgressBarVotes.Bottom + 5);


            this.labelGenres.Text = movie.GenresAsSting;
            this.labelGenres.AutoSize = true;

            // Position it just below the title, whether it wraps or not

            this.labelGenres.Location = new Point(this.labelTitle.Location.X, this.labelTitle.Bottom + 5);
            this.labelOriginalTitle.Location = new Point(this.labelOriginalTitle.Location.X, this.labelGenres.Bottom + 5);

            CheckAvailability(movie);

            this.btnImdb.Enabled = !string.IsNullOrEmpty(Movie?.ImdbId);


            this.Refresh();
        }


        private void CheckAvailability(Movie movie)
        {
            {
                //Get the active rental for this movie

                var rental = service.GetMovieRental(movie.Id);

                if (rental == null)
                {
                    // No one has it
                    pictureBoxAvailable.BackColor = Color.Green;
                    labelAvailable.Text = "Ready to rent";
                    buttonStartEndRent.Text = "Start Rent";
                }
                else
                {
                    // Someone rented it — lookup the customer
                    var customer = service._customersRepository.GetById(rental.CustomerId);
             
                    buttonStartEndRent.Text = "End Rent";
                    pictureBoxAvailable.BackColor = Color.Red;


                    if (customer != null)
                    {
                        labelAvailable.Text = $"Rental not available: Rented by {customer.Name} ({customer.Id})";
                    }
                    else
                    {
                        labelAvailable.Text = "Rental not available (Rented by: unknown)";
                    }
                }
            }
        }


        public override void Refresh()
        {
            base.Refresh();
            CheckAvailability(Movie);
        }

        private void buttonStartEndRent_Click(object sender, EventArgs e)
        {
            var rentalForm = new RentalForm(Movie, this);
            rentalForm.ShowDialog();
        }

        private void btnImdb_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Movie.ImdbId))
            {
                string imdbUrl = $"https://www.imdb.com/es-es/title/{Movie.ImdbId}";

                var imdbForm = new ImdbForm(imdbUrl, Movie.Title);
                imdbForm.ShowDialog();
            }
        }
    }
}

