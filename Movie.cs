using System;
using System.Collections.Generic;
using System.Text;

/* Create a new Movie object based on the given info
 */

namespace CAB301
{
    /* Genre selections for the movie
     */
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

    /* Classification selections for the movie
     */
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

        /* Adds copies of the movie
         */
        public void AddCopies(int num)
        {
            for (int i = 0; i < num; i++) {
                this.copies += 1;
            }
            
        }

        /* Borrows the movie and decreased available copies by 1
         */
        public void borrow()
        {
            this.borrowedCount += 1;
            this.copies -= 1;
        }

        /* Returns the movie and increases available copies by 1
         */
        public void Return()
        {
            this.copies += 1;
        }

        /* Returns the number of times this movie has been borrowed
         */
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

        /* Returns the title of the current movie
         */
        public string getTitle()
        {
            return title;
        }

        /* Prints all the info of the current movie to the console
         */
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

        /* Returns strings of all current info 
         */
        public override string ToString()
        {
            return title + " " + starring + " " + director + " " + duration + " " + genre + " " + classification + " " + releaseDate + " " + copies;
        }

    }

}
