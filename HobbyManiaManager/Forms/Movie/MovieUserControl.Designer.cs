﻿namespace HobbyManiaManager
{
    partial class MovieUserControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieUserControl));
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxPoster = new System.Windows.Forms.PictureBox();
            this.labelOriginalTitle = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.labelOverview = new System.Windows.Forms.Label();
            this.labelAvailable = new System.Windows.Forms.Label();
            this.pictureBoxAvailable = new System.Windows.Forms.PictureBox();
            this.buttonStartEndRent = new System.Windows.Forms.Button();
            this.circularProgressBarVotes = new CircularProgressBar.CircularProgressBar();
            this.labelVotesCount = new System.Windows.Forms.Label();
            this.btnImdb = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelGenres = new System.Windows.Forms.Label();
            this.btnDataApp = new System.Windows.Forms.Button();
            this.lblRented = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(209, 3);
            this.labelTitle.MaximumSize = new System.Drawing.Size(600, 0);
            this.labelTitle.MinimumSize = new System.Drawing.Size(0, 51);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(600, 51);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            // 
            // pictureBoxPoster
            // 
            this.pictureBoxPoster.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxPoster.Name = "pictureBoxPoster";
            this.pictureBoxPoster.Size = new System.Drawing.Size(200, 300);
            this.pictureBoxPoster.TabIndex = 1;
            this.pictureBoxPoster.TabStop = false;
            // 
            // labelOriginalTitle
            // 
            this.labelOriginalTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOriginalTitle.Location = new System.Drawing.Point(212, 54);
            this.labelOriginalTitle.MaximumSize = new System.Drawing.Size(600, 0);
            this.labelOriginalTitle.Name = "labelOriginalTitle";
            this.labelOriginalTitle.Size = new System.Drawing.Size(600, 0);
            this.labelOriginalTitle.TabIndex = 2;
            this.labelOriginalTitle.Text = "Original Title";
            // 
            // labelId
            // 
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.Location = new System.Drawing.Point(817, 3);
            this.labelId.Name = "labelId";
            this.labelId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelId.Size = new System.Drawing.Size(90, 26);
            this.labelId.TabIndex = 3;
            this.labelId.Text = "ID";
            // 
            // labelOverview
            // 
            this.labelOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOverview.Location = new System.Drawing.Point(303, 83);
            this.labelOverview.MaximumSize = new System.Drawing.Size(600, 0);
            this.labelOverview.MinimumSize = new System.Drawing.Size(600, 18);
            this.labelOverview.Name = "labelOverview";
            this.labelOverview.Size = new System.Drawing.Size(600, 18);
            this.labelOverview.TabIndex = 4;
            this.labelOverview.Text = "Overview";
            // 
            // labelAvailable
            // 
            this.labelAvailable.AutoSize = true;
            this.labelAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvailable.Location = new System.Drawing.Point(227, 281);
            this.labelAvailable.Name = "labelAvailable";
            this.labelAvailable.Size = new System.Drawing.Size(105, 20);
            this.labelAvailable.TabIndex = 6;
            this.labelAvailable.Text = "labelAvailable";
            // 
            // pictureBoxAvailable
            // 
            this.pictureBoxAvailable.Location = new System.Drawing.Point(212, 285);
            this.pictureBoxAvailable.Name = "pictureBoxAvailable";
            this.pictureBoxAvailable.Size = new System.Drawing.Size(12, 12);
            this.pictureBoxAvailable.TabIndex = 7;
            this.pictureBoxAvailable.TabStop = false;
            // 
            // buttonStartEndRent
            // 
            this.buttonStartEndRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartEndRent.Location = new System.Drawing.Point(733, 265);
            this.buttonStartEndRent.Name = "buttonStartEndRent";
            this.buttonStartEndRent.Size = new System.Drawing.Size(171, 38);
            this.buttonStartEndRent.TabIndex = 8;
            this.buttonStartEndRent.Text = "Start Rent";
            this.buttonStartEndRent.UseVisualStyleBackColor = true;
            this.buttonStartEndRent.Click += new System.EventHandler(this.buttonStartEndRent_Click);
            // 
            // circularProgressBarVotes
            // 
            this.circularProgressBarVotes.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBarVotes.AnimationSpeed = 500;
            this.circularProgressBarVotes.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBarVotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.circularProgressBarVotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBarVotes.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circularProgressBarVotes.InnerMargin = 2;
            this.circularProgressBarVotes.InnerWidth = -1;
            this.circularProgressBarVotes.Location = new System.Drawing.Point(217, 83);
            this.circularProgressBarVotes.MarqueeAnimationSpeed = 2000;
            this.circularProgressBarVotes.Name = "circularProgressBarVotes";
            this.circularProgressBarVotes.OuterColor = System.Drawing.Color.Gray;
            this.circularProgressBarVotes.OuterMargin = -25;
            this.circularProgressBarVotes.OuterWidth = 25;
            this.circularProgressBarVotes.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.circularProgressBarVotes.ProgressWidth = 7;
            this.circularProgressBarVotes.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.circularProgressBarVotes.Size = new System.Drawing.Size(80, 80);
            this.circularProgressBarVotes.StartAngle = 270;
            this.circularProgressBarVotes.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBarVotes.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.circularProgressBarVotes.SubscriptText = "";
            this.circularProgressBarVotes.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBarVotes.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.circularProgressBarVotes.SuperscriptText = "";
            this.circularProgressBarVotes.TabIndex = 9;
            this.circularProgressBarVotes.Text = "52";
            this.circularProgressBarVotes.TextMargin = new System.Windows.Forms.Padding(0);
            this.circularProgressBarVotes.Value = 10;
            // 
            // labelVotesCount
            // 
            this.labelVotesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVotesCount.Location = new System.Drawing.Point(214, 166);
            this.labelVotesCount.Name = "labelVotesCount";
            this.labelVotesCount.Size = new System.Drawing.Size(80, 23);
            this.labelVotesCount.TabIndex = 10;
            this.labelVotesCount.Text = "Votes Count";
            this.labelVotesCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnImdb
            // 
            this.btnImdb.BackColor = System.Drawing.Color.Gainsboro;
            this.btnImdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImdb.ImageIndex = 0;
            this.btnImdb.ImageList = this.imageList1;
            this.btnImdb.Location = new System.Drawing.Point(820, 217);
            this.btnImdb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnImdb.Name = "btnImdb";
            this.btnImdb.Size = new System.Drawing.Size(83, 42);
            this.btnImdb.TabIndex = 11;
            this.btnImdb.UseVisualStyleBackColor = false;
            this.btnImdb.Click += new System.EventHandler(this.btnImdb_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "imdb.PNG");
            // 
            // labelGenres
            // 
            this.labelGenres.AutoSize = true;
            this.labelGenres.Location = new System.Drawing.Point(214, 54);
            this.labelGenres.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGenres.Name = "labelGenres";
            this.labelGenres.Size = new System.Drawing.Size(36, 13);
            this.labelGenres.TabIndex = 12;
            this.labelGenres.Text = "Genre";
            // 
            // btnDataApp
            // 
            this.btnDataApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnDataApp.Location = new System.Drawing.Point(480, 269);
            this.btnDataApp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDataApp.Name = "btnDataApp";
            this.btnDataApp.Size = new System.Drawing.Size(248, 32);
            this.btnDataApp.TabIndex = 13;
            this.btnDataApp.Text = "Data Application";
            this.btnDataApp.UseVisualStyleBackColor = true;
            this.btnDataApp.Click += new System.EventHandler(this.btnDataApp_Click);
            // 
            // lblRented
            // 
            this.lblRented.AutoSize = true;
            this.lblRented.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRented.Location = new System.Drawing.Point(207, 261);
            this.lblRented.Name = "lblRented";
            this.lblRented.Size = new System.Drawing.Size(51, 20);
            this.lblRented.TabIndex = 14;
            this.lblRented.Text = "label1";
            // 
            // MovieUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRented);
            this.Controls.Add(this.btnDataApp);
            this.Controls.Add(this.labelGenres);
            this.Controls.Add(this.btnImdb);
            this.Controls.Add(this.labelVotesCount);
            this.Controls.Add(this.circularProgressBarVotes);
            this.Controls.Add(this.buttonStartEndRent);
            this.Controls.Add(this.pictureBoxAvailable);
            this.Controls.Add(this.labelAvailable);
            this.Controls.Add(this.labelOverview);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelOriginalTitle);
            this.Controls.Add(this.pictureBoxPoster);
            this.Controls.Add(this.labelTitle);
            this.Name = "MovieUserControl";
            this.Size = new System.Drawing.Size(907, 307);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvailable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxPoster;
        private System.Windows.Forms.Label labelOriginalTitle;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelOverview;
        private System.Windows.Forms.Label labelAvailable;
        private System.Windows.Forms.PictureBox pictureBoxAvailable;
        private System.Windows.Forms.Button buttonStartEndRent;
        private CircularProgressBar.CircularProgressBar circularProgressBarVotes;
        private System.Windows.Forms.Label labelVotesCount;
        private System.Windows.Forms.Button btnImdb;
        private System.Windows.Forms.Label labelGenres;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnDataApp;
        private System.Windows.Forms.Label lblRented;
    }
}
