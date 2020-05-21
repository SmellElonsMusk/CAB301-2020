using System;
using System.Collections.Generic;
using System.Text;

/* Create a new Movie object based on the given info
 */

namespace CAB301
{
    class Movie
    {
        private string title;
        private string starring;
        private string director;
        private string duration;
        private string genre;
        private string classification;
        private string releaseDate;
        private int copies;
        private int borrowedCount;

        /* 
         * Creates a new movie 
         */
        public void add(string title, string starring, string director, string duration, string genre, string classification, string releaseDate)
        {
            this.title = title;
            this.starring = starring;
            this.director = director;
            this.duration = duration;
            this.genre = genre;
            this.classification = classification;
            this.releaseDate = releaseDate;
        }

        // Removes a single copy of the movie from the movie object

        public void removeCopies()
        {
            this.copies -= 1;
        }

        /*
         * Lists number of current copies of this movie object
         */

        public int currentCopies()
        {
            return copies;
        }

        public string getTitle()
        {
            return title;
        }

        public override string ToString()
        {
            return title + " " + starring + " " + director + " " + duration + " " + genre + " " + classification + " " + releaseDate;
        }

    }

}
