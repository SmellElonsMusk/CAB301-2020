using System;
using System.Collections.Generic;
using System.Text;

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


    }
}
