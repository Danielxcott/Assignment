using System;


namespace Cinema.Entities.Movie
{
    /// <summary>
    /// Defines the <see cref="MovieEntity" />.
    /// </summary>
    public class MovieEntity
    {
        /// <summary>
        /// Gets or sets the movie id.
        /// </summary>
        public int MovieId { get; set; }

        /// <summary>
        /// Gets or sets the movies rented.
        /// </summary>
        public string MoviesRented { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieEntity"/> class.
        /// </summary>
        public MovieEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.MovieId = 0;
            this.MoviesRented = string.Empty;
        }
    }
}
