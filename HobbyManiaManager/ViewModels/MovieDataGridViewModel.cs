﻿using System;
using System.Windows.Input;
using HobbyManiaManager.Models;

namespace HobbyManiaManager.ViewModels
{
    public class MovieDataGridViewModel
    {
        private readonly RentalService _rentalService;
        public MovieDataGridViewModel(Movie m)
        {
            Id = m.Id;
            Title = m.Title;
            OriginalTitle = m.OriginalTitle;
            ReleaseDate = m.ReleaseDate;
            VoteAverage = Math.Round(m.VoteAverage *10);
            IsAvailable = m.IsAvailable;

        }

        public int Id { get; set; }

        public string Title { get; set; }
        
        public string OriginalTitle { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double VoteAverage { get; set; }

        // the movies is available for rental if there is no active rental
        public bool IsAvailable { get; set; }
    }
}