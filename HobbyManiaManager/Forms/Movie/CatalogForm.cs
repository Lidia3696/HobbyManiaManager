﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using HobbyManiaManager.Models;
using HobbyManiaManager.ViewModels;

namespace HobbyManiaManager
{
    public partial class CatalogForm : Form
    {
        private readonly MoviesRepository _moviesRepository;

        public CatalogForm()
        {
            InitializeComponent();
            _moviesRepository = MoviesRepository.Instance;

        }

        private void CatalogForm_Load(object sender, EventArgs e)
        {
            movieUserControl.Load(_moviesRepository.GetAll().First());

            dataGridViewMoviesList.AutoGenerateColumns = true;

            dataGridViewMoviesList.DataSource = _moviesRepository.GetAll()
                .Select(m => new MovieDataGridViewModel(m))
                .ToList();

            ConfigureMoviesDatagrid();
        }

        private void ConfigureMoviesDatagrid()
        {
            dataGridViewMoviesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMoviesList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMoviesList.ReadOnly = true;
            dataGridViewMoviesList.Columns["Id"].Visible = false;
            dataGridViewMoviesList.Columns["VoteAverage"].HeaderText = "Votes Average";
            movieUserControl.Parent = this;


            if (!dataGridViewMoviesList.Columns.Contains("IsAvailable"))
            {
                DataGridViewCheckBoxColumn isAvailableColumn = new DataGridViewCheckBoxColumn();
                isAvailableColumn.DataPropertyName = "IsAvailable";
                isAvailableColumn.HeaderText = "Available";
                isAvailableColumn.Name = "IsAvailable";
                isAvailableColumn.ReadOnly = true;

                dataGridViewMoviesList.Columns.Add(isAvailableColumn);
            }
           






        }





        private void dataGridViewMoviesList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMoviesList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewMoviesList.SelectedRows[0];
                var id = (int) selectedRow.Cells["Id"].Value;

                var selected = _moviesRepository.GetById(id);
                movieUserControl.Load(selected);
            }
        }

        private void dataGridViewMoviesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
