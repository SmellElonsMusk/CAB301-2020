using System;
using System.Collections.Generic;
using System.Text;

/* Create a new Movie object based on the given info
 */

namespace CAB301
{
    enum Genre
    {
        Drama,
        Adventure,
        Family,
        Action,
        SciFi,
        Comedy,
        Animated,
        Thriller,
        Other
    }

    enum Classification
    {
        G,
        PG,
        M,
        MA15
    }



    class Movie
    {
        private string title;
        private string starring;
        private string director;
        private string duration;
        private Genre genre;
        private Classification classification;
        private string releaseDate;
        private int copies;
        private int borrowedCount;
        private bool isBorrowed;

        /* Creates a new movie 
         * 
         */
        public void create(string title, string starring, string director, string duration, Genre genre, Classification classification, string releaseDate, int copies)
        {
            this.title = title;
            this.starring = starring;
            this.director = director;
            this.duration = duration;
            this.genre = genre;
            this.classification = classification;
            this.releaseDate = releaseDate;
            this.copies = copies;

        }


        public void AddCopies(int num)
        {
            for (int i = 0; i < num; i++) {
                this.copies += 1;
            }
            
        }

        // Removes a single copy of the movie from the movie object
        public void removeCopies()
        {
            this.copies -= 1;
        }

        public void borrow()
        {
            this.borrowedCount += 1;
            this.copies -= 1;
        }

        public int BorrowedCount()
        {
            return borrowedCount;
        }

        /*  Lists number of current copies of this movie object
         *
         */
        public int currentCopies()
        {
            return copies;
        }

        public string getTitle()
        {
            return title;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Starring: " + starring);
            Console.WriteLine("Direcotr: " + director);
            Console.WriteLine("Genre: " + genre);
            Console.WriteLine("Classification: "+ classification);
            Console.WriteLine("Duration: "+ duration);
            Console.WriteLine("Release Date: "+ releaseDate);
            Console.WriteLine("Copies Available: " + copies);
            Console.WriteLine("Times Rented: "+ borrowedCount);
            Console.WriteLine("\n");

        }

        public override string ToString()
        {
            return title + " " + starring + " " + director + " " + duration + " " + genre + " " + classification + " " + releaseDate + " " + copies;
        }

    }

}
